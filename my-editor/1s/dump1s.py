#!/opt/local/bin/python3
# coding: utf-8

"""
dump1s.py

======

The MIT License (MIT)

Copyright (c) 2023 Togenyan, Emilia

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


def edit_yokai(yokailist, index, yokai=None, attitude=None, nickname=None, IV=None, EV=None): #massively overcomplicated and broken simultaneously 
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
            yokailist[index]["id"] = yokai
    try:
        yokailist[index]["nickname"] = yokailist[index]["nickname"]
    except:
        yokailist[index]["nickname"] = ""
    if nickname != None: #may cause problems
        yokailist[index]["nickname"] = nickname
    yokailist[index]["attack"] = 255 
    yokailist[index]["technique"] = 255
    yokailist[index]["soultimate"] = 255
    
    if IV == None: # IV1
        IV = [2,2,2,2,2]
    else:
        if sum(IV) != 10:
            IV = [2,2,2,2,2]
    if EV == None:
        EV = [4,4,4,4,4]
    else:
        if sum(EV) != 20:
            EV = [4,4,4,4,4]
    
    yokailist[index]["stats"] = { #HP must be even
        "TIV_HP": TIVs[yokailist[index]["id"]][0], 
        "TIV_Str": TIVs[yokailist[index]["id"]][1], 
        "TIV_Spr": TIVs[yokailist[index]["id"]][2], 
        "TIV_Def": TIVs[yokailist[index]["id"]][3], 
        "TIV_Spd": TIVs[yokailist[index]["id"]][4], 
        "IV1_HP": IV[0], #sums to 10
        "IV1_Str": IV[1], 
        "IV1_Spr": IV[2], 
        "IV1_Def": IV[3], 
        "IV1_Spd": IV[4], 
        "IV2_HP": 15, # ingame max is 3, still needs testing
        "IV2_Str": 15, 
        "IV2_Spr": 15, 
        "IV2_Def": 15,  
        "IV2_Spd": 15,  
        "EV_HP": EV[0], #sums to 20
        "EV_Str": EV[1], 
        "EV_Spr": EV[2], 
        "EV_Def": EV[3], 
        "EV_Spd": EV[4], 
    }
    yokailist[index]["level"] = 255
    try: # this is for appending, which is currently broken
        yokailist[index]["attitude"] = yokailist[index]["attitude"]
    except:
        yokailist[index]["attitude"] = 0
    if attitude != None:
        try:
            yokailist[index]["attitude"] = attitudes.index(attitude)
        except:
            yokailist[index]["attitude"] = attitudes[attitude]

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
    if amount:
        itemlist[index]["amount"] = amount
    return itemlist

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
    if amount:
        equipmentlist[index]["amount"] = amount
    equipmentlist[index]["used"] = 0
    return equipmentlist

def edit_important(importantlist, index, important):
    try:
        if index < 0:
            index = len(importantlist)-index #appending shortcut
    except:
        pass
    try:
        importantlist[index]
    except:
        index = len(importantlist)
        importantlist.append({})
    importantlist[index]["num1"] = index
    importantlist[index]["num2"] = index+1
    try:
        importantlist[index]["important"] = reverse_importants[important]
    except:
        importantlist[index]["important"] = important
    return importantlist


#main
def main(file): #TODO fix yokai. medalium
    try:
        file = open(file, "r+b")
    except:
        import io
        file = io.BytesIO(file)
    with file as f:
        yokailist = []
        index = 0
        f.seek(7696) #1 yokai takes up 124 bytes.
        while True:
            yokai = f.read(124)
            if get(yokai, 0) == 0 and index != 0: #could be broken
                break

            yokailist.append({
                "num1": get(yokai, 0, 2), #0
                "num2": get(yokai, 2, 2), #2
                "id": get(yokai, 4, 4), #4-07
                "nickname": get(yokai, 8, 68, False), #8-76 maybe broken
                "attack": get(yokai, 78),
                "technique": get(yokai, 82),
                "soultimate": get(yokai, 86),
                "stats": {
                    "TIV_HP": get(yokai, 96), 
                    "TIV_Str": get(yokai, 97), 
                    "TIV_Spr": get(yokai, 98), 
                    "TIV_Def": get(yokai, 99), 
                    "TIV_Spd": get(yokai, 100), 
                    "IV1_HP": get(yokai, 101, half=True)[1], #could swap these around but consistency is key...
                    "IV1_Str": get(yokai, 102, half=True)[1], 
                    "IV1_Spr": get(yokai, 103, half=True)[1], 
                    "IV1_Def": get(yokai, 104, half=True)[1], 
                    "IV1_Spd": get(yokai, 105, half=True)[1], 
                    "IV2_HP": get(yokai, 101, half=True)[0], 
                    "IV2_Str": get(yokai, 102, half=True)[0], 
                    "IV2_Spr": get(yokai, 103, half=True)[0], 
                    "IV2_Def": get(yokai, 104, half=True)[0], 
                    "IV2_Spd": get(yokai, 105, half=True)[0], 
                    "EV_HP": get(yokai, 106), 
                    "EV_Str": get(yokai, 107), 
                    "EV_Spr": get(yokai, 108), 
                    "EV_Def": get(yokai, 109), 
                    "EV_Spd": get(yokai, 110), 
                }, 
                "level": get(yokai, 116), 
                "attitude": get(yokai, 117), 
                #TODO loaf level, xp, HP, soul, held item & affection
                #"affection": get(yokai, 120), #this is wrong i think
            })

            index += 1
        original_yokai_amount = index

        itemlist = []
        index = 0
        f.seek(1784) #1 item takes up 12 bytes. 00
        while True:
            item = f.read(12)

            if get(item, 0) == 0 and index != 0: #could be broken
                break

            itemlist.append({
                "num1": get(item, 0, 2), #0
                "num2": get(item, 2, 2), #2
                "item": get(item, 4, 4), #4
                "amount": get(item, 8, 4) #8
            })

            index += 1
        original_item_amount = index

        equipmentlist = []
        index = 0
        f.seek(4868) #1 equipment takes up 16 bytes. 10
        while True:
            equipment = f.read(16)

            if get(equipment, 0) == 0 and index != 0: #could be broken
                break

            equipmentlist.append({
                "num1": get(equipment, 0, 1), #0
                "num2": get(equipment, 2, 1), #2
                "equipment": get(equipment, 4, 4), #4
                "amount": get(equipment, 8, 4), #8 #maybe 1 byte
                "used": get(equipment, 12, 4) #how many are in use (leave alone or set to zero)
            })

            index += 1
        original_equipment_amount = index

        importantlist = []
        index = 0
        f.seek(6480) #1 important takes up 8 bytes. 20
        while True:
            important = f.read(8)

            if get(important, 0) == 0 and index != 0: #could be broken
                break

            importantlist.append({
                "num1": get(important, 0, 1), #0
                "num2": get(important, 2, 1), #2 unsure.
                "important": get(important, 4, 4), #4
            })

            index += 1
        original_important_amount = index

        medalliumlist = [] # the way this works is weird. the first bit is always False (because there is no 0th yokai) and it's still in little endian so the bytes are backwards. the last 7 bits are unused (False) because the are no more yokai. maybe the unused space is the for future updates?
        f.seek(1476)
        medalliumlist.append(get(f.read(32), 0, 32, half=None)) # seen
        medalliumlist.append(get(f.read(32), 0, 32, half=None)) # befriended
        medalliumlist.append(get(f.read(32), 0, 32, half=None)) # seen
        medalliumlist.append(get(f.read(32), 0, 32, half=None)) # camera


        #editor goes here
        if 1: #appending yokai is currently broken TODO
            for i in range(len(yokailist)):
                edit_yokai(yokailist, i, "shogunyan", "rough", "", [3,4,0,0,3],[7,7,0,0,6])
        
        #print data 
        if 0:
            #print(", ".join([yokais[i["id"]]for i in yokailist]))

            print("\nseen yokai:")
            for i in range(246):
                if medalliumlist[0][i]: # medalliumlist[0][0] should never be true
                    print(indexs[i], end=", ")
            print("\nbefriended yokai:")
            for i in range(224): #got rid of printing boss yokai to avoid confusion, since seen boss yokai show up as befriended because otherwise you wouldn't be able to see their profile
                if medalliumlist[1][i]: # medalliumlist[1][0] should never be true. the boss yokai are just weird i think
                    print(indexs[i], end=", ")
            print("\nnew yokai:")
            for i in range(246):
                if medalliumlist[2][i]: # medalliumlist[2][0] should never be true. the boss yokai are just weird i think
                    print(indexs[i], end=", ")
            print("\ncamera yokai:")
            for i in range(246):
                if medalliumlist[3][i]: # medalliumlist[3][0] should never be true. the boss yokai are just weird i think
                    print(indexs[i], end=", ")

        #write everything back to file TODO
        if 1:
            #write items back
            j=0
            for i in itemlist:
                f.seek(1784+12*j)
                f.write(i["num1"].to_bytes(1, "little")) 
                f.seek(1784+12*j+2)
                f.write(i["num2"].to_bytes(2, "little"))
                f.seek(1784+12*j+4)
                f.write(i["item"].to_bytes(4, "little"))
                f.seek(1784+12*j+8)
                f.write(i["amount"].to_bytes(4, "little"))
                j+=1
            
            #clear item overflow
            if original_item_amount - len(itemlist) > 0:
                f.seek(1784+12*j)
                f.write(b"\x00"*12*(original_item_amount - len(itemlist)))

            #write equipment back
            j=0
            for i in equipmentlist:
                f.seek(4868+16*j)
                f.write(i["num1"].to_bytes(2, "little"))
                f.seek(4868+16*j+1)
                f.write(b"\x10") # i don't know what this does, may be unnecessary
                f.seek(4868+16*j+2)
                f.write(i["num2"].to_bytes(2, "little"))
                f.seek(4868+16*j+4)
                f.write(i["equipment"].to_bytes(4, "little"))
                f.seek(4868+16*j+8)
                f.write(i["amount"].to_bytes(4, "little"))
                f.seek(4868+16*j+12)
                f.write(i["used"].to_bytes(4, "little"))
                j+=1

            #clear equipment overflow
            if original_equipment_amount - len(equipmentlist) > 0:
                f.seek(4868+16*j)
                f.write(b"\x00"*16*(original_equipment_amount - len(equipmentlist)))

            #write important back
            j=0
            for i in importantlist:
                f.seek(6480+8*j)
                f.write(i["num1"].to_bytes(2, "little"))
                f.seek(6480+8*j+1)
                f.write(b"\x20") # i don't know what this does, may be unnecessary
                f.seek(6480+8*j+2)
                f.write(i["num2"].to_bytes(2, "little"))
                f.seek(6480+8*j+4)
                f.write(i["important"].to_bytes(4, "little"))
                j+=1

            #clear important overflow
            if original_important_amount - len(importantlist) > 0:
                f.seek(6480+8*j)
                f.write(b"\x00"*8*(original_important_amount - len(importantlist)))
            
            #write yokai back
            j=0
            for i in yokailist:
                f.seek(7696+124*j)
                f.write(i["num1"].to_bytes(2, "little"))
                f.seek(7696+124*j+2)
                f.write(i["num2"].to_bytes(2, "little"))
                f.seek(7696+124*j+4)
                f.write(i["id"].to_bytes(4, "little"))
                f.seek(7696+124*j+8)
                f.write((bytearray(list(i["nickname"].encode('utf-8')))+bytearray(60))[:60])
                f.seek(7696+124*j+78)
                f.write(i["attack"].to_bytes(1, "little"))
                f.seek(7696+124*j+82)
                f.write(i["technique"].to_bytes(1, "little"))
                f.seek(7696+124*j+86)
                f.write(i["soultimate"].to_bytes(1, "little"))

                f.seek(7696+124*j+96)
                f.write(i["stats"]["TIV_HP"].to_bytes(1, "little"))
                f.seek(7696+124*j+97)
                f.write(i["stats"]["TIV_Str"].to_bytes(1, "little"))
                f.seek(7696+124*j+98)
                f.write(i["stats"]["TIV_Spr"].to_bytes(1, "little"))
                f.seek(7696+124*j+99)
                f.write(i["stats"]["TIV_Def"].to_bytes(1, "little"))
                f.seek(7696+124*j+100)
                f.write(i["stats"]["TIV_Spd"].to_bytes(1, "little"))
                f.seek(7696+124*j+101)
                f.write(int(f'{i["stats"]["IV1_HP"]:04b}'+f'{i["stats"]["IV2_HP"]:04b}', 2).to_bytes(1, "little"))
                f.seek(7696+124*j+102)
                f.write(int(f'{i["stats"]["IV1_Str"]:04b}'+f'{i["stats"]["IV2_Str"]:04b}', 2).to_bytes(1, "little"))
                f.seek(7696+124*j+103)
                f.write(int(f'{i["stats"]["IV1_Spr"]:04b}'+f'{i["stats"]["IV2_Spr"]:04b}', 2).to_bytes(1, "little"))
                f.seek(7696+124*j+104)
                f.write(int(f'{i["stats"]["IV1_Def"]:04b}'+f'{i["stats"]["IV2_Def"]:04b}', 2).to_bytes(1, "little"))
                f.seek(7696+124*j+105)
                f.write(int(f'{i["stats"]["IV1_Spd"]:04b}'+f'{i["stats"]["IV2_Spd"]:04b}', 2).to_bytes(1, "little"))
                f.seek(7696+124*j+106)
                f.write(i["stats"]["EV_HP"].to_bytes(1, "little"))
                f.seek(7696+124*j+107)
                f.write(i["stats"]["EV_Str"].to_bytes(1, "little"))
                f.seek(7696+124*j+108)
                f.write(i["stats"]["EV_Spr"].to_bytes(1, "little"))
                f.seek(7696+124*j+109)
                f.write(i["stats"]["EV_Def"].to_bytes(1, "little"))
                f.seek(7696+124*j+110)
                f.write(i["stats"]["EV_Spd"].to_bytes(1, "little"))

                f.seek(7696+124*j+116)
                f.write(i["level"].to_bytes(1, "little"))
                f.seek(7696+124*j+117)
                f.write(i["attitude"].to_bytes(1, "little"))
                # TODO more when i figure it out
                j+=1

            #clear yokai overflow
            if original_yokai_amount - len(yokailist) > 0:
                f.seek(7696+124*j)
                f.write(b"\x00"*124*(original_yokai_amount - len(yokailist)))

            #write medallium back
            f.seek(1476) # seen
            f.write(bytearray([int(''.join('1' if bit else '0' for bit in medalliumlist[0][i:i+8][::-1]), 2) for i in range(0, 256, 8)]))
            f.seek(1508) # befriended
            f.write(bytearray([int(''.join('1' if bit else '0' for bit in medalliumlist[1][i:i+8][::-1]), 2) for i in range(0, 256, 8)]))
            f.seek(1540) # new
            f.write(bytearray([int(''.join('1' if bit else '0' for bit in medalliumlist[2][i:i+8][::-1]), 2) for i in range(0, 256, 8)]))
            f.seek(1572) # camera
            f.write(bytearray([int(''.join('1' if bit else '0' for bit in medalliumlist[3][i:i+8][::-1]), 2) for i in range(0, 256, 8)]))

        f.seek(0)
        return f.read() #for the .yw files


infile = "/Users/emilia/Documents/dev/ykw/20230716-140104 XAW7/new.ywd"
#infile = "/Volumes/UNTITLED/switch/Checkpoint/saves/0x0100C0000CEEA000 0x0100C0000CEEA000/temp/game1.yw"

if infile[-3:] == "ywd":
    main(infile)
else: #TODO make compatible on windows
    from pathlib import Path
    import sys
    sys.path.insert(0, str(Path(__file__).resolve().parent.parent.parent)+"/save-tools") #TODO make compatible on windows
    import yw_save
    with open(infile, "r+b") as f:
        out = main(yw_save.yw_proc(f.read(), False)) #out is the edited binary data
        f.seek(0)
        f.write(yw_save.yw_proc(out, True))