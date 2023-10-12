#include <iostream>
#include <cstring>
#include <dirent.h>
#include <switch.h>
#include <vector>
#include <cstdint>
#include <algorithm>
#include <stdexcept>
#include <fstream>
#include <map>

class CRC32 {
public:
    static uint32_t calcCRC32(const std::vector<uint8_t>& data);
private:
    static const uint32_t crc32_tab[];
};

const uint32_t CRC32::crc32_tab[] = {
    0x00000000, 0x77073096, 0xee0e612c, 0x990951ba,
    0x076dc419, 0x706af48f, 0xe963a535, 0x9e6495a3,
    0x0edb8832, 0x79dcb8a4, 0xe0d5e91e, 0x97d2d988,
    0x09b64c2b, 0x7eb17cbd, 0xe7b82d07, 0x90bf1d91,
    0x1db71064, 0x6ab020f2, 0xf3b97148, 0x84be41de,
    0x1adad47d, 0x6ddde4eb, 0xf4d4b551, 0x83d385c7,
    0x136c9856, 0x646ba8c0, 0xfd62f97a, 0x8a65c9ec,
    0x14015c4f, 0x63066cd9, 0xfa0f3d63, 0x8d080df5,
    0x3b6e20c8, 0x4c69105e, 0xd56041e4, 0xa2677172,
    0x3c03e4d1, 0x4b04d447, 0xd20d85fd, 0xa50ab56b,
    0x35b5a8fa, 0x42b2986c, 0xdbbbc9d6, 0xacbcf940,
    0x32d86ce3, 0x45df5c75, 0xdcd60dcf, 0xabd13d59,
    0x26d930ac, 0x51de003a, 0xc8d75180, 0xbfd06116,
    0x21b4f4b5, 0x56b3c423, 0xcfba9599, 0xb8bda50f,
    0x2802b89e, 0x5f058808, 0xc60cd9b2, 0xb10be924,
    0x2f6f7c87, 0x58684c11, 0xc1611dab, 0xb6662d3d,
    0x76dc4190, 0x01db7106, 0x98d220bc, 0xefd5102a,
    0x71b18589, 0x06b6b51f, 0x9fbfe4a5, 0xe8b8d433,
    0x7807c9a2, 0x0f00f934, 0x9609a88e, 0xe10e9818,
    0x7f6a0dbb, 0x086d3d2d, 0x91646c97, 0xe6635c01,
    0x6b6b51f4, 0x1c6c6162, 0x856530d8, 0xf262004e,
    0x6c0695ed, 0x1b01a57b, 0x8208f4c1, 0xf50fc457,
    0x65b0d9c6, 0x12b7e950, 0x8bbeb8ea, 0xfcb9887c,
    0x62dd1ddf, 0x15da2d49, 0x8cd37cf3, 0xfbd44c65,
    0x4db26158, 0x3ab551ce, 0xa3bc0074, 0xd4bb30e2,
    0x4adfa541, 0x3dd895d7, 0xa4d1c46d, 0xd3d6f4fb,
    0x4369e96a, 0x346ed9fc, 0xad678846, 0xda60b8d0,
    0x44042d73, 0x33031de5, 0xaa0a4c5f, 0xdd0d7cc9,
    0x5005713c, 0x270241aa, 0xbe0b1010, 0xc90c2086,
    0x5768b525, 0x206f85b3, 0xb966d409, 0xce61e49f,
    0x5edef90e, 0x29d9c998, 0xb0d09822, 0xc7d7a8b4,
    0x59b33d17, 0x2eb40d81, 0xb7bd5c3b, 0xc0ba6cad,
    0xedb88320, 0x9abfb3b6, 0x03b6e20c, 0x74b1d29a,
    0xead54739, 0x9dd277af, 0x04db2615, 0x73dc1683,
    0xe3630b12, 0x94643b84, 0x0d6d6a3e, 0x7a6a5aa8,
    0xe40ecf0b, 0x9309ff9d, 0x0a00ae27, 0x7d079eb1,
    0xf00f9344, 0x8708a3d2, 0x1e01f268, 0x6906c2fe,
    0xf762575d, 0x806567cb, 0x196c3671, 0x6e6b06e7,
    0xfed41b76, 0x89d32be0, 0x10da7a5a, 0x67dd4acc,
    0xf9b9df6f, 0x8ebeeff9, 0x17b7be43, 0x60b08ed5,
    0xd6d6a3e8, 0xa1d1937e, 0x38d8c2c4, 0x4fdff252,
    0xd1bb67f1, 0xa6bc5767, 0x3fb506dd, 0x48b2364b,
    0xd80d2bda, 0xaf0a1b4c, 0x36034af6, 0x41047a60,
    0xdf60efc3, 0xa867df55, 0x316e8eef, 0x4669be79,
    0xcb61b38c, 0xbc66831a, 0x256fd2a0, 0x5268e236,
    0xcc0c7795, 0xbb0b4703, 0x220216b9, 0x5505262f,
    0xc5ba3bbe, 0xb2bd0b28, 0x2bb45a92, 0x5cb36a04,
    0xc2d7ffa7, 0xb5d0cf31, 0x2cd99e8b, 0x5bdeae1d,
    0x9b64c2b0, 0xec63f226, 0x756aa39c, 0x026d930a,
    0x9c0906a9, 0xeb0e363f, 0x72076785, 0x05005713,
    0x95bf4a82, 0xe2b87a14, 0x7bb12bae, 0x0cb61b38,
    0x92d28e9b, 0xe5d5be0d, 0x7cdcefb7, 0x0bdbdf21,
    0x86d3d2d4, 0xf1d4e242, 0x68ddb3f8, 0x1fda836e,
    0x81be16cd, 0xf6b9265b, 0x6fb077e1, 0x18b74777,
    0x88085ae6, 0xff0f6a70, 0x66063bca, 0x11010b5c,
    0x8f659eff, 0xf862ae69, 0x616bffd3, 0x166ccf45,
    0xa00ae278, 0xd70dd2ee, 0x4e048354, 0x3903b3c2,
    0xa7672661, 0xd06016f7, 0x4969474d, 0x3e6e77db,
    0xaed16a4a, 0xd9d65adc, 0x40df0b66, 0x37d83bf0,
    0xa9bcae53, 0xdebb9ec5, 0x47b2cf7f, 0x30b5ffe9,
    0xbdbdf21c, 0xcabac28a, 0x53b39330, 0x24b4a3a6,
    0xbad03605, 0xcdd70693, 0x54de5729, 0x23d967bf,
    0xb3667a2e, 0xc4614ab8, 0x5d681b02, 0x2a6f2b94,
    0xb40bbe37, 0xc30c8ea1, 0x5a05df1b, 0x2d02ef8d
};

uint32_t CRC32::calcCRC32(const std::vector<uint8_t>& data) {
    const uint8_t* p = data.data();
    int size = data.size();
    uint32_t crc = 0xFFFFFFFF;

    while (size--) {
        crc = crc32_tab[(crc ^ *p++) & 0xFF] ^ (crc >> 8);
    }

    return crc ^ 0xFFFFFFFF;
}

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

private:
    std::vector<uint8_t> table;
};

std::vector<uint8_t> yw_proc(const std::vector<uint8_t> &data, bool isEncrypt) {
    std::vector<uint8_t> out;
    size_t length = data.size();
    uint32_t new_crc32 = *(reinterpret_cast<const uint32_t*>(&data[length - 8]));
    uint32_t seed = *(reinterpret_cast<const uint32_t*>(&data[length - 4]));

    if (!isEncrypt) {
        uint32_t calculated_crc32 = CRC32::calcCRC32(std::vector<uint8_t>(data.begin(), data.end() - 8));
        if (calculated_crc32 != new_crc32) {
            std::cout << "\nERROR: Checksum does not match" << std::endl;
            //should maybe break here
        }
    }

    YWCipher c(seed, 0x1000);
    std::vector<uint8_t> encrypted_data = c.encrypt(std::vector<uint8_t>(data.begin(), data.end() - 8));
    out.insert(out.end(), encrypted_data.begin(), encrypted_data.end());
    out.insert(out.end(), data.end() - 8, data.end());

    if (isEncrypt) {
        uint32_t new_crc32 = CRC32::calcCRC32(std::vector<uint8_t>(out.begin(), out.end() - 8));
        memcpy(&out[length - 8], &new_crc32, sizeof(uint32_t));
    }

    return out;
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
                    FILE* file = fopen(filePath, "r+b");

                    if (file == NULL) {
                        std::cout << "Failed to open file " << filePath << "." << std::endl;
                    } else {
                        // fseek(file, 0, SEEK_END);
                        // long fileSize = ftell(file);
                        // fseek(file, 0, SEEK_SET);

                        char buffer[256];
                        size_t bytesRead;

                        std::vector<uint8_t> encryptedData;

                        while ((bytesRead = fread(buffer, 1, sizeof(buffer), file)) > 0) {
                            encryptedData.insert(encryptedData.end(), buffer, buffer + bytesRead);
                        }
                        
                        std::vector<uint8_t> decryptedData = yw_proc(encryptedData, false);

                        // printf("Decrypted data: ");
                        // int bytes = 0;
                        // for (const auto& byte : decryptedData) {
                        //     if (bytes == 120) {
                        //         break;
                        //     }
                        //     printf("%02x", byte);
                        //     bytes++;
                        // }

                        //EDIT HERE

                        // uint64_t* location = reinterpret_cast<uint64_t*>(& decryptedData[112]);
                        // printf("\nLocation: %lu", *location);

                        // // printf("\nLocation: ");
                        // // for (int i = 112; i < 119; i++) {
                        // //     printf("%c", decryptedData[i]);
                        // // }

                        // uint32_t* x = reinterpret_cast<uint32_t*>(& decryptedData[20]);
                        // printf("\nx: %u", *x);
                        // uint32_t* y = reinterpret_cast<uint32_t*>(& decryptedData[24]);
                        // printf("\nx: %u", *y);
                        // uint32_t* z = reinterpret_cast<uint32_t*>(& decryptedData[28]);
                        // printf("\nx: %u", *z);

                        // // Open the file for appending
                        // std::ofstream json("mapcoord.json", std::ios::app | std::ios::out);

                        // // Append the data to the file
                        // json << *location << ": [" << *x << ", " << *y << ", " << *z << "]\n";

                        // // Close the file
                        // json.close();
                        
                        // //increase money by 1
                        // uint32_t* money = reinterpret_cast<uint32_t*>(& decryptedData[37620]); 
                        // (*money) = (*money) + 1;
                        // printf("\nmoney: %u\n", *money);

                        fseek(file, 0, SEEK_SET);
                        fwrite(yw_proc(decryptedData, true).data(), 1, decryptedData.size(), file); //could hardcode 47564 or use fileSize
                        fclose(file);

                        std::string bakfilePath = filePath;
                        bakfilePath.replace(bakfilePath.rfind(".yw"), 3, ".bak");
                        FILE* bakfile = fopen(bakfilePath.c_str(), "wb");
                        fwrite(encryptedData.data(), 1, encryptedData.size(), bakfile);
                        fclose(bakfile);

                        fsdevCommitDevice("save"); //TODO test this
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