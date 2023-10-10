#include <iostream>
#include <cstring>
#include <dirent.h>
#include <switch.h>
#include <vector>
#include <cstdint>
#include <algorithm>
#include <stdexcept>

std::vector<uint32_t> odd_primes = {
    3,    5,    7,   11,   13,   17,   19,   23,   29,   31,   37,   41,   43,   47,   53,   59,
   61,   67,   71,   73,   79,   83,   89,   97,  101,  103,  107,  109,  113,  127,  131,  137,
  139,  149,  151,  157,  163,  167,  173,  179,  181,  191,  193,  197,  199,  211,  223,  227,
  229,  233,  239,  241,  251,  257,  263,  269,  271,  277,  281,  283,  293,  307,  311,  313,
  317,  331,  337,  347,  349,  353,  359,  367,  373,  379,  383,  389,  397,  401,  409,  419,
  421,  431,  433,  439,  443,  449,  457,  461,  463,  467,  479,  487,  491,  499,  503,  509,
  521,  523,  541,  547,  557,  563,  569,  571,  577,  587,  593,  599,  601,  607,  613,  617,
  619,  631,  641,  643,  647,  653,  659,  661,  673,  677,  683,  691,  701,  709,  719,  727,
  733,  739,  743,  751,  757,  761,  769,  773,  787,  797,  809,  811,  821,  823,  827,  829,
  839,  853,  857,  859,  863,  877,  881,  883,  887,  907,  911,  919,  929,  937,  941,  947,
  953,  967,  971,  977,  983,  991,  997, 1009, 1013, 1019, 1021, 1031, 1033, 1039, 1049, 1051,
 1061, 1063, 1069, 1087, 1091, 1093, 1097, 1103, 1109, 1117, 1123, 1129, 1151, 1153, 1163, 1171,
 1181, 1187, 1193, 1201, 1213, 1217, 1223, 1229, 1231, 1237, 1249, 1259, 1277, 1279, 1283, 1289,
 1291, 1297, 1301, 1303, 1307, 1319, 1321, 1327, 1361, 1367, 1373, 1381, 1399, 1409, 1423, 1427,
 1429, 1433, 1439, 1447, 1451, 1453, 1459, 1471, 1481, 1483, 1487, 1489, 1493, 1499, 1511, 1523,
 1531, 1543, 1549, 1553, 1559, 1567, 1571, 1579, 1583, 1597, 1601, 1607, 1609, 1613, 1619, 1621
};

class Xorshift {
public:
    Xorshift(uint32_t seed) {
        states = {0x6C078966, 0xDD5254A5, 0xB9523B81, 0x03DF95B3};

        if (seed == 0) {
            return;
        }

        seed = seed ^ (seed >> 30);
        seed = (seed * (0x6C078966 - 1)) & 0xFFFFFFFF;
        seed = seed + 1;
        states[0] = seed;

        seed = seed ^ (seed >> 30);
        seed = (seed * (0x6C078966 - 1)) & 0xFFFFFFFF;
        seed = seed + 2;
        states[1] = seed;

        seed = seed ^ (seed >> 30);
        seed = (seed * (0x6C078966 - 1)) & 0xFFFFFFFF;
        seed = seed + 3;
        states[2] = seed;
    }

    uint32_t xorshift(uint32_t arg) {
        uint32_t x = states[0];
        uint32_t y = states[3];

        states[0] = states[1];
        states[1] = states[2];
        states[2] = states[3];

        x = x ^ ((x << 11) & 0xFFFFFFFF);
        x = x ^ ((x >> 8) & 0xFFFFFFFF);
        y = y ^ ((y >> 19) & 0xFFFFFFFF);

        states[3] = x ^ y;

        if (arg == 0) {
            return states[3];
        }

        return states[3] % arg;
    }

private:
    std::vector<uint32_t> states;
};

class YWCipher : public Xorshift {
public:
    YWCipher(uint32_t seed, uint32_t count) : Xorshift(seed) {
        table.resize(0x100);
        for (uint32_t i = 0; i < 0x100; ++i) {
            table[i] = i;
        }

        for (uint32_t i = 0; i < count; ++i) {
            uint32_t r = xorshift(0x10000);
            uint32_t r1 = r & 0xFF;
            uint32_t r2 = (r >> 8) & 0xFF;

            if (r1 != r2) {
                uint32_t a = table[r1];
                uint32_t b = table[r2];
                std::swap(table[a], table[b]);
            }
        }
    }

    std::vector<uint8_t> encrypt(const std::vector<uint8_t>& data) {
        std::vector<uint8_t> out;
        uint32_t ka = 0;
        for (size_t i = 0; i < data.size(); ++i) {
            if (i % 0x100 == 0) {
                ka = odd_primes[table[(i & 0xFF00) >> 8]];
            }
            uint32_t kb = table[ka * (i + 1) & 0xFF];
            out.push_back(data[i] ^ kb);
        }
        return out;
    }

    std::vector<uint8_t> decrypt(const std::vector<uint8_t>& data) {
        return encrypt(data);
    }

private:
    std::vector<uint8_t> table;
};

std::vector<uint8_t> yw_proc(const std::vector<uint8_t>& data) {
    uint32_t seed = *(reinterpret_cast<const uint32_t*>(&data[data.size() - 4]));
    YWCipher c(seed, 0x1000);
    std::vector<uint8_t> encrypted_data = c.encrypt(data);
    return encrypted_data;
}

Result get_save(u64* application_id, AccountUid* uid) {
    Result rc = 0;
    FsSaveDataInfoReader reader;
    s64 total_entries = 0;
    FsSaveDataInfo info;
    bool found = 0;

    rc = fsOpenSaveDataInfoReader(&reader, FsSaveDataSpaceId_User);

    if (R_FAILED(rc)) {
        std::cout << "fsOpenSaveDataInfoReader() failed: 0x" << std::hex << rc << std::dec << std::endl;
        return rc;
    }

    while (true) {
        rc = fsSaveDataInfoReaderRead(&reader, &info, 1, &total_entries);

        if (R_FAILED(rc) || total_entries == 0)
            break;

        if (info.save_data_type == FsSaveDataType_Account) {
            *uid = info.uid;
            found = true;
            break;
        }
    }

    fsSaveDataInfoReaderClose(&reader);

    if (R_SUCCEEDED(rc) && !found)
        return MAKERESULT(Module_Libnx, LibnxError_NotFound);

    return rc;
}

int main(int argc, char** argv) {
    Result rc = 0;

    DIR* dir;
    struct dirent* ent;

    AccountUid uid = {0};
    u64 application_id = 0x0100c0000ceea000; // ApplicationId of the save to mount. TODO add game selection

    consoleInit(NULL);

    padConfigureInput(1, HidNpadStyleSet_NpadStandard);

    PadState pad;
    padInitializeDefault(&pad);

    if (R_FAILED(get_save(&application_id, &uid))) {
        rc = accountInitialize(AccountServiceType_Application);

        if (R_FAILED(rc)) {
            std::cout << "accountInitialize() failed: 0x" << std::hex << rc << std::dec << std::endl;
        }

        if (R_SUCCEEDED(rc)) {
            rc = accountGetPreselectedUser(&uid);
            accountExit();

            if (R_FAILED(rc)) {
                std::cout << "accountGetPreselectedUser() failed: 0x" << std::hex << rc << std::dec << std::endl;
            }
        }
    }

    if (R_SUCCEEDED(rc)) {
        std::cout << "Using application_id=0x" << std::hex << application_id << " uid: 0x" << uid.uid[1] << " 0x" << uid.uid[0] << std::dec << std::endl;
    }

    if (R_SUCCEEDED(rc)) {
        rc = fsdevMountSaveData("save", application_id, uid);

        if (R_FAILED(rc)) {
            std::cout << "fsdevMountSaveData() failed: 0x" << std::hex << rc << std::dec << std::endl;
            std::cout << "Close your game and try again." << std::endl;
        }
    }

    if (R_SUCCEEDED(rc)) {
        dir = opendir("save:/");

        if (dir == NULL) {
            std::cout << "Failed to open dir." << std::endl;
        } else {
            while ((ent = readdir(dir))) {
                if (strcmp(ent->d_name, "game1.yw") == 0) { //TODO add save selection
                    char filePath[256];
                    snprintf(filePath, sizeof(filePath), "save:/%s", ent->d_name);
                    FILE* file = fopen(filePath, "rb");

                    if (file == NULL) {
                        std::cout << "Failed to open file " << filePath << "." << std::endl;
                    } else {
                        fseek(file, 0, SEEK_END);
                        long fileSize = ftell(file);
                        fseek(file, 0, SEEK_SET);

                        char buffer[256];
                        size_t bytesRead;

                        std::vector<uint8_t> encryptedData;

                        while ((bytesRead = fread(buffer, 1, sizeof(buffer), file)) > 0) {
                            encryptedData.insert(encryptedData.end(), buffer, buffer + bytesRead);
                        }
                        
                        std::vector<uint8_t> decryptedData = yw_proc(encryptedData);

                        printf("Decrypted data: ");
                        int bytes = 0;
                        for (const auto& byte : decryptedData) {
                            if (bytes == 120) {
                                break;
                            }
                            printf("%02x", byte);
                            bytes++;
                        }

                        printf("\n7 bytes at 112: ");
                        for (int i = 112; i < 119; i++) {
                            printf("%02x", decryptedData[i]);
                        }

                        fclose(file);
                    }
                }
            }

            closedir(dir);
            std::cout << "\nDone." << std::endl;
        }

        fsdevUnmountDevice("save");
    }

    while (appletMainLoop()) {
        padUpdate(&pad);
        u64 kDown = padGetButtonsDown(&pad);

        if (kDown & HidNpadButton_Plus)
            break;

        consoleUpdate(NULL);
    }

    consoleExit(NULL);
    return 0;
}
