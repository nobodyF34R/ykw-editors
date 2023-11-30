#ifndef EDIT_H
#define EDIT_H

#include <switch.h>
#include "struct.h"
#include <vector>
#include <cstdint>

int selectInput(bool* selected, int& currentSelection, u64 kDown, int listSize) {
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

namespace edit1s {
    void edit_yokai(std::vector<struct1s::Yokai> &yokailist, PadState pad) {
        bool selected[yokailist.size()];
        for (int i = 0; i < yokailist.size(); i++) {
            selected[i] = false;
        }
        int currentSelection = 0;
        int currentEdit = 0;
        bool selectPage = true;
        int end;

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
                end = selectInput(selected, currentSelection, kDown, yokailist.size());
                for (int i = currentSelection/44*44; i < end; i++) {
                    std::cout << "\n" << (selected[i] ? "> " : "  ") << data1s::yokais.at(*yokailist[i].id) << (currentSelection == i ? " <<<" : "");
                }
            } else { //edit page
                //TODO
            }

            consoleUpdate(NULL);
        }
    }

    void edit_item(std::vector<struct1s::Item> &itemlist, PadState pad) {
        bool selected[itemlist.size()];
        for (int i = 0; i < itemlist.size(); i++) {
            selected[i] = false;
        }
        int currentSelection = 0;
        int currentEdit = 0;
        bool selectPage = true;
        int end;

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
                end = selectInput(selected, currentSelection, kDown, itemlist.size());
                for (int i = currentSelection/44*44; i < end; i++) {
                    std::cout << "\n" << (selected[i] ? "> " : "  ") << data1s::items.at(*itemlist[i].id) << (currentSelection == i ? " <<<" : "");
                }
            } else { //edit page
                //TODO
            }

            consoleUpdate(NULL);
        }
    }

    void edit_equipment(std::vector<struct1s::Equipment> &equipmentlist, PadState pad) {
        bool selected[equipmentlist.size()];
        for (int i = 0; i < equipmentlist.size(); i++) {
            selected[i] = false;
        }
        int currentSelection = 0;
        int currentEdit = 0;
        bool selectPage = true;
        int end;

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
                end = selectInput(selected, currentSelection, kDown, equipmentlist.size());
                for (int i = currentSelection/44*44; i < end; i++) {
                    std::cout << "\n" << (selected[i] ? "> " : "  ") << data1s::equipments.at(*equipmentlist[i].id) << (currentSelection == i ? " <<<" : "");
                }
            } else { //edit page
                //TODO
            }

            consoleUpdate(NULL);
        }
    }

    void edit_important(std::vector<struct1s::Important> &importantlist, PadState pad) {
        bool selected[importantlist.size()];
        for (int i = 0; i < importantlist.size(); i++) {
            selected[i] = false;
        }
        int currentSelection = 0;
        int currentEdit = 0;
        bool selectPage = true;
        int end;

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
                end = selectInput(selected, currentSelection, kDown, importantlist.size());
                for (int i = currentSelection/44*44; i < end; i++) {
                    std::cout << "\n" << (selected[i] ? "> " : "  ") << data1s::importants.at(*importantlist[i].id) << (currentSelection == i ? " <<<" : "");
                }
            } else { //edit page
                //TODO
            }

            consoleUpdate(NULL);
        }
    }

    void edit_misc(uint32_t* x, uint32_t* y, uint32_t* z, uint64_t* location, uint16_t* time, uint8_t* sun, uint32_t* money, PadState pad) {
        return; //TODO
    }
};

namespace edit4 {
    void edit_character(std::vector<struct4::Yokai> &characterlist, PadState pad) {
        bool selected[characterlist.size()];
        for (int i = 0; i < characterlist.size(); i++) {
            selected[i] = false;
        }
        int currentSelection = 0;
        int currentEdit = 0;
        bool selectPage = true;
        int end;
        
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
                end = selectInput(selected, currentSelection, kDown, characterlist.size());
                for (int i = currentSelection/44*44; i < end; i++) {
                    auto it = data4::characters.find(*characterlist[i].id);
                    if (it != data4::characters.end()) {
                        std::cout << "\n" << (selected[i] ? "> " : "  ") << it->second << (currentSelection == i ? " <<<" : "");
                    } else {
                        std::cout << "\n" << (selected[i] ? "> " : "  ") << *characterlist[i].id << " TODO" << (currentSelection == i ? " <<<" : "");
                    }
                }
            } else { //edit page
                //TODO
            }
            
            consoleUpdate(NULL);
        }
    }
    
    void edit_yokai(std::vector<struct4::Yokai> &yokailist, PadState pad) {
        bool selected[yokailist.size()];
        for (int i = 0; i < yokailist.size(); i++) {
            selected[i] = false;
        }
        int currentSelection = 0;
        int currentEdit = 0;
        bool selectPage = true;
        int end;

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
                end = selectInput(selected, currentSelection, kDown, yokailist.size());
                for (int i = currentSelection/44*44; i < end; i++) {
                    auto it = data4::yokais.find(*yokailist[i].id);
                    if (it != data4::yokais.end()) {                                                                                 //     if (i/44 == selectedYokai/44) {
                        std::cout << "\n" << (selected[i] ? "> " : "  ") << it->second << (currentSelection == i ? " <<<" : "");
                    } else {
                        std::cout << "\n" << (selected[i] ? "> " : "  ") << *yokailist[i].id << " TODO" << (currentSelection == i ? " <<<" : "");
                    }
                }
            } else { //edit page
                //TODO
            }

            consoleUpdate(NULL);
        }
    }

    void edit_item(std::vector<struct4::Item> &itemlist, PadState pad) {
        bool selected[itemlist.size()];
        for (int i = 0; i < itemlist.size(); i++) {
            selected[i] = false;
        }
        int currentSelection = 0;
        int currentEdit = 0;
        bool selectPage = true;
        int end;

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
                end = selectInput(selected, currentSelection, kDown, itemlist.size());
                for (int i = currentSelection/44*44; i < end; i++) {
                    auto it = data4::items.find(*itemlist[i].id);
                    if (it != data4::items.end()) {
                        std::cout << "\n" << (selected[i] ? "> " : "  ") << it->second << (currentSelection == i ? " <<<" : "");
                    } else {
                        std::cout << "\n" << (selected[i] ? "> " : "  ") << *itemlist[i].id << " TODO" << (currentSelection == i ? " <<<" : "");
                    }
                }
            } else { //edit page
                //TODO
            }

            consoleUpdate(NULL);
        }
    }

    void edit_equipment(std::vector<struct4::Equipment> &equipmentlist, PadState pad) {
        bool selected[equipmentlist.size()];
        for (int i = 0; i < equipmentlist.size(); i++) {
            selected[i] = false;
        }
        int currentSelection = 0;
        int currentEdit = 0;
        bool selectPage = true;
        int end;
        
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
                end = selectInput(selected, currentSelection, kDown, equipmentlist.size());
                for (int i = currentSelection/44*44; i < end; i++) {
                    auto it = data4::equipments.find(*equipmentlist[i].id);
                    if (it != data4::equipments.end()) {
                        std::cout << "\n" << (selected[i] ? "> " : "  ") << it->second << (currentSelection == i ? " <<<" : "");
                    } else {
                        std::cout << "\n" << (selected[i] ? "> " : "  ") << *equipmentlist[i].id << " TODO" << (currentSelection == i ? " <<<" : "");
                    }
                }
            } else { //edit page
                //TODO
            }
            
            consoleUpdate(NULL);
        }
    }

    void edit_special_soul(std::vector<struct4::SpecialSoul> &specialsoullist, PadState pad) {
        bool selected[specialsoullist.size()];
        for (int i = 0; i < specialsoullist.size(); i++) {
            selected[i] = false;
        }
        int currentSelection = 0;
        int currentEdit = 0;
        bool selectPage = true;
        int end;

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
                end = selectInput(selected, currentSelection, kDown, specialsoullist.size());
                for (int i = currentSelection/44*44; i < end; i++) {
                    std::cout << "\n" << (selected[i] ? "> " : "  ") << *specialsoullist[i].id << " TODO" << (currentSelection == i ? " <<<" : "");
                }
            } else { //edit page
                //TODO
            }

            consoleUpdate(NULL);
        }
    }

    void edit_yokai_soul(std::vector<struct4::YokaiSoul> &yokaisoullist, PadState pad) {
        bool selected[yokaisoullist.size()];
        for (int i = 0; i < yokaisoullist.size(); i++) {
            selected[i] = false;
        }
        int currentSelection = 0;
        int currentEdit = 0;
        bool selectPage = true;
        int end;

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
                end = selectInput(selected, currentSelection, kDown, yokaisoullist.size());
                for (int i = currentSelection/44*44; i < end; i++) {
                    std::cout << "\n" << (selected[i] ? "> " : "  ") << *yokaisoullist[i].id << " TODO" << (currentSelection == i ? " <<<" : "");
                }
            } else { //edit page
                //TODO
            }

            consoleUpdate(NULL);
        }
    }
    
    void edit_misc(uint32_t* x, uint32_t* y, uint32_t* z, uint32_t* location, uint32_t* money, char* nate, char* katie, char* summer, char* cole, char* bruno, char* jack, uint8_t* gatcharemaining, uint8_t* gatchamax, PadState pad) {
        return; //TODO
    }
};

#endif // EDIT_H