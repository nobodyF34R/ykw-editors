#include <iostream>
#include <cstring>
#include <dirent.h>
#include <switch.h>

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
    u64 application_id = 0x0100c0000ceea000; // ApplicationId of the save to mount

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
        }
    }

    if (R_SUCCEEDED(rc)) {
        dir = opendir("save:/");

        if (dir == NULL) {
            std::cout << "Failed to open dir." << std::endl;
        } else {
            while ((ent = readdir(dir))) {
                if (strcmp(ent->d_name, "game1.yw") == 0) {
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

                        while ((bytesRead = fread(buffer, 1, sizeof(buffer), file)) > 0) {
                            fwrite(buffer, 1, bytesRead, stdout);
                        }

                        std::cout << "\n\nFile size: " << fileSize << " bytes" << std::endl;
                        uint32_t seed;

                        if (fileSize >= 4) {
                            fseek(file, -4, SEEK_END);
                            fread(&seed, sizeof(seed), 1, file);
                            std::cout << "Last 4 bytes (little-endian uint32): " << seed << std::endl;
                        }

                        fclose(file);
                    }
                }
            }

            closedir(dir);
            std::cout << "Done." << std::endl;
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
