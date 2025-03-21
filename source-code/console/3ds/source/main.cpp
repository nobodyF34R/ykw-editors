#include <iostream>
#include <cstring>
#include <dirent.h>
#include <3ds.h>
#include <vector>
#include <cstdint>
#include <algorithm>
#include <stdexcept>
#include <fstream>
#include "cipher.h"
#include "struct.h"
#include "data.h"
#include "edit.h"


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
    u64 application_id; // ApplicationId of the save to mount.

    consoleInit(NULL);

    padConfigureInput(1, HidNpadStyleSet_NpadStandard);

    PadState pad;
    padInitializeDefault(&pad);

    int selectedGame = 0;
    std::vector<u64> games = {0x0100c0000ceea000, 0x010086c00af7c000};
                
    while (appletMainLoop()) {
        consoleUpdate(NULL);
        padUpdate(&pad);
        u64 kDown = padGetButtonsDown(&pad);
        inputHandling(selectedGame, kDown, games.size());

        if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus || kDown & HidNpadButton_B) {
            fsdevUnmountDevice("save");
            consoleExit(NULL);
            return 0;
        }

        printf("\x1b[1;1H\x1b[2JSelect a game:\n");
        std::cout << (0 == selectedGame ? "> " : "  ") << "1" << std::endl; //hardcoded for now?
        std::cout << (1 == selectedGame ? "> " : "  ") << "4" << std::endl;

        if (kDown & HidNpadButton_A) {
            application_id = games[selectedGame];

            if (R_FAILED(get_save(&application_id, &uid))) {
                rc = accountInitialize(AccountServiceType_Application);

                if (R_FAILED(rc)) {
                    std::cout << "accountInitialize() failed: 0x" << std::hex << rc << std::dec << std::endl;
                    break;
                }

                if (R_SUCCEEDED(rc)) {
                    rc = accountGetPreselectedUser(&uid);
                    accountExit();

                    if (R_FAILED(rc)) {
                        std::cout << "accountGetPreselectedUser() failed: 0x" << std::hex << rc << std::dec << std::endl;
                        break; //TODO make more elegant
                    }
                }
            }

            // if (R_SUCCEEDED(rc)) {
            //     std::cout << "application_id=0x" << std::hex << application_id << " uid: 0x" << uid.uid[1] << " 0x" << uid.uid[0] << std::dec << std::endl;
            // }

            if (R_SUCCEEDED(rc)) {
                rc = fsdevMountSaveData("save", application_id, uid);

                if (R_FAILED(rc)) {
                    std::cout << "fsdevMountSaveData() failed: 0x" << std::hex << rc << std::dec << std::endl;
                    std::cout << "Close your game and try again." << std::endl;
                    break;
                }
            }

            if (R_SUCCEEDED(rc)) {
                if (application_id == 0x010086c00af7c000) {
                    dir = opendir("save:/USERDATA00/");
                } else {
                    dir = opendir("save:/");
                }

                if (dir == NULL) {
                    std::cout << "Failed to open dir." << std::endl;
                } else {
                    std::vector<std::string> saveFiles;
                    while ((ent = readdir(dir))) {
                        if (strcmp(ent->d_name + strlen(ent->d_name) - 4, ".bak") != 0 & strcmp(ent->d_name + strlen(ent->d_name) - 4, ".ywd") != 0) {
                            saveFiles.push_back(ent->d_name);
                        }
                    }
                    if (saveFiles.empty()) {
                        std::cout << "No save files found." << std::endl;
                    } else {
                        std::sort(saveFiles.begin(), saveFiles.end());

                        int selectedSave = 0;
                        
                        while (appletMainLoop()) {
                            consoleUpdate(NULL);
                            padUpdate(&pad);
                            u64 kDown = padGetButtonsDown(&pad);
                            inputHandling(selectedSave, kDown, saveFiles.size());

                            if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus || kDown & HidNpadButton_B) {
                                break;
                            }

                            printf("\x1b[1;1H\x1b[2JSelect a save file:\n");
                            for (int i = 0; i < saveFiles.size(); i++) {
                                std::cout << (i == selectedSave ? "> " : "  ") << saveFiles[i] << std::endl;
                            }

                            if (kDown & HidNpadButton_A || application_id == 0x010086c00af7c000) {
                                // if app ID 1
                                char filePath[15] = "save:/";
                                strcat(filePath, saveFiles[selectedSave].c_str());
                                FILE* file = fopen(filePath, "r+b");

                                if (file == NULL) {
                                    std::cout << "Failed to open file " << filePath << "." << std::endl;
                                } else {
                                    char buffer[256];
                                    size_t bytesRead;

                                    std::vector<uint8_t> encryptedData;

                                    while ((bytesRead = fread(buffer, 1, sizeof(buffer), file)) > 0) {
                                        encryptedData.insert(encryptedData.end(), buffer, buffer + bytesRead);
                                    }
                                    
                                    std::vector<uint8_t> decryptedData = yw_proc(encryptedData, false);

                                    //EDIT HERE

                                    bool save = true;
                                    uint32_t size;

                                    if (saveFiles[selectedSave] == "head.yw") {

                                        size = 10176;

                                        //define variables here

                                    } else {

                                        size = 47564;

                                        uint32_t* x = (uint32_t*)(&decryptedData[20]);
                                        uint32_t* y = (uint32_t*)(& decryptedData[24]);
                                        uint32_t* z = (uint32_t*)(& decryptedData[28]);

                                        uint64_t* location = (uint64_t*)(& decryptedData[112]);

                                        uint16_t* time = (uint16_t*)(& decryptedData[1752]);
                                        uint8_t* sun = (uint8_t*)(& decryptedData[1754]);

                                        uint32_t* money = (uint32_t*)(& decryptedData[37620]); 


                                        int offset;

                                        std::vector<struct1::Yokai> yokailist;
                                        offset = 7696;
                                        for (int i = 0; i < 240; i++) {

                                            if (decryptedData[offset+2] == 0) {
                                                break;
                                            }

                                            yokailist.push_back(struct1::Yokai(decryptedData, offset));
                                            offset += 124;
                                        }

                                        std::vector<struct1::Item> itemlist;
                                        offset = 1784;
                                        for (int i = 0; i < 256; i++) {

                                            if (decryptedData[offset+2] == 0) {
                                                break;
                                            }
                                            
                                            itemlist.push_back(struct1::Item(decryptedData, offset));
                                            offset += 12;
                                        }

                                        std::vector<struct1::Equipment> equipmentlist;
                                        offset = 4868;
                                        for (int i = 0; i < 100; i++) {

                                            if (decryptedData[offset+2] == 0) {
                                                break;
                                            }

                                            equipmentlist.push_back(struct1::Equipment(decryptedData, offset));
                                            offset += 12;
                                        }

                                        std::vector<struct1::Important> importantlist;
                                        offset = 6480;
                                        for (int i = 0; i < 150; i++) {

                                            if (decryptedData[offset+2] == 0) {
                                                break;
                                            }

                                            importantlist.push_back(struct1::Important(decryptedData, offset));
                                            offset += 8;
                                        }
                                        
                                        int selectedAction = 0;

                                        while (appletMainLoop()) {
                                            padUpdate(&pad);
                                            u64 kDown = padGetButtonsDown(&pad);
                                            inputHandling(selectedAction, kDown, 5);

                                            if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_B){
                                                break;
                                            }
                                            if (kDown & HidNpadButton_Minus){
                                                save = false;
                                                break;
                                            }

                                            printf("\x1b[1;1H\x1b[2J- to exit without saving \n");
                                            std::cout << (0 == selectedAction ? "> " : "  ") << "yokai" << std::endl;
                                            std::cout << (1 == selectedAction ? "> " : "  ") << "items" << std::endl;
                                            std::cout << (2 == selectedAction ? "> " : "  ") << "equipment" << std::endl;
                                            std::cout << (3 == selectedAction ? "> " : "  ") << "important" << std::endl;
                                            std::cout << (4 == selectedAction ? "> " : "  ") << "misc" << std::endl;

                                            if (kDown & HidNpadButton_A) {
                                                switch (selectedAction) {
                                                    case 0: //yokai
                                                        edit1::edit_yokai(yokailist, pad);
                                                        break;
                                                    case 1: //items
                                                        edit1::edit_item(itemlist, pad);
                                                        break;
                                                    case 2: //equipment
                                                        edit1::edit_equipment(equipmentlist, pad);
                                                        break;
                                                    case 3: //important
                                                        edit1::edit_important(importantlist, pad);
                                                        break;
                                                    case 4: //misc
                                                        edit1::edit_misc(x, y, z, location, time, sun, money, pad);
                                                        break;
                                                };

                                                padUpdate(&pad);
                                            }

                                            consoleUpdate(NULL);
                                        }
                                    }
                                    
                                    if (save) {
                                        fseek(file, 0, SEEK_SET);
                                        fwrite(yw_proc(decryptedData, true).data(), 1, size, file);
                                        fclose(file);

                                        // std::string bakfilePath = filePath;
                                        // bakfilePath.replace(bakfilePath.rfind(".yw"), 3, ".bak");
                                        // FILE* bakfile = fopen(bakfilePath.c_str(), "wb");
                                        // fwrite(encryptedData.data(), 1, size, bakfile);
                                        // fclose(bakfile);
                                        fsdevCommitDevice("save");
                                    }
                                    else {
                                        fclose(file);
                                    }
                                }
                            }
                        }
                        closedir(dir);
                    }
                }
                fsdevUnmountDevice("save");
            }

        }
    }

    consoleExit(NULL);
    return 0;
}