#ifndef EDIT_H
#define EDIT_H

#include "struct.h"

std::wstring_convert<std::codecvt_utf8_utf16<wchar_t>> converter;
std::vector<std::pair<int, std::string>> sortedMap; //TODO remove these globals
std::vector<std::pair<int, std::string>> filteredMap;
int mapSelection;
bool activeKeyboard;

void pause(PadState &pad) {
    while (appletMainLoop()) {
        consoleUpdate(NULL);
        padUpdate(&pad);
        u64 kDown = padGetButtonsDown(&pad);
        if (kDown) break;
    }
}

// swap full-width and half-width characters
std::wstring convert_width(std::wstring str) {
    bool half = true;
    for (int i = 0; i < str.size(); i++) { //make half
        if (str[i] >= 0xFF01 && str[i] <= 0xFF5E) {
            half = false;
            str[i] -= 0xFEE0;
        }
    }
    if (half) { //make wide
        for (int i = 0; i < str.size(); i++) {
            if (str[i] >= 0x21 && str[i] <= 0x7E) {
                str[i] += 0xFEE0;
            }
        }
    }
    return str;
}

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
    printf("\x1b[1;1H\x1b[2JL or R to swap pages, X to select/deselect all, Y to hex edit");
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
    swkbdInlineMakeAppearArg(&appearArg, SwkbdType_All);
    // You can optionally set appearArg text / fields here.
    // appearArg.dicFlag = 1;
    // appearArg.returnButtonFlag = 1;
    
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
                currentSelection = 0;
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
    if (keyboardType == SwkbdType_NumPad) {
        maxSize++;
    }
    Result rc=0;
    SwkbdConfig kbd;
    memset(outstr, 0, maxSize);
    swkbdCreate(&kbd, 0);
    swkbdConfigMakePresetDefault(&kbd);
    swkbdConfigSetType(&kbd, keyboardType);
    swkbdConfigSetGuideText(&kbd, GuideText);
    swkbdConfigSetInitialText(&kbd, InitialText);
    swkbdConfigSetStringLenMax(&kbd, maxSize-1);
    swkbdConfigSetInitialCursorPos(&kbd, strlen(InitialText));
    rc = swkbdShow(&kbd, outstr, maxSize);
    swkbdClose(&kbd);

    if (R_FAILED(rc)) {
        outstr[0] = '\0';
    }
}

void hexEdit(int& hexSelection, u64 kDown, char* buffer, int* mode, std::vector<uint8_t*> &data) {
    if (kDown & HidNpadButton_AnyLeft) {
        hexSelection--;
        if (hexSelection < 0) {
            hexSelection = data.size() - 1;
        }
    }
    if (kDown & HidNpadButton_AnyRight) {
        hexSelection++;
        if (hexSelection >= data.size()) {
            hexSelection = 0;
        }
    }
    if (kDown & HidNpadButton_AnyUp) {
        hexSelection -= 20;
        if (hexSelection < 0) {
            hexSelection = 0;
        }
    }
    if (kDown & HidNpadButton_AnyDown) {
        hexSelection += 20;
        if (hexSelection >= data.size()) {
            hexSelection = data.size() - 1;
        }
    }

    if (kDown & HidNpadButton_X) {
        if (*mode == 1) {
            *mode = 4;
        } else {
            *mode = 1;
        }
    }

    if (kDown & HidNpadButton_A) {
        if (*mode == 1) {
            keyboardInput(buffer, SwkbdType_NumPad, 3, "0-255", std::to_string(*data[hexSelection]).c_str());
            if (buffer[0] != '\0') {
                int newValue = std::stoi(buffer);
                if (newValue >= 0 && newValue <= 255) {
                    *data[hexSelection] = static_cast<uint8_t>(newValue);
                }
            }
        } else {
            keyboardInput(buffer, SwkbdType_NumPad, 10, "0-4294967295", std::to_string(*reinterpret_cast<uint32_t*>(data[hexSelection])).c_str());
            if (buffer[0] != '\0') {
                uint32_t newValue = std::stoul(buffer);
                if (newValue <= 4294967295) {
                    *reinterpret_cast<uint32_t*>(data[hexSelection]) = newValue;
                }
            }
        }
        }

    printf("\x1b[1;1H\x1b[2JHex Editing Menu (L/R to cycle selection, X to swap mode)\n\n");
    for (int i = 0; i < data.size(); i++) {
        printf("%s%02x ", (hexSelection == i ? ">" : " "), *data[i]); //20 bytes per line
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
        char buffer[32];
        int end;

        int currentYokai = 0;
        int currentAttitude = 0;
        int currentLevel = 0;
        std::vector<uint8_t> tiv;
        std::map<std::vector<uint8_t>, std::string> presets = { //EVs (/2 for ivs)
            {{4, 10, 0, 2, 4}, "FIGHTER"},
            {{4, 0, 10, 2, 4}, "TECHNICAL"},
            {{8, 0, 0, 4, 8}, "HEALER"},
            {{10, 0, 0, 10, 0}, "TANK"},
            {{4, 4, 4, 4, 4}, "BALANCED"}
        };

        while (appletMainLoop()) {
            consoleUpdate(NULL);
            padUpdate(&pad);
            u64 kDown = padGetButtonsDown(&pad);

            if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus){
                break;
            }

            if (kDown & HidNpadButton_B) {
                if (selectPage) {
                    //if all false, break
                    if (!std::any_of(selected, selected + yokailist.size(), [](bool v) { return v; })) {
                        break;
                    } else {
                        //else, set all false
                        for (int i = 0; i < yokailist.size(); i++) {
                            selected[i] = false;
                        }
                    }
                } else {
                    selectPage = !selectPage;
                }
            }

            if (kDown & HidNpadButton_L || kDown & HidNpadButton_R) {
                selectPage = !selectPage;
            }

            if (selectPage) {
                if (kDown & HidNpadButton_Y) {
                    int hexSelection = 0;
                    int mode = 1;
                    while (appletMainLoop()) {
                        consoleUpdate(NULL);
                        padUpdate(&pad);
                        u64 kDown = padGetButtonsDown(&pad);

                        hexEdit(hexSelection, kDown, buffer, &mode, yokailist[currentSelection].data);
                        if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus || kDown & HidNpadButton_B || kDown & HidNpadButton_Y) {
                            break;
                        }
                        if (kDown & HidNpadButton_L) {
                            currentSelection -= 1;
                            if (currentSelection < 0) {
                                currentSelection = yokailist.size() - 1;
                            }
                        }
                        if (kDown & HidNpadButton_R) {
                            currentSelection += 1;
                            if (currentSelection >= yokailist.size()) {
                                currentSelection = 0;
                            }
                        }

                        std::cout << "\n\nIndex " << hexSelection << "/" << yokailist[currentSelection].data.size() << " of " << currentSelection+1 << "/" << yokailist.size() << " - " << mode << " byte mode.";
                    }
                }

                end = selectInput(selected, currentSelection, kDown, yokailist.size());
                for (int i = currentSelection/44*44; i < end; i++) {
                    std::cout << "\n" << (selected[i] ? "> " : "  ") << data1s::yokais.at(*yokailist[i].type) << (currentSelection == i ? " <<<" : "");
                }
            } else { //edit page
                printf("\x1b[1;1H\x1b[2JL or R to swap pages\n");
                inputHandling(currentEdit, kDown, 6);
                if (kDown & HidNpadButton_A) {
                    if (currentEdit == 0) { //yokai
                        mapInput(pad, currentYokai, "yokai");
                        padUpdate(&pad);
                    } else if (currentEdit == 1) { //attitude
                        listInput(pad, currentAttitude, data1s::attitudes, sizeof(data1s::attitudes)/sizeof(data1s::attitudes[0]), "attitude");
                        padUpdate(&pad);
                    } else if (currentEdit == 2) { //level
                        keyboardInput(buffer, SwkbdType_NumPad, 3, "0-255", (currentLevel == 0 ? "99" : std::to_string(currentLevel).c_str()));
                        if (buffer[0] == '\0') {
                            currentLevel = 0;
                        } else { //criteria
                            if (std::stoi(buffer) > 255) {
                                currentLevel = 255;
                            } else {
                                currentLevel = std::stoi(buffer);
                            }
                        }
                    } else if (currentEdit == 3) { //edit stats
                        std::vector<int> selectedIndexes;
                        for (int i = 0; i < yokailist.size(); i++) {
                            if (selected[i]) {
                                selectedIndexes.push_back(i);
                            }
                        }
                        int totalSelected = selectedIndexes.size();
                        if (totalSelected == 0) continue; //no yokai selected
                        int currentStat = 0;
                        int currentPreset = 0;
                        int index = 0;
                        std::vector<uint8_t> evs;
                        std::vector<uint8_t> ivs;
                        while (appletMainLoop()) {
                            consoleUpdate(NULL);
                            padUpdate(&pad);
                            u64 kDown = padGetButtonsDown(&pad);
                            inputHandling(currentStat, kDown, 4);

                            if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus || kDown & HidNpadButton_B) {
                                break;
                            }
                            
                            if (kDown & HidNpadButton_A) {
                                if (currentStat == 0) { //presets
                                    auto it = presets.find(evs);
                                    if (it != presets.end()) {
                                        bool match = true;
                                        for (int i = 0; i < 5; i++) {
                                            if (ivs[i]*2 != evs[i]) {
                                                match = false;
                                                break;
                                            }
                                        }
                                        if (match) {
                                            currentPreset = std::distance(presets.begin(), it);
                                        } else {
                                            currentPreset = presets.size();
                                        }
                                    } else {
                                        currentPreset = presets.size();
                                    }
                                    while (appletMainLoop()) {
                                        consoleUpdate(NULL);
                                        padUpdate(&pad);
                                        u64 kDown = padGetButtonsDown(&pad);
                                        inputHandling(currentPreset, kDown, presets.size()+1);

                                        if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus || kDown & HidNpadButton_B) {
                                            break; //could add to the A logic
                                        }

                                        if (kDown & HidNpadButton_A) {
                                            if (currentPreset != presets.size()) {
                                                auto it = presets.begin();
                                                std::advance(it, currentPreset);
                                                *yokailist[selectedIndexes[index]].stats.ev_hp = it->first[0]; //TODO find a way to use ev/iv list
                                                *yokailist[selectedIndexes[index]].stats.ev_str = it->first[1];
                                                *yokailist[selectedIndexes[index]].stats.ev_spr = it->first[2];
                                                *yokailist[selectedIndexes[index]].stats.ev_def = it->first[3];
                                                *yokailist[selectedIndexes[index]].stats.ev_spd = it->first[4];
                                                *yokailist[selectedIndexes[index]].stats.iv21_hp = (*yokailist[selectedIndexes[index]].stats.iv21_hp & 0xF0) | (it->first[0]/2 & 0x0F);
                                                *yokailist[selectedIndexes[index]].stats.iv21_str = (*yokailist[selectedIndexes[index]].stats.iv21_str & 0xF0) | (it->first[1]/2 & 0x0F);
                                                *yokailist[selectedIndexes[index]].stats.iv21_spr = (*yokailist[selectedIndexes[index]].stats.iv21_spr & 0xF0) | (it->first[2]/2 & 0x0F);
                                                *yokailist[selectedIndexes[index]].stats.iv21_def = (*yokailist[selectedIndexes[index]].stats.iv21_def & 0xF0) | (it->first[3]/2 & 0x0F);
                                                *yokailist[selectedIndexes[index]].stats.iv21_spd = (*yokailist[selectedIndexes[index]].stats.iv21_spd & 0xF0) | (it->first[4]/2 & 0x0F);
                                            }

                                            break;
                                        }

                                        printf("\x1b[1;1H\x1b[2JSelect a preset:\n");
                                        for (int i = 0; i < presets.size(); i++) {
                                            auto it = presets.begin();
                                            std::advance(it, i);
                                            std::cout << (i == currentPreset ? "> " : "  ") << it->second << std::endl;
                                        }
                                        printf("\n");
                                        std::cout << (presets.size() == currentPreset ? "> " : "  ") << "custom" << std::endl;
                                    };
                                } else if (currentStat == 1) { //EVs
                                    int currentEV = 0;
                                    while (appletMainLoop()) {
                                        consoleUpdate(NULL);
                                        padUpdate(&pad);
                                        u64 kDown = padGetButtonsDown(&pad);

                                        inputHandling(currentEV, kDown, 5);

                                        if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus || kDown & HidNpadButton_B) {
                                            break;
                                        }

                                        if (kDown & HidNpadButton_A) {
                                            keyboardInput(buffer, SwkbdType_NumPad, 2, "0-20", std::to_string(evs[currentEV]).c_str());
                                            if (buffer[0] != '\0') {
                                                if (std::stoi(buffer) > 20) {
                                                    evs[currentEV] = 20;
                                                } else {
                                                    evs[currentEV] = std::stoi(buffer);
                                                }
                                            }
                                        }

                                        printf("\x1b[1;1H\x1b[2JEdit EVs\n\n");
                                        std::cout << (currentEV == 0 ? "> " : "  ") << "HP:  " << std::to_string(evs[0]) << std::endl;
                                        std::cout << (currentEV == 1 ? "> " : "  ") << "STR: " << std::to_string(evs[1]) << std::endl;
                                        std::cout << (currentEV == 2 ? "> " : "  ") << "SPR: " << std::to_string(evs[2]) << std::endl;
                                        std::cout << (currentEV == 3 ? "> " : "  ") << "DEF: " << std::to_string(evs[3]) << std::endl;
                                        std::cout << (currentEV == 4 ? "> " : "  ") << "SPD: " << std::to_string(evs[4]) << std::endl;
                                        printf("\n");
                                        std::cout << "EVs must sum to 20 at most" << std::endl;
                                    }
                                    *yokailist[selectedIndexes[index]].stats.ev_hp = evs[0]; //temporary fix
                                    *yokailist[selectedIndexes[index]].stats.ev_str = evs[1];
                                    *yokailist[selectedIndexes[index]].stats.ev_spr = evs[2];
                                    *yokailist[selectedIndexes[index]].stats.ev_def = evs[3];
                                    *yokailist[selectedIndexes[index]].stats.ev_spd = evs[4];
                                } else if (currentStat == 2) { //IVs
                                    int currentIV = 0;
                                    while (appletMainLoop()) {
                                        consoleUpdate(NULL);
                                        padUpdate(&pad);
                                        u64 kDown = padGetButtonsDown(&pad);

                                        inputHandling(currentIV, kDown, 5);

                                        if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus || kDown & HidNpadButton_B) {
                                            break;
                                        }

                                        if (kDown & HidNpadButton_A) {
                                            keyboardInput(buffer, SwkbdType_NumPad, 2, "0-10", std::to_string(ivs[currentIV]).c_str());
                                            if (buffer[0] != '\0') {
                                                if (std::stoi(buffer) > 10) {
                                                    ivs[currentIV] = 10;
                                                } else {
                                                    ivs[currentIV] = std::stoi(buffer);
                                                }
                                            }
                                        }

                                        printf("\x1b[1;1H\x1b[2JEdit IVs\n\n");
                                        std::cout << (currentIV == 0 ? "> " : "  ") << "HP:  " << std::to_string(ivs[0]) << std::endl;
                                        std::cout << (currentIV == 1 ? "> " : "  ") << "STR: " << std::to_string(ivs[1]) << std::endl;
                                        std::cout << (currentIV == 2 ? "> " : "  ") << "SPR: " << std::to_string(ivs[2]) << std::endl;
                                        std::cout << (currentIV == 3 ? "> " : "  ") << "DEF: " << std::to_string(ivs[3]) << std::endl;
                                        std::cout << (currentIV == 4 ? "> " : "  ") << "SPD: " << std::to_string(ivs[4]) << std::endl;
                                        printf("\n");
                                        std::cout << "IVs must sum to 10" << std::endl;
                                    }
                                    *yokailist[selectedIndexes[index]].stats.iv21_hp = (*yokailist[selectedIndexes[index]].stats.iv21_hp & 0xF0) | (ivs[0] & 0x0F);
                                    *yokailist[selectedIndexes[index]].stats.iv21_str = (*yokailist[selectedIndexes[index]].stats.iv21_str & 0xF0) | (ivs[1] & 0x0F);
                                    *yokailist[selectedIndexes[index]].stats.iv21_spr = (*yokailist[selectedIndexes[index]].stats.iv21_spr & 0xF0) | (ivs[2] & 0x0F);
                                    *yokailist[selectedIndexes[index]].stats.iv21_def = (*yokailist[selectedIndexes[index]].stats.iv21_def & 0xF0) | (ivs[3] & 0x0F);
                                    *yokailist[selectedIndexes[index]].stats.iv21_spd = (*yokailist[selectedIndexes[index]].stats.iv21_spd & 0xF0) | (ivs[4] & 0x0F);
                                } else if (currentStat == 3) { //set all
                                    for (int selectedIndex : selectedIndexes) {
                                        // Apply the same stats to all selected yokai
                                        *yokailist[selectedIndex].stats.ev_hp = *yokailist[selectedIndexes[index]].stats.ev_hp;
                                        *yokailist[selectedIndex].stats.ev_str = *yokailist[selectedIndexes[index]].stats.ev_str;
                                        *yokailist[selectedIndex].stats.ev_spr = *yokailist[selectedIndexes[index]].stats.ev_spr;
                                        *yokailist[selectedIndex].stats.ev_def = *yokailist[selectedIndexes[index]].stats.ev_def;
                                        *yokailist[selectedIndex].stats.ev_spd = *yokailist[selectedIndexes[index]].stats.ev_spd;

                                        *yokailist[selectedIndex].stats.iv21_hp = (*yokailist[selectedIndex].stats.iv21_hp & 0xF0) | (*yokailist[selectedIndexes[index]].stats.iv21_hp & 0x0F);
                                        *yokailist[selectedIndex].stats.iv21_str = (*yokailist[selectedIndex].stats.iv21_str & 0xF0) | (*yokailist[selectedIndexes[index]].stats.iv21_str & 0x0F);
                                        *yokailist[selectedIndex].stats.iv21_spr = (*yokailist[selectedIndex].stats.iv21_spr & 0xF0) | (*yokailist[selectedIndexes[index]].stats.iv21_spr & 0x0F);
                                        *yokailist[selectedIndex].stats.iv21_def = (*yokailist[selectedIndex].stats.iv21_def & 0xF0) | (*yokailist[selectedIndexes[index]].stats.iv21_def & 0x0F);
                                        *yokailist[selectedIndex].stats.iv21_spd = (*yokailist[selectedIndex].stats.iv21_spd & 0xF0) | (*yokailist[selectedIndexes[index]].stats.iv21_spd & 0x0F);
                                    }
                                }
                            }

                            if (kDown & HidNpadButton_L) {
                                index -= 1;
                                if (index < 0) {
                                    index = totalSelected - 1;
                                }
                            }
                            if (kDown & HidNpadButton_R) {
                                index += 1;
                                if (index >= totalSelected) {
                                    index = 0;
                                }
                            }

                            printf("\x1b[1;1H\x1b[2JEdit stats\n\n");
                            std::cout << (currentStat == 0 ? "> " : "  ") << "preset: ";
                            evs = {
                                *yokailist[selectedIndexes[index]].stats.ev_hp,
                                *yokailist[selectedIndexes[index]].stats.ev_str,
                                *yokailist[selectedIndexes[index]].stats.ev_spr,
                                *yokailist[selectedIndexes[index]].stats.ev_def,
                                *yokailist[selectedIndexes[index]].stats.ev_spd
                            };
                            ivs = {
                                static_cast<uint8_t>(*yokailist[selectedIndexes[index]].stats.iv21_hp & 0x0F),
                                static_cast<uint8_t>(*yokailist[selectedIndexes[index]].stats.iv21_str & 0x0F),
                                static_cast<uint8_t>(*yokailist[selectedIndexes[index]].stats.iv21_spr & 0x0F),
                                static_cast<uint8_t>(*yokailist[selectedIndexes[index]].stats.iv21_def & 0x0F),
                                static_cast<uint8_t>(*yokailist[selectedIndexes[index]].stats.iv21_spd & 0x0F)
                            };
                            auto it = presets.find(evs); //expensive to run every frame??
                            if (it != presets.end()) {
                                bool match = true;
                                for (int i = 0; i < 5; i++) {
                                    if (ivs[i]*2 != evs[i]) {
                                        match = false;
                                        break;
                                    }
                                }
                                if (match) {
                                    std::cout << it->second;
                                } else {
                                    std::cout << "custom";
                                }
                            } else {
                                std::cout << "custom";
                            }
                            printf("\n\n");
                            std::cout << (currentStat == 1 ? "> " : "  ") << "edit EVs" << std::endl;
                            std::cout << (currentStat == 2 ? "> " : "  ") << "edit IVs" << std::endl;
                            printf("\n");
                            std::cout << (currentStat == 3 ? "> " : "  ") << "set all" << std::endl; //set all selected yokai to the same stats
                            //print errors
                            if (std::accumulate(evs.begin(), evs.end(), 0) > 20) {
                                std::cout << "\nWARNING: EVs must sum to 20 at most" << std::endl;
                            }
                            if (std::accumulate(ivs.begin(), ivs.end(), 0) != 10) {//, [](int sum, uint8_t val) { return sum + (val & 0x0F); }) != 10) {
                                std::cout << "\nWARNING: IVs must sum to 10" << std::endl;
                            }
                            if (currentStat == 3) {
                                std::cout << "\nediting ALL" << std::endl;
                            } else {
                                std::cout << "\nediting " << index + 1 << "/" << totalSelected << std::endl; //index always starts at 0 now
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
                                if (currentEdit == 4) {
                                    *yokailist[i].attack = 255; //ingame max is 10
                                    *yokailist[i].technique = 255;
                                    *yokailist[i].soultimate = 255;

                                    tiv = data1s::tivs.at(*yokailist[i].type); //every tribe has a different tiv
                                    *yokailist[i].stats.tiv_hp = tiv[0];
                                    *yokailist[i].stats.tiv_str = tiv[1];
                                    *yokailist[i].stats.tiv_spr = tiv[2];
                                    *yokailist[i].stats.tiv_def = tiv[3];
                                    *yokailist[i].stats.tiv_spd = tiv[4];

                                    *yokailist[i].stats.iv21_hp = (*yokailist[i].stats.iv21_hp & 0x0F) | (15 << 4); //set first nibble to 15 ingame max is 3
                                    *yokailist[i].stats.iv21_str = (*yokailist[i].stats.iv21_str & 0x0F) | (15 << 4);
                                    *yokailist[i].stats.iv21_spr = (*yokailist[i].stats.iv21_spr & 0x0F) | (15 << 4);
                                    *yokailist[i].stats.iv21_def = (*yokailist[i].stats.iv21_def & 0x0F) | (15 << 4);
                                    *yokailist[i].stats.iv21_spd = (*yokailist[i].stats.iv21_spd & 0x0F) | (15 << 4);

                                    //TODO loaf level
                                }
                            }
                        }
                    }
                }
                std::cout << (currentEdit == 0 ? "> " : "  ") << "yokai: " << (currentYokai == 0 ? "" : data1s::yokais.at(currentYokai)) << std::endl;
                std::cout << (currentEdit == 1 ? "> " : "  ") << "attitude: " << data1s::attitudes[currentAttitude] << std::endl;
                std::cout << (currentEdit == 2 ? "> " : "  ") << "level: " << (currentLevel == 0 ? "" : std::to_string(currentLevel)) << std::endl;
                printf("\n");
                std::cout << (currentEdit == 3 ? "> " : "  ") << "edit stats" << std::endl;
                printf("\n");
                std::cout << (currentEdit == 4 ? "> " : "  ") << "apply and set max" << std::endl;
                std::cout << (currentEdit == 5 ? "> " : "  ") << "apply" << std::endl;
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
        char buffer[32];
        int end;

        int currentItem = 0;
        int currentAmount = 0;

        while (appletMainLoop()) {
            consoleUpdate(NULL);
            padUpdate(&pad);
            u64 kDown = padGetButtonsDown(&pad);

            if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus){
                break;
            }

            if (kDown & HidNpadButton_B) {
                if (selectPage) {
                    //if all false, break
                    if (!std::any_of(selected, selected + itemlist.size(), [](bool v) { return v; })) {
                        break;
                    } else {
                        //else, set all false
                        for (int i = 0; i < itemlist.size(); i++) {
                            selected[i] = false;
                        }
                    }
                } else {
                    selectPage = !selectPage;
                }
            }

            if (kDown & HidNpadButton_L || kDown & HidNpadButton_R) {
                selectPage = !selectPage;
            }

            if (selectPage) {
                if (kDown & HidNpadButton_Y) {
                    int hexSelection = 0;
                    int mode = 1;
                    while (appletMainLoop()) {
                        consoleUpdate(NULL);
                        padUpdate(&pad);
                        u64 kDown = padGetButtonsDown(&pad);

                        hexEdit(hexSelection, kDown, buffer, &mode, itemlist[currentSelection].data);
                        if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus || kDown & HidNpadButton_B || kDown & HidNpadButton_Y) {
                            break;
                        }
                        if (kDown & HidNpadButton_L) {
                            currentSelection -= 1;
                            if (currentSelection < 0) {
                                currentSelection = itemlist.size() - 1;
                            }
                        }
                        if (kDown & HidNpadButton_R) {
                            currentSelection += 1;
                            if (currentSelection >= itemlist.size()) {
                                currentSelection = 0;
                            }
                        }

                        std::cout << "\n\nIndex " << hexSelection << "/" << itemlist[currentSelection].data.size() << " of " << currentSelection+1 << "/" << itemlist.size() << " - " << mode << " byte mode.";
                    }
                }

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
                        keyboardInput(buffer, SwkbdType_NumPad, 2, "0-99", (currentAmount == 0 ? "99" : std::to_string(currentAmount).c_str()));
                        if (buffer[0] == '\0') {
                            currentAmount = 0;
                        } else { //criteria
                            if (std::stoi(buffer) > 99) {
                                currentAmount = 99;
                            } else {
                                currentAmount = std::stoi(buffer);
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
        char buffer[32];
        int end;

        int currentEquipment = 0;
        int currentAmount = 0;

        while (appletMainLoop()) {
            consoleUpdate(NULL);
            padUpdate(&pad);
            u64 kDown = padGetButtonsDown(&pad);

            if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus){
                break;
            }

            if (kDown & HidNpadButton_L || kDown & HidNpadButton_R) {
                selectPage = !selectPage;
            }

            if (kDown & HidNpadButton_B) {
                if (selectPage) {
                    //if all false, break
                    if (!std::any_of(selected, selected + equipmentlist.size(), [](bool v) { return v; })) {
                        break;
                    } else {
                        //else, set all false
                        for (int i = 0; i < equipmentlist.size(); i++) {
                            selected[i] = false;
                        }
                    }
                } else {
                    selectPage = !selectPage;
                }
            }

            if (selectPage) {
                if (kDown & HidNpadButton_Y) {
                    int hexSelection = 0;
                    int mode = 1;
                    while (appletMainLoop()) {
                        consoleUpdate(NULL);
                        padUpdate(&pad);
                        u64 kDown = padGetButtonsDown(&pad);

                        hexEdit(hexSelection, kDown, buffer, &mode, equipmentlist[currentSelection].data);
                        if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus || kDown & HidNpadButton_B || kDown & HidNpadButton_Y) {
                            break;
                        }
                        if (kDown & HidNpadButton_L) {
                            currentSelection -= 1;
                            if (currentSelection < 0) {
                                currentSelection = equipmentlist.size() - 1;
                            }
                        }
                        if (kDown & HidNpadButton_R) {
                            currentSelection += 1;
                            if (currentSelection >= equipmentlist.size()) {
                                currentSelection = 0;
                            }
                        }

                        std::cout << "\n\nIndex " << hexSelection << "/" << equipmentlist[currentSelection].data.size() << " of " << currentSelection+1 << "/" << equipmentlist.size() << " - " << mode << " byte mode.";
                    }
                }

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
                        keyboardInput(buffer, SwkbdType_NumPad, 3, "0-255", (currentAmount == 0 ? "99" : std::to_string(currentAmount).c_str()));
                        if (buffer[0] == '\0') {
                            currentAmount = 0;
                        } else { //criteria
                            if (std::stoi(buffer) > 255) {
                                currentAmount = 255;
                            } else {
                                currentAmount = std::stoi(buffer);
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
        char buffer[32];
        int end;

        int currentImportant = 0;

        while (appletMainLoop()) {
            consoleUpdate(NULL);
            padUpdate(&pad);
            u64 kDown = padGetButtonsDown(&pad);

            if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus){
                break;
            }

            if (kDown & HidNpadButton_B) {
                if (selectPage) {
                    //if all false, break
                    if (!std::any_of(selected, selected + importantlist.size(), [](bool v) { return v; })) {
                        break;
                    } else {
                        //else, set all false
                        for (int i = 0; i < importantlist.size(); i++) {
                            selected[i] = false;
                        }
                    }
                } else {
                    selectPage = !selectPage;
                }
            }

            if (kDown & HidNpadButton_L || kDown & HidNpadButton_R) {
                selectPage = !selectPage;
            }

            if (selectPage) {
                if (kDown & HidNpadButton_Y) {
                    int hexSelection = 0;
                    int mode = 1;
                    while (appletMainLoop()) {
                        consoleUpdate(NULL);
                        padUpdate(&pad);
                        u64 kDown = padGetButtonsDown(&pad);

                        hexEdit(hexSelection, kDown, buffer, &mode, importantlist[currentSelection].data);
                        if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus || kDown & HidNpadButton_B || kDown & HidNpadButton_Y) {
                            break;
                        }
                        if (kDown & HidNpadButton_L) {
                            currentSelection -= 1;
                            if (currentSelection < 0) {
                                currentSelection = importantlist.size() - 1;
                            }
                        }
                        if (kDown & HidNpadButton_R) {
                            currentSelection += 1;
                            if (currentSelection >= importantlist.size()) {
                                currentSelection = 0;
                            }
                        }

                        std::cout << "\n\nIndex " << hexSelection << "/" << importantlist[currentSelection].data.size() << " of " << currentSelection+1 << "/" << importantlist.size() << " - " << mode << " byte mode.";
                    }
                }

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
        sortedMap.clear();
        for (auto const& pair : data1s::locations) {
            sortedMap.push_back(pair);
        }
        std::sort(sortedMap.begin(), sortedMap.end(), [](const std::pair<int, std::string> &left, const std::pair<int, std::string> &right) {
            return left.second < right.second;
        });
        filteredMap = sortedMap;

        int currentSelection = 0;
        int currentEdit = 0;
        char buffer[46];
        int end;
        int offset = 0;

        int currentLocation = 0;

        while (appletMainLoop()) {
            consoleUpdate(NULL);
            padUpdate(&pad);
            u64 kDown = padGetButtonsDown(&pad);

            if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus || kDown & HidNpadButton_B){
                break;
            }

            inputHandling(currentEdit, kDown, 5);
            if (kDown & HidNpadButton_A) {
                if (currentEdit == 0) { //nicknames
                    while (appletMainLoop()) {
                        consoleUpdate(NULL);
                        padUpdate(&pad);
                        u64 kDown = padGetButtonsDown(&pad);

                        if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus || kDown & HidNpadButton_B){
                            break;
                        }
                        inputHandling(currentSelection, kDown, 1+yokailist.size());
                        if (kDown & HidNpadButton_A) {
                            if (currentSelection == 0) {
                                for (int i = 0; i < yokailist.size(); i++) {
                                    strcpy(yokailist[i].nickname, "");
                                }
                            } else {
                                keyboardInput(buffer, SwkbdType_All, 46, "enter a nickname", yokailist[currentSelection-1].nickname); //nicknames are technically 68 characters long, but that won't fit on the screen so I'm arbitrarily limiting it to 46
                                if (buffer[0] != '\0') {
                                    strcpy(yokailist[currentSelection-1].nickname, buffer);
                                }
                            }
                        } else if (kDown & HidNpadButton_X) { //clear
                            if (currentSelection != 0) {
                                strcpy(yokailist[currentSelection-1].nickname, "");
                            }
                        } else if (kDown & HidNpadButton_Y) { //swap width
                            if (currentSelection != 0) {
                                strcpy(yokailist[currentSelection-1].nickname, converter.to_bytes(convert_width(converter.from_bytes(yokailist[currentSelection-1].nickname))).substr(0, 45).c_str()); //same here, but it's divisible by 3
                            }
                        }
                        printf("\x1b[1;1H\x1b[2JSelect an option: (Y to swap width, X to clear. Japanese is scrambled)");
                        if (currentSelection < 43) { //45 - 2 dead lines
                            offset = 0;
                            printf("\n");
                            std::cout << (currentSelection == 0 ? "> " : "  ") << "clear all" << std::endl;
                        } else {
                            offset = 1;
                        }
                        end = (currentSelection-offset)/44*44+44;
                        if (end > yokailist.size()) {
                            end = yokailist.size();
                        }
                        for (int i = (currentSelection-offset)/44*44; i < end; i++) {
                            if (i > 41 && currentSelection < 43) { //first page has extra options
                                break;
                            }
                            auto it = data1s::yokais.find(*yokailist[i].type);
                            if (it != data1s::yokais.end()) {
                                std::string nickname = yokailist[i].nickname;
                                std::replace(nickname.begin(), nickname.end(), '\n', 'n');
                                std::cout << "\n" << (currentSelection == i+1 ? "> " : "  ") << it->second << ":" << std::string(31 - it->second.size(), ' ') << nickname; //TODO fix alignment
                            }
                        }
                    }
                } else if (currentEdit == 1) { //location
                    mapInput(pad, currentLocation, "location (TODO)");
                    padUpdate(&pad);
                    //TODO set location and x, y, z
                } else if (currentEdit == 2) { //time
                    //TODO
                } else if (currentEdit == 3) { //crank-a-kai
                    //TODO
                } else if (currentEdit == 4) { //money
                    keyboardInput(buffer, SwkbdType_NumPad, 8, "0-999999", (*money == 0 ? "999999" : std::to_string(*money).c_str())); //TODO test max again
                    if (buffer[0] != '\0') {
                        if (std::stoi(buffer) > 999999) {
                            *money = 999999;
                        } else {
                            *money = std::stoi(buffer);
                        }
                    }
                }
            }
            printf("\x1b[1;1H\x1b[2JSelect an option:\n");
            std::cout << (currentEdit == 0 ? "> " : "  ") << "nicknames" << std::endl;
            std::cout << (currentEdit == 1 ? "> " : "  ") << "location TODO" << std::endl;
            std::cout << (currentEdit == 2 ? "> " : "  ") << "time TODO" << std::endl;
            std::cout << (currentEdit == 3 ? "> " : "  ") << "crank-a-kai TODO" << std::endl;
            std::cout << (currentEdit == 4 ? "> " : "  ") << "money" << std::endl;
            //TODO time
        }
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
        char buffer[32];
        int end;

        int currentCharacter = 0;
        int currentLevel = 0;
        
        while (appletMainLoop()) {
            consoleUpdate(NULL);
            padUpdate(&pad);
            u64 kDown = padGetButtonsDown(&pad);
            
            if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus){
                break;
            }

            if (kDown & HidNpadButton_B) {
                if (selectPage) {
                    //if all false, break
                    if (!std::any_of(selected, selected + characterlist.size(), [](bool v) { return v; })) {
                        break;
                    } else {
                        //else, set all false
                        for (int i = 0; i < characterlist.size(); i++) {
                            selected[i] = false;
                        }
                    }
                } else {
                    selectPage = !selectPage;
                }
            }
            
            if (kDown & HidNpadButton_L || kDown & HidNpadButton_R) {
                selectPage = !selectPage;
            }

            if (selectPage) {
                if (kDown & HidNpadButton_Y) {
                    int hexSelection = 0;
                    int mode = 1;
                    while (appletMainLoop()) {
                        consoleUpdate(NULL);
                        padUpdate(&pad);
                        u64 kDown = padGetButtonsDown(&pad);

                        hexEdit(hexSelection, kDown, buffer, &mode, characterlist[currentSelection].data);
                        if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus || kDown & HidNpadButton_B || kDown & HidNpadButton_Y) {
                            break;
                        }
                        if (kDown & HidNpadButton_L) {
                            currentSelection -= 1;
                            if (currentSelection < 0) {
                                currentSelection = characterlist.size() - 1;
                            }
                        }
                        if (kDown & HidNpadButton_R) {
                            currentSelection += 1;
                            if (currentSelection >= characterlist.size()) {
                                currentSelection = 0;
                            }
                        }

                        std::cout << "\n\nIndex " << hexSelection << "/" << characterlist[currentSelection].data.size() << " of " << currentSelection+1 << "/" << characterlist.size() << " - " << mode << " byte mode.";
                    }
                }

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
                inputHandling(currentEdit, kDown, 6);
                if (kDown & HidNpadButton_A) {
                    if (currentEdit == 0) { //character
                        mapInput(pad, currentCharacter, "character");
                        padUpdate(&pad);
                    } else if (currentEdit == 1) { //level
                        keyboardInput(buffer, SwkbdType_NumPad, 2, "0-99", (currentLevel == 0 ? "99" : std::to_string(currentLevel).c_str()));
                        if (buffer[0] == '\0') {
                            currentLevel = 0;
                        } else { //criteria
                            if (std::stoi(buffer) > 99) {
                                currentLevel = 99;
                            } else {
                                currentLevel = std::stoi(buffer);
                            }
                        }
                    } else if (currentEdit == 2) { //edit moves
                        std::vector<int> selectedIndexes;
                        for (int i = 0; i < characterlist.size(); i++) {
                            if (selected[i]) {
                                selectedIndexes.push_back(i);
                            }
                        }
                        int totalSelected = selectedIndexes.size();
                        if (totalSelected == 0) continue; //no yokai selected
                        int currentMove = 0;
                        int index = 0;
                        std::vector<uint8_t> evs;
                        std::vector<uint8_t> ivs;
                        while (appletMainLoop()) {
                            consoleUpdate(NULL);
                            padUpdate(&pad);
                            u64 kDown = padGetButtonsDown(&pad);
                            inputHandling(currentMove, kDown, 7);

                            if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus || kDown & HidNpadButton_B) {
                                break;
                            }
                            
                            if (kDown & HidNpadButton_A) {
                                if (currentMove < 6) { //edit move
                                    std::vector<std::pair<int, std::string>> moveMap;
                                    for (auto const& pair : data4::moves) {
                                        moveMap.push_back(pair);
                                    }
                                    std::sort(moveMap.begin(), moveMap.end(), [](const std::pair<int, std::string> &left, const std::pair<int, std::string> &right) {
                                        return left.second < right.second;
                                    });

                                    moveMap.erase(moveMap.begin()); // Exclude the first part of sorted moveMap (None)

                                    uint32_t move = 0;
                                    if (*characterlist[selectedIndexes[index]].moves[currentMove] == 0) {
                                        mapSelection = 0;
                                    } else {
                                        for (int i = 0; i < moveMap.size(); i++) {
                                            if (moveMap[i].first == *characterlist[selectedIndexes[index]].moves[currentMove]) {
                                                mapSelection = i;
                                                break;
                                            }
                                        }
                                    }
                                    SwkbdInline kbdinline;
                                    swkbdInlineCreate(&kbdinline);
                                    swkbdInlineSetFinishedInitializeCallback(&kbdinline, NULL);
                                    swkbdInlineLaunchForLibraryApplet(&kbdinline, SwkbdInlineMode_AppletDisplay, 0);
                                    swkbdInlineSetChangedStringCallback(&kbdinline, callback);
                                    swkbdInlineSetDecidedEnterCallback(&kbdinline, enter);
                                    swkbdInlineSetDecidedCancelCallback(&kbdinline, cancel);
                                    SwkbdAppearArg appearArg;
                                    swkbdInlineMakeAppearArg(&appearArg, SwkbdType_All);
                                    
                                    activeKeyboard = false;

                                    while (appletMainLoop()) {
                                        padUpdate(&pad);
                                        swkbdInlineUpdate(&kbdinline, NULL);
                                        u64 kDown = padGetButtonsDown(&pad);
                                        if (!activeKeyboard) {
                                            if (moveMap.size() != 0) {
                                                inputHandling(mapSelection, kDown, moveMap.size());
                                            }
                                            if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus || kDown & HidNpadButton_B || kDown & HidNpadButton_A){
                                                if (moveMap.size() == 0) {
                                                    move = 0;
                                                    break;
                                                }
                                                move = moveMap[mapSelection].first;
                                                break;
                                            }
                                            if (kDown & HidNpadButton_Y) {
                                                move = 0;
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
                                        std::cout << "\x1b[1;1H\x1b[2JSelect a move (Y for none, X to toggle keyboard)";
                                        for (auto const& pair : moveMap) {
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
                                    *characterlist[selectedIndexes[index]].moves[currentMove] = move;
                                } else if (currentMove == 6) { //set all
                                    for (int selectedIndex : selectedIndexes) {
                                        // Apply the same moves to all selected yokai
                                        for (int i = 0; i < 6; i++) {
                                            *characterlist[selectedIndex].moves[i] = *characterlist[selectedIndexes[index]].moves[i];
                                        }
                                    }
                                }
                            }

                            if (kDown & HidNpadButton_L) {
                                index -= 1;
                                if (index < 0) {
                                    index = totalSelected - 1;
                                }
                            }
                            if (kDown & HidNpadButton_R) {
                                index += 1;
                                if (index >= totalSelected) {
                                    index = 0;
                                }
                            }

                            printf("\x1b[1;1H\x1b[2JEdit moves\n\n");
                            for (int i = 0; i < 6; i++) {
                                std::cout << (currentMove == i ? "> " : "  ") << i+1 << ": " << data4::moves.find(*characterlist[selectedIndexes[index]].moves[i])->second << std::endl;
                            }
                            printf("\n");
                            std::cout << (currentMove == 6 ? "> " : "  ") << "set all" << std::endl; //set all selected yokai to the same stats
                            
                            if (currentMove == 6) {
                                std::cout << "\nediting ALL" << std::endl;
                            } else {
                                std::cout << "\nediting " << index + 1 << "/" << totalSelected << std::endl; //index always starts at 0 now
                            }
                        }
                    } else if (currentEdit == 3) { //edit stats
                        //TODO
                    } else { //apply (and set max)
                        for (int i = 0; i < characterlist.size(); i++) {
                            if (selected[i]) {
                                *characterlist[i].hp = 1; //incase you lower the level
                                if (currentCharacter != 0) {
                                    *characterlist[i].type = currentCharacter;
                                }
                                if (currentLevel != 0) {
                                    *characterlist[i].level = currentLevel;
                                }
                                if (currentEdit == 4) {
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
                std::cout << (currentEdit == 2 ? "> " : "  ") << "edit moves" << std::endl;
                std::cout << (currentEdit == 3 ? "> " : "  ") << "edit stats TODO" << std::endl;
                printf("\n");
                std::cout << (currentEdit == 4 ? "> " : "  ") << "apply and set max" << std::endl;
                std::cout << (currentEdit == 5 ? "> " : "  ") << "apply" << std::endl;
            }
        }
    }
    
    void edit_yokai(std::vector<struct4::Yokai> &yokailist, PadState pad) {
        sortedMap.clear();
        for (auto const& pair : data4::characters) { //some characters break the game
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
        char buffer[32];
        int end;

        int currentYokai = 0;
        int currentLevel = 0;

        while (appletMainLoop()) {
            consoleUpdate(NULL);
            padUpdate(&pad);
            u64 kDown = padGetButtonsDown(&pad);

            if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus){
                break;
            }

            if (kDown & HidNpadButton_B) {
                if (selectPage) {
                    //if all false, break
                    if (!std::any_of(selected, selected + yokailist.size(), [](bool v) { return v; })) {
                        break;
                    } else {
                        //else, set all false
                        for (int i = 0; i < yokailist.size(); i++) {
                            selected[i] = false;
                        }
                    }
                } else {
                    selectPage = !selectPage;
                }
            }

            if (kDown & HidNpadButton_L || kDown & HidNpadButton_R) {
                selectPage = !selectPage;
            }

            if (selectPage) {
                if (kDown & HidNpadButton_Y) {
                    int hexSelection = 0;
                    int mode = 1;
                    while (appletMainLoop()) {
                        consoleUpdate(NULL);
                        padUpdate(&pad);
                        u64 kDown = padGetButtonsDown(&pad);

                        hexEdit(hexSelection, kDown, buffer, &mode, yokailist[currentSelection].data);
                        if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus || kDown & HidNpadButton_B || kDown & HidNpadButton_Y) {
                            break;
                        }
                        if (kDown & HidNpadButton_L) {
                            currentSelection -= 1;
                            if (currentSelection < 0) {
                                currentSelection = yokailist.size() - 1;
                            }
                        }
                        if (kDown & HidNpadButton_R) {
                            currentSelection += 1;
                            if (currentSelection >= yokailist.size()) {
                                currentSelection = 0;
                            }
                        }

                        std::cout << "\n\nIndex " << hexSelection << "/" << yokailist[currentSelection].data.size() << " of " << currentSelection+1 << "/" << yokailist.size() << " - " << mode << " byte mode.";
                    }
                }

                end = selectInput(selected, currentSelection, kDown, yokailist.size());
                for (int i = currentSelection/44*44; i < end; i++) {
                    auto it = data4::characters.find(*yokailist[i].type); //makes debugging harder
                    if (it != data4::characters.end()) {
                        std::cout << "\n" << (selected[i] ? "> " : "  ") << it->second << (currentSelection == i ? " <<<" : "");
                    } else {
                        std::cout << "\n" << (selected[i] ? "> " : "  ") << *yokailist[i].type << " TODO" << (currentSelection == i ? " <<<" : "");
                    }
                }
            } else { //edit page
                printf("\x1b[1;1H\x1b[2JL or R to swap pages\n");
                inputHandling(currentEdit, kDown, 6);
                if (kDown & HidNpadButton_A) {
                    if (currentEdit == 0) { //yokai
                        mapInput(pad, currentYokai, "yokai");
                        padUpdate(&pad);
                    } else if (currentEdit == 1) { //level
                        keyboardInput(buffer, SwkbdType_NumPad, 3, "0-120", (currentLevel == 0 ? "120" : std::to_string(currentLevel).c_str()));
                        if (buffer[0] == '\0') {
                            currentLevel = 0;
                        } else { //criteria
                            if (std::stoi(buffer) > 120) {
                                currentLevel = 120;
                            } else {
                                currentLevel = std::stoi(buffer);
                            }
                        }
                    } else if (currentEdit == 2) { //edit moves
                        std::vector<int> selectedIndexes;
                        for (int i = 0; i < yokailist.size(); i++) {
                            if (selected[i]) {
                                selectedIndexes.push_back(i);
                            }
                        }
                        int totalSelected = selectedIndexes.size();
                        if (totalSelected == 0) continue; //no yokai selected
                        int currentMove = 0;
                        int index = 0;
                        std::vector<uint8_t> evs;
                        std::vector<uint8_t> ivs;
                        while (appletMainLoop()) {
                            consoleUpdate(NULL);
                            padUpdate(&pad);
                            u64 kDown = padGetButtonsDown(&pad);
                            inputHandling(currentMove, kDown, 7);

                            if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus || kDown & HidNpadButton_B) {
                                break;
                            }
                            
                            if (kDown & HidNpadButton_A) {
                                if (currentMove < 6) { //edit move
                                    std::vector<std::pair<int, std::string>> moveMap;
                                    for (auto const& pair : data4::moves) {
                                        moveMap.push_back(pair);
                                    }
                                    std::sort(moveMap.begin(), moveMap.end(), [](const std::pair<int, std::string> &left, const std::pair<int, std::string> &right) {
                                        return left.second < right.second;
                                    });

                                    moveMap.erase(moveMap.begin()); // Exclude the first part of sorted moveMap (None)

                                    uint32_t move = 0;
                                    if (*yokailist[selectedIndexes[index]].moves[currentMove] == 0) {
                                        mapSelection = 0;
                                    } else {
                                        for (int i = 0; i < moveMap.size(); i++) {
                                            if (moveMap[i].first == *yokailist[selectedIndexes[index]].moves[currentMove]) {
                                                mapSelection = i;
                                                break;
                                            }
                                        }
                                    }
                                    SwkbdInline kbdinline;
                                    swkbdInlineCreate(&kbdinline);
                                    swkbdInlineSetFinishedInitializeCallback(&kbdinline, NULL);
                                    swkbdInlineLaunchForLibraryApplet(&kbdinline, SwkbdInlineMode_AppletDisplay, 0);
                                    swkbdInlineSetChangedStringCallback(&kbdinline, callback);
                                    swkbdInlineSetDecidedEnterCallback(&kbdinline, enter);
                                    swkbdInlineSetDecidedCancelCallback(&kbdinline, cancel);
                                    SwkbdAppearArg appearArg;
                                    swkbdInlineMakeAppearArg(&appearArg, SwkbdType_All);
                                    
                                    activeKeyboard = false;

                                    while (appletMainLoop()) {
                                        padUpdate(&pad);
                                        swkbdInlineUpdate(&kbdinline, NULL);
                                        u64 kDown = padGetButtonsDown(&pad);
                                        if (!activeKeyboard) {
                                            if (moveMap.size() != 0) {
                                                inputHandling(mapSelection, kDown, moveMap.size());
                                            }
                                            if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus || kDown & HidNpadButton_B || kDown & HidNpadButton_A){
                                                if (moveMap.size() == 0) {
                                                    move = 0;
                                                    break;
                                                }
                                                move = moveMap[mapSelection].first;
                                                break;
                                            }
                                            if (kDown & HidNpadButton_Y) {
                                                move = 0;
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
                                        std::cout << "\x1b[1;1H\x1b[2JSelect a move (Y for none, X to toggle keyboard)";
                                        for (auto const& pair : moveMap) {
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
                                    *yokailist[selectedIndexes[index]].moves[currentMove] = move;
                                } else if (currentMove == 6) { //set all
                                    for (int selectedIndex : selectedIndexes) {
                                        // Apply the same moves to all selected yokai
                                        for (int i = 0; i < 6; i++) {
                                            *yokailist[selectedIndex].moves[i] = *yokailist[selectedIndexes[index]].moves[i];
                                        }
                                    }
                                }
                            }

                            if (kDown & HidNpadButton_L) {
                                index -= 1;
                                if (index < 0) {
                                    index = totalSelected - 1;
                                }
                            }
                            if (kDown & HidNpadButton_R) {
                                index += 1;
                                if (index >= totalSelected) {
                                    index = 0;
                                }
                            }

                            printf("\x1b[1;1H\x1b[2JEdit moves\n\n");
                            for (int i = 0; i < 6; i++) {
                                std::cout << (currentMove == i ? "> " : "  ") << i+1 << ": " << data4::moves.find(*yokailist[selectedIndexes[index]].moves[i])->second << std::endl;
                            }
                            printf("\n");
                            std::cout << (currentMove == 6 ? "> " : "  ") << "set all" << std::endl; //set all selected yokai to the same stats
                            
                            if (currentMove == 6) {
                                std::cout << "\nediting ALL" << std::endl;
                            } else {
                                std::cout << "\nediting " << index + 1 << "/" << totalSelected << std::endl; //index always starts at 0 now
                            }
                        }
                    } else if (currentEdit == 3) { //edit stats
                        //TODO
                    } else { //apply (and set max)
                        for (int i = 0; i < yokailist.size(); i++) {
                            if (selected[i]) {
                                *yokailist[i].hp = 1; //incase you lower the level
                                if (currentYokai != 0) {
                                    *yokailist[i].type = currentYokai;
                                }
                                if (currentLevel != 0) {
                                    *yokailist[i].level = currentLevel;
                                }
                                if (currentEdit == 4) {
                                    //TODO stats
                                }
                            }
                        }
                    }
                }
                //TODO stats etc
                std::cout << (currentEdit == 0 ? "> " : "  ") << "yokai: " << (currentYokai == 0 ? "" : data4::characters.at(currentYokai)) << std::endl;
                std::cout << (currentEdit == 1 ? "> " : "  ") << "level: " << (currentLevel == 0 ? "" : std::to_string(currentLevel)) << std::endl;
                printf("\n");
                std::cout << (currentEdit == 2 ? "> " : "  ") << "edit moves" << std::endl;
                std::cout << (currentEdit == 3 ? "> " : "  ") << "edit stats TODO" << std::endl;
                printf("\n");
                std::cout << (currentEdit == 4 ? "> " : "  ") << "apply and set max" << std::endl;
                std::cout << (currentEdit == 5 ? "> " : "  ") << "apply" << std::endl;
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
        char buffer[32];
        int end;

        int currentItem = 0;
        int currentAmount = 0;

        while (appletMainLoop()) {
            consoleUpdate(NULL);
            padUpdate(&pad);
            u64 kDown = padGetButtonsDown(&pad);

            if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus){
                break;
            }

            if (kDown & HidNpadButton_B) {
                if (selectPage) {
                    //if all false, break
                    if (!std::any_of(selected, selected + itemlist.size(), [](bool v) { return v; })) {
                        break;
                    } else {
                        //else, set all false
                        for (int i = 0; i < itemlist.size(); i++) {
                            selected[i] = false;
                        }
                    }
                } else {
                    selectPage = !selectPage;
                }
            }

            if (kDown & HidNpadButton_L || kDown & HidNpadButton_R) {
                selectPage = !selectPage;
            }

            if (selectPage) {
                if (kDown & HidNpadButton_Y) {
                    int hexSelection = 0;
                    int mode = 1;
                    while (appletMainLoop()) {
                        consoleUpdate(NULL);
                        padUpdate(&pad);
                        u64 kDown = padGetButtonsDown(&pad);

                        hexEdit(hexSelection, kDown, buffer, &mode, itemlist[currentSelection].data);
                        if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus || kDown & HidNpadButton_B || kDown & HidNpadButton_Y) {
                            break;
                        }
                        if (kDown & HidNpadButton_L) {
                            currentSelection -= 1;
                            if (currentSelection < 0) {
                                currentSelection = itemlist.size() - 1;
                            }
                        }
                        if (kDown & HidNpadButton_R) {
                            currentSelection += 1;
                            if (currentSelection >= itemlist.size()) {
                                currentSelection = 0;
                            }
                        }

                        std::cout << "\n\nIndex " << hexSelection << "/" << itemlist[currentSelection].data.size() << " of " << currentSelection+1 << "/" << itemlist.size() << " - " << mode << " byte mode.";
                    }
                }

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
                        keyboardInput(buffer, SwkbdType_NumPad, 3, "0-999", (currentAmount == 0 ? "999" : std::to_string(currentAmount).c_str()));
                        if (buffer[0] == '\0') {
                            currentAmount = 0;
                        } else { //criteria
                            if (std::stoi(buffer) > 999) {
                                currentAmount = 999;
                            } else {
                                currentAmount = std::stoi(buffer);
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
        char buffer[32];
        int end;

        int currentEquipment = 0;
        int currentAmount = 0;
        
        while (appletMainLoop()) {
            consoleUpdate(NULL);
            padUpdate(&pad);
            u64 kDown = padGetButtonsDown(&pad);
            
            if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus){
                break;
            }

            if (kDown & HidNpadButton_B) {
                if (selectPage) {
                    //if all false, break
                    if (!std::any_of(selected, selected + equipmentlist.size(), [](bool v) { return v; })) {
                        break;
                    } else {
                        //else, set all false
                        for (int i = 0; i < equipmentlist.size(); i++) {
                            selected[i] = false;
                        }
                    }
                } else {
                    selectPage = !selectPage;
                }
            }
            
            if (kDown & HidNpadButton_L || kDown & HidNpadButton_R) {
                selectPage = !selectPage;
            }
            
            if (selectPage) {
                if (kDown & HidNpadButton_Y) {
                    int hexSelection = 0;
                    int mode = 1;
                    while (appletMainLoop()) {
                        consoleUpdate(NULL);
                        padUpdate(&pad);
                        u64 kDown = padGetButtonsDown(&pad);

                        hexEdit(hexSelection, kDown, buffer, &mode, equipmentlist[currentSelection].data);
                        if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus || kDown & HidNpadButton_B || kDown & HidNpadButton_Y) {
                            break;
                        }
                        if (kDown & HidNpadButton_L) {
                            currentSelection -= 1;
                            if (currentSelection < 0) {
                                currentSelection = equipmentlist.size() - 1;
                            }
                        }
                        if (kDown & HidNpadButton_R) {
                            currentSelection += 1;
                            if (currentSelection >= equipmentlist.size()) {
                                currentSelection = 0;
                            }
                        }

                        std::cout << "\n\nIndex " << hexSelection << "/" << equipmentlist[currentSelection].data.size() << " of " << currentSelection+1 << "/" << equipmentlist.size() << " - " << mode << " byte mode.";
                    }
                }

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
                        keyboardInput(buffer, SwkbdType_NumPad, 3, "0-999", (currentAmount == 0 ? "999" : std::to_string(currentAmount).c_str()));
                        if (buffer[0] == '\0') {
                            currentAmount = 0;
                        } else { //criteria
                            if (std::stoi(buffer) > 999) {
                                currentAmount = 999;
                            } else {
                                currentAmount = std::stoi(buffer);
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
        char buffer[32];
        int end;

        int currentSoul = 0;
        int currentWhiteAmount = 0;
        int currentRedAmount = 0;
        int currentGoldAmount = 0;

        while (appletMainLoop()) {
            consoleUpdate(NULL);
            padUpdate(&pad);
            u64 kDown = padGetButtonsDown(&pad);

            if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus){
                break;
            }

            if (kDown & HidNpadButton_B) {
                if (selectPage) {
                    //if all false, break
                    if (!std::any_of(selected, selected + soullist.size(), [](bool v) { return v; })) {
                        break;
                    } else {
                        //else, set all false
                        for (int i = 0; i < soullist.size(); i++) {
                            selected[i] = false;
                        }
                    }
                } else {
                    selectPage = !selectPage;
                }
            }

            if (kDown & HidNpadButton_L || kDown & HidNpadButton_R) {
                selectPage = !selectPage;
            }

            if (selectPage) {
                if (kDown & HidNpadButton_Y) {
                    int hexSelection = 0;
                    int mode = 1;
                    while (appletMainLoop()) {
                        consoleUpdate(NULL);
                        padUpdate(&pad);
                        u64 kDown = padGetButtonsDown(&pad);

                        hexEdit(hexSelection, kDown, buffer, &mode, soullist[currentSelection].data);
                        if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus || kDown & HidNpadButton_B || kDown & HidNpadButton_Y) {
                            break;
                        }
                        if (kDown & HidNpadButton_L) {
                            currentSelection -= 1;
                            if (currentSelection < 0) {
                                currentSelection = soullist.size() - 1;
                            }
                        }
                        if (kDown & HidNpadButton_R) {
                            currentSelection += 1;
                            if (currentSelection >= soullist.size()) {
                                currentSelection = 0;
                            }
                        }

                        std::cout << "\n\nIndex " << hexSelection << "/" << soullist[currentSelection].data.size() << " of " << currentSelection+1 << "/" << soullist.size() << " - " << mode << " byte mode.";
                    }
                }

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
                        keyboardInput(buffer, SwkbdType_NumPad, 3, "0-999", (currentWhiteAmount == 0 ? "999" : std::to_string(currentWhiteAmount).c_str()));
                        if (buffer[0] == '\0') {
                            currentWhiteAmount = 0;
                        } else { //criteria
                            if (std::stoi(buffer) > 999) {
                                currentWhiteAmount = 999;
                            } else {
                                currentWhiteAmount = std::stoi(buffer);
                            }
                        }
                    } else if (currentEdit == 2) { //red amount
                        keyboardInput(buffer, SwkbdType_NumPad, 3, "0-999", (currentRedAmount == 0 ? "999" : std::to_string(currentRedAmount).c_str()));
                        if (buffer[0] == '\0') {
                            currentRedAmount = 0;
                        } else { //criteria
                            if (std::stoi(buffer) > 999) {
                                currentRedAmount = 999;
                            } else {
                                currentRedAmount = std::stoi(buffer);
                            }
                        }
                    } else if (currentEdit == 3) { //gold amount
                        keyboardInput(buffer, SwkbdType_NumPad, 3, "0-999", (currentGoldAmount == 0 ? "999" : std::to_string(currentGoldAmount).c_str()));
                        if (buffer[0] == '\0') {
                            currentGoldAmount = 0;
                        } else { //criteria
                            if (std::stoi(buffer) > 999) {
                                currentGoldAmount = 999;
                            } else {
                                currentGoldAmount = std::stoi(buffer);
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
        char buffer[32];
        int end;

        int currentSpecial = 0;
        int currentAmount = 0;

        while (appletMainLoop()) {
            consoleUpdate(NULL);
            padUpdate(&pad);
            u64 kDown = padGetButtonsDown(&pad);

            if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus){
                break;
            }

            if (kDown & HidNpadButton_L || kDown & HidNpadButton_R) {
                selectPage = !selectPage;
            }

            if (kDown & HidNpadButton_B) {
                if (selectPage) {
                    //if all false, break
                    if (!std::any_of(selected, selected + speciallist.size(), [](bool v) { return v; })) {
                        break;
                    } else {
                        //else, set all false
                        for (int i = 0; i < speciallist.size(); i++) {
                            selected[i] = false;
                        }
                    }
                } else {
                    selectPage = !selectPage;
                }
            }

            if (selectPage) {
                if (kDown & HidNpadButton_Y) {
                    int hexSelection = 0;
                    int mode = 1;
                    while (appletMainLoop()) {
                        consoleUpdate(NULL);
                        padUpdate(&pad);
                        u64 kDown = padGetButtonsDown(&pad);

                        hexEdit(hexSelection, kDown, buffer, &mode, speciallist[currentSelection].data);
                        if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus || kDown & HidNpadButton_B || kDown & HidNpadButton_Y) {
                            break;
                        }
                        if (kDown & HidNpadButton_L) {
                            currentSelection -= 1;
                            if (currentSelection < 0) {
                                currentSelection = speciallist.size() - 1;
                            }
                        }
                        if (kDown & HidNpadButton_R) {
                            currentSelection += 1;
                            if (currentSelection >= speciallist.size()) {
                                currentSelection = 0;
                            }
                        }

                        std::cout << "\n\nIndex " << hexSelection << "/" << speciallist[currentSelection].data.size() << " of " << currentSelection+1 << "/" << speciallist.size() << " - " << mode << " byte mode.";
                    }
                }

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
                        keyboardInput(buffer, SwkbdType_NumPad, 3, "0-999", (currentAmount == 0 ? "999" : std::to_string(currentAmount).c_str()));
                        if (buffer[0] == '\0') {
                            currentAmount = 0;
                        } else { //criteria
                            if (std::stoi(buffer) > 999) {
                                currentAmount = 999;
                            } else {
                                currentAmount = std::stoi(buffer);
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

    void edit_misc(uint32_t* x, uint32_t* y, uint32_t* z, uint32_t* location, uint32_t* money, char* nate, char* katie, char* summer, char* cole, char* bruno, char* jack, std::vector<struct4::Yokai> &yokailist, uint8_t* gatcharemaining, uint8_t* gatchamax, PadState pad) {
        sortedMap.clear();
        for (auto const& pair : data4::locations) {
            sortedMap.push_back(pair);
        }
        std::sort(sortedMap.begin(), sortedMap.end(), [](const std::pair<int, std::string> &left, const std::pair<int, std::string> &right) {
            return left.second < right.second;
        });
        filteredMap = sortedMap;

        char* names[] = {nate, katie, summer, cole, bruno, jack};
        int currentSelection = 0;
        int currentEdit = 0;
        char buffer[36];
        int end;
        int offset = 0;

        int currentLocation = 0;

        while (appletMainLoop()) {
            consoleUpdate(NULL);
            padUpdate(&pad);
            u64 kDown = padGetButtonsDown(&pad);

            if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus || kDown & HidNpadButton_B){
                break;
            }

            inputHandling(currentEdit, kDown, 4);
            if (kDown & HidNpadButton_A) {
                if (currentEdit == 0) { //nicknames
                    while (appletMainLoop()) {
                        consoleUpdate(NULL);
                        padUpdate(&pad);
                        u64 kDown = padGetButtonsDown(&pad);

                        if (kDown & HidNpadButton_Plus || kDown & HidNpadButton_Minus || kDown & HidNpadButton_B){
                            break;
                        }
                        inputHandling(currentSelection, kDown, 7+yokailist.size());
                        if (kDown & HidNpadButton_A) {
                            if (currentSelection == 0) {
                                strcpy(nate, "Nate");
                                strcpy(katie, "Katie");
                                strcpy(summer, "Summer");
                                strcpy(cole, "Cole");
                                strcpy(bruno, "Bruno");
                                strcpy(jack, "Jack");
                                for (int i = 0; i < yokailist.size(); i++) {
                                    strcpy(yokailist[i].nickname, "");
                                }
                            } else if (currentSelection > 0 && currentSelection < 7) {
                                keyboardInput(buffer, SwkbdType_All, 36, "enter a nickname", names[currentSelection-1]);
                                if (buffer[0] != '\0') {
                                    strcpy(names[currentSelection-1], buffer);
                                }
                            } else {
                                keyboardInput(buffer, SwkbdType_All, 36, "enter a nickname", yokailist[currentSelection-7].nickname);
                                if (buffer[0] != '\0') {
                                    strcpy(yokailist[currentSelection-7].nickname, buffer);
                                }
                            }
                        } else if (kDown & HidNpadButton_X) { //clear
                            if (currentSelection != 0) {
                                if (currentSelection < 7) {
                                    switch (currentSelection) {
                                        case 1:
                                            strcpy(nate, "Nate");
                                            break;
                                        case 2:
                                            strcpy(katie, "Katie");
                                            break;
                                        case 3:
                                            strcpy(summer, "Summer");
                                            break;
                                        case 4:
                                            strcpy(cole, "Cole");
                                            break;
                                        case 5:
                                            strcpy(bruno, "Bruno");
                                            break;
                                        case 6:
                                            strcpy(jack, "Jack");
                                            break;
                                        default:
                                            printf("something went wrong with your switch-case :(");
                                            pause(pad);
                                            break;
                                    }
                                } else {
                                    strcpy(yokailist[currentSelection-7].nickname, "");
                                }
                            }
                        } else if (kDown & HidNpadButton_Y) { //swap width
                            if (currentSelection != 0) {
                                if (currentSelection < 7) {
                                    strcpy(names[currentSelection-1], converter.to_bytes(convert_width(converter.from_bytes(names[currentSelection-1]))).substr(0, 33).c_str()); //TODO fix substring logic
                                } else {
                                    strcpy(yokailist[currentSelection-7].nickname, converter.to_bytes(convert_width(converter.from_bytes(yokailist[currentSelection-7].nickname))).substr(0, 33).c_str());
                                }
                            }
                        }
                        printf("\x1b[1;1H\x1b[2JSelect an option: (Y to swap width, X to clear. Japanese is scrambled)");
                        if (currentSelection < 42) { //45 - 3 dead lines
                            offset = 0;
                            printf("\n");
                            std::cout << (currentSelection == 0 ? "> " : "  ") << "clear all" << std::endl;
                            printf("\n");
                            std::cout << (currentSelection == 1 ? "> " : "  ") << "Nate: " << nate << std::endl; //could change these to the character types
                            std::cout << (currentSelection == 2 ? "> " : "  ") << "Katie: " << katie << std::endl;
                            std::cout << (currentSelection == 3 ? "> " : "  ") << "Summer: " << summer << std::endl;
                            std::cout << (currentSelection == 4 ? "> " : "  ") << "Cole: " << cole << std::endl;
                            std::cout << (currentSelection == 5 ? "> " : "  ") << "Bruno: " << bruno << std::endl;
                            std::cout << (currentSelection == 6 ? "> " : "  ") << "Jack: " << jack << std::endl;
                        } else {
                            offset = 7;
                        }
                        end = (currentSelection-offset)/44*44+44;
                        if (end > yokailist.size()) {
                            end = yokailist.size();
                        }
                        for (int i = (currentSelection-offset)/44*44; i < end; i++) {
                            if (i > 34 && currentSelection < 42) { //first page has extra options
                                break;
                            }
                            auto it = data4::characters.find(*yokailist[i].type);
                            if (it != data4::characters.end()) {
                                std::string nickname = yokailist[i].nickname;
                                std::replace(nickname.begin(), nickname.end(), '\n', 'n');
                                std::cout << "\n" << (currentSelection == i+7 ? "> " : "  ") << it->second << ":" << std::string(31 - it->second.size(), ' ') << nickname;
                            } else {
                                std::string nickname = yokailist[i].nickname;
                                std::replace(nickname.begin(), nickname.end(), '\n', 'n');
                                std::cout << "\n" << (currentSelection == i+7 ? "> " : "  ") << *yokailist[i].type << " TODO:" << std::string(26 - std::to_string(*yokailist[i].type).size(), ' ') << nickname;
                            }
                        }
                    }
                } else if (currentEdit == 1) { //location
                    mapInput(pad, currentLocation, "location (TODO)");
                    padUpdate(&pad);
                    //TODO set location and x, y, z
                } else if (currentEdit == 2) { //crank-a-kai
                    keyboardInput(buffer, SwkbdType_NumPad, 2, "0-99", (*gatcharemaining == 0 ? "99" : std::to_string(*gatcharemaining).c_str())); //could use gatchamax
                    if (buffer[0] != '\0') {
                        if (std::stoi(buffer) > 99) {
                            *gatchamax = 99;
                            *gatcharemaining = 99;
                        } else {
                            *gatchamax = std::stoi(buffer);
                            *gatcharemaining = std::stoi(buffer);
                        }
                    }
                } else if (currentEdit == 3) { //money
                    keyboardInput(buffer, SwkbdType_NumPad, 7, "0-9999999", (*money == 0 ? "9999999" : std::to_string(*money).c_str())); //TODO test max again
                    if (buffer[0] != '\0') {
                        if (std::stoi(buffer) > 9999999) {
                            *money = 9999999;
                        } else {
                            *money = std::stoi(buffer);
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