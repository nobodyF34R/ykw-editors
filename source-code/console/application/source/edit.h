#ifndef EDIT_H
#define EDIT_H

#include "struct.h"
#include "draw.h"

void pausing() {
	while (aptMainLoop()) {
		hidScanInput();
		u32 kDown = hidKeysDown();
		if (kDown) break;
	}
}

void inputHandling(int& currentSelection, u32 kDown, int listSize) {
    if (kDown & KEY_UP) {
        currentSelection--;
        if (currentSelection < 0) {
            currentSelection = listSize - 1;
        }
    }
    if (kDown & KEY_DOWN) {
        currentSelection++;
        if (currentSelection >= listSize) {
            currentSelection = 0;
        }
    }
    if (kDown & KEY_LEFT) {
        currentSelection -= 29;
        if (currentSelection < 0) {
            currentSelection = 0;
        }
    }
    if (kDown & KEY_RIGHT) {
        currentSelection += 29;
        if (currentSelection >= listSize) {
            currentSelection = listSize - 1;
        }
    }
}

namespace edit1 {
    void edit_yokai(std::vector<struct1::Yokai> &yokailist) {
        std::vector<std::pair<int, std::string>> sortedMap;
        for (auto const& pair : data1::yokais) {
            sortedMap.push_back(pair);
        }
        std::sort(sortedMap.begin(), sortedMap.end(), [](const std::pair<int, std::string> &left, const std::pair<int, std::string> &right) {
            return left.second < right.second;
        });

        int selection = 0;
        int currentSelection = 0;
        int listSize = yokailist.size();

        consoleInit(GFX_TOP, NULL);

        C3D_RenderTarget *target = C2D_CreateScreenTarget(GFX_BOTTOM, GFX_LEFT);
        C2D_Image image = get_image("romfs:/pandle.rgba", 128, 128);
        float x = 0;
        float y = 0;
        int bounceX = 1;
        int bounceY = 1;

        printf("\nStart (M) to exit");
	    while (aptMainLoop()){
            C3D_FrameBegin(C3D_FRAME_SYNCDRAW);
            C2D_SceneBegin(target);
            C2D_TargetClear(target, C2D_Color32(0x0, 0x0, 0x0, 0x0));

            C2D_DrawImageAt(image, x, y, 0., NULL, 1., 1.);
            x += bounceX;
            y += bounceY;

            if (x + 192 >= 400) {
                bounceX = -1;
            }
            if (x <= 0) {
                bounceX = 1;
            }

            if (y + 128 >= 240) {
                bounceY = -1;
            }
            if (y <= 0) {
                bounceY = 1;
            }

            C3D_FrameEnd(0);
            gspWaitForVBlank();
            // gfxSwapBuffers();
            hidScanInput();

            u32 kDown = hidKeysDown();
            inputHandling(currentSelection, kDown, listSize);

            printf("\x1b[1;1H\x1b[2JSelect a yokai:");
            
            for (int i = 0; i < listSize; i++) {
                if (i/29 == currentSelection/29) {
                    std::cout << "\n" << (i == currentSelection ? "> " : "  ") << data1::yokais.at(*yokailist[i].type);
                }		
                if (i == currentSelection + 29) {
                    break;
                }	
            }

            if (kDown & KEY_A) {
                while (aptMainLoop()){
                    gspWaitForVBlank();
                    gfxSwapBuffers();
                    hidScanInput();

                    u32 kDown = hidKeysDown();
                    inputHandling(selection, kDown, data1::yokais.size());

                    std::cout << "\x1b[1;1H\x1b[2JWhat would you like to replace " << data1::yokais.at(*yokailist[currentSelection].type) << " with?";
                    
                    int i = 0;
                    for (auto const& pair : sortedMap) {
                        if (i/29 == selection/29) {
                            std::cout << "\n" << (i == selection ? "> " : "  ") << pair.second;
                        }
                        if (i == selection + 29) {
                            break;
                        }
                        i++;
                    }

                    if (kDown & KEY_A) {
                        *yokailist[currentSelection].type = sortedMap[selection].first;
                        break;
                    }

                    if (kDown & KEY_START || kDown & KEY_B)
                        break;
                }
            }

            if (kDown & KEY_START || kDown & KEY_B)
                break;
        }
    }
}

#endif // EDIT_H