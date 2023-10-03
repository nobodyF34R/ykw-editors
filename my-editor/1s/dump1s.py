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


def edit_yokai(yokailist, index, yokai=None, attitude=None, nickname=None, iv=None, ev=None, level=None): #massively overcomplicated and broken simultaneously 
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
            yokailist[index]["yokai"] = reverse_yokais[yokai]
        except:
            yokailist[index]["yokai"] = yokai
    try:
        yokailist[index]["nickname"] = yokailist[index]["nickname"]
    except:
        yokailist[index]["nickname"] = ""
    if nickname != None: #may cause problems
        yokailist[index]["nickname"] = nickname
    yokailist[index]["attack"] = 255 
    yokailist[index]["technique"] = 255
    yokailist[index]["soultimate"] = 255
    
    if iv == None: # iv1
        iv = [2,2,2,2,2]
    else:
        if sum(iv) != 10:
            iv = [2,2,2,2,2]
    if ev == None:
        ev = [4,4,4,4,4]
    else:
        if sum(ev) != 20:
            ev = [4,4,4,4,4]
    
    yokailist[index]["stats"] = { #hp must be even
        "tiv_hp": tivs[yokailist[index]["yokai"]][0], 
        "tiv_str": tivs[yokailist[index]["yokai"]][1], 
        "tiv_spr": tivs[yokailist[index]["yokai"]][2], 
        "tiv_def": tivs[yokailist[index]["yokai"]][3], 
        "tiv_spd": tivs[yokailist[index]["yokai"]][4], 
        "iv1_hp": iv[0], #sums to 10
        "iv1_str": iv[1], 
        "iv1_spr": iv[2], 
        "iv1_def": iv[3], 
        "iv1_spd": iv[4], 
        "iv2_hp": 15, # ingame max is 3, still needs testing
        "iv2_str": 15, 
        "iv2_spr": 15, 
        "iv2_def": 15,  
        "iv2_spd": 15,  
        "ev_hp": ev[0], #sums to 20
        "ev_str": ev[1], 
        "ev_spr": ev[2], 
        "ev_def": ev[3], 
        "ev_spd": ev[4], 
    }
    if level == None:
        yokailist[index]["level"] = 255
    else:
        yokailist[index]["level"] = level #if you want it to be 100 etc
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

def edit_item(itemlist, index, item=None, amount=None):
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
    equipmentlist[index]["num1"] = index+4096
    equipmentlist[index]["num2"] = index+1
    if equipment:
        try:
            equipmentlist[index]["equipment"] = reverse_equipments[equipment]
        except:
            equipmentlist[index]["equipment"] = equipment
    if amount:
        equipmentlist[index]["amount"] = amount
    equipmentlist[index]["used"] = 0 #could cause problems
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
    importantlist[index]["num1"] = index+8192
    importantlist[index]["num2"] = index+1
    try:
        importantlist[index]["important"] = reverse_importants[important]
    except:
        importantlist[index]["important"] = important
    return importantlist


#main
def main(f, edit):
    f.seek(20) #misc
    position = [get(f.read(4),0,4), get(f.read(4),0,4), get(f.read(4),0,4)] #x,y,z
    f.seek(112)
    location = get(f.read(7),0,7)
    f.seek(1752)
    time = get(f.read(2),0,2) # how many 0.? seconds have passed in the 6 hour window. NEED TO TEST
    f.seek(1754)
    sun = get(f.read(1),0) #keeps track of how many 6 hours have passed
    f.seek(37620)
    money = get(f.read(4),0,4)
    
    
    yokailist = []
    index = 0
    f.seek(7696) #1 yokai takes up 124 bytes.
    while True:
        yokai = f.read(124)
        if get(yokai, 0) == 0 and index != 0: #could be broken
            break

        yokailist.append({ #some of these might take 2 bytes instead of 1
            "num1": get(yokai, 0, 2), #0 starts from 0
            "num2": get(yokai, 2, 2), #2
            "yokai": get(yokai, 4, 4), #4-07
            "nickname": get(yokai, 8, 68, False), #8-76 maybe broken
            "attack": get(yokai, 78),
            "technique": get(yokai, 82),
            "soultimate": get(yokai, 86),
            "xp": get(yokai, 88,4),
            "hp": get(yokai, 92, 2), #current hp (if it's over the max, the game will bug out)
            "soul": get(yokai, 94, 2), #current soul gauge. could be 1 byte
            "stats": {
                "tiv_hp": get(yokai, 96), 
                "tiv_str": get(yokai, 97), 
                "tiv_spr": get(yokai, 98), 
                "tiv_def": get(yokai, 99), 
                "tiv_spd": get(yokai, 100), 
                "iv1_hp": get(yokai, 101, half=True)[1], #could swap these around but consistency is key...
                "iv1_str": get(yokai, 102, half=True)[1], 
                "iv1_spr": get(yokai, 103, half=True)[1], 
                "iv1_def": get(yokai, 104, half=True)[1], 
                "iv1_spd": get(yokai, 105, half=True)[1], 
                "iv2_hp": get(yokai, 101, half=True)[0], 
                "iv2_str": get(yokai, 102, half=True)[0], 
                "iv2_spr": get(yokai, 103, half=True)[0], 
                "iv2_def": get(yokai, 104, half=True)[0], 
                "iv2_spd": get(yokai, 105, half=True)[0], 
                "ev_hp": get(yokai, 106), 
                "ev_str": get(yokai, 107), 
                "ev_spr": get(yokai, 108),
                "ev_def": get(yokai, 109), 
                "ev_spd": get(yokai, 110), 
            }, 
            "level": get(yokai, 116), 
            "attitude": get(yokai, 117), 
            #TODO loaf level, held item & affection
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
            "num1": get(item, 0, 2), #0 starts from 0
            "num2": get(item, 2, 2), #2
            "item": get(item, 4, 4), #4
            "amount": get(item, 8) #8 up to 255
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
            "num1": get(equipment, 0, 2), #0 starts from 4096
            "num2": get(equipment, 2, 2), #2
            "equipment": get(equipment, 4, 4), #4
            "amount": get(equipment, 8), #8 up to 255
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
            "num1": get(important, 0, 2), #0 starts from 8192
            "num2": get(important, 2, 2), #2
            "important": get(important, 4, 4), #4
        })

        index += 1
    original_important_amount = index

    medalliumlist = [] # the way this works is weird. the first bit is always False (because there is no 0th yokai) and it's still in little endian so the bytes are backwards. the last 7 bits are unused (False) because the are no more yokai. maybe the unused space is there for future updates?
    f.seek(1476)
    medalliumlist.append(get(f.read(32), 0, 32, half=None)) # seen
    medalliumlist.append(get(f.read(32), 0, 32, half=None)) # befriended
    medalliumlist.append(get(f.read(32), 0, 32, half=None)) # new (pointless)
    medalliumlist.append(get(f.read(32), 0, 32, half=None)) # camera

    #edit
    time, sun, position, location, money, yokailist, itemlist, equipmentlist, importantlist, medalliumlist = edit(time, sun, position, location, money, yokailist, itemlist, equipmentlist, importantlist, medalliumlist)

    #write
    
    #misc
    f.seek(20)
    f.write(give(position[0], 4))
    f.write(give(position[1], 4))
    f.write(give(position[2], 4))
    f.seek(112)
    f.write(give(location, 7))
    f.seek(1752)
    f.write(give(time,2))
    f.write(give(sun))
    f.seek(37620)
    f.write(give(money, 4))

    #write items back
    j=0
    for i in itemlist:
        f.seek(1784+12*j)
        f.write(give(i["num1"], 2)) 
        f.seek(1784+12*j+2)
        f.write(give(i["num2"], 2))
        f.seek(1784+12*j+4)
        f.write(give(i["item"], 4))
        f.seek(1784+12*j+8)
        f.write(give(i["amount"], 4))
        j+=1
    
    #clear item overflow
    if original_item_amount - len(itemlist) > 0:
        f.seek(1784+12*j)
        f.write(b"\x00"*12*(original_item_amount - len(itemlist)))

    #write equipment back
    j=0
    for i in equipmentlist:
        f.seek(4868+16*j)
        f.write(give(i["num1"], 2))
        f.seek(4868+16*j+2)
        f.write(give(i["num2"], 2))
        f.seek(4868+16*j+4)
        f.write(give(i["equipment"], 4))
        f.seek(4868+16*j+8)
        f.write(give(i["amount"], 4))
        f.seek(4868+16*j+12)
        f.write(give(i["used"], 4))
        j+=1

    #clear equipment overflow
    if original_equipment_amount - len(equipmentlist) > 0:
        f.seek(4868+16*j)
        f.write(b"\x00"*16*(original_equipment_amount - len(equipmentlist)))

    #write important back
    j=0
    for i in importantlist:
        f.seek(6480+8*j)
        f.write(give(i["num1"], 2))
        f.seek(6480+8*j+2)
        f.write(give(i["num2"], 2))
        f.seek(6480+8*j+4)
        f.write(give(i["important"], 4))
        j+=1

    #clear important overflow
    if original_important_amount - len(importantlist) > 0:
        f.seek(6480+8*j)
        f.write(b"\x00"*8*(original_important_amount - len(importantlist)))

    #write yokai back
    j=0
    for i in yokailist:
        f.seek(7696+124*j)
        f.write(give(i["num1"], 2))
        f.seek(7696+124*j+2)
        f.write(give(i["num2"], 2))
        f.seek(7696+124*j+4)
        f.write(give(i["yokai"], 4))
        f.seek(7696+124*j+8)
        f.write(give(i["nickname"], 60, False))
        f.seek(7696+124*j+78)
        f.write(give(i["attack"]))
        f.seek(7696+124*j+82)
        f.write(give(i["technique"]))
        f.seek(7696+124*j+86)
        f.write(give(i["soultimate"]))

        f.seek(7696+124*j+96)
        f.write(give(i["stats"]["tiv_hp"]))
        f.seek(7696+124*j+97)
        f.write(give(i["stats"]["tiv_str"]))
        f.seek(7696+124*j+98)
        f.write(give(i["stats"]["tiv_spr"]))
        f.seek(7696+124*j+99)
        f.write(give(i["stats"]["tiv_def"]))
        f.seek(7696+124*j+100)
        f.write(give(i["stats"]["tiv_spd"]))
        f.seek(7696+124*j+101)
        f.write(give([i["stats"]["iv2_hp"], i["stats"]["iv1_hp"]], half=True)) #sloppy. TODO add stuff like this to the give function
        f.seek(7696+124*j+102)
        f.write(give([i["stats"]["iv2_str"], i["stats"]["iv1_str"]], half=True))
        f.seek(7696+124*j+103)
        f.write(give([i["stats"]["iv2_spr"], i["stats"]["iv1_spr"]], half=True))
        f.seek(7696+124*j+104)
        f.write(give([i["stats"]["iv2_def"], i["stats"]["iv1_def"]], half=True))
        f.seek(7696+124*j+105)
        f.write(give([i["stats"]["iv2_spd"], i["stats"]["iv1_spd"]], half=True))
        f.seek(7696+124*j+106)
        f.write(give(i["stats"]["ev_hp"]))
        f.seek(7696+124*j+107)
        f.write(give(i["stats"]["ev_str"]))
        f.seek(7696+124*j+108)
        f.write(give(i["stats"]["ev_spr"]))
        f.seek(7696+124*j+109)
        f.write(give(i["stats"]["ev_def"]))
        f.seek(7696+124*j+110)
        f.write(give(i["stats"]["ev_spd"]))

        f.seek(7696+124*j+116)
        f.write(give(i["level"]))
        f.seek(7696+124*j+117)
        f.write(give(i["attitude"]))
        # TODO more when i figure it out
        j+=1

    #clear yokai overflow
    if original_yokai_amount - len(yokailist) > 0:
        f.seek(7696+124*j)
        f.write(b"\x00"*124*(original_yokai_amount - len(yokailist)))

    #write medallium back
    f.seek(1476) # seen
    f.write(give(medalliumlist[0], 256, half=None))
    f.seek(1508) # befriended
    f.write(give(medalliumlist[1], 256, half=None))
    f.seek(1540) # new
    f.write(give(medalliumlist[2], 256, half=None))
    f.seek(1572) # camera
    f.write(give(medalliumlist[3], 256, half=None))

    f.seek(0)
    return f.read() #for the .yw files