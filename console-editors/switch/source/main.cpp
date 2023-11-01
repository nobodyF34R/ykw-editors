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

                                        printf("\nCharacters:");
                                        for (int i = 0; i < characterlist.size(); i++) {
                                            auto it = data4::characters.find(*characterlist[i].yokai);
                                            if (it != data4::characters.end()) {
                                                printf("\n%s", it->second);
                                            } else {
                                                printf("\n%u", *characterlist[i].yokai);
                                            }
                                        }

                                        printf("\n\nYokai:");
                                        for (int i = 0; i < yokailist.size(); i++) {
                                            auto it = data4::yokais.find(*yokailist[i].yokai);
                                            if (it != data4::yokais.end()) {
                                                printf("\n%s", it->second);
                                            } else {
                                                printf("\n%u", *yokailist[i].yokai);
                                            }
                                        }

                                        printf("\n\nItems:");
                                        for (int i = 0; i < itemlist.size(); i++) {
                                            auto it = data4::items.find(*itemlist[i].item);
                                            if (it != data4::items.end()) {
                                                printf("\n%s", it->second);
                                            } else {
                                                printf("\n%u", *itemlist[i].item);
                                            }
                                        }

                                        // TODO souls

                                        printf("\n\nEquipment:");
                                        for (int i = 0; i < equipmentlist.size(); i++) {
                                            auto it = data4::equipments.find(*equipmentlist[i].equipment);
                                            if (it != data4::equipments.end()) {
                                                printf("\n%s", it->second);
                                            } else {
                                                printf("\n%u", *equipmentlist[i].equipment);
                                            }
                                        }

                                        printf("\n\n+ to save and exit, - to exit without saving\nA to increment money, X to set all yokai to smogmella");
                                        printf("\nmoney: %u\n", *money);
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
                                            if (kDown & HidNpadButton_A){
                                                (*money)++;
                                                printf("money: %u\n", *money);
                                            }
                                            if (kDown & HidNpadButton_Y){
                                                (*money)--;
                                                printf("money: %u\n", *money);
                                            }
                                            if (kDown & HidNpadButton_X){
                                                for (int i = 0; i < characterlist.size(); i++) {
                                                    *characterlist[i].yokai = 253585921;
                                                }
                                                for (int i = 0; i < yokailist.size(); i++) {
                                                    *yokailist[i].yokai = 253585921;
                                                }
                                                printf("all yokai set to smogmella");
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

                                        bool save = true;
                                        uint32_t size;

                                        if (saveFiles[selectedSave] == "head.yw") {

                                            size = 10176;

                                            //define variables here

                                            printf("\n\n+ to save and exit, - to exit without saving\nhead editing not implemented yet");
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

                                                consoleUpdate(NULL);
                                            }
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

                                            // std::vector<int> medalliumlist; //TODO
                                            // offset = 1476;
                                            // importantlist.push_back();

                                            // printf("\nYokai:");

                                            // for (int i = 0; i < yokailist.size(); i++) {
                                            //     printf("\n%s %s", data1s::yokais.at(*yokailist[i].yokai), yokailist[i].nickname); //unicode is not compatible with the terminal
                                            // }

                                            // printf("\n\nItems:");

                                            // for (int i = 0; i < itemlist.size(); i++) {
                                            //     printf("\n%s", data1s::items.at(*itemlist[i].item));
                                            // }

                                            // printf("\n\nEquipment:");

                                            // for (int i = 0; i < equipmentlist.size(); i++) {
                                            //     printf("\n%s", data1s::equipments.at(*equipmentlist[i].equipment));
                                            // }

                                            // printf("\n\nImportant:");

                                            // for (int i = 0; i < importantlist.size(); i++) {
                                            //     printf("\n%s", data1s::importants.at(*importantlist[i].important));
                                            // }

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

                                                printf("\x1b[1;1H\x1b[2J+ to save and exit, - to exit without saving \n");
                                                std::cout << (0 == selectedAction ? "> " : "  ") << "yokai" << std::endl;
                                                std::cout << (1 == selectedAction ? "> " : "  ") << "items" << std::endl;
                                                std::cout << (2 == selectedAction ? "> " : "  ") << "equipment" << std::endl;
                                                std::cout << (3 == selectedAction ? "> " : "  ") << "important" << std::endl;
                                                std::cout << (4 == selectedAction ? "> " : "  ") << "misc" << std::endl;

                                                if (kDown & HidNpadButton_A) {
                                                    if (selectedAction == 4) {
                                                        //TODO misc
                                                    } else {
                                                        int listSize;
                                                        switch (selectedAction) {
                                                            case 0:
                                                                listSize = yokailist.size();
                                                                break;
                                                            case 1:
                                                                listSize = itemlist.size();
                                                                break;
                                                            case 2:
                                                                listSize = equipmentlist.size();
                                                                break;
                                                            case 3:
                                                                listSize = importantlist.size();
                                                                break;
                                                        };
                                                        bool selectedItems[listSize];
                                                        for (int i = 0; i < listSize; i++) {
                                                            selectedItems[i] = false;
                                                        }
                                                        int currentItem = 0;
                                                        int currentEdit = 0;
                                                        bool selectPage = true;
                                                        int end;
                                                        int selectedYokai = 0;
                                                        int selectedItem = 0;
                                                        int selectedEquipment = 0;
                                                        int selectedImportant = 0;

                                                        while (appletMainLoop()) {
                                                            padUpdate(&pad);
                                                            u64 kDown = padGetButtonsDown(&pad);

                                                            if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus || kDown & HidNpadButton_B){
                                                                break;
                                                            }

                                                            if (kDown & HidNpadButton_L || kDown & HidNpadButton_R) {
                                                                selectPage = !selectPage;
                                                            }

                                                            if (selectPage) {
                                                                if (kDown & HidNpadButton_AnyUp) {
                                                                    currentItem--;
                                                                    if (currentItem < 0) {
                                                                        currentItem = listSize - 1;
                                                                    }
                                                                }
                                                                if (kDown & HidNpadButton_AnyDown) {
                                                                    currentItem++;
                                                                    if (currentItem >= listSize) {
                                                                        currentItem = 0;
                                                                    }
                                                                }
                                                                if (kDown & HidNpadButton_AnyLeft) {
                                                                    currentItem -= 44;
                                                                    if (currentItem < 0) {
                                                                        currentItem = 0;
                                                                    }
                                                                }
                                                                if (kDown & HidNpadButton_AnyRight) {
                                                                    currentItem += 44;
                                                                    if (currentItem >= listSize) {
                                                                        currentItem = listSize - 1;
                                                                    }
                                                                }
                                                                if (kDown & HidNpadButton_A) {
                                                                    selectedItems[currentItem] = !selectedItems[currentItem];
                                                                }
                                                                if (kDown & HidNpadButton_X) {
                                                                    //if all true make all false
                                                                    if (std::all_of(selectedItems, selectedItems + listSize, [](bool v) { return v; })) {
                                                                        for (int i = 0; i < listSize; i++) {
                                                                            selectedItems[i] = false;
                                                                        }
                                                                    } else{
                                                                        for (int i = 0; i < listSize; i++) {
                                                                            selectedItems[i] = true;
                                                                        }
                                                                    }
                                                                }
                                                                printf("\x1b[1;1H\x1b[2JL or R to swap pages, X to select/deselect all");
                                                                end = currentItem/44+44;
                                                                if (selectedAction == 0) {
                                                                    if (end > yokailist.size()) {
                                                                        end = yokailist.size();
                                                                    }
                                                                    for (int i = currentItem/44; i < end; i++) {
                                                                        std::cout << "\n" << (selectedItems[i] ? "> " : "  ") << data1s::yokais.at(*yokailist[i].yokai) << (currentItem == i ? " <<<" : "");
                                                                    }
                                                                }
                                                                if (selectedAction == 1) {
                                                                    if (end > itemlist.size()) {
                                                                        end = itemlist.size();
                                                                    }
                                                                    for (int i = currentItem/44; i < end; i++) {
                                                                        std::cout << "\n" << (selectedItems[i] ? "> " : "  ") << data1s::items.at(*itemlist[i].item) << (currentItem == i ? " <<<" : "");
                                                                    }
                                                                }
                                                                if (selectedAction == 2) {
                                                                    if (end > equipmentlist.size()) {
                                                                        end = equipmentlist.size();
                                                                    }
                                                                    for (int i = currentItem/44; i < end; i++) {
                                                                        std::cout << "\n" << (selectedItems[i] ? "> " : "  ") << data1s::equipments.at(*equipmentlist[i].equipment) << (currentItem == i ? " <<<" : "");
                                                                    }
                                                                }
                                                                if (selectedAction == 3) {
                                                                    if (end > importantlist.size()) {
                                                                        end = importantlist.size();
                                                                    }
                                                                    for (int i = currentItem/44; i < end; i++) {
                                                                        std::cout << "\n" << (selectedItems[i] ? "> " : "  ") << data1s::importants.at(*importantlist[i].important) << (currentItem == i ? " <<<" : "");
                                                                    }
                                                                }
                                                            } else { //edit page
                                                                if (selectedAction == 0) { //yokai
                                                                    if (kDown & HidNpadButton_AnyUp) {
                                                                        currentEdit--;
                                                                        if (currentEdit < 0) {
                                                                            currentEdit = 4;
                                                                        }
                                                                    }
                                                                    if (kDown & HidNpadButton_AnyDown) {
                                                                        currentEdit++;
                                                                        if (currentEdit >= 5) {
                                                                            currentEdit = 0;
                                                                        }
                                                                    }
                                                                    if (kDown & HidNpadButton_AnyLeft) {
                                                                        currentEdit = 0;
                                                                    }
                                                                    if (kDown & HidNpadButton_AnyRight) {
                                                                        currentEdit = 4;
                                                                    }
                                                                    if (kDown & HidNpadButton_A) {
                                                                        if (currentEdit == 0) {
                                                                            //print all yokai from data1s then select one
                                                                            while (appletMainLoop()) {
                                                                                padUpdate(&pad);
                                                                                u64 kDown = padGetButtonsDown(&pad);

                                                                                if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus || kDown & HidNpadButton_B || kDown & HidNpadButton_A) {
                                                                                    break;
                                                                                }
                                                                                if (kDown & HidNpadButton_AnyUp) {
                                                                                    selectedYokai--;
                                                                                    if (selectedYokai < 0) {
                                                                                        selectedYokai = data1s::yokais.size() - 1;
                                                                                    }
                                                                                }
                                                                                if (kDown & HidNpadButton_AnyDown) {
                                                                                    selectedYokai++;
                                                                                    if (selectedYokai >= data1s::yokais.size()) {
                                                                                        selectedYokai = 0;
                                                                                    }
                                                                                }
                                                                                if (kDown & HidNpadButton_AnyLeft) {
                                                                                    selectedYokai -= 44;
                                                                                    if (selectedYokai < 0) {
                                                                                        selectedYokai = 0;
                                                                                    }
                                                                                }
                                                                                if (kDown & HidNpadButton_AnyRight) {
                                                                                    selectedYokai += 44;
                                                                                    if (selectedYokai >= data1s::yokais.size()) {
                                                                                        selectedYokai = data1s::yokais.size() - 1;
                                                                                    }
                                                                                }
                                                                                int i = 0;

                                                                                printf("\x1b[1;1H\x1b[2JSelect a yokai:");
                                                                                // for (const auto& pair : data1s::yokais) {
                                                                                //     if (i/44 == selectedYokai/44) {
                                                                                //         std::cout << "\n" << (i == selectedYokai ? "> " : "  ") << pair.second;
                                                                                //     }
                                                                                //     if (i == selectedYokai + 44) {
                                                                                //         break;
                                                                                //     }
                                                                                //     i++;
                                                                                // }

                                                                                consoleUpdate(NULL);
                                                                            }
                                                                        }
                                                                        if (currentEdit == 1) {
                                                                        }
                                                                        if (currentEdit == 2) {
                                                                        }
                                                                        if (currentEdit == 3) {
                                                                        }
                                                                        if (currentEdit == 4) {
                                                                        }
                                                                    }

                                                                    printf("\x1b[1;1H\x1b[2JL or R to swap pages\n");

                                                                    std::cout << (currentEdit == 0 ? "> " : "  ") << "yokai: " << std::endl;
                                                                    std::cout << (currentEdit == 1 ? "> " : "  ") << "attitude: " << std::endl;
                                                                    std::cout << (currentEdit == 2 ? "> " : "  ") << "level: " << std::endl;
                                                                    printf("\n");
                                                                    std::cout << (currentEdit == 3 ? "> " : "  ") << "apply and set max" << std::endl;
                                                                    std::cout << (currentEdit == 4 ? "> " : "  ") << "apply" << std::endl;
                                                                }
                                                            }

                                                            consoleUpdate(NULL);
                                                        }
                                                    }
                                                    
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