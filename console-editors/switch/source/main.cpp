#include <iostream>
#include <cstring>
#include <dirent.h>
#include <switch.h>
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

        if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus || kDown & HidNpadButton_B) {
            fsdevUnmountDevice("save");
            consoleExit(NULL);
            return 0;
        }
        if (kDown & HidNpadButton_AnyUp) {
            selectedGame--;
            if (selectedGame < 0) {
                selectedGame = games.size() - 1;
            }
        }
        if (kDown & HidNpadButton_AnyDown) {
            selectedGame++;
            if (selectedGame >= games.size()) {
                selectedGame = 0;
            }
        }
        if (kDown & HidNpadButton_AnyLeft) {
            selectedGame = 0;
        }
        if (kDown & HidNpadButton_AnyRight) {
            selectedGame = games.size() - 1;
        }

        printf("\x1b[1;1H\x1b[2JSelect a game:\n");
        std::cout << (0 == selectedGame ? "> " : "  ") << "1s" << std::endl; //hardcoded for now?
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
                        int selectedSave = 0;
                        
                        while (appletMainLoop()) {
                            consoleUpdate(NULL);
                            padUpdate(&pad);
                            u64 kDown = padGetButtonsDown(&pad);

                            if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus || kDown & HidNpadButton_B) {
                                break;
                            }
                            if (kDown & HidNpadButton_AnyUp) {
                                selectedSave--;
                                if (selectedSave < 0) {
                                    selectedSave = saveFiles.size() - 1;
                                }
                            }
                            if (kDown & HidNpadButton_AnyDown) {
                                selectedSave++;
                                if (selectedSave >= saveFiles.size()) {
                                    selectedSave = 0;
                                }
                            }
                            if (kDown & HidNpadButton_AnyLeft) {
                                selectedSave = 0;
                            }
                            if (kDown & HidNpadButton_AnyRight) {
                                selectedSave = saveFiles.size() - 1;
                            }

                            printf("\x1b[1;1H\x1b[2JSelect a save file:\n");
                            for (int i = 0; i < saveFiles.size(); i++) {
                                std::cout << (i == selectedSave ? "> " : "  ") << saveFiles[i] << std::endl;
                            }

                            if (kDown & HidNpadButton_A) {
                                if (application_id == 0x010086c00af7c000) {
                                    char filePath[27] = "save:/USERDATA00/";
                                    strcat(filePath, saveFiles[selectedSave].c_str());
                                    FILE* file = fopen(filePath, "r+b");

                                    if (file == NULL) {
                                        std::cout << "Failed to open file " << filePath << "." << std::endl;
                                    } else {
                                        char buffer[256];
                                        size_t bytesRead;

                                        std::vector<uint8_t> data;

                                        while ((bytesRead = fread(buffer, 1, sizeof(buffer), file)) > 0) {
                                            data.insert(data.end(), buffer, buffer + bytesRead);
                                        }

                                        bool save = true;
                                        
                                        uint32_t* x = (uint32_t*)(& data[131]);
                                        uint32_t* y = (uint32_t*)(& data[135]);
                                        uint32_t* z = (uint32_t*)(& data[139]);

                                        uint32_t* location = (uint32_t*)(& data[167]);

                                        uint32_t* money = (uint32_t*)(& data[203]);

                                        char* nate = (char*)(& data[282]);
                                        char* katie = (char*)(& data[318]);
                                        char* summer = (char*)(& data[354]);
                                        char* cole = (char*)(& data[390]);
                                        char* bruno = (char*)(& data[426]);
                                        char* jack = (char*)(& data[462]);
        
                                        uint8_t* gatcharemaining = (uint8_t*)(& data[2082]);
                                        uint8_t* gatchamax = (uint8_t*)(& data[2083]);


                                        std::vector<struct4::Yokai> characterlist;
                                        uint32_t offset = 166627;

                                        for (int i = 0; i < 6; i++) {
                                            if (data[offset+2] == 0) {
                                                break;
                                            }

                                            characterlist.push_back(struct4::Yokai(data, offset));

                                            offset += 469;
                                        }

                                        std::vector<struct4::Yokai> yokailist;
                                        offset = 169449;

                                        for (int i = 0; i < 999; i++) {
                                            if (data[offset+2] == 0) {
                                                break;
                                            }

                                            yokailist.push_back(struct4::Yokai(data, offset));

                                            offset += 469;
                                        }
                                        
                                        std::vector<struct4::Item> itemlist;
                                        offset = 76579;

                                        for (int i = 0; i < 256; i++) {
                                            if (data[offset+2] == 0) {
                                                break;
                                            }

                                            itemlist.push_back(struct4::Item(data, offset));

                                            offset += 54;
                                        }

                                        std::vector<struct4::SpecialSoul> specialsoullist;
                                        offset = 958227;

                                        for (int i = 0; i < 256; i++) {
                                            if (data[offset+2] == 0) {
                                                break;
                                            }

                                            specialsoullist.push_back(struct4::SpecialSoul(data, offset));

                                            offset += 54;
                                        }

                                        std::vector<struct4::YokaiSoul> yokaisoullist;
                                        offset = 963635;

                                        for (int i = 0; i < 256; i++) {
                                            if (data[offset+2] == 0) {
                                                break;
                                            }

                                            yokaisoullist.push_back(struct4::YokaiSoul(data, offset));

                                            offset += 80;
                                        }

                                        std::vector<struct4::Equipment> equipmentlist;
                                        offset = 103587;

                                        for (int i = 0; i < 100; i++) {
                                            if (data[offset+2] == 0) {
                                                break;
                                            }

                                            equipmentlist.push_back(struct4::Equipment(data, offset));

                                            offset += 63;
                                        }
                                            
                                        int selectedAction = 0;

                                        while (appletMainLoop()) {
                                            padUpdate(&pad);
                                            u64 kDown = padGetButtonsDown(&pad);

                                            if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_B){
                                                break;
                                            }
                                            if (kDown & HidNpadButton_Minus){
                                                save = false;
                                                break;
                                            }
                                            
                                            if (kDown & HidNpadButton_AnyUp) {
                                                selectedAction--;
                                                if (selectedAction < 0) {
                                                    selectedAction = 6;
                                                }
                                            }
                                            if (kDown & HidNpadButton_AnyDown) {
                                                selectedAction++;
                                                if (selectedAction >= 7) {
                                                    selectedAction = 0;
                                                }
                                            }
                                            if (kDown & HidNpadButton_AnyLeft) {
                                                selectedAction = 0;
                                            }
                                            if (kDown & HidNpadButton_AnyRight) {
                                                selectedAction = 6;
                                            }

                                            printf("\x1b[1;1H\x1b[2J- to exit without saving \n");
                                            std::cout << (0 == selectedAction ? "> " : "  ") << "characters" << std::endl;
                                            std::cout << (1 == selectedAction ? "> " : "  ") << "yokai" << std::endl;
                                            std::cout << (2 == selectedAction ? "> " : "  ") << "items" << std::endl;
                                            std::cout << (3 == selectedAction ? "> " : "  ") << "equipment" << std::endl;
                                            std::cout << (4 == selectedAction ? "> " : "  ") << "special souls" << std::endl;
                                            std::cout << (5 == selectedAction ? "> " : "  ") << "yokai souls" << std::endl;
                                            std::cout << (6 == selectedAction ? "> " : "  ") << "misc" << std::endl;

                                            if (kDown & HidNpadButton_A) {
                                                switch (selectedAction) {
                                                    case 0: //characters
                                                        edit4::edit_character(characterlist, pad);
                                                    case 1: //yokai
                                                        edit4::edit_yokai(yokailist, pad);
                                                    case 2: //items
                                                        edit4::edit_item(itemlist, pad);
                                                    case 3: //equipment
                                                        edit4::edit_equipment(equipmentlist, pad);
                                                    case 4: //special souls
                                                        edit4::edit_special_soul(specialsoullist, pad);
                                                    case 5: //yokai souls
                                                        edit4::edit_yokai_soul(yokaisoullist, pad);
                                                    case 6: //misc
                                                        edit4::edit_misc(x, y, z, location, money, nate, katie, summer, cole, bruno, jack, gatcharemaining, gatchamax, pad);
                                                };

                                                padUpdate(&pad);
                                            }

                                            consoleUpdate(NULL);
                                        }

                                        if (save) {
                                            fseek(file, 0, SEEK_SET);
                                            fwrite(data.data(), 1, 1046707, file);
                                            fclose(file);

                                            // std::string bakfilePath = filePath;
                                            // bakfilePath.replace(bakfilePath.rfind(".bin"), 3, ".bak");
                                            // FILE* bakfile = fopen(bakfilePath.c_str(), "wb");
                                            // fwrite(encryptedData.data(), 1, 1046707, bakfile);
                                            // fclose(bakfile);
                                            fsdevCommitDevice("save");
                                        }
                                        else {
                                            fclose(file);
                                        }
                                    }
                                } else {
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


                                            int16_t offset;

                                            std::vector<struct1s::Yokai> yokailist;
                                            offset = 7696;
                                            for (int i = 0; i < 240; i++) {

                                                if (decryptedData[offset+2] == 0) {
                                                    break;
                                                }

                                                yokailist.push_back(struct1s::Yokai(decryptedData, offset));
                                                offset += 124;
                                            }

                                            std::vector<struct1s::Item> itemlist;
                                            offset = 1784;
                                            for (int i = 0; i < 256; i++) {

                                                if (decryptedData[offset+2] == 0) {
                                                    break;
                                                }
                                                
                                                itemlist.push_back(struct1s::Item(decryptedData, offset));
                                                offset += 12;
                                            }

                                            std::vector<struct1s::Equipment> equipmentlist;
                                            offset = 4868;
                                            for (int i = 0; i < 100; i++) {

                                                if (decryptedData[offset+2] == 0) {
                                                    break;
                                                }

                                                equipmentlist.push_back(struct1s::Equipment(decryptedData, offset));
                                                offset += 12;
                                            }

                                            std::vector<struct1s::Important> importantlist;
                                            offset = 6480;
                                            for (int i = 0; i < 150; i++) {

                                                if (decryptedData[offset+2] == 0) {
                                                    break;
                                                }

                                                importantlist.push_back(struct1s::Important(decryptedData, offset));
                                                offset += 8;
                                            }
                                            
                                            int selectedAction = 0;

                                            while (appletMainLoop()) {
                                                padUpdate(&pad);
                                                u64 kDown = padGetButtonsDown(&pad);

                                                if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_B){
                                                    break;
                                                }
                                                if (kDown & HidNpadButton_Minus){
                                                    save = false;
                                                    break;
                                                }
                                                
                                                if (kDown & HidNpadButton_AnyUp) {
                                                    selectedAction--;
                                                    if (selectedAction < 0) {
                                                        selectedAction = 4;
                                                    }
                                                }
                                                if (kDown & HidNpadButton_AnyDown) {
                                                    selectedAction++;
                                                    if (selectedAction >= 5) {
                                                        selectedAction = 0;
                                                    }
                                                }
                                                if (kDown & HidNpadButton_AnyLeft) {
                                                    selectedAction = 0;
                                                }
                                                if (kDown & HidNpadButton_AnyRight) {
                                                    selectedAction = 4;
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
                                                            edit1s::edit_yokai(yokailist, pad);
                                                        case 1: //items
                                                            edit1s::edit_item(itemlist, pad);
                                                        case 2: //equipment
                                                            edit1s::edit_equipment(equipmentlist, pad);
                                                        case 3: //important
                                                            edit1s::edit_important(importantlist, pad);
                                                        case 4: //misc
                                                            edit1s::edit_misc(x, y, z, location, time, sun, money, pad);
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