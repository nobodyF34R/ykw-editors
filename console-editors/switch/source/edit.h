#ifndef EDIT_H
#define EDIT_H

#include "struct.h"
#include <vector>
#include <cstdint>

namespace edit1s {
    void edit_yokai(struct1s::Yokai &edit, uint32_t yokai, uint8_t attitude, std::vector<uint8_t> iv, std::vector<uint8_t> ev, uint32_t level) {
        *edit.yokai = yokai;
        *edit.attack = 255;
        *edit.technique = 255;
        *edit.soultimate = 255;
        //TODO iv and tiv
        *edit.stats.ev_hp = ev[0];
        *edit.stats.ev_str = ev[1];
        *edit.stats.ev_spr = ev[2];
        *edit.stats.ev_def = ev[3];
        *edit.stats.ev_spd = ev[4];
        *edit.level = level;
        *edit.attitude = attitude;
    }

    void edit_item(struct1s::Item &edit, uint32_t item, uint32_t amount) {
        *edit.item = item;
        *edit.amount = amount;
    }

    void edit_equipment(struct1s::Equipment &edit, uint32_t equipment, uint32_t amount) {
        *edit.equipment = equipment;
        *edit.amount = amount;
    }

    void edit_important(struct1s::Important &edit, uint32_t important) {
        *edit.important = important;
    }
};

namespace edit4 {
    void edit_yokai(struct4::Yokai &edit, uint32_t yokai, uint8_t attitude, std::vector<uint8_t> iv, std::vector<uint32_t> skills, uint32_t level) {
        *edit.yokai = yokai;
        *edit.skill1 = skills[0];
        *edit.skill2 = skills[1];
        *edit.skill3 = skills[2];
        *edit.skill4 = skills[3];
        *edit.skill5 = skills[4];
        *edit.skill6 = skills[5];
        *edit.xp = 0;
        *edit.hp = 1;
        *edit.yp = 1;
        *edit.pg = 4294967295;
        *edit.flag1 = 1;
        *edit.level = level;
        *edit.stats.hp_plus = 65535;
        *edit.stats.yp_plus = 65535;
        *edit.stats.st_plus = 65535;
        *edit.stats.sp_plus = 65535;
        *edit.stats.pa_plus = 65535;
        *edit.stats.sa_plus = 65535;
        *edit.stats.iv_hp = iv[0];
        *edit.stats.iv_str = iv[1];
        *edit.stats.iv_spr = iv[2];
        *edit.stats.iv_def = iv[3];
        *edit.stats.iv_spd = iv[4];
        //TODO other stats
    }

    void edit_item(struct4::Item &edit, uint32_t item, uint32_t amount) {
        *edit.item = item;
        *edit.amount = amount;
    }

    void edit_special_soul(struct4::SpecialSoul &edit, uint32_t soul, uint32_t amount) {
        *edit.soul = soul;
        *edit.amount = amount;
    }

    void edit_yokai_soul(struct4::YokaiSoul &edit, uint32_t soul, uint32_t red, uint32_t white, uint32_t gold, uint32_t flags) {
        *edit.soul = soul;
        *edit.red = red;
        *edit.white = white;
        *edit.gold = gold;
        *edit.flags = flags;
    }

    void edit_equipment(struct4::Equipment &edit, uint32_t equipment, uint32_t amount) {
        *edit.equipment = equipment;
        *edit.amount = amount;
    }
};

#endif // EDIT_H