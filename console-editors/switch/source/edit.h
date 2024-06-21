#ifndef EDIT_H
#define EDIT_H

#include "struct.h"

std::vector<std::pair<int, std::string>> sortedMap; //TODO remove these globals
std::vector<std::pair<int, std::string>> filteredMap;
int mapSelection;
bool activeKeyboard;

std::string zfill(int num, int width) { //TODO add this where applicable
    std::ostringstream ss;
    ss << std::setw(width) << std::setfill( '0' ) << num;
    return ss.str();
}

void callback(const char* str, SwkbdChangedStringArg* arg) {
    filteredMap.clear();
    std::string lowercaseStr = str;
    std::transform(lowercaseStr.begin(), lowercaseStr.end(), lowercaseStr.begin(), [](unsigned char c){ return std::tolower(c); });
    for (auto const& pair : sortedMap) {
        std::string lowercasePair = pair.second;
        std::transform(lowercasePair.begin(), lowercasePair.end(), lowercasePair.begin(), [](unsigned char c){ return std::tolower(c); });
        if (lowercasePair.find(lowercaseStr) != std::string::npos) {
            filteredMap.push_back(pair);
        }
    }
    mapSelection = 0;
}
void enter(const char* str, SwkbdDecidedEnterArg* arg) {
    activeKeyboard = !activeKeyboard;
}
void cancel(void) {
    activeKeyboard = !activeKeyboard;
}

void inputHandling(int& currentSelection, u64 kDown, int listSize) {
    if (kDown & HidNpadButton_AnyUp) {
        currentSelection--;
        if (currentSelection < 0) {
            currentSelection = listSize - 1;
        }
    }
    if (kDown & HidNpadButton_AnyDown) {
        currentSelection++;
        if (currentSelection >= listSize) {
            currentSelection = 0;
        }
    }
    if (kDown & HidNpadButton_AnyLeft) {
        currentSelection -= 44;
        if (currentSelection < 0) {
            currentSelection = 0;
        }
    }
    if (kDown & HidNpadButton_AnyRight) {
        currentSelection += 44;
        if (currentSelection >= listSize) {
            currentSelection = listSize - 1;
        }
    }
}

int selectInput(bool* selected, int& currentSelection, u64 kDown, int listSize) {
    inputHandling(currentSelection, kDown, listSize);
    if (kDown & HidNpadButton_A) {
        selected[currentSelection] = !selected[currentSelection];
    }
    if (kDown & HidNpadButton_X) {
        //if all true make all false
        if (std::all_of(selected, selected + listSize, [](bool v) { return v; })) {
            for (int i = 0; i < listSize; i++) {
                selected[i] = false;
            }
        } else{
            for (int i = 0; i < listSize; i++) {
                selected[i] = true;
            }
        }
    }
    printf("\x1b[1;1H\x1b[2JL or R to swap pages, X to select/deselect all");
    int end = currentSelection/44*44+44;
    if (end > listSize) {
        end = listSize;
    }

    return end;
}

void mapInput(PadState pad, int& currentSelection, std::string type) {
    mapSelection = currentSelection;
    if (filteredMap.size() == 0) {
        filteredMap = sortedMap;
    }
    for (int i = 0; i < filteredMap.size(); i++) {
        if (filteredMap[i].first == mapSelection) {
            mapSelection = i;
            break;
        }
    }
    SwkbdInline kbdinline;
    swkbdInlineCreate(&kbdinline);
    swkbdInlineSetFinishedInitializeCallback(&kbdinline, NULL);
    swkbdInlineLaunchForLibraryApplet(&kbdinline, SwkbdInlineMode_AppletDisplay, 0);

    swkbdInlineSetChangedStringCallback(&kbdinline, callback);
    swkbdInlineSetDecidedEnterCallback(&kbdinline, enter);
    swkbdInlineSetDecidedCancelCallback(&kbdinline, cancel);

    // Make the applet appear, can be used whenever.
    SwkbdAppearArg appearArg;
    swkbdInlineMakeAppearArg(&appearArg, SwkbdType_Normal);
    // You can optionally set appearArg text / fields here.
    // appearArg.dicFlag = 1;
    // appearArg.returnButtonFlag = 1;
    
    // swkbdInlineAppear(&kbdinline, &appearArg);
    activeKeyboard = false;

    while (appletMainLoop()) {
        padUpdate(&pad);
        swkbdInlineUpdate(&kbdinline, NULL);
        u64 kDown = padGetButtonsDown(&pad);
        if (!activeKeyboard) {
            if (filteredMap.size() != 0) {
                inputHandling(mapSelection, kDown, filteredMap.size());
            }
            if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus || kDown & HidNpadButton_B || kDown & HidNpadButton_A){
                if (filteredMap.size() == 0) {
                    currentSelection = 0;
                    break;
                }
                currentSelection = filteredMap[mapSelection].first;
                break;
            }
            if (kDown & HidNpadButton_Y) {
                mapSelection = 0;
                break;
            }
        }
        if (kDown & HidNpadButton_X) {
            if (activeKeyboard) {
                swkbdInlineDisappear(&kbdinline);
            } else {
                swkbdInlineAppear(&kbdinline, &appearArg);
            }
            activeKeyboard = !activeKeyboard;
        }

        int i = 0;
        std::cout << "\x1b[1;1H\x1b[2JSelect a " << type << " (Y for none, X to toggle keyboard)";
        for (auto const& pair : filteredMap) {
            if (i/44 == mapSelection/44) {
                std::cout << "\n" << (i == mapSelection ? "> " : "  ") << pair.second;
            }
            if (i == mapSelection + 44) {
                break;
            }
            i++;
        }
        
        consoleUpdate(NULL);
    }

    swkbdInlineClose(&kbdinline);
}

void listInput(PadState pad, int& currentSelection, std::string list[], int listSize, std::string type) {
    //put all elements except the first from list into a new list
    listSize--;
    if (currentSelection != 0) {
        currentSelection--;
    }
    std::string list2[listSize]; //because the first element is "none"
    for (int i = 0; i < listSize; i++) {
        list2[i] = list[i + 1];
    }
    while (appletMainLoop()) {
        padUpdate(&pad);
        u64 kDown = padGetButtonsDown(&pad);

        inputHandling(currentSelection, kDown, listSize);
        if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus || kDown & HidNpadButton_B || kDown & HidNpadButton_A){
            currentSelection++;
            break;
        }
        if (kDown & HidNpadButton_Y) {
            currentSelection = 0;
            break;
        }

        std::cout << "\x1b[1;1H\x1b[2JSelect a " << type << " (Y for none)";
        for (int i = 0; i < listSize; i++) {
            if (i/44 == currentSelection/44) {
                std::cout << "\n" << (i == currentSelection ? "> " : "  ") << list2[i];
            }
            if (i == currentSelection + 44) {
                break;
            }
        }

        consoleUpdate(NULL);
    }
}

void keyboardInput(char* outstr, SwkbdType keyboardType, u32 maxSize, const char* GuideText, const char* InitialText) {
    Result rc=0;
    SwkbdConfig kbd;
    // memset(outstr, 0, 100);
    swkbdCreate(&kbd, 0);
    swkbdConfigMakePresetDefault(&kbd);
    swkbdConfigSetType(&kbd, keyboardType);
    swkbdConfigSetGuideText(&kbd, GuideText);
    swkbdConfigSetInitialText(&kbd, InitialText);
    swkbdConfigSetStringLenMax(&kbd, maxSize);
    swkbdConfigSetInitialCursorPos(&kbd, strlen(InitialText));
    rc = swkbdShow(&kbd, outstr, sizeof(outstr));
    swkbdClose(&kbd);

    if (R_FAILED(rc)) {
        outstr[0] = '\0';
    }
}

namespace edit1s {
    void edit_yokai(std::vector<struct1s::Yokai> &yokailist, PadState pad) {
        sortedMap.clear();
        for (auto const& pair : data1s::yokais) {
            sortedMap.push_back(pair);
        }
        std::sort(sortedMap.begin(), sortedMap.end(), [](const std::pair<int, std::string> &left, const std::pair<int, std::string> &right) {
            return left.second < right.second;
        });
        filteredMap = sortedMap;
        bool selected[yokailist.size()];
        for (int i = 0; i < yokailist.size(); i++) {
            selected[i] = false;
        }
        int currentSelection = 0;
        int currentEdit = 0;
        bool selectPage = true;
        char outstr[32];
        int end;

        int currentYokai = 0;
        int currentAttitude = 0;
        int currentLevel = 0;

        while (appletMainLoop()) {
            consoleUpdate(NULL);
            padUpdate(&pad);
            u64 kDown = padGetButtonsDown(&pad);

            if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus || kDown & HidNpadButton_B){
                break;
            }

            if (kDown & HidNpadButton_L || kDown & HidNpadButton_R) {
                selectPage = !selectPage;
            }

            if (selectPage) {
                end = selectInput(selected, currentSelection, kDown, yokailist.size());
                for (int i = currentSelection/44*44; i < end; i++) {
                    std::cout << "\n" << (selected[i] ? "> " : "  ") << data1s::yokais.at(*yokailist[i].type) << (currentSelection == i ? " <<<" : "");
                }
            } else { //edit page
                printf("\x1b[1;1H\x1b[2JL or R to swap pages\n");
                inputHandling(currentEdit, kDown, 5);
                if (kDown & HidNpadButton_A) {
                    if (currentEdit == 0) { //yokai
                        mapInput(pad, currentYokai, "yokai");
                        padUpdate(&pad);
                    } else if (currentEdit == 1) { //attitude
                        listInput(pad, currentAttitude, data1s::attitudes, sizeof(data1s::attitudes)/sizeof(data1s::attitudes[0]), "attitude");
                        padUpdate(&pad);
                    } else if (currentEdit == 2) { //level
                        keyboardInput(outstr, SwkbdType_NumPad, 3, "0-255", (currentLevel == 0 ? "99" : std::to_string(currentLevel).c_str()));
                        if (outstr[0] == '\0') {
                            currentLevel = 0;
                        } else { //criteria
                            if (std::stoi(outstr) > 255) {
                                currentLevel = 255;
                            } else {
                                currentLevel = std::stoi(outstr);
                            }
                        }
                    } else { //apply (and set max)
                        for (int i = 0; i < yokailist.size(); i++) {
                            if (selected[i]) {
                                *yokailist[i].hp = 1; //incase you lower the level
                                if (currentYokai != 0) {
                                    *yokailist[i].type = currentYokai;
                                }
                                if (currentAttitude != 0) {
                                    *yokailist[i].attitude = currentAttitude;
                                }
                                if (currentLevel != 0) {
                                    *yokailist[i].level = currentLevel;
                                }
                                if (currentEdit == 3) {
                                    *yokailist[i].attack = 255;
                                    *yokailist[i].technique = 255;
                                    *yokailist[i].soultimate = 255;
                                    //TODO stats
                                }
                            }
                        }
                    }
                }
                //TODO stats etc
                std::cout << (currentEdit == 0 ? "> " : "  ") << "yokai: " << (currentYokai == 0 ? "" : data1s::yokais.at(currentYokai)) << std::endl;
                std::cout << (currentEdit == 1 ? "> " : "  ") << "attitude: " << data1s::attitudes[currentAttitude] << std::endl;
                std::cout << (currentEdit == 2 ? "> " : "  ") << "level: " << (currentLevel == 0 ? "" : std::to_string(currentLevel)) << std::endl;
                printf("\n");
                std::cout << (currentEdit == 3 ? "> " : "  ") << "apply and set max" << std::endl;
                std::cout << (currentEdit == 4 ? "> " : "  ") << "apply" << std::endl;
            }
        }
    }

    void edit_item(std::vector<struct1s::Item> &itemlist, PadState pad) {
        sortedMap.clear();
        for (auto const& pair : data1s::items) {
            sortedMap.push_back(pair);
        }
        std::sort(sortedMap.begin(), sortedMap.end(), [](const std::pair<int, std::string> &left, const std::pair<int, std::string> &right) {
            return left.second < right.second;
        });
        filteredMap = sortedMap;
        bool selected[itemlist.size()];
        for (int i = 0; i < itemlist.size(); i++) {
            selected[i] = false;
        }
        int currentSelection = 0;
        int currentEdit = 0;
        bool selectPage = true;
        char outstr[32];
        int end;

        int currentItem = 0;
        int currentAmount = 0;

        while (appletMainLoop()) {
            consoleUpdate(NULL);
            padUpdate(&pad);
            u64 kDown = padGetButtonsDown(&pad);

            if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus || kDown & HidNpadButton_B){
                break;
            }

            if (kDown & HidNpadButton_L || kDown & HidNpadButton_R) {
                selectPage = !selectPage;
            }

            if (selectPage) {
                end = selectInput(selected, currentSelection, kDown, itemlist.size());
                for (int i = currentSelection/44*44; i < end; i++) {
                    std::cout << "\n" << (selected[i] ? "> " : "  ") << data1s::items.at(*itemlist[i].type) << (currentSelection == i ? " <<<" : "");
                }
            } else { //edit page
                printf("\x1b[1;1H\x1b[2JL or R to swap pages\n");
                inputHandling(currentEdit, kDown, 3);
                if (kDown & HidNpadButton_A) {
                    if (currentEdit == 0) { //item
                        mapInput(pad, currentItem, "item");
                        padUpdate(&pad);
                    } else if (currentEdit == 1) { //amount
                        keyboardInput(outstr, SwkbdType_NumPad, 2, "0-99", (currentAmount == 0 ? "99" : std::to_string(currentAmount).c_str()));
                        if (outstr[0] == '\0') {
                            currentAmount = 0;
                        } else { //criteria
                            if (std::stoi(outstr) > 99) {
                                currentAmount = 99;
                            } else {
                                currentAmount = std::stoi(outstr);
                            }
                        }
                    } else if (currentEdit == 2){ //apply
                        for (int i = 0; i < itemlist.size(); i++) {
                            if (selected[i]) {
                                if (currentItem != 0) {
                                    *itemlist[i].type = currentItem;
                                }
                                if (currentAmount != 0) {
                                    *itemlist[i].amount = currentAmount;
                                }
                            }
                        }
                    }
                }
                std::cout << (currentEdit == 0 ? "> " : "  ") << "item: " << (currentItem == 0 ? "" : data1s::items.at(currentItem)) << std::endl;
                std::cout << (currentEdit == 1 ? "> " : "  ") << "amount: " << (currentAmount == 0 ? "" : std::to_string(currentAmount)) << std::endl;
                printf("\n");
                std::cout << (currentEdit == 2 ? "> " : "  ") << "apply" << std::endl;
            }
        }
    }

    void edit_equipment(std::vector<struct1s::Equipment> &equipmentlist, PadState pad) {
        sortedMap.clear();
        for (auto const& pair : data1s::equipments) {
            sortedMap.push_back(pair);
        }
        std::sort(sortedMap.begin(), sortedMap.end(), [](const std::pair<int, std::string> &left, const std::pair<int, std::string> &right) {
            return left.second < right.second;
        });
        filteredMap = sortedMap;
        bool selected[equipmentlist.size()];
        for (int i = 0; i < equipmentlist.size(); i++) {
            selected[i] = false;
        }
        int currentSelection = 0;
        int currentEdit = 0;
        bool selectPage = true;
        char outstr[32];
        int end;

        int currentEquipment = 0;
        int currentAmount = 0;

        while (appletMainLoop()) {
            consoleUpdate(NULL);
            padUpdate(&pad);
            u64 kDown = padGetButtonsDown(&pad);

            if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus || kDown & HidNpadButton_B){
                break;
            }

            if (kDown & HidNpadButton_L || kDown & HidNpadButton_R) {
                selectPage = !selectPage;
            }

            if (selectPage) {
                end = selectInput(selected, currentSelection, kDown, equipmentlist.size());
                for (int i = currentSelection/44*44; i < end; i++) {
                    std::cout << "\n" << (selected[i] ? "> " : "  ") << data1s::equipments.at(*equipmentlist[i].type) << (currentSelection == i ? " <<<" : "");
                }
            } else { //edit page
                printf("\x1b[1;1H\x1b[2JL or R to swap pages\n");
                inputHandling(currentEdit, kDown, 3);
                if (kDown & HidNpadButton_A) {
                    if (currentEdit == 0) { //equipment
                        mapInput(pad, currentEquipment, "equipment");
                        padUpdate(&pad);
                    } else if (currentEdit == 1) { //amount
                        keyboardInput(outstr, SwkbdType_NumPad, 3, "0-255", (currentAmount == 0 ? "99" : std::to_string(currentAmount).c_str()));
                        if (outstr[0] == '\0') {
                            currentAmount = 0;
                        } else { //criteria
                            if (std::stoi(outstr) > 255) {
                                currentAmount = 255;
                            } else {
                                currentAmount = std::stoi(outstr);
                            }
                        }
                    } else if (currentEdit == 2){ //apply
                        for (int i = 0; i < equipmentlist.size(); i++) {
                            if (selected[i]) {
                                if (currentEquipment != 0) {
                                    *equipmentlist[i].type = currentEquipment;
                                }
                                if (currentAmount != 0) {
                                    *equipmentlist[i].amount = currentAmount;
                                }
                            }
                        }
                    }
                }
                std::cout << (currentEdit == 0 ? "> " : "  ") << "equipment: " << (currentEquipment == 0 ? "" : data1s::equipments.at(currentEquipment)) << std::endl;
                std::cout << (currentEdit == 1 ? "> " : "  ") << "amount: " << (currentAmount == 0 ? "" : std::to_string(currentAmount)) << std::endl;
                printf("\n");
                std::cout << (currentEdit == 2 ? "> " : "  ") << "apply" << std::endl;
            }
        }
    }

    void edit_important(std::vector<struct1s::Important> &importantlist, PadState pad) {
        sortedMap.clear();
        for (auto const& pair : data1s::importants) {
            sortedMap.push_back(pair);
        }
        std::sort(sortedMap.begin(), sortedMap.end(), [](const std::pair<int, std::string> &left, const std::pair<int, std::string> &right) {
            return left.second < right.second;
        });
        filteredMap = sortedMap;
        bool selected[importantlist.size()];
        for (int i = 0; i < importantlist.size(); i++) {
            selected[i] = false;
        }
        int currentSelection = 0;
        int currentEdit = 0;
        bool selectPage = true;
        char outstr[32];
        int end;

        int currentImportant = 0;

        while (appletMainLoop()) {
            consoleUpdate(NULL);
            padUpdate(&pad);
            u64 kDown = padGetButtonsDown(&pad);

            if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus || kDown & HidNpadButton_B){
                break;
            }

            if (kDown & HidNpadButton_L || kDown & HidNpadButton_R) {
                selectPage = !selectPage;
            }

            if (selectPage) {
                end = selectInput(selected, currentSelection, kDown, importantlist.size());
                for (int i = currentSelection/44*44; i < end; i++) {
                    std::cout << "\n" << (selected[i] ? "> " : "  ") << data1s::importants.at(*importantlist[i].type) << (currentSelection == i ? " <<<" : "");
                }
            } else { //edit page
                printf("\x1b[1;1H\x1b[2JL or R to swap pages\n");
                inputHandling(currentEdit, kDown, 2);
                if (kDown & HidNpadButton_A) {
                    if (currentEdit == 0) { //important
                        mapInput(pad, currentImportant, "important");
                        padUpdate(&pad);
                    } else if (currentEdit == 1){ //apply
                        for (int i = 0; i < importantlist.size(); i++) {
                            if (selected[i]) {
                                if (currentImportant != 0) {
                                    *importantlist[i].type = currentImportant;
                                }
                            }
                        }
                    }
                }
                std::cout << (currentEdit == 0 ? "> " : "  ") << "important: " << (currentImportant == 0 ? "" : data1s::importants.at(currentImportant)) << std::endl;
                printf("\n");
                std::cout << (currentEdit == 1 ? "> " : "  ") << "apply" << std::endl;
            }
        }
    }

    void edit_misc(uint32_t* x, uint32_t* y, uint32_t* z, uint64_t* location, uint16_t* time, uint8_t* sun, uint32_t* money, std::vector<struct1s::Yokai> yokailist, PadState pad) {
        return; //TODO
    }
};

namespace edit4 {
    void edit_character(std::vector<struct4::Yokai> &characterlist, PadState pad) {
        sortedMap.clear();
        for (auto const& pair : data4::characters) {
            sortedMap.push_back(pair);
        }
        std::sort(sortedMap.begin(), sortedMap.end(), [](const std::pair<int, std::string> &left, const std::pair<int, std::string> &right) {
            return left.second < right.second;
        });
        filteredMap = sortedMap;
        bool selected[characterlist.size()];
        for (int i = 0; i < characterlist.size(); i++) {
            selected[i] = false;
        }
        int currentSelection = 0;
        int currentEdit = 0;
        bool selectPage = true;
        char outstr[32];
        int end;

        int currentCharacter = 0;
        int currentLevel = 0;
        
        while (appletMainLoop()) {
            consoleUpdate(NULL);
            padUpdate(&pad);
            u64 kDown = padGetButtonsDown(&pad);
            
            if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus || kDown & HidNpadButton_B){
                break;
            }
            
            if (kDown & HidNpadButton_L || kDown & HidNpadButton_R) {
                selectPage = !selectPage;
            }
            
            if (selectPage) {
                end = selectInput(selected, currentSelection, kDown, characterlist.size());
                for (int i = currentSelection/44*44; i < end; i++) {
                    auto it = data4::characters.find(*characterlist[i].type);
                    if (it != data4::characters.end()) {
                        std::cout << "\n" << (selected[i] ? "> " : "  ") << it->second << (currentSelection == i ? " <<<" : "");
                    } else {
                        std::cout << "\n" << (selected[i] ? "> " : "  ") << *characterlist[i].type << " TODO" << (currentSelection == i ? " <<<" : "");
                    }
                }
            } else { //edit page
                printf("\x1b[1;1H\x1b[2JL or R to swap pages\n");
                inputHandling(currentEdit, kDown, 4);
                if (kDown & HidNpadButton_A) {
                    if (currentEdit == 0) { //character
                        mapInput(pad, currentCharacter, "character");
                        padUpdate(&pad);
                    } else if (currentEdit == 1) { //level
                        keyboardInput(outstr, SwkbdType_NumPad, 2, "0-99", (currentLevel == 0 ? "99" : std::to_string(currentLevel).c_str()));
                        if (outstr[0] == '\0') {
                            currentLevel = 0;
                        } else { //criteria
                            if (std::stoi(outstr) > 99) {
                                currentLevel = 99;
                            } else {
                                currentLevel = std::stoi(outstr);
                            }
                        }
                    } else { //apply (and set max)
                        for (int i = 0; i < characterlist.size(); i++) {
                            if (selected[i]) {
                                // *characterlist[i].hp = 1; //incase you lower the level
                                if (currentCharacter != 0) {
                                    *characterlist[i].type = currentCharacter;
                                }
                                if (currentLevel != 0) {
                                    *characterlist[i].level = currentLevel;
                                }
                                if (currentEdit == 3) {
                                    //TODO stats
                                }
                            }
                        }
                    }
                }
                //TODO stats etc
                std::cout << (currentEdit == 0 ? "> " : "  ") << "character: " << (currentCharacter == 0 ? "" : data4::characters.at(currentCharacter)) << std::endl;
                std::cout << (currentEdit == 1 ? "> " : "  ") << "level: " << (currentLevel == 0 ? "" : std::to_string(currentLevel)) << std::endl;
                printf("\n");
                std::cout << (currentEdit == 2 ? "> " : "  ") << "apply and set max" << std::endl;
                std::cout << (currentEdit == 3 ? "> " : "  ") << "apply" << std::endl;
            }
        }
    }
    
    void edit_yokai(std::vector<struct4::Yokai> &yokailist, PadState pad) {
        sortedMap.clear();
        for (auto const& pair : data4::yokais) {
            sortedMap.push_back(pair);
        }
        std::sort(sortedMap.begin(), sortedMap.end(), [](const std::pair<int, std::string> &left, const std::pair<int, std::string> &right) {
            return left.second < right.second;
        });
        filteredMap = sortedMap;
        bool selected[yokailist.size()];
        for (int i = 0; i < yokailist.size(); i++) {
            selected[i] = false;
        }
        int currentSelection = 0;
        int currentEdit = 0;
        bool selectPage = true;
        char outstr[32];
        int end;

        int currentYokai = 0;
        int currentLevel = 0;

        while (appletMainLoop()) {
            consoleUpdate(NULL);
            padUpdate(&pad);
            u64 kDown = padGetButtonsDown(&pad);

            if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus || kDown & HidNpadButton_B){
                break;
            }

            if (kDown & HidNpadButton_L || kDown & HidNpadButton_R) {
                selectPage = !selectPage;
            }

            if (selectPage) {
                end = selectInput(selected, currentSelection, kDown, yokailist.size());
                for (int i = currentSelection/44*44; i < end; i++) {
                    auto it = data4::yokais.find(*yokailist[i].type);
                    if (it != data4::yokais.end()) {
                        std::cout << "\n" << (selected[i] ? "> " : "  ") << it->second << (currentSelection == i ? " <<<" : "");
                    } else {
                        std::cout << "\n" << (selected[i] ? "> " : "  ") << *yokailist[i].type << " TODO" << (currentSelection == i ? " <<<" : "");
                    }
                }
            } else { //edit page
                printf("\x1b[1;1H\x1b[2JL or R to swap pages\n");
                inputHandling(currentEdit, kDown, 4);
                if (kDown & HidNpadButton_A) {
                    if (currentEdit == 0) { //yokai
                        mapInput(pad, currentYokai, "yokai");
                        padUpdate(&pad);
                    } else if (currentEdit == 1) { //level
                        keyboardInput(outstr, SwkbdType_NumPad, 2, "0-99", (currentLevel == 0 ? "99" : std::to_string(currentLevel).c_str()));
                        if (outstr[0] == '\0') {
                            currentLevel = 0;
                        } else { //criteria
                            if (std::stoi(outstr) > 99) {
                                currentLevel = 99;
                            } else {
                                currentLevel = std::stoi(outstr);
                            }
                        }
                    } else { //apply (and set max)
                        for (int i = 0; i < yokailist.size(); i++) {
                            if (selected[i]) {
                                // *yokailist[i].hp = 1; //incase you lower the level
                                if (currentYokai != 0) {
                                    *yokailist[i].type = currentYokai;
                                }
                                if (currentLevel != 0) {
                                    *yokailist[i].level = currentLevel;
                                }
                                if (currentEdit == 3) {
                                    //TODO stats
                                }
                            }
                        }
                    }
                }
                //TODO stats etc
                std::cout << (currentEdit == 0 ? "> " : "  ") << "yokai: " << (currentYokai == 0 ? "" : data4::yokais.at(currentYokai)) << std::endl;
                std::cout << (currentEdit == 1 ? "> " : "  ") << "level: " << (currentLevel == 0 ? "" : std::to_string(currentLevel)) << std::endl;
                printf("\n");
                std::cout << (currentEdit == 2 ? "> " : "  ") << "apply and set max" << std::endl;
                std::cout << (currentEdit == 3 ? "> " : "  ") << "apply" << std::endl;
            }
        }
    }

    void edit_item(std::vector<struct4::Item> &itemlist, PadState pad) {
        sortedMap.clear();
        for (auto const& pair : data4::items) {
            sortedMap.push_back(pair);
        }
        std::sort(sortedMap.begin(), sortedMap.end(), [](const std::pair<int, std::string> &left, const std::pair<int, std::string> &right) {
            return left.second < right.second;
        });
        filteredMap = sortedMap;
        bool selected[itemlist.size()];
        for (int i = 0; i < itemlist.size(); i++) {
            selected[i] = false;
        }
        int currentSelection = 0;
        int currentEdit = 0;
        bool selectPage = true;
        char outstr[32];
        int end;

        int currentItem = 0;
        int currentAmount = 0;

        while (appletMainLoop()) {
            consoleUpdate(NULL);
            padUpdate(&pad);
            u64 kDown = padGetButtonsDown(&pad);

            if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus || kDown & HidNpadButton_B){
                break;
            }

            if (kDown & HidNpadButton_L || kDown & HidNpadButton_R) {
                selectPage = !selectPage;
            }

            if (selectPage) {
                end = selectInput(selected, currentSelection, kDown, itemlist.size());
                for (int i = currentSelection/44*44; i < end; i++) {
                    auto it = data4::items.find(*itemlist[i].type);
                    if (it != data4::items.end()) {
                        std::cout << "\n" << (selected[i] ? "> " : "  ") << it->second << (currentSelection == i ? " <<<" : "");
                    } else {
                        std::cout << "\n" << (selected[i] ? "> " : "  ") << *itemlist[i].type << " TODO" << (currentSelection == i ? " <<<" : "");
                    }
                }
            } else { //edit page
                printf("\x1b[1;1H\x1b[2JL or R to swap pages\n");
                inputHandling(currentEdit, kDown, 3);
                if (kDown & HidNpadButton_A) {
                    if (currentEdit == 0) { //item
                        mapInput(pad, currentItem, "item");
                        padUpdate(&pad);
                    } else if (currentEdit == 1) { //amount
                        keyboardInput(outstr, SwkbdType_NumPad, 3, "0-999", (currentAmount == 0 ? "999" : std::to_string(currentAmount).c_str()));
                        if (outstr[0] == '\0') {
                            currentAmount = 0;
                        } else { //criteria
                            if (std::stoi(outstr) > 999) {
                                currentAmount = 999;
                            } else {
                                currentAmount = std::stoi(outstr);
                            }
                        }
                    } else if (currentEdit == 2){ //apply
                        for (int i = 0; i < itemlist.size(); i++) {
                            if (selected[i]) {
                                if (currentItem != 0) {
                                    *itemlist[i].type = currentItem;
                                }
                                if (currentAmount != 0) {
                                    *itemlist[i].amount = currentAmount;
                                }
                            }
                        }
                    }
                }
                std::cout << (currentEdit == 0 ? "> " : "  ") << "item: " << (currentItem == 0 ? "" : data4::items.at(currentItem)) << std::endl;
                std::cout << (currentEdit == 1 ? "> " : "  ") << "amount: " << (currentAmount == 0 ? "" : std::to_string(currentAmount)) << std::endl;
                printf("\n");
                std::cout << (currentEdit == 2 ? "> " : "  ") << "apply" << std::endl;
            }
        }
    }

    void edit_equipment(std::vector<struct4::Equipment> &equipmentlist, PadState pad) {
        sortedMap.clear();
        for (auto const& pair : data4::equipments) {
            sortedMap.push_back(pair);
        }
        std::sort(sortedMap.begin(), sortedMap.end(), [](const std::pair<int, std::string> &left, const std::pair<int, std::string> &right) {
            return left.second < right.second;
        });
        filteredMap = sortedMap;
        bool selected[equipmentlist.size()];
        for (int i = 0; i < equipmentlist.size(); i++) {
            selected[i] = false;
        }
        int currentSelection = 0;
        int currentEdit = 0;
        bool selectPage = true;
        char outstr[32];
        int end;

        int currentEquipment = 0;
        int currentAmount = 0;
        
        while (appletMainLoop()) {
            consoleUpdate(NULL);
            padUpdate(&pad);
            u64 kDown = padGetButtonsDown(&pad);
            
            if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus || kDown & HidNpadButton_B){
                break;
            }
            
            if (kDown & HidNpadButton_L || kDown & HidNpadButton_R) {
                selectPage = !selectPage;
            }
            
            if (selectPage) {
                end = selectInput(selected, currentSelection, kDown, equipmentlist.size());
                for (int i = currentSelection/44*44; i < end; i++) {
                    auto it = data4::equipments.find(*equipmentlist[i].type);
                    if (it != data4::equipments.end()) {
                        std::cout << "\n" << (selected[i] ? "> " : "  ") << it->second << (currentSelection == i ? " <<<" : "");
                    } else {
                        std::cout << "\n" << (selected[i] ? "> " : "  ") << *equipmentlist[i].type << " TODO" << (currentSelection == i ? " <<<" : "");
                    }
                }
            } else { //edit page
                printf("\x1b[1;1H\x1b[2JL or R to swap pages\n");
                inputHandling(currentEdit, kDown, 3);
                if (kDown & HidNpadButton_A) {
                    if (currentEdit == 0) { //equipment
                        mapInput(pad, currentEquipment, "equipment");
                        padUpdate(&pad);
                    } else if (currentEdit == 1) { //amount
                        keyboardInput(outstr, SwkbdType_NumPad, 3, "0-999", (currentAmount == 0 ? "999" : std::to_string(currentAmount).c_str()));
                        if (outstr[0] == '\0') {
                            currentAmount = 0;
                        } else { //criteria
                            if (std::stoi(outstr) > 999) {
                                currentAmount = 999;
                            } else {
                                currentAmount = std::stoi(outstr);
                            }
                        }
                    } else if (currentEdit == 2){ //apply
                        for (int i = 0; i < equipmentlist.size(); i++) {
                            if (selected[i]) {
                                if (currentEquipment != 0) {
                                    *equipmentlist[i].type = currentEquipment;
                                }
                                if (currentAmount != 0) {
                                    *equipmentlist[i].amount = currentAmount;
                                }
                            }
                        }
                    }
                }
                std::cout << (currentEdit == 0 ? "> " : "  ") << "equipment: " << (currentEquipment == 0 ? "" : data4::equipments.at(currentEquipment)) << std::endl;
                std::cout << (currentEdit == 1 ? "> " : "  ") << "amount: " << (currentAmount == 0 ? "" : std::to_string(currentAmount)) << std::endl;
                printf("\n");
                std::cout << (currentEdit == 2 ? "> " : "  ") << "apply" << std::endl;
            }
        }
    }
    //could just be added to misc
    void edit_special(std::vector<struct4::Special> &speciallist, PadState pad) {
        sortedMap.clear();
        for (auto const& pair : data4::specials) { 
            sortedMap.push_back(pair);
        }
        std::sort(sortedMap.begin(), sortedMap.end(), [](const std::pair<int, std::string> &left, const std::pair<int, std::string> &right) {
            return left.second < right.second;
        });
        filteredMap = sortedMap;
        bool selected[speciallist.size()];
        for (int i = 0; i < speciallist.size(); i++) {
            selected[i] = false;
        }
        int currentSelection = 0;
        int currentEdit = 0;
        bool selectPage = true;
        char outstr[32];
        int end;

        int currentSpecial = 0;
        int currentAmount = 0;

        while (appletMainLoop()) {
            consoleUpdate(NULL);
            padUpdate(&pad);
            u64 kDown = padGetButtonsDown(&pad);

            if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus || kDown & HidNpadButton_B){
                break;
            }

            if (kDown & HidNpadButton_L || kDown & HidNpadButton_R) {
                selectPage = !selectPage;
            }

            if (selectPage) {
                end = selectInput(selected, currentSelection, kDown, speciallist.size());
                for (int i = currentSelection/44*44; i < end; i++) {
                    auto it = data4::specials.find(*speciallist[i].type);
                    if (it != data4::specials.end()) {
                        std::cout << "\n" << (selected[i] ? "> " : "  ") << it->second << (currentSelection == i ? " <<<" : "");
                    } else {
                        std::cout << "\n" << (selected[i] ? "> " : "  ") << *speciallist[i].type << " TODO" << (currentSelection == i ? " <<<" : "");
                    }
                }
            } else { //edit page
                printf("\x1b[1;1H\x1b[2JL or R to swap pages\n");
                inputHandling(currentEdit, kDown, 3);
                if (kDown & HidNpadButton_A) {
                    if (currentEdit == 0) { //special
                        mapInput(pad, currentSpecial, "special soul");
                        padUpdate(&pad);
                    } else if (currentEdit == 1) { //amount
                        keyboardInput(outstr, SwkbdType_NumPad, 3, "0-999", (currentAmount == 0 ? "999" : std::to_string(currentAmount).c_str()));
                        if (outstr[0] == '\0') {
                            currentAmount = 0;
                        } else { //criteria
                            if (std::stoi(outstr) > 999) {
                                currentAmount = 999;
                            } else {
                                currentAmount = std::stoi(outstr);
                            }
                        }
                    } else if (currentEdit == 2){ //apply
                        for (int i = 0; i < speciallist.size(); i++) {
                            if (selected[i]) {
                                if (currentSpecial != 0) {
                                    *speciallist[i].type = currentSpecial;
                                }
                                if (currentAmount != 0) {
                                    *speciallist[i].amount = currentAmount;
                                }
                            }
                        }
                    }
                }
                std::cout << (currentEdit == 0 ? "> " : "  ") << "soul: " << (currentSpecial == 0 ? "" : data4::specials.at(currentSpecial)) << std::endl;
                std::cout << (currentEdit == 1 ? "> " : "  ") << "amount: " << (currentAmount == 0 ? "" : std::to_string(currentAmount)) << std::endl;
                printf("\n");
                std::cout << (currentEdit == 2 ? "> " : "  ") << "apply" << std::endl;
            }
        }
    }

    void edit_soul(std::vector<struct4::Soul> &soullist, PadState pad) {
        sortedMap.clear();
        for (auto const& pair : data4::souls) {
            sortedMap.push_back(pair);
        }
        std::sort(sortedMap.begin(), sortedMap.end(), [](const std::pair<int, std::string> &left, const std::pair<int, std::string> &right) {
            return left.second < right.second;
        });
        filteredMap = sortedMap;
        bool selected[soullist.size()];
        for (int i = 0; i < soullist.size(); i++) {
            selected[i] = false;
        }
        int currentSelection = 0;
        int currentEdit = 0;
        bool selectPage = true;
        char outstr[32];
        int end;

        int currentSoul = 0;
        int currentWhiteAmount = 0;
        int currentRedAmount = 0;
        int currentGoldAmount = 0;

        while (appletMainLoop()) {
            consoleUpdate(NULL);
            padUpdate(&pad);
            u64 kDown = padGetButtonsDown(&pad);

            if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus || kDown & HidNpadButton_B){
                break;
            }

            if (kDown & HidNpadButton_L || kDown & HidNpadButton_R) {
                selectPage = !selectPage;
            }

            if (selectPage) {
                end = selectInput(selected, currentSelection, kDown, soullist.size());
                for (int i = currentSelection/44*44; i < end; i++) {
                    auto it = data4::souls.find(*soullist[i].type);
                    if (it != data4::souls.end()) {
                        std::cout << "\n" << (selected[i] ? "> " : "  ") << it->second << (currentSelection == i ? " <<<" : "");
                    } else {
                        std::cout << "\n" << (selected[i] ? "> " : "  ") << *soullist[i].type << " TODO" << (currentSelection == i ? " <<<" : "");
                    }
                }
            } else { //edit page
                printf("\x1b[1;1H\x1b[2JL or R to swap pages\n");
                inputHandling(currentEdit, kDown, 5);
                if (kDown & HidNpadButton_A) {
                    if (currentEdit == 0) { //soul
                        mapInput(pad, currentSoul, "yokai soul");
                        padUpdate(&pad);
                    } else if (currentEdit == 1) { //white amount
                        keyboardInput(outstr, SwkbdType_NumPad, 3, "0-999", (currentWhiteAmount == 0 ? "999" : std::to_string(currentWhiteAmount).c_str()));
                        if (outstr[0] == '\0') {
                            currentWhiteAmount = 0;
                        } else { //criteria
                            if (std::stoi(outstr) > 999) {
                                currentWhiteAmount = 999;
                            } else {
                                currentWhiteAmount = std::stoi(outstr);
                            }
                        }
                    } else if (currentEdit == 2) { //red amount
                        keyboardInput(outstr, SwkbdType_NumPad, 3, "0-999", (currentRedAmount == 0 ? "999" : std::to_string(currentRedAmount).c_str()));
                        if (outstr[0] == '\0') {
                            currentRedAmount = 0;
                        } else { //criteria
                            if (std::stoi(outstr) > 999) {
                                currentRedAmount = 999;
                            } else {
                                currentRedAmount = std::stoi(outstr);
                            }
                        }
                    } else if (currentEdit == 3) { //gold amount
                        keyboardInput(outstr, SwkbdType_NumPad, 3, "0-999", (currentGoldAmount == 0 ? "999" : std::to_string(currentGoldAmount).c_str()));
                        if (outstr[0] == '\0') {
                            currentGoldAmount = 0;
                        } else { //criteria
                            if (std::stoi(outstr) > 999) {
                                currentGoldAmount = 999;
                            } else {
                                currentGoldAmount = std::stoi(outstr);
                            }
                        }
                    } else if (currentEdit == 4) { //apply
                        for (int i = 0; i < soullist.size(); i++) {
                            if (selected[i]) {
                                if (currentSoul != 0) {
                                    *soullist[i].type = currentSoul;
                                }
                                if (currentWhiteAmount != 0) {
                                    *soullist[i].white = currentWhiteAmount;
                                }
                                if (currentRedAmount != 0) {
                                    *soullist[i].red = currentRedAmount;
                                }
                                if (currentGoldAmount != 0) {
                                    *soullist[i].gold = currentGoldAmount;
                                }
                            }
                        }
                    }
                }
                std::cout << (currentEdit == 0 ? "> " : "  ") << "soul: " << (currentSoul == 0 ? "" : data4::souls.at(currentSoul)) << std::endl;
                std::cout << (currentEdit == 1 ? "> " : "  ") << "white amount: " << (currentWhiteAmount == 0 ? "" : std::to_string(currentWhiteAmount)) << std::endl;
                std::cout << (currentEdit == 2 ? "> " : "  ") << "red amount: " << (currentRedAmount == 0 ? "" : std::to_string(currentRedAmount)) << std::endl;
                std::cout << (currentEdit == 3 ? "> " : "  ") << "gold amount: " << (currentGoldAmount == 0 ? "" : std::to_string(currentGoldAmount)) << std::endl;
                printf("\n");
                std::cout << (currentEdit == 4 ? "> " : "  ") << "apply" << std::endl;
            }
        }
    }
    
    void edit_misc(uint32_t* x, uint32_t* y, uint32_t* z, uint32_t* location, uint32_t* money, char* nate, char* katie, char* summer, char* cole, char* bruno, char* jack, std::vector<struct4::Yokai> &yokailist, uint8_t* gatcharemaining, uint8_t* gatchamax, PadState pad) {
        sortedMap.clear();
        for (auto const& pair : data4::locations) {
            sortedMap.push_back(pair);
        }
        std::sort(sortedMap.begin(), sortedMap.end(), [](const std::pair<int, std::string> &left, const std::pair<int, std::string> &right) {
            return left.second < right.second;
        });
        filteredMap = sortedMap;

        int currentSelection = 0;
        int currentEdit = 0;
        char outstr[43];
        int end;

        int currentLocation = 0;

        while (appletMainLoop()) {
            consoleUpdate(NULL);
            padUpdate(&pad);
            u64 kDown = padGetButtonsDown(&pad);

            if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus || kDown & HidNpadButton_B){
                break;
            }
            inputHandling(currentEdit, kDown, 3);
            if (kDown & HidNpadButton_A) {
                if (currentEdit == 0) { //nicknames
                    while (appletMainLoop()) {
                        consoleUpdate(NULL);
                        padUpdate(&pad);
                        u64 kDown = padGetButtonsDown(&pad);

                        if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus || kDown & HidNpadButton_B){
                            break;
                        }
                        inputHandling(currentSelection, kDown, 7+yokailist.size()); //extra one for "set default"
                        if (kDown & HidNpadButton_A) {
                            if (currentSelection == 0) {
                                strcpy(nate, "Nate");
                                strcpy(katie, "Katie");
                                strcpy(summer, "Summer");
                                strcpy(cole, "Cole");
                                strcpy(bruno, "Bruno");
                                strcpy(jack, "Jack");
                            } else if (currentSelection == 1) {
                                keyboardInput(outstr, SwkbdType_Normal, 35, nate, nate);
                                if (outstr[0] != '\0') {
                                    strcpy(nate, outstr);
                                }
                            } else if (currentSelection == 2) {
                                keyboardInput(outstr, SwkbdType_Normal, 35, katie, katie);
                                if (outstr[0] != '\0') {
                                    strcpy(katie, outstr);
                                }
                            } else if (currentSelection == 3) {
                                keyboardInput(outstr, SwkbdType_Normal, 35, summer, summer);
                                if (outstr[0] != '\0') {
                                    strcpy(summer, outstr);
                                }
                            } else if (currentSelection == 4) {
                                keyboardInput(outstr, SwkbdType_Normal, 35, cole, cole);
                                if (outstr[0] != '\0') {
                                    strcpy(cole, outstr);
                                }
                            } else if (currentSelection == 5) {
                                keyboardInput(outstr, SwkbdType_Normal, 35, bruno, bruno);
                                if (outstr[0] != '\0') {
                                    strcpy(bruno, outstr);
                                }
                            } else if (currentSelection == 6) {
                                keyboardInput(outstr, SwkbdType_Normal, 35, jack, jack);
                                if (outstr[0] != '\0') {
                                    strcpy(jack, outstr);
                                }
                            } else {
                                keyboardInput(outstr, SwkbdType_Normal, 43, "enter a nickname", yokailist[currentSelection-7].nickname);
                                if (outstr[0] != '\0') {
                                    strcpy(yokailist[currentSelection-7].nickname, outstr);
                                }
                            }
                        }
                        printf("\x1b[1;1H\x1b[2JSelect an option: (Japanese is scrambled until you click on it.)\n");
                        std::cout << (currentSelection == 0 ? "> " : "  ") << "fix nicknames" << std::endl;
                        printf("\n");
                        std::cout << (currentSelection == 1 ? "> " : "  ") << "Nate: " << nate << std::endl;
                        std::cout << (currentSelection == 2 ? "> " : "  ") << "Katie: " << katie << std::endl;
                        std::cout << (currentSelection == 3 ? "> " : "  ") << "Summer: " << summer << std::endl;
                        std::cout << (currentSelection == 4 ? "> " : "  ") << "Cole: " << cole << std::endl;
                        std::cout << (currentSelection == 5 ? "> " : "  ") << "Bruno: " << bruno << std::endl;
                        std::cout << (currentSelection == 6 ? "> " : "  ") << "Jack: " << jack << std::endl;
                        printf("\n");
                        int end = currentSelection/44*44+44;
                        if (end > yokailist.size()) {
                            end = yokailist.size();
                        }
                        for (int i = currentSelection/44*44; i < end; i++) {
                            auto it = data4::yokais.find(*yokailist[i].type);
                            if (it != data4::yokais.end()) {
                                std::cout << "\n" << (currentSelection == i+7 ? "> " : "  ") << it->second << "\t\t\t\t\t\t" << yokailist[i].nickname;
                            } else {
                                std::cout << "\n" << (currentSelection == i+7 ? "> " : "  ") << *yokailist[i].type << " TODO" << ":\t\t\t\t\t\t" << yokailist[i].nickname;
                            }
                        }
                    }
                } else if (currentEdit == 1) { //location
                    mapInput(pad, currentLocation, "location (TODO)");
                    padUpdate(&pad);
                    //TODO set location and x, y, z
                
                } else if (currentEdit == 2) { //crank-a-kai
                    keyboardInput(outstr, SwkbdType_NumPad, 2, "0-99", "99");
                    if (outstr[0] != '\0') {
                        if (std::stoi(outstr) < 99) {
                            *gatchamax = 99;
                            *gatcharemaining = 99;
                        } else {
                            *gatchamax = std::stoi(outstr);
                            *gatcharemaining = std::stoi(outstr);
                        }
                    }
                } else if (currentEdit == 3) { //money
                    keyboardInput(outstr, SwkbdType_NumPad, 8, "0-99999999", (*money == 0 ? "99999999" : std::to_string(*money).c_str()));
                    if (outstr[0] != '\0') {
                        if (std::stoi(outstr) < 99999999) {
                            *money = 99999999;
                        } else {
                            *money = std::stoi(outstr);
                        }
                    }
                }
            }
            printf("\x1b[1;1H\x1b[2JSelect an option:\n");
            std::cout << (currentEdit == 0 ? "> " : "  ") << "nicknames" << std::endl;
            std::cout << (currentEdit == 1 ? "> " : "  ") << "location TODO" << std::endl;
            std::cout << (currentEdit == 2 ? "> " : "  ") << "crank-a-kai" << std::endl;
            std::cout << (currentEdit == 3 ? "> " : "  ") << "money" << std::endl;
        }
    }
};

#endif // EDIT_H