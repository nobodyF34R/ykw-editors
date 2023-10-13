#ifndef STRUCTS_H
#define STRUCTS_H

#include <iostream>

// Define the Yokai struct to store the extracted data
struct Yokai {
    uint16_t num1;
    uint16_t num2;
    uint32_t yokai;
    // std::string nickname[68];
    uint8_t attack;
    uint8_t technique;
    uint8_t soultimate;
    uint32_t xp;
    uint16_t hp;
    uint8_t soul;
    struct {
        uint8_t tiv_hp;
        uint8_t tiv_str;
        uint8_t tiv_spr;
        uint8_t tiv_def;
        uint8_t tiv_spd;
        uint8_t iv21_hp;
        uint8_t iv21_str;
        uint8_t iv21_spr;
        uint8_t iv21_def;
        uint8_t iv21_spd;
        uint8_t ev_hp;
        uint8_t ev_str;
        uint8_t ev_spr;
        uint8_t ev_def;
        uint8_t ev_spd;
    } stats;
    uint8_t level;
    uint8_t attitude;
    // TODO: Add fields for "loaf level," "held item," and "affection"
};

#endif // STRUCTS_H