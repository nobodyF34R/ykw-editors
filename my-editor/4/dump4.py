#!/opt/local/bin/python3
# coding: utf-8

"""
dump4.py

======

The MIT License (MIT)

Copyright (c) 2023 RSM, bqsantana, nobody_fear

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
            return finished.encode('latin-1').decode('utf-8') #im not too sure what the correct encoding is. TBD

def give(write, length=1, integer=True, half=False):
    if half == True:
        return int(f'{write[0]:04b}'+f'{write[1]:04b}', 2).to_bytes(1, 'little')
    elif half == None: #medallium
        return bytearray([int(''.join('1' if bit else '0' for bit in write[i:i+8][::-1]), 2) for i in range(0, length, 8)])
    else:
        if integer == True: #int
            return write.to_bytes(length, "little")
        elif integer == None: #float
            if write == 0: return b"\x00"*length  #some shenanigans to convert a float to bytes ONLY TESTED ON LENGTH 4
            e = 0
            while write >= 2: write, e = write / 2, e + 1
            while write < 1: write, e = write * 2, e - 1
            return (0 | (e + 127) << 23 | int((write - 1) * (2**23))).to_bytes(length, 'little')
        else: #string
            return (bytearray(write.encode('utf-8'))+bytearray(length))[:length]


def edit_yokai(yokailist, index, yokai=None, nickname=None, iv=None, moves=None): #massively overcomplicated and broken simultaneously works with characterlist too
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
            yokailist[index]["type"] = reverse_characters[yokai]
        except:
            yokailist[index]["type"] = yokai
    try:
        yokailist[index]["nickname"] = yokailist[index]["nickname"]
    except:
        yokailist[index]["nickname"] = ""
    if nickname != None: #may cause problems
        yokailist[index]["nickname"] = nickname
    if moves:# e.g. ["blah", None, 1234, None, 0, 0]
        try:
            yokailist[index]["moves"] = [yokailist[index]["moves"][move] if moves[move] == None else reverse_moves[moves[move]] for move in range(6)]
        except:
            yokailist[index]["moves"] = [yokailist[index]["moves"][move] if moves[move] == None else moves[move] for move in range(6)]
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
            itemlist[index]["type"] = reverse_items[item]
        except:
            itemlist[index]["type"] = item
    try:
        itemlist[index]["order"]
    except:
        itemlist[index]["order"] = 0 
    if amount:
        itemlist[index]["amount"] = amount
    return itemlist

def edit_special(speciallist, index, soul=None, amount=None):
    try:
        if index < 0:
            index = len(speciallist)-index #appending shortcut
    except:
        pass
    try:
        speciallist[index]
    except:
        index = len(speciallist)
        speciallist.append({})
    speciallist[index]["num1"] = index
    speciallist[index]["num2"] = index+1
    if soul:
        try:
            speciallist[index]["type"] = reverse_souls[soul] #TODO
        except:
            speciallist[index]["type"] = item
    try:
        speciallist[index]["order"]
    except:
        speciallist[index]["order"] = 0 
    if amount:
        speciallist[index]["amount"] = amount
    return speciallist

def edit_soul(soullist, index, soul=None, red=None, white=None, gold=None, flags=None):
    try:
        if index < 0:
            index = len(soullist)-index #appending shortcut
    except:
        pass
    try:
        soullist[index]
    except:
        index = len(soullist)
        soullist.append({})
    soullist[index]["num1"] = index
    soullist[index]["num2"] = index+1
    if soul:
        try:
            soullist[index]["type"] = reverse_souls[soul] #TODO
        except:
            soullist[index]["type"] = item
    try:
        soullist[index]["order"]
    except:
        soullist[index]["order"] = 0 
    if red:
        soullist[index]["red"] = red
    if white:
        soullist[index]["white"] = white
    if gold:
        soullist[index]["gold"] = gold
    if flags:
        soullist[index]["flags"] = flags #idk
    return soullist

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
            equipmentlist[index]["type"] = reverse_equipments[equipment]
        except:
            equipmentlist[index]["type"] = equipment
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

            if get(character, 2, 2) == 0 or index >= 6: #could be broken
                break

            characterlist.append({
                "num1": get(character, 0, 2), #starts from 0
                "num2": get(character, 2, 2), 
                "nickname": get(character, 28, 24, False), #maybe more?
                "type": get(character, 72, 4), 
                "moves": [
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

        yokailist = []
        index = 0
        f.seek(169449)
        while True:
            yokai = f.read(469)

            if get(yokai, 2, 2) == 0:
                break

            yokailist.append({
                "num1": get(yokai, 0, 2), #starts from 4096
                "num2": get(yokai, 2, 2), 
                "nickname": get(yokai, 28, 24, False), #maybe more?
                "type": get(yokai, 72, 4), 
                "moves": [
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

        itemlist = []
        index = 0
        f.seek(76579)
        while True:
            item = f.read(54)

            if get(item, 2, 2) == 0:
                break

            itemlist.append({
                "num1": get(item, 0, 2), #starts from 0
                "num2": get(item, 2, 2),
                "type": get(item, 12, 4),
                "order": get(item, 24, 4), #what's this?
                "amount": get(item, 36, 2) # maybe 4 bytes?
            })
            
            index += 1

        speciallist = [] #TODO rename
        index = 0
        f.seek(958227)
        while True:
            special = f.read(54)

            if get(special, 2, 2) == 0:
                break

            speciallist.append({
                "num1": get(special, 0, 2), #starts from 16384
                "num2": get(special, 2, 2),
                "type": get(special, 12, 4),
                "order": get(special, 24, 4),
                "amount": get(special, 36, 2),
            })

            index += 1

        soullist = [] #TODO rename
        index = 0
        f.seek(963635)
        while True:
            soul = f.read(80)

            if get(soul, 2, 2) == 0:
                break

            soullist.append({
                "num1": get(soul, 0, 2), #starts from 12288
                "num2": get(soul, 2, 2), 
                "type": get(soul, 12, 4),
                "order": get(soul, 24, 4),
                "white": get(soul, 36, 2), #amount
                "red": get(soul, 38, 2), #amount
                "gold": get(soul, 40, 2), #amount
                "flags":[
                    get(soul, 50), 
                    get(soul, 51), 
                    get(soul, 52), 
                    get(soul, 61), 
                    get(soul, 62), 
                    get(soul, 63), 
                ], 
            })

            index += 1

        equipmentlist = []
        index = 0
        f.seek(103587)
        while True:
            equipment = f.read(63)

            if get(equipment, 2, 2) == 0:
                break

            equipmentlist.append({
                "num1": get(equipment, 0, 2), #starts from 4096
                "num2": get(equipment, 2, 2), 
                "type": get(equipment, 12, 4),
                "order": get(equipment, 24, 4),
                "amount": get(equipment, 36, 2),
                "used": get(equipment, 46, 1) #how many are in use (leave alone or set to zero)
            })

            index += 1

        #TODO important

        #editor goes here
        if edit:
            position, location, money, namelist, gatcharemaining, gatchamax, characterlist, yokailist, itemlist, speciallist, soullist, equipmentlist = edit(position, location, money, namelist, gatcharemaining, gatchamax, characterlist, yokailist, itemlist, speciallist, soullist, equipmentlist)

        #write everything back to file
        if 1:
            #misc
            f.seek(131)
            f.write(give(position[0], 4))
            f.write(give(position[1], 4))
            f.write(give(position[2], 4))
            f.seek(167)
            f.write(give(location, 4))
            f.seek(203)
            f.write(give(money, 4))
            namenum = 0
            for name in namelist:
                f.seek(282+36*namenum)
                f.write(give(namelist[name], 24, integer=False))
                namenum += 1
            f.seek(2082)
            f.write(give(gatcharemaining))
            f.write(give(gatchamax))

            #write character back
            j=0
            for i in characterlist:
                f.seek(166627+469*j+0)
                f.write(give(i["num1"], 2))
                f.seek(166627+469*j+2)
                f.write(give(i["num2"], 2))
                f.seek(166627+469*j+28)
                f.write(give(i["nickname"], 24, integer=False))
                f.seek(166627+469*j+72)
                f.write(give(i["type"], 4))
                f.seek(166627+469*j+84)
                for move in range(6): #always 6?
                    f.write(give(i["moves"][move], 4))
                f.seek(166627+469*j+132)
                f.write(give(i["xp"], 4))
                f.seek(166627+469*j+144)
                f.write(give(i["hp"], 4))
                f.seek(166627+469*j+156)
                f.write(give(i["yp"], 4))
                f.seek(166627+469*j+168)
                f.write(give(i["pg"], 4))
                f.seek(166627+469*j+180)
                f.write(give(i["level"], 4))
                f.seek(166627+469*j+204)
                f.write(give(i["flag1"], 2))
                f.seek(166627+469*j+214)
                f.write(give(i["stats"]["hp_plus"], 2))
                f.write(give(i["stats"]["yp_plus"], 2))
                f.write(give(i["stats"]["st_plus"], 2))
                f.write(give(i["stats"]["sp_plus"], 2))
                f.write(give(i["stats"]["pa_plus"], 2))
                f.write(give(i["stats"]["sa_plus"], 2))
                f.seek(166627+469*j+254)
                f.write(give(i["stats"]["iv_hp"]))
                f.write(give(i["stats"]["iv_str"]))
                f.write(give(i["stats"]["iv_spr"]))
                f.write(give(i["stats"]["iv_def"]))
                f.write(give(i["stats"]["iv_spd"]))
                f.seek(166627+469*j+330)
                f.write(give(i["order"]))
                
                j+=1

            #write yokai back
            j=0
            for i in yokailist:
                f.seek(169449+469*j+0)
                f.write(give(i["num1"], 2))
                f.seek(169449+469*j+2)
                f.write(give(i["num2"], 2))
                f.seek(169449+469*j+28)
                f.write(give(i["nickname"], 24, integer=False))
                f.seek(169449+469*j+72)
                f.write(give(i["type"], 4))
                f.seek(169449+469*j+84)
                for move in range(6):
                    f.write(give(i["moves"][move], 4))
                f.seek(169449+469*j+132)
                f.write(give(i["xp"], 4))
                f.seek(169449+469*j+144)
                f.write(give(i["hp"], 4))
                f.seek(169449+469*j+156)
                f.write(give(i["yp"], 4))
                f.seek(169449+469*j+168)
                f.write(give(i["pg"], 4))
                f.seek(169449+469*j+180)
                f.write(give(i["level"], 4))
                f.seek(169449+469*j+204)
                f.write(give(i["flag1"], 2))
                f.seek(169449+469*j+214)
                f.write(give(i["stats"]["hp_plus"], 2))
                f.write(give(i["stats"]["yp_plus"], 2))
                f.write(give(i["stats"]["st_plus"], 2))
                f.write(give(i["stats"]["sp_plus"], 2))
                f.write(give(i["stats"]["pa_plus"], 2))
                f.write(give(i["stats"]["sa_plus"], 2))
                f.seek(169449+469*j+254)
                f.write(give(i["stats"]["iv_hp"]))
                f.write(give(i["stats"]["iv_str"]))
                f.write(give(i["stats"]["iv_spr"]))
                f.write(give(i["stats"]["iv_def"]))
                f.write(give(i["stats"]["iv_spd"]))
                f.seek(169449+469*j+330)
                f.write(give(i["order"]))
                
                j+=1

            #write item back
            j=0
            for i in itemlist:
                f.seek(76579+54*j+0)
                f.write(give(i["num1"], 2))
                f.seek(76579+54*j+2)
                f.write(give(i["num2"], 2))
                f.seek(76579+54*j+12)
                f.write(give(i["type"], 4))
                f.seek(76579+54*j+24)
                f.write(give(i["order"], 4))
                f.seek(76579+54*j+36)
                f.write(give(i["amount"], 4))

                j+=1

            #write special soul back
            j=0
            for i in speciallist:
                f.seek(958227+54*j+0)
                f.write(give(i["num1"], 2))
                f.seek(958227+54*j+2)
                f.write(give(i["num2"], 2))
                f.seek(958227+54*j+12)
                f.write(give(i["type"], 4))
                f.seek(958227+54*j+24)
                f.write(give(i["order"], 4))
                f.seek(958227+54*j+36)
                f.write(give(i["amount"], 2))

                j+=1

            #write yokai soul back
            j=0
            for i in soullist:
                f.seek(963635+80*j+0)
                f.write(give(i["num1"], 2))
                f.seek(963635+80*j+2)
                f.write(give(i["num2"], 2))
                f.seek(963635+80*j+12)
                f.write(give(i["type"], 4))
                f.seek(963635+80*j+24)
                f.write(give(i["order"], 4))
                f.seek(963635+80*j+36)
                f.write(give(i["white"], 2))
                f.seek(963635+80*j+38)
                f.write(give(i["red"], 2))
                f.seek(963635+80*j+40)
                f.write(give(i["gold"], 2))
                for flag in range(6): #always 6?
                    f.write(give(i["flags"][flag]))

                j+=1

            #write equipment back
            j=0
            for i in equipmentlist:
                f.seek(103587+63*j+0)
                f.write(give(i["num1"], 2))
                f.seek(103587+63*j+2)
                f.write(give(i["num2"], 2))
                f.seek(103587+63*j+12)
                f.write(give(i["type"], 4))
                f.seek(103587+63*j+24)
                f.write(give(i["order"], 4))
                f.seek(103587+63*j+36)
                f.write(give(i["amount"], 2))
                f.seek(103587+63*j+46)
                f.write(give(i["used"]))

                j+=1