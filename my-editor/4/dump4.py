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

from data import *

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


def edit_yokai(yokailist, index, yokai=None, nickname=None, iv=None, skills=None): #massively overcomplicated and broken simultaneously 
    try:
        if index < 0:
            index = len(yokailist)-index #appending shortcut
    except:
        pass
    try:
        yokailist[index]
    except:
        temp_yokailist = yokailist #pointless now???
        index = len(yokailist)
        yokailist.append({})
        yokailist[index]["num1"] = 0 #this part is probably overcomplicated 
        j=0
        for i in range(len(temp_yokailist)):
            if temp_yokailist[i]["num1"] != j:
                yokailist[index]["num1"] = j
                break
            if temp_yokailist[i]["num1"] > yokailist[index]["num1"]:
                yokailist[index]["num1"] = temp_yokailist[i]["num1"]+1
            j+=1
        yokailist[index]["num2"] = 1
        for i in range(j):
            if temp_yokailist[i]["num2"] > yokailist[index]["num2"]:
                yokailist[index]["num2"] = temp_yokailist[i]["num2"]
                location = i
        yokailist[index]["num2"]+=(j-location)
    if yokai != None:
        try:
            yokailist[index]["id"] = reverse_yokais[yokai]
        except:
            try:
                yokailist[index]["id"] = reverse_characters[yokai]
            except:
                yokailist[index]["id"] = yokai
    try:
        yokailist[index]["nickname"] = yokailist[index]["nickname"]
    except:
        yokailist[index]["nickname"] = ""
    if nickname != None: #may cause problems
        yokailist[index]["nickname"] = nickname
    if skills:# e.g. ["blah", None, 1234, None, 0, 0]
        try:
            yokailist[index]["skills"] = [yokailist[index]["skills"][skill] if skills[skill] == None else reverse_skills[skills[skill]] for skill in range(6)]
        except:
            yokailist[index]["skills"] = [yokailist[index]["skills"][skill] if skills[skill] == None else skills[skill] for skill in range(6)]
    yokailist[index]["xp"] = 0 
    yokailist[index]["hp"] = 1 #if these are over the max the game crashes TODO test
    yokailist[index]["yp"] = 1
    # yokailist[index]["pg"] = 4294967295 #idk what this does
    yokailist[index]["flag1"] = 1
    yokailist[index]["level"] = 99 #automatically lowers to 99
    if iv == None:
        iv = [16,8,8,8,8]
    else:
        if sum(iv) - iv[0]/2 != 40: #will complain if hp is odd so no need to check for that
            iv = [16,8,8,8,8]
    yokailist[index]["stats"] = { #hp must be even
        "hp_plus": 65535, 
        "yp_plus": 65535, 
        "st_plus": 65535, 
        "sp_plus": 65535, 
        "pa_plus": 65535, 
        "sa_plus": 65535, 
        "iv_hp": iv[0], #iv rules: hp / 2 + Str + Spr + Def + Spd = 40
        "iv_str": iv[1], 
        "iv_spr": iv[2], 
        "iv_def": iv[3], 
        "iv_spd": iv[4], 
    }
    try:
        yokailist[index]["order"]
    except:
        yokailist[index]["order"] = 0 #TODO ummmm idk lol
    # yokailist[index]["loaflevel"] = 5 #2?
    # try:
    #     yokailist[index]["attitude"] = yokailist[index]["attitude"] #for appending
    # except:
    #     yokailist[index]["attitude"] = 0
    # if attitude != None:
    #     try:
    #         yokailist[index]["attitude"] = attitudes.index(attitude)
    #     except:
    #         yokailist[index]["attitude"] = attitudes[attitude]

    return sorted(yokailist, key=lambda x:x["num1"])

def edit_item(itemlist, index, item=None, amount=None): #broken for some reason
    try:
        if index < 0:
            index = len(itemlist)-index #appending shortcut
    except:
        pass
    try:
        itemlist[index]
    except:
        index = len(itemlist)
        itemlist.append({})
    itemlist[index]["num1"] = index
    itemlist[index]["num2"] = index+1
    if item:
        try:
            itemlist[index]["item"] = reverse_items[item]
        except:
            itemlist[index]["item"] = item
    try:
        itemlist[index]["order"]
    except:
        itemlist[index]["order"] = 0 
    if amount:
        itemlist[index]["amount"] = amount
    return itemlist

def edit_special_soul(specialsoullist, index, soul=None, amount=None):
    try:
        if index < 0:
            index = len(specialsoullist)-index #appending shortcut
    except:
        pass
    try:
        specialsoullist[index]
    except:
        index = len(specialsoullist)
        specialsoullist.append({})
    specialsoullist[index]["num1"] = index
    specialsoullist[index]["num2"] = index+1
    if soul:
        try:
            specialsoullist[index]["soul"] = reverse_souls[soul] #TODO
        except:
            specialsoullist[index]["soul"] = item
    try:
        specialsoullist[index]["order"]
    except:
        specialsoullist[index]["order"] = 0 
    if amount:
        specialsoullist[index]["amount"] = amount
    return specialsoullist

def edit_yokai_soul(yokaisoullist, index, soul=None, red=None, white=None, gold=None, flags=None):
    try:
        if index < 0:
            index = len(yokaisoullist)-index #appending shortcut
    except:
        pass
    try:
        yokaisoullist[index]
    except:
        index = len(yokaisoullist)
        yokaisoullist.append({})
    yokaisoullist[index]["num1"] = index
    yokaisoullist[index]["num2"] = index+1
    if soul:
        try:
            yokaisoullist[index]["soul"] = reverse_souls[soul] #TODO
        except:
            yokaisoullist[index]["soul"] = item
    try:
        yokaisoullist[index]["order"]
    except:
        yokaisoullist[index]["order"] = 0 
    if red:
        yokaisoullist[index]["red"] = red
    if white:
        yokaisoullist[index]["white"] = white
    if gold:
        yokaisoullist[index]["gold"] = gold
    if flags:
        yokaisoullist[index]["flags"] = flags #idk
    return yokaisoullist

def edit_equipment(equipmentlist, index, equipment=None, amount=None):
    try:
        if index < 0:
            index = len(equipmentlist)-index #appending shortcut
    except:
        pass
    try:
        equipmentlist[index]
    except:
        index = len(equipmentlist)
        equipmentlist.append({})
    equipmentlist[index]["num1"] = index
    equipmentlist[index]["num2"] = index+1
    if equipment:
        try:
            equipmentlist[index]["equipment"] = reverse_equipments[equipment]
        except:
            equipmentlist[index]["equipment"] = equipment
    try:
        equipmentlist[index]["order"] #overkill until i learn how to use it
    except:
        equipmentlist[index]["order"] = 0 
    if amount:
        equipmentlist[index]["amount"] = amount
    equipmentlist[index]["used"] = 0
    return equipmentlist

#important???

#main
def main(file, edit):
    with open(file, "r+b") as f:
        f.seek(131) #misc
        position = [get(f.read(4),0,4), get(f.read(4),0,4), get(f.read(4),0,4)] #x,y,z
        f.seek(167)
        location = get(f.read(4),0,4)
        f.seek(203)
        money = get(f.read(4),0,4)
        f.seek(282)
        namelist = { #not a list...
            "nate": get(f.read(36),0,24,False), 
            "katie": get(f.read(36),0,24,False), 
            "summer": get(f.read(36),0,24,False), 
            "cole": get(f.read(36),0,24,False), 
            "bruno": get(f.read(36),0,24,False), 
            "jack": get(f.read(36),0,24,False), 
        }
        f.seek(2082)
        gatcharemaining = get(f.read(1),0) #crank-a-kai, could maybe rename?
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
                "id": get(character, 72, 4), 
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
                    # "ev_hp": get(character, 259), #TODO (indexes are wrong)
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
                "id": get(yokai, 72, 4), 
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
                    # "ev_hp": get(yokai, 259), #TODO (indexes are wrong)
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
                "item": get(item, 12, 4),
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
                "white": get(yokaisoul, 36, 2), #amount
                "red": get(yokaisoul, 38, 2), #amount
                "gold": get(yokaisoul, 40, 2), #amount
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

        #TODO important

        #editor goes here
        if edit:
            position, location, money, namelist, gatcharemaining, gatchamax, characterlist, yokailist, itemlist, specialsoullist, yokaisoullist, equipmentlist = edit(position, location, money, namelist, gatcharemaining, gatchamax, characterlist, yokailist, itemlist, specialsoullist, yokaisoullist, equipmentlist)

        #write everything back to file
        if 1:
            #misc
            f.seek(131)
            f.write(position[0].to_bytes(4, "little"))
            f.write(position[1].to_bytes(4, "little"))
            f.write(position[2].to_bytes(4, "little"))
            f.seek(167)
            f.write(location.to_bytes(4, "little"))
            f.seek(203)
            f.write(money.to_bytes(4, "little"))
            namenum = 0
            for name in namelist:
                f.seek(282+36*namenum)
                f.write((bytearray(list(namelist[name].encode('utf-8')))+bytearray(24))[:24])
                namenum += 1
            #clear overflow????
            f.seek(2082)
            f.write(gatcharemaining.to_bytes(1, "little"))
            f.write(gatchamax.to_bytes(1, "little"))

            #write character back
            j=0
            for i in characterlist:
                f.seek(166627+469*j+0)
                f.write(i["num1"].to_bytes(2, "little"))
                f.seek(166627+469*j+2)
                f.write(i["num2"].to_bytes(2, "little"))
                f.seek(166627+469*j+28)
                f.write((bytearray([ord(k)for k in i["nickname"]])+bytearray(24))[:24])
                f.seek(166627+469*j+72)
                f.write(i["id"].to_bytes(4, "little"))
                f.seek(166627+469*j+84)
                for skill in range(6): #always 6?
                    f.write(i["skills"][skill].to_bytes(4, "little"))
                f.seek(166627+469*j+132)
                f.write(i["xp"].to_bytes(4, "little"))
                f.seek(166627+469*j+144)
                f.write(i["hp"].to_bytes(4, "little"))
                f.seek(166627+469*j+156)
                f.write(i["yp"].to_bytes(4, "little"))
                f.seek(166627+469*j+168)
                f.write(i["pg"].to_bytes(4, "little"))
                f.seek(166627+469*j+180)
                f.write(i["level"].to_bytes(4, "little"))
                f.seek(166627+469*j+204)
                f.write(i["flag1"].to_bytes(2, "little"))
                f.seek(166627+469*j+214)
                f.write(i["stats"]["hp_plus"].to_bytes(2, "little"))
                f.write(i["stats"]["yp_plus"].to_bytes(2, "little"))
                f.write(i["stats"]["st_plus"].to_bytes(2, "little"))
                f.write(i["stats"]["sp_plus"].to_bytes(2, "little"))
                f.write(i["stats"]["pa_plus"].to_bytes(2, "little"))
                f.write(i["stats"]["sa_plus"].to_bytes(2, "little"))
                f.seek(166627+469*j+254)
                f.write(i["stats"]["iv_hp"].to_bytes(1, "little"))
                f.write(i["stats"]["iv_str"].to_bytes(1, "little"))
                f.write(i["stats"]["iv_spr"].to_bytes(1, "little"))
                f.write(i["stats"]["iv_def"].to_bytes(1, "little"))
                f.write(i["stats"]["iv_spd"].to_bytes(1, "little"))
                f.seek(166627+469*j+330)
                f.write(i["order"].to_bytes(1, "little"))
                
                j+=1

            #clear character overflow
            if original_character_amount - len(characterlist) > 0:
                f.seek(166627+469*j)
                f.write(b"\x00"*469*(original_character_amount - len(characterlist)))

            #write yokai back
            j=0
            for i in yokailist:
                f.seek(169449+469*j+0)
                f.write(i["num1"].to_bytes(2, "little"))
                f.seek(169449+469*j+2)
                f.write(i["num2"].to_bytes(2, "little"))
                f.seek(169449+469*j+28)
                f.write((bytearray([ord(k)for k in i["nickname"]])+bytearray(24))[:24])
                f.seek(169449+469*j+72)
                f.write(i["id"].to_bytes(4, "little"))
                f.seek(169449+469*j+84)
                for skill in range(6):
                    f.write(i["skills"][skill].to_bytes(4, "little"))
                f.seek(169449+469*j+132)
                f.write(i["xp"].to_bytes(4, "little"))
                f.seek(169449+469*j+144)
                f.write(i["hp"].to_bytes(4, "little"))
                f.seek(169449+469*j+156)
                f.write(i["yp"].to_bytes(4, "little"))
                f.seek(169449+469*j+168)
                f.write(i["pg"].to_bytes(4, "little"))
                f.seek(169449+469*j+180)
                f.write(i["level"].to_bytes(4, "little"))
                f.seek(169449+469*j+204)
                f.write(i["flag1"].to_bytes(2, "little"))
                f.seek(169449+469*j+214)
                f.write(i["stats"]["hp_plus"].to_bytes(2, "little"))
                f.write(i["stats"]["yp_plus"].to_bytes(2, "little"))
                f.write(i["stats"]["st_plus"].to_bytes(2, "little"))
                f.write(i["stats"]["sp_plus"].to_bytes(2, "little"))
                f.write(i["stats"]["pa_plus"].to_bytes(2, "little"))
                f.write(i["stats"]["sa_plus"].to_bytes(2, "little"))
                f.seek(169449+469*j+254)
                f.write(i["stats"]["iv_hp"].to_bytes(1, "little"))
                f.write(i["stats"]["iv_str"].to_bytes(1, "little"))
                f.write(i["stats"]["iv_spr"].to_bytes(1, "little"))
                f.write(i["stats"]["iv_def"].to_bytes(1, "little"))
                f.write(i["stats"]["iv_spd"].to_bytes(1, "little"))
                f.seek(169449+469*j+330)
                f.write(i["order"].to_bytes(1, "little"))
                
                j+=1

            #clear yokai overflow
            if original_yokai_amount - len(yokailist) > 0:
                f.seek(169449+469*j)
                f.write(b"\x00"*469*(original_yokai_amount - len(yokailist)))

            #write item back
            j=0
            for i in itemlist:
                f.seek(76579+54*j+0)
                f.write(i["num1"].to_bytes(2, "little"))
                f.seek(76579+54*j+2)
                f.write(i["num2"].to_bytes(2, "little"))
                f.seek(76579+54*j+12)
                f.write(i["item"].to_bytes(4, "little"))
                f.seek(76579+54*j+24)
                f.write(i["order"].to_bytes(4, "little"))
                f.seek(76579+54*j+36)
                f.write(i["amount"].to_bytes(4, "little"))

                j+=1

            #clear item overflow
            if original_item_amount - len(itemlist) > 0:
                f.seek(76579+54*j)
                f.write(b"\x00"*54*(original_item_amount - len(itemlist)))

            #write special soul back
            j=0
            for i in specialsoullist:
                f.seek(958227+54*j+0)
                f.write(i["num1"].to_bytes(2, "little"))
                f.seek(958227+54*j+2)
                f.write(i["num2"].to_bytes(2, "little"))
                f.seek(958227+54*j+12)
                f.write(i["soul"].to_bytes(4, "little"))
                f.seek(958227+54*j+24)
                f.write(i["order"].to_bytes(4, "little"))
                f.seek(958227+54*j+36)
                f.write(i["amount"].to_bytes(2, "little"))

                j+=1

            #clear special soul overflow
            if original_special_soul_amount - len(specialsoullist) > 0:
                f.seek(958227+54*j)
                f.write(b"\x00"*54*(original_special_soul_amount - len(specialsoullist)))
            
            #write yokai soul back
            j=0
            for i in yokaisoullist:
                f.seek(963635+80*j+0)
                f.write(i["num1"].to_bytes(2, "little"))
                f.seek(963635+80*j+2)
                f.write(i["num2"].to_bytes(2, "little"))
                f.seek(963635+80*j+12)
                f.write(i["soul"].to_bytes(4, "little"))
                f.seek(963635+80*j+24)
                f.write(i["order"].to_bytes(4, "little"))
                f.seek(963635+80*j+36)
                f.write(i["white"].to_bytes(2, "little"))
                f.seek(963635+80*j+38)
                f.write(i["red"].to_bytes(2, "little"))
                f.seek(963635+80*j+40)
                f.write(i["gold"].to_bytes(2, "little"))
                for flag in range(6): #always 6?
                    f.write(i["flags"][flag].to_bytes(1, "little"))

                j+=1

            #clear yokai soul overflow
            if original_yokai_soul_amount - len(yokaisoullist) > 0:
                f.seek(963635+80*j)
                f.write(b"\x00"*80*(original_yokai_soul_amount - len(yokaisoullist)))
            
            #write equipment back
            j=0
            for i in equipmentlist:
                f.seek(103587+63*j+0)
                f.write(i["num1"].to_bytes(2, "little"))
                f.seek(103587+63*j+2)
                f.write(i["num2"].to_bytes(2, "little"))
                f.seek(103587+63*j+12)
                f.write(i["equipment"].to_bytes(4, "little"))
                f.seek(103587+63*j+24)
                f.write(i["order"].to_bytes(4, "little"))
                f.seek(103587+63*j+36)
                f.write(i["amount"].to_bytes(2, "little"))
                f.seek(103587+63*j+46)
                f.write(i["used"].to_bytes(1, "little"))

                j+=1

            #clear equipment overflow
            if original_equipment_amount - len(equipmentlist) > 0:
                f.seek(103587+63*j)
                f.write(b"\x00"*63*(original_equipment_amount - len(equipmentlist)))