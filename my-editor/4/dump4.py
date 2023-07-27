#!/opt/local/bin/python3
# coding: utf-8

"""
dump1s.py

======

The MIT License (MIT)

Copyright (c) 2023 RSM, bqsantana, Emilia

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
"""

from data import * #will/may eventually remove, added to make program nicer

#functions
def get(read, place, length=1, integer=True, half=False):
    finished = ""
    if half == True:
        return [int(f'{read[place]:08b}'[:4], 2), int(f'{read[place]:08b}'[4:], 2)] 
    elif half == None: #list of bits (for the medallium)
        return [bit == '1' for byte in read[place:place+length][-1::-1] for bit in f'{byte:08b}'][-1::-1] #list of True or False
    else:
        if integer == None: #float
            if read[place:place+length] == b'\x00'*4: #5.877471754111438e-39
                return 0
            hex_int = int.from_bytes(read[place:place+length], "little")
            sign_bit = (hex_int >> 31) & 1
            exponent = ((hex_int >> 23) & 0xFF) - 127
            mantissa = hex_int & 0x7FFFFF
            return (-1)**sign_bit*(1+mantissa/2**23)*2**exponent #may have to remove rounding
        elif integer: #int
            for i in read[place:place+length][-1::-1]:
                finished += f'{i:08b}'
            return int(finished, 2)
        else: #string
            if read[place:place+length][0]==0:
                return ""
            for i in read[place:place+length]:
                if i == 0:
                    break
                finished += chr(i)
            return finished.encode('latin-1').decode('utf-8')

def give(floa): #some shenanigans to convert a float to bytes
    if floa == 0: return b"\x00"*4
    e = 0
    while floa >= 2: floa, e = floa / 2, e + 1
    while floa < 1: floa, e = floa * 2, e - 1
    return (0 | (e + 127) << 23 | int((floa - 1) * (2**23))).to_bytes(4, 'little')

def main(file):
    with open(file, "r+b") as f:
        f.seek(131) #misc
        position = [get(f.read(4),0,4), get(f.read(4),0,4), get(f.read(4),0,4)] #x,y,z
        f.seek(167)
        location = get(f.read(4),0,4)
        f.seek(203)
        money = get(f.read(4),0,4)
        f.seek(282)
        namelist = {
            "nate": get(f.read(36),0,24,False), 
            "katie": get(f.read(36),0,24,False), 
            "summer": get(f.read(36),0,24,False), 
            "touma": get(f.read(36),0,24,False), 
            "akinori": get(f.read(36),0,24,False), 
            "jack": get(f.read(36),0,24,False), 
        }
        f.seek(2082)
        gatcharemaining = get(f.read(1),0) #crank-a-kai
        gatchamax = get(f.read(1),0)

        characterlist = [] # should maybe merge with yokailist
        index = 0
        f.seek(166627)
        while True:
            character = f.read(469)
            
            if (get(character, 0) == 0 and index != 0) or index >= 6: #could be broken
                break

            characterlist.append({
                "num1": get(character, 0, 2), #starts from 0
                "num2": get(character, 2, 2), 
                "nickname": get(character, 28, 24, False), #maybe more?
                "id": characters[get(character, 72, 4)], 
                "skills": [
                    get(character, 84, 4), 
                    get(character, 88, 4), 
                    get(character, 92, 4), 
                    get(character, 96, 4), 
                    get(character, 100, 4), 
                    get(character, 104, 4), 
                ], 
                "xp": get(character, 132, 4), 
                "hp": get(character, 144, 4), 
                "yp": get(character, 156, 4), 
                "pg": get(character, 168, 4),  #i haven't played enough yw4 to know what this is lol
                "level": get(character, 180, 4), 
                "flag1": get(character, 204, 2), #?
                "stats": {
                    "hp_plus": get(character, 214, 2), 
                    "yp_plus": get(character, 216, 2), 
                    "st_plus": get(character, 218, 2), 
                    "sp_plus": get(character, 220, 2), 
                    "pa_plus": get(character, 222, 2), 
                    "sa_plus": get(character, 224, 2), 
                    "iv_hp": get(character, 254), #yw2 iv/ev rules i think
                    "iv_str": get(character, 255), 
                    "iv_spr": get(character, 256), 
                    "iv_def": get(character, 257), 
                    "iv_spd": get(character, 258), 
                    # "ev_hp": get(character, 259), #TODO (indexs are wrong)
                    # "ev_str": get(character, 268), 
                    # "ev_spr": get(character, 292), 
                    # "ev_def": get(character, 317), 
                    # "ev_spd": get(character, 330), 
                }, 
                "order": get(character, 330), 
    
                # "Unknown11": get(character, 356), #TODO
                # "Unknown12": get(character, 380), 
                # "Unknown13": get(character, 389), 
                # "Unknown14": get(character, 398), 
                # "Unknown15": get(character, 416), 
                # "Unknown16": get(character, 425), 
                # "Unknown17": get(character, 452), 
            })

            index += 1
            original_character_amount = index

        yokailist = []
        index = 0
        f.seek(169449)
        while True:
            yokai = f.read(469)

            if get(yokai, 0) == 0 and index != 0: #could be broken
                break

            yokailist.append({
                "num1": get(yokai, 0, 2), #starts from 4096
                "num2": get(yokai, 2, 2), 
                "nickname": get(yokai, 28, 24, False), #maybe more?
                "id": characters[get(yokai, 72, 4)], 
                "skills": [
                    get(yokai, 84, 4), 
                    get(yokai, 88, 4), 
                    get(yokai, 92, 4), 
                    get(yokai, 96, 4), 
                    get(yokai, 100, 4), 
                    get(yokai, 104, 4), 
                ], 
                "xp": get(yokai, 132, 4), 
                "hp": get(yokai, 144, 4), 
                "yp": get(yokai, 156, 4), 
                "pg": get(yokai, 168, 4),  #i haven't played enough yw4 to know what this is lol
                "level": get(yokai, 180, 4), 
                "flag1": get(yokai, 204, 2), #?
                "stats": {
                    "hp_plus": get(yokai, 214, 2), 
                    "yp_plus": get(yokai, 216, 2), 
                    "st_plus": get(yokai, 218, 2), 
                    "sp_plus": get(yokai, 220, 2), 
                    "pa_plus": get(yokai, 222, 2), 
                    "sa_plus": get(yokai, 224, 2), 
                    "iv_hp": get(yokai, 254), #yw2 iv/ev rules i think
                    "iv_str": get(yokai, 255), 
                    "iv_spr": get(yokai, 256), 
                    "iv_def": get(yokai, 257), 
                    "iv_spd": get(yokai, 258), 
                    # "ev_hp": get(yokai, 259), #TODO (indexs are wrong)
                    # "ev_str": get(yokai, 268), 
                    # "ev_spr": get(yokai, 292), 
                    # "ev_def": get(yokai, 317), 
                    # "ev_spd": get(yokai, 330), 
                }, 
                "order": get(yokai, 330), 
    
                # "Unknown11": get(yokai, 356), #TODO
                # "Unknown12": get(yokai, 380), 
                # "Unknown13": get(yokai, 389), 
                # "Unknown14": get(yokai, 398), 
                # "Unknown15": get(yokai, 416), 
                # "Unknown16": get(yokai, 425), 
                # "Unknown17": get(yokai, 452), 
            })

            index += 1
            original_yokai_amount = index

        itemlist = []
        index = 0
        f.seek(76579)
        while True:
            item = f.read(54)

            if get(item, 0) == 0 and index != 0: #could be broken
                break

            itemlist.append({
                "num1": get(item, 0, 2), #starts from 0
                "num2": get(item, 2, 2),
                "item": items[get(item, 12, 4)],
                "order": get(item, 24, 4), #what's this?
                "amount": get(item, 36, 2) # maybe 4 bytes?
            })
            
            index += 1
        original_item_amount = index

        specialsoullist = [] #TODO rename
        index = 0
        f.seek(958227)
        while True:
            specialsoul = f.read(54)

            if get(specialsoul, 0) == 0 and index != 0: #could be broken
                break

            specialsoullist.append({
                "num1": get(specialsoul, 0, 2), #starts from 16384
                "num2": get(specialsoul, 2, 2),
                "soul": get(specialsoul, 12, 4),
                "order": get(specialsoul, 24, 4),
                "amount": get(specialsoul, 36, 2),
            })

            index += 1
        original_special_soul_amount = index

        yokaisoullist = [] #TODO rename
        index = 0
        f.seek(963635)
        while True:
            yokaisoul = f.read(80)

            if get(yokaisoul, 0) == 0 and index != 0: #could be broken
                break

            yokaisoullist.append({
                "num1": get(yokaisoul, 0, 2), #starts from 12288
                "num2": get(yokaisoul, 2, 2), 
                "soul": get(yokaisoul, 12, 4),
                "order": get(yokaisoul, 24, 4),
                "white": get(yokaisoul, 36, 2),
                "red": get(yokaisoul, 38, 2),
                "gold": get(yokaisoul, 40, 2),
                "flags":[
                    get(yokaisoul, 50), 
                    get(yokaisoul, 51), 
                    get(yokaisoul, 52), 
                    get(yokaisoul, 61), 
                    get(yokaisoul, 62), 
                    get(yokaisoul, 63), 
                ], 
            })

            index += 1
        original_yokai_soul_amount = index

        equipmentlist = []
        index = 0
        f.seek(103587)
        while True:
            equipment = f.read(63)

            if get(equipment, 0) == 0 and index != 0: #could be broken
                break

            equipmentlist.append({
                "num1": get(equipment, 0, 2), #starts from 4096
                "num2": get(equipment, 2, 2), 
                "equipment": get(equipment, 12, 4),
                "order": get(equipment, 24, 4),
                "amount": get(equipment, 36, 2),
                "used": get(equipment, 46, 1) #how many are in use (leave alone or set to zero)
            })

            index += 1
        original_equipment_amount = index

        pass

infile = "/Users/emilia/Downloads/0000000000000001/0/USERDATA00/data.bin"
#infile = "/Volumes/UNTITLED/switch/Checkpoint/saves/........"

main(infile)