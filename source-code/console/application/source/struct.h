#ifndef STRUCT_H
#define STRUCT_H

struct struct1 {
    struct Head { //TODO

        Head(std::vector<uint8_t>& decryptedData, int16_t offset) {
        }
    };

    struct Yokai {
        std::vector<uint8_t*> data;
        uint16_t* num1;
        uint16_t* num2;
        uint32_t* type;
        // char* nickname; //utf-8 string
        // uint8_t* attack;
        // uint8_t* technique;
        // uint8_t* soultimate;
        // uint32_t* xp;
        // uint16_t* hp;
        // uint8_t* soul;
        // struct {
        //     uint8_t* tiv_hp;
        //     uint8_t* tiv_str;
        //     uint8_t* tiv_spr;
        //     uint8_t* tiv_def;
        //     uint8_t* tiv_spd;
        //     uint8_t* iv21_hp; // TODO nibbles
        //     uint8_t* iv21_str;
        //     uint8_t* iv21_spr;
        //     uint8_t* iv21_def;
        //     uint8_t* iv21_spd;
        //     uint8_t* ev_hp;
        //     uint8_t* ev_str;
        //     uint8_t* ev_spr;
        //     uint8_t* ev_def;
        //     uint8_t* ev_spd;
        // } stats;
        // uint8_t* level;
        // uint8_t* attitude;
        // TODO: Add fields for "loaf level," "held item," and "affection"

        // Construct given decryptedData and offset
        Yokai(std::vector<uint8_t>& decryptedData, int16_t offset) {
            for(int i=0;i<124;i++)data.push_back(&decryptedData[offset+i]);
            num1 = (uint16_t*)(&decryptedData[offset]);
            num2 = (uint16_t*)(&decryptedData[offset+2]);
            type = (uint32_t*)(&decryptedData[offset+4]);
            // nickname = (char*)(&decryptedData[offset + 8]); //may need to have jpn logic
            // attack = &decryptedData[offset+78]; //-32
            // technique = &decryptedData[offset+82];
            // soultimate = &decryptedData[offset+86];
            // xp = (uint32_t*)(&decryptedData[offset+88]);
            // hp = (uint16_t*)(&decryptedData[offset+92]);
            // soul = &decryptedData[offset+94];
            // stats.tiv_hp = &decryptedData[offset+96];
            // stats.tiv_str = &decryptedData[offset+97];
            // stats.tiv_spr = &decryptedData[offset+98];
            // stats.tiv_def = &decryptedData[offset+99];
            // stats.tiv_spd = &decryptedData[offset+100];
            // stats.iv21_hp = &decryptedData[offset+101];
            // stats.iv21_str = &decryptedData[offset+102];
            // stats.iv21_spr = &decryptedData[offset+103];
            // stats.iv21_def = &decryptedData[offset+104];
            // stats.iv21_spd = &decryptedData[offset+105];
            // stats.ev_hp = &decryptedData[offset+106];
            // stats.ev_str = &decryptedData[offset+107];
            // stats.ev_spr = &decryptedData[offset+108];
            // stats.ev_def = &decryptedData[offset+109];
            // stats.ev_spd = &decryptedData[offset+110];
            // level = &decryptedData[offset+116];
            // attitude = &decryptedData[offset+117];
        }
    };

    // struct Item {
    //     std::vector<uint8_t*> data;
    //     uint16_t* num1;
    //     uint16_t* num2;
    //     uint32_t* type;
    //     uint8_t* amount;

    //     Item(std::vector<uint8_t>& decryptedData, int16_t offset) {
    //         for(int i=0;i<12;i++)data.push_back(&decryptedData[offset+i]);
    //         num1 = (uint16_t*)(&decryptedData[offset]);
    //         num2 = (uint16_t*)(&decryptedData[offset+2]);
    //         type = (uint32_t*)(&decryptedData[offset+4]);
    //         amount = &decryptedData[offset+8];
    //     }
    // };

    // struct Equipment {
    //     std::vector<uint8_t*> data;
    //     uint16_t* num1;
    //     uint16_t* num2;
    //     uint32_t* type;
    //     uint32_t* amount;

    //     Equipment(std::vector<uint8_t>& decryptedData, int16_t offset) {
    //         for(int i=0;i<12;i++)data.push_back(&decryptedData[offset+i]);
    //         num1 = (uint16_t*)(&decryptedData[offset]);
    //         num2 = (uint16_t*)(&decryptedData[offset+2]);
    //         type = (uint32_t*)(&decryptedData[offset+4]);
    //         amount = (uint32_t*)(&decryptedData[offset+8]);
    //     }
    // };

    // struct Important{
    //     std::vector<uint8_t*> data;
    //     uint16_t* num1;
    //     uint16_t* num2;
    //     uint32_t* type;

    //     Important(std::vector<uint8_t>& decryptedData, int16_t offset) {
    //         for(int i=0;i<8;i++)data.push_back(&decryptedData[offset+i]);
    //         num1 = (uint16_t*)(&decryptedData[offset]);
    //         num2 = (uint16_t*)(&decryptedData[offset+2]);
    //         type = (uint32_t*)(&decryptedData[offset+4]);
    //     }
    // };
};

#endif // STRUCT_H