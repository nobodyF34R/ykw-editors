#ifndef STRUCT_H
#define STRUCT_H

#include <iostream>


struct struct1s {
    struct Head { //TODO

        Head(std::vector<uint8_t>& decryptedData, int16_t offset) {
        }
    };

    struct Yokai {
        uint16_t* num1;
        uint16_t* num2;
        uint32_t* yokai;
        char* nickname; //wide char
        uint8_t* attack;
        uint8_t* technique;
        uint8_t* soultimate;
        uint32_t* xp;
        uint16_t* hp;
        uint8_t* soul;
        struct {
            uint8_t* tiv_hp;
            uint8_t* tiv_str;
            uint8_t* tiv_spr;
            uint8_t* tiv_def;
            uint8_t* tiv_spd;
            uint8_t* iv21_hp; // TODO nibbles
            uint8_t* iv21_str;
            uint8_t* iv21_spr;
            uint8_t* iv21_def;
            uint8_t* iv21_spd;
            uint8_t* ev_hp;
            uint8_t* ev_str;
            uint8_t* ev_spr;
            uint8_t* ev_def;
            uint8_t* ev_spd;
        } stats;
        uint8_t* level;
        uint8_t* attitude;
        // TODO: Add fields for "loaf level," "held item," and "affection"

        // Construct given decryptedData and offset
        Yokai(std::vector<uint8_t>& decryptedData, int16_t offset) {
            num1 = (uint16_t*)(&decryptedData[offset]);
            num2 = (uint16_t*)(&decryptedData[offset+2]);
            yokai = (uint32_t*)(&decryptedData[offset+4]);
            nickname = (char*)(&decryptedData[offset + 8]);
            attack = &decryptedData[offset+78];
            technique = &decryptedData[offset+82];
            soultimate = &decryptedData[offset+86];
            xp = (uint32_t*)(&decryptedData[offset+88]);
            hp = (uint16_t*)(&decryptedData[offset+92]);
            soul = &decryptedData[offset+94];
            stats.tiv_hp = &decryptedData[offset+96];
            stats.tiv_str = &decryptedData[offset+97];
            stats.tiv_spr = &decryptedData[offset+98];
            stats.tiv_def = &decryptedData[offset+99];
            stats.tiv_spd = &decryptedData[offset+100];
            stats.iv21_hp = &decryptedData[offset+101];
            stats.iv21_str = &decryptedData[offset+102];
            stats.iv21_spr = &decryptedData[offset+103];
            stats.iv21_def = &decryptedData[offset+104];
            stats.iv21_spd = &decryptedData[offset+105];
            stats.ev_hp = &decryptedData[offset+106];
            stats.ev_str = &decryptedData[offset+107];
            stats.ev_spr = &decryptedData[offset+108];
            stats.ev_def = &decryptedData[offset+109];
            stats.ev_spd = &decryptedData[offset+110];
            level = &decryptedData[offset+116];
            attitude = &decryptedData[offset+117];
        }
    };

    struct Item {
        uint16_t* num1;
        uint16_t* num2;
        uint32_t* item;
        uint8_t* amount;

        Item(std::vector<uint8_t>& decryptedData, int16_t offset) {
            num1 = (uint16_t*)(&decryptedData[offset]);
            num2 = (uint16_t*)(&decryptedData[offset+2]);
            item = (uint32_t*)(&decryptedData[offset+4]);
            amount = &decryptedData[offset+8];
        }
    };

    struct Equipment {
        uint16_t* num1;
        uint16_t* num2;
        uint32_t* equipment;
        uint32_t* amount;

        Equipment(std::vector<uint8_t>& decryptedData, int16_t offset) {
            num1 = (uint16_t*)(&decryptedData[offset]);
            num2 = (uint16_t*)(&decryptedData[offset+2]);
            equipment = (uint32_t*)(&decryptedData[offset+4]);
            amount = (uint32_t*)(&decryptedData[offset+8]);
        }
    };


    struct Important{
        uint16_t* num1;
        uint16_t* num2;
        uint32_t* important;

        Important(std::vector<uint8_t>& decryptedData, int16_t offset) {
            num1 = (uint16_t*)(&decryptedData[offset]);
            num2 = (uint16_t*)(&decryptedData[offset+2]);
            important = (uint32_t*)(&decryptedData[offset+4]);
        }
    };
};


struct struct4 { 
    struct Yokai {
        uint16_t* num1;
        uint16_t* num2;
        // char* nickname; //wide char
        uint32_t* yokai;
        uint32_t* skill1;
        uint32_t* skill2;
        uint32_t* skill3;
        uint32_t* skill4;
        uint32_t* skill5;
        uint32_t* skill6;
        uint32_t* xp;
        uint32_t* hp;
        uint32_t* yp;
        uint32_t* pg;
        uint32_t* level;
        uint16_t* flag1;
        struct {
            uint16_t* hp_plus;
            uint16_t* yp_plus;
            uint16_t* st_plus;
            uint16_t* sp_plus;
            uint16_t* pa_plus;
            uint16_t* sa_plus;
            uint8_t* iv_hp;
            uint8_t* iv_str;
            uint8_t* iv_spr;
            uint8_t* iv_def;
            uint8_t* iv_spd;
            uint8_t* ev_hp;
            uint8_t* ev_str;
            uint8_t* ev_spr;
            uint8_t* ev_def;
            uint8_t* ev_spd;
        } stats;
        uint8_t* order;

        // Construct given decryptedData and offset
        Yokai(std::vector<uint8_t>& decryptedData, int32_t offset) {
            num1 = (uint16_t*)(&decryptedData[offset]);
            num2 = (uint16_t*)(&decryptedData[offset+2]);
            // nickname = (char*)(&decryptedData[offset+8]);
            yokai = (uint32_t*)(&decryptedData[offset+72]);
            skill1 = (uint32_t*)(&decryptedData[offset+84]);
            skill2 = (uint32_t*)(&decryptedData[offset+88]);
            skill3 = (uint32_t*)(&decryptedData[offset+92]);
            skill4 = (uint32_t*)(&decryptedData[offset+96]);
            skill5 = (uint32_t*)(&decryptedData[offset+100]);
            skill6 = (uint32_t*)(&decryptedData[offset+104]);
            xp = (uint32_t*)(&decryptedData[offset+132]);
            hp = (uint32_t*)(&decryptedData[offset+144]);
            yp = (uint32_t*)(&decryptedData[offset+156]);
            pg = (uint32_t*)(&decryptedData[offset+168]);
            level = (uint32_t*)(&decryptedData[offset+180]);
            flag1 = (uint16_t*)(&decryptedData[offset+204]);
            stats.hp_plus = (uint16_t*)(&decryptedData[offset+214]);
            stats.yp_plus = (uint16_t*)(&decryptedData[offset+216]);
            stats.st_plus = (uint16_t*)(&decryptedData[offset+218]);
            stats.sp_plus = (uint16_t*)(&decryptedData[offset+220]);
            stats.pa_plus = (uint16_t*)(&decryptedData[offset+222]);
            stats.sa_plus = (uint16_t*)(&decryptedData[offset+224]);
            stats.iv_hp = &decryptedData[offset+254];
            stats.iv_str = &decryptedData[offset+255];
            stats.iv_spr = &decryptedData[offset+256];
            stats.iv_def = &decryptedData[offset+257];
            stats.iv_spd = &decryptedData[offset+258];
            order = &decryptedData[offset+330];
        }
    };

    struct Item {
        uint16_t* num1;
        uint16_t* num2;
        uint32_t* item;
        uint32_t* order;
        uint32_t* amount;

        Item(std::vector<uint8_t>& decryptedData, int32_t offset) {
            num1 = (uint16_t*)(&decryptedData[offset]);
            num2 = (uint16_t*)(&decryptedData[offset+2]);
            item = (uint32_t*)(&decryptedData[offset+12]);
            order = (uint32_t*)(&decryptedData[offset+24]);
            amount = (uint32_t*)(&decryptedData[offset+36]);
        }
    };

    struct SpecialSoul {
        uint16_t* num1;
        uint16_t* num2;
        uint32_t* soul;
        uint32_t* order;
        uint32_t* amount;

        SpecialSoul(std::vector<uint8_t>& decryptedData, int32_t offset) {
            num1 = (uint16_t*)(&decryptedData[offset]);
            num2 = (uint16_t*)(&decryptedData[offset+2]);
            soul = (uint32_t*)(&decryptedData[offset+12]);
            order = (uint32_t*)(&decryptedData[offset+24]);
            amount = (uint32_t*)(&decryptedData[offset+36]);
        }
    };

    struct YokaiSoul {
        uint16_t* num1;
        uint16_t* num2;
        uint32_t* soul;
        uint32_t* order;
        uint32_t* white;
        uint32_t* red;
        uint32_t* gold;
        uint8_t* flags;

        YokaiSoul(std::vector<uint8_t>& decryptedData, int32_t offset) {
            num1 = (uint16_t*)(&decryptedData[offset]);
            num2 = (uint16_t*)(&decryptedData[offset+2]);
            soul = (uint32_t*)(&decryptedData[offset+12]);
            order = (uint32_t*)(&decryptedData[offset+24]);
            white = (uint32_t*)(&decryptedData[offset+36]);
            red = (uint32_t*)(&decryptedData[offset+38]);
            gold = (uint32_t*)(&decryptedData[offset+40]);
            flags = &decryptedData[offset+50];
        }
    };

    struct Equipment {
        uint16_t* num1;
        uint16_t* num2;
        uint32_t* equipment;
        uint32_t* order;
        uint32_t* amount;
        uint32_t* used;

        Equipment(std::vector<uint8_t>& decryptedData, int32_t offset) {
            num1 = (uint16_t*)(&decryptedData[offset]);
            num2 = (uint16_t*)(&decryptedData[offset+2]);
            equipment = (uint32_t*)(&decryptedData[offset+12]);
            order = (uint32_t*)(&decryptedData[offset+24]);
            amount = (uint32_t*)(&decryptedData[offset+36]);
            used = (uint32_t*)(&decryptedData[offset+46]);
        }
    };
};

#endif // STRUCT_H