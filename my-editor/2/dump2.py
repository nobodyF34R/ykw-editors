#!/opt/local/bin/python3
# coding: utf-8

"""
dump2.py

======

The MIT License (MIT)

Copyright (c) 2023 Togenyan, nobody_fear

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
            return finished

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


def edit_yokai(yokailist, index, ownerid, yokai=None, attitude=None, nickname=None, iv=None, ev=None): #massively overcomplicated and broken simultaneously 
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
            yokailist[index]["type"] = reverse_yokais[yokai]
        except:
            yokailist[index]["type"] = yokai
    try:
        yokailist[index]["nickname"] = yokailist[index]["nickname"]
    except:
        yokailist[index]["nickname"] = ""
    if nickname != None: #may cause problems
        yokailist[index]["nickname"] = nickname
    yokailist[index]["attack"] = 255 
    yokailist[index]["technique"] = 255
    yokailist[index]["soultimate"] = 255
    yokailist[index]["xp"] = 0 #0 because level is 99
    yokailist[index]["ownerid"] = ownerid
    if iv == None:
        iv = [16,8,8,8,8]
    else:
        if sum(iv) - iv[0]/2 != 40: #will complain if hp is odd so no need to check for that
            iv = [16,8,8,8,8]
    if ev == None:
        ev = [8,4,4,4,4]
    else:
        if sum(ev) - ev[0]/2 != 20:
            ev = [8,4,4,4,4]
    yokailist[index]["stats"] = { #hp must be even
        "iv_hp": iv[0], #iv rules: hp / 2 + Str + Spr + Def + Spd = 40
        "iv_str": iv[1], 
        "iv_spr": iv[2], 
        "iv_def": iv[3], 
        "iv_spd": iv[4], 
        "ev_hp": ev[0], #ev rules: hp / 2 + Str + Spr + Def + Spd <= 20
        "ev_str": ev[1], 
        "ev_spr": ev[2], 
        "ev_def": ev[3], 
        "ev_spd": ev[4], 
        "sc_hp": 0, #brokennnnn (probably written in a different way) +25, -10 per stat TODO figure out. 15?
        "sc_str": 0, 
        "sc_spr": 0, 
        "sc_def": 0,
        "sc_spd": 0  
    }
    yokailist[index]["level"] = 99 #255 works too but it automatically lowers to 99
    yokailist[index]["loaflevel"] = 5 #2?
    try:
        yokailist[index]["attitude"] = yokailist[index]["attitude"] #for appending
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
            itemlist[index]["type"] = reverse_items[item]
        except:
            itemlist[index]["type"] = item
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
            equipmentlist[index]["type"] = reverse_equipments[equipment]
        except:
            equipmentlist[index]["type"] = equipment
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
    importantlist[index]["num1"] = index+8192
    importantlist[index]["num2"] = index+1
    try:
        importantlist[index]["type"] = reverse_importants[important]
    except:
        importantlist[index]["type"] = important
    return importantlist

def edit_soul(soullist, index, soul):
    try:
        if index < 0:
            index = len(soullist)-index #appending shortcut (semi-redundant)
    except:
        pass
    try:
        soullist[index]
    except:
        index = len(soullist)
        soullist.append({})
    soullist[index]["num1"] = index+12288
    soullist[index]["num2"] = index+1
    try:
        soullist[index]["type"] = reverse_souls[soul]
    except:
        soullist[index]["type"] = soul
    soullist[index]["xp"] = 0 #65535 is too high but it already auto sets back to 0
    soullist[index]["level"] = 10 #10 is the highest (255 looks funny but it is weaker than 10 because of the way the game calculates soul stats)
    soullist[index]["used"] = 0
    return soullist

def edit_contact(contactlist, index, readable=True, name=None, starred=None, ownerid=None, comment=None, favourite=None, game=None, face=None, hq=None, job=None, hobby=None, ambition=None, yokai=None): #can alse be used for profile
    # if readable is true, there will be no overlapping text. if it's false then values will be their limits (255)
    try:
        if index < 0:
            index = len(contactlist)-index #appending shortcut (semi-redundant)
    except:
        pass
    dicti = False
    if isinstance(contactlist, dict): #for your profile
        dicti = True
        index = 0
        contactlist = [contactlist]
    else:
        try:
            contactlist[index]
        except:
            index = len(contactlist)
            contactlist.append({})
    if name != None:
        contactlist[index]["name"] = name
    if starred != None:
        contactlist[index]["name"] = starred #0 or 1
    if ownerid != None:
        contactlist[index]["ownerid"] = ownerid
    if comment != None:
        contactlist[index]["comment"] = comment
    if favourite != None:
        contactlist[index]["favourite"] = favourite
    contactlist[index]["bronze"] = 99 if readable else 255
    contactlist[index]["silver"] = 99 if readable else 255
    contactlist[index]["gold"] = 99 if readable else 255
    if game != None:
        contactlist[index]["game"] = game
    contactlist[index]["playtime"] = 4659.9997222222222 #ingame max is 999.9997222222222
    contactlist[index]["tunnel"] = 9999999 if readable else 2147483647
    if face != None:
        contactlist[index]["face"] = face
    if hq != None:
        try:
            contactlist[index]["hq"] = hqs.index(hq)
        except:
            contactlist[index]["hq"] = hq
        contactlist[index]["hq"] = hq
    if job != None:
        try:
            contactlist[index]["job"] = jobs.index(job)
        except:
            contactlist[index]["job"] = job
    if hobby != None:
        try:
            contactlist[index]["hobby"] = hobbys.index(hobby)
        except:
            contactlist[index]["hobby"] = hobby
    if ambition != None:
        try:
            contactlist[index]["ambition"] = ambitions.index(ambition)
        except:
            contactlist[index]["ambition"] = ambition
    contactlist[index]["requests"] = 255
    contactlist[index]["arrested"] = 255
    contactlist[index]["medallium"] = 255 #fake percentage (100)
    contactlist[index]["bugs"] = 255
    contactlist[index]["fish"] = 255
    contactlist[index]["battles"] = 255
    contactlist[index]["battles"] = 255
    contactlist[index]["personal"] = 65535
    contactlist[index]["public"] = 9999 if readable else 65535
    contactlist[index]["rankl"] = 65535
    contactlist[index]["local"] = 99 if readable else 65535
    contactlist[index]["rankr"] = 65535
    contactlist[index]["random"] = 65535
    contactlist[index]["tagged"] = 65535
    contactlist[index]["photographs"] = 65535
    if yokai != None:
        contactlist[index]["yokai"] = yokai
    contactlist[index]["races"] = [.01,.01,.01,.01] #could use 0.00001 so it shows as a 0 in the game
    if dicti:
        return contactlist[0]
    else:
        return contactlist


#main
def main(file, edit): #TODO fix yokai.
    try:
        file = open(file, "r+b")
    except:
        import io
        file = io.BytesIO(file)
    with file as f:
        # f.seek(20) #misc
        # position = [get(f.read(4),0,4), get(f.read(4),0,4), get(f.read(4),0,4)] #x,y,z
        # f.seek(72)
        # location = get(f.read(8),0,8)
        f.seek(67808)
        money = get(f.read(4),0,4)

        yokailist = []
        index = 0
        f.seek(20744) # 20744 is always yokai info location. 1 yokai takes up 92 bytes. offset same for all files. 00
        while True:
            yokai = f.read(92)
            if get(yokai, 2, 2) == 0:
                break

            yokailist.append({
                "num1": get(yokai, 0, 2), #0 starts from 0
                "num2": get(yokai, 2, 2), #2
                "type": get(yokai, 4, 4), #4-07
                "nickname": get(yokai, 8, 24, False), #8-32 maybe broken
                "attack": get(yokai, 42), #42
                "technique": get(yokai, 46), #46
                "soultimate": get(yokai, 50), #50
                "xp": get(yokai, 52, 4), #52 - 55
                "ownerid": get(yokai, 60, 4), #60 - 63
                "stats": { # 64 - 78
                    "iv_hp": get(yokai, 64), 
                    "iv_str": get(yokai, 65), 
                    "iv_spr": get(yokai, 66), 
                    "iv_def": get(yokai, 67), 
                    "iv_spd": get(yokai, 68), 
                    "ev_hp": get(yokai, 69), 
                    "ev_str": get(yokai, 70), 
                    "ev_spr": get(yokai, 71), 
                    "ev_def": get(yokai, 72), 
                    "ev_spd": get(yokai, 73), 
                    "sc_hp": get(yokai, 74), 
                    "sc_str": get(yokai, 75), 
                    "sc_spr": get(yokai, 76), 
                    "sc_def": get(yokai, 77), 
                    "sc_spd": get(yokai, 78)
                }, 
                "level": get(yokai, 79), #79
                "loaflevel": get(yokai, 84, half=True)[0], #84
                "attitude": get(yokai, 84, half=True)[1] #84 (shared byte)
            })

            index += 1
        original_yokai_amount = index

        #offset at the location "\xFE\x6D\x08\xFE\xFF\x00\x00\x03\x48\x24\x00\xFE\xFF" + 19th byte aka item location
        f.seek(0)
        offset = f.read(20744).index(b"\xFE\x6D\x08\xFE\xFF\x00\x00\x03\x48\x24\x00\xFE\xFF")+19 #there's probably a better way to do this

        itemlist = []
        index = 0
        f.seek(offset) # offset is item info location. 1 item takes up 12 bytes. 00
        while True:
            item = f.read(12)

            if get(item, 2, 2) == 0:
                break

            itemlist.append({
                "num1": get(item, 0, 2), #0 starts from 0
                "num2": get(item, 2, 2), #2
                "type": get(item, 4, 4), #4
                "amount": get(item, 8, 4) #8
            })

            index += 1
        original_item_amount = index

        equipmentlist = []
        index = 0
        f.seek(offset+5172) # offset + 5172 is equipment info location. 1 equipment takes up 16 bytes. 10
        while True:
            equipment = f.read(16)

            if get(equipment, 2, 2) == 0:
                break

            equipmentlist.append({
                "num1": get(equipment, 0, 2), #0 starts from 4096
                "num2": get(equipment, 2, 2), #2
                "type": get(equipment, 4, 4), #4
                "amount": get(equipment, 8, 4), #8 #maybe 1 byte
                "used": get(equipment, 12, 4) #how many are in use (leave alone or set to zero)
            })

            index += 1
        original_equipment_amount = index

        importantlist = []
        index = 0
        f.seek(offset+6624) # offset + 6624 is important info location. 1 important takes up 8 bytes. 20
        while True:
            important = f.read(8)

            if get(important, 2, 2) == 0:
                break

            importantlist.append({
                "num1": get(important, 0, 2), #0 starts from 8192
                "num2": get(important, 2, 2), #2
                "type": get(important, 4, 4), #4
            })

            index += 1
        original_important_amount = index

        soullist = []
        index = 0
        f.seek(offset+8076) # offset + 8076 is soul info location. 1 soul takes up 12 bytes. 30
        while True:
            soul = f.read(12)

            if get(soul, 2, 2) == 0:
                break

            soullist.append({
                "num1": get(soul, 0, 2), #0 starts from 12288
                "num2": get(soul, 2, 2), #2
                "type": get(soul, 4, 4), #4
                "xp": get(soul, 8, 2), #8
                "level": get(soul, 10), #8
                "used": get(soul, 11) #11 true or false
            })

            index += 1
        original_soul_amount = index

        #extra stuff TODO add stuff like story progression
        f.seek(20744)
        postyokai = f.read() #for the stuff below that i commented out TODO
        unknown = postyokai.index(b"\xfe\xff\xd5\x08\x14\x90\x24\x00")+8+20744
        f.seek(unknown)  # this is your profile info location. your profile takes up 156 bytes
        contact = f.read(156)
        profile = { #name & playtime is stored in the head file (can decrypt head.yw as a yokai watch 1 save. may impliment in the future)
            "ownerid": get(contact, 0, 4),
            "comment": get(contact, 4, 64, False),
            "favourite": get(contact, 68, 4), #favourite yokai (by choice),
            "bronze": get(contact, 72), #what medals they have
            "silver": get(contact, 73),
            "gold": get(contact, 74),
            "game": get(contact, 75),
            "playtime": get(contact, 76, 3)/3600, #in hours
            #00 inbetween
            "tunnel": get(contact, 80, 4),
            "face": get(contact, 84, 4), #can be a yokai or human, etc.
            "hq": get(contact, 88),
            "job": get(contact, 89),
            "hobby": get(contact, 90),
            "ambition": get(contact, 91), 
            #00 inbetween
            "requests": get(contact, 93), #i can't remember what this is lol
            "arrested": get(contact, 94), #yo-criminals
            "medallium": get(contact, 95), #percentage
            "bugs": get(contact, 96),
            "fish": get(contact, 97),
            "battles": get(contact, 98),
            #something here?
            "personal": get(contact, 100, 2), #best tournament run, may have to remove ", 2"
            "public": get(contact, 102, 2), #best public tournament run
            "rankl": get(contact, 104, 2), #wether you're a beginner or master in local battles TODO look into this
            "local": get(contact, 106, 2), #local battle wins
            "rankr": get(contact, 108, 2),
            "random": get(contact, 110, 2),
            "tagged": get(contact, 112, 2),
            "photographs": get(contact, 114, 2),
            "yokai": [ #favourite yokai 1-6 (by playtime),
                get(contact, 116, 4), #if it is a 0 then there is no yokai in the slot. (early game)
                get(contact, 120, 4),
                get(contact, 124, 4),
                get(contact, 128, 4),
                get(contact, 132, 4),
                get(contact, 136, 4)
            ],
            "races": [ #if it is a 0 then the race has not been completed. in minutes (floating point) displays in-game to two decimal places without rounding
                get(contact, 140, 4, None), #uptown springdale
                get(contact, 144, 4, None), #harrisville
                get(contact, 148, 4, None), #san fantastico
                get(contact, 152, 4, None), #(old) springdale
            ]
        }

        contactlist = []
        index = 0
        while True: # this is the contact info location. 1 contact takes up 184 bytes
            contact = f.read(184)

            if get(contact, 0) == 0:
                break

            contactlist.append({ #max 50 contacts
                "name": get(contact, 0, 25, False), #max length is 24 with a 00 on the end
                "starred": get(contact, 26), #true or false (1 or 0)
                #00 inbetween
                "ownerid": get(contact, 28, 4),
                "comment": get(contact, 32, 64, False),
                "favourite": get(contact, 96, 4), #favourite yokai (by choice),
                "bronze": get(contact, 100), #what medals they have
                "silver": get(contact, 101),
                "gold": get(contact, 102),
                "game": get(contact, 103),
                "playtime": get(contact, 104, 3)/3600, #in hours
                #00 inbetween
                "tunnel": get(contact, 108, 4),
                "face": get(contact, 112, 4), #can be a yokai or human, etc.
                "hq": get(contact, 116),
                "job": get(contact, 117),
                "hobby": get(contact, 118),
                "ambition": get(contact, 119), 
                #00 inbetween
                "requests": get(contact, 121), #i can't remember what this is lol
                "arrested": get(contact, 122), #yo-criminals
                "medallium": get(contact, 123), #percentage
                "bugs": get(contact, 124),
                "fish": get(contact, 125),
                "battles": get(contact, 126),
                #something here?
                "personal": get(contact, 128, 2), #best tournament run, may have to remove ", 2"
                "public": get(contact, 130, 2), #best public tournament run
                "rankl": get(contact, 132, 2), #wether you're a beginner or master in local battles TODO look into this
                "local": get(contact, 134, 2), #local battle wins
                "rankr": get(contact, 132, 2),
                "random": get(contact, 138, 2),
                "tagged": get(contact, 140, 2),
                "photographs": get(contact, 142, 2),
                "yokai": [ #favourite yokai 1-6 (by playtime),
                    get(contact, 144, 4),
                    get(contact, 148, 4),
                    get(contact, 152, 4),
                    get(contact, 156, 4),
                    get(contact, 160, 4),
                    get(contact, 164, 4)
                ],
                "races": [ #if it is a 0 then the race has not been completed. in minutes (floating point)
                    get(contact, 168, 4, None), #uptown springdale
                    get(contact, 172, 4, None), #harrisville
                    get(contact, 176, 4, None), #san fantastico
                    get(contact, 180, 4, None), #(old) springdale
                ]
            })

            index += 1
        original_contact_amount = index

        medalliumlist = [] # the way this works is weird. the first bit is always False (because there is no 0th yokai) and it's still in big endian so the bytes are backwards. the last 7 bits are unused (False) because the are no more yokai. maybe the unused space is the for updates? (64 bits total)
        f.seek(1460) # seen
        medalliumlist.append(get(f.read(57), 0, 57, half=None))
        f.seek(1524) # befriended
        medalliumlist.append(get(f.read(57), 0, 57, half=None)) #seen boss yokai show up as befriended because otherwise you wouldn't be able to see their profile
        f.seek(1588) # new 
        medalliumlist.append(get(f.read(57), 0, 57, half=None)) #the ones that say new in the medallium
        f.seek(1652) # camera
        medalliumlist.append(get(f.read(57), 0, 57, half=None))

        # f.seek(postyokai.index(b"\xff\xfe\x6b\x08\xfe\xff")+20744) #!P & T ..... currently i have no idea what this is or how to use it. part of it is probably story progress, etc
        # unknown1 = f.read(150) #138
        # # f.seek(postyokai.index(b"\xff\xfe\xd5\x08\xfe\xff\xd5\x08\x15")+20744) maybe this T
        # # unknown15 = f.read(10)
        # f.seek(postyokai.index(b"\xff\xfe\xd5\x08\xfe\xff\xd5\x08\x12")+20744) #N`
        # unknown2 = f.read(49)
        # f.seek(postyokai.index(b"\xff\xfe\xd5\x08\xfe\xff\xd5\x08\x0e\x00")+20744) #wArt
        # unknown3 = f.read(1036)
        # f.seek(postyokai.index(b"\xff\xfe\xd5\x08\xfe\xff\x00\x00\x08")+20744) #<==>
        # unknown4 = f.read(272)
        # f.seek(postyokai.index(b"\xff\xfe\x47\x08\xfe")+20744) #??@@AABBCCDD
        # unknown5 = f.read(1636)

        #editor goes here
        if edit: #appending yokai is currently broken TODO
            yokailist, itemlist, equipmentlist, importantlist, soullist, medalliumlist, profile, contactlist = edit(yokailist, itemlist, equipmentlist, importantlist, soullist, medalliumlist, profile, contactlist)

        #write everything back to file
        if 1:
            f.seek(67808)
            f.write(give(money, 4))
            #write items back
            j=0
            for i in itemlist:
                f.seek(offset+12*j)
                f.write(give(i["num1"], 2)) 
                f.seek(offset+12*j+2)
                f.write(give(i["num2"], 2))
                f.seek(offset+12*j+4)
                f.write(give(i["type"], 4))
                f.seek(offset+12*j+8)
                f.write(give(i["amount"], 4))
                j+=1
            
            #clear item overflow
            if original_item_amount - len(itemlist) > 0:
                f.seek(offset+12*j)
                f.write(b"\x00"*12*(original_item_amount - len(itemlist)))

            #write equipment back
            j=0
            for i in equipmentlist:
                f.seek(offset+5172+16*j)
                f.write(give(i["num1"], 2))
                f.seek(offset+5172+16*j+2)
                f.write(give(i["num2"], 2))
                f.seek(offset+5172+16*j+4)
                f.write(give(i["type"], 4))
                f.seek(offset+5172+16*j+8)
                f.write(give(i["amount"], 4))
                f.seek(offset+5172+16*j+12)
                f.write(give(i["used"], 4))
                j+=1

            #clear equipment overflow
            if original_equipment_amount - len(equipmentlist) > 0:
                f.seek(offset+5172+16*j)
                f.write(b"\x00"*16*(original_equipment_amount - len(equipmentlist)))

            #write important back
            j=0
            for i in importantlist:
                f.seek(offset+6624+8*j)
                f.write(give(i["num1"], 2))
                f.seek(offset+6624+8*j+2)
                f.write(give(i["num2"], 2))
                f.seek(offset+6624+8*j+4)
                f.write(give(i["type"], 4))
                j+=1

            #clear important overflow
            if original_important_amount - len(importantlist) > 0:
                f.seek(offset+6624+8*j)
                f.write(b"\x00"*8*(original_important_amount - len(importantlist)))

            #write soul back
            j=0
            for i in soullist:
                f.seek(offset+8076+12*j)
                f.write(give(i["num1"], 2))
                f.seek(offset+8076+12*j+2)
                f.write(give(i["num2"], 2))
                f.seek(offset+8076+12*j+4)
                f.write(give(i["type"], 4))
                f.seek(offset+8076+12*j+8)
                f.write(give(i["xp"], 2))
                f.seek(offset+8076+12*j+10)
                f.write(give(i["level"]))
                f.seek(offset+8076+12*j+11)
                f.write(give(i["used"]))
                j+=1

            #clear soul overflow
            if original_soul_amount - len(soullist) > 0:
                f.seek(offset+8076+12*j)
                f.write(b"\x00"*12*(original_soul_amount - len(soullist)))

            #write yokai back
            j=0
            for i in yokailist:
                f.seek(20744+92*j)
                f.write(give(i["num1"], 2))
                f.seek(20744+92*j+2)
                f.write(give(i["num2"], 2))
                f.seek(20744+92*j+4)
                f.write(give(i["type"], 4))
                f.seek(20744+92*j+8)
                f.write(give(i["nickname"], 24, False)) # to be more accurate to game could just append with trailing 00
                f.seek(20744+92*j+42)
                f.write(give(i["attack"]))
                f.seek(20744+92*j+46)
                f.write(give(i["technique"]))
                f.seek(20744+92*j+50)
                f.write(give(i["soultimate"]))
                f.seek(20744+92*j+52)
                f.write(give(i["xp"], 4))
                f.seek(20744+92*j+60)
                f.write(give(i["ownerid"], 4))
                statnum = 64
                for stat in i["stats"]:
                    f.seek(20744+92*j+statnum)
                    f.write(give(i["stats"][stat]))
                    statnum +=1
                f.seek(20744+92*j+79)
                f.write(give(i["level"]))
                f.seek(20744+92*j+84)
                f.write(give([i["loaflevel"], i["attitude"]], half=True))
                j+=1

            #clear yokai overflow
            if original_yokai_amount - len(yokailist) > 0:
                f.seek(20744+92*j)
                f.write(b"\x00"*92*(original_yokai_amount - len(yokailist)))

            #write profile back (the beginning part of your contact list)
            f.seek(unknown)
            f.write(give(profile["ownerid"], 4))
            f.write(give(profile["comment"], 64, False))
            f.write(give(profile["favourite"], 4))
            f.write(give(profile["bronze"]))
            f.write(give(profile["silver"]))
            f.write(give(profile["gold"]))
            f.write(give(profile["game"]))
            f.write(give(int(profile["playtime"]*3600), 3)) #may cause problems
            f.seek(unknown+80)
            f.write(give(profile["tunnel"], 4))
            f.write(give(profile["face"], 4))
            f.write(give(profile["hq"]))
            f.write(give(profile["job"]))
            f.write(give(profile["hobby"]))
            f.write(give(profile["ambition"]))
            f.seek(unknown+93)
            #00 inbetween
            f.write(give(profile["requests"]))
            f.write(give(profile["arrested"]))
            f.write(give(profile["medallium"]))
            f.write(give(profile["bugs"]))
            f.write(give(profile["fish"]))
            f.write(give(profile["battles"]))
            f.seek(unknown+100)
            #something here?
            f.write(give(profile["personal"], 2)) #may have to rename this
            f.write(give(profile["public"], 2))
            f.write(give(profile["rankl"], 2)) #ffff = master, 0000 = beginner
            f.write(give(profile["local"], 2))
            f.write(give(profile["rankr"], 2)) #120 >= master (maybe less)
            f.write(give(profile["random"], 2))
            f.write(give(profile["tagged"], 2))
            f.write(give(profile["photographs"], 2))
            for k in profile["yokai"]:
                f.write(give(k, 4))
            for k in profile["races"]:
                f.write(give(k, 4, None))

            #no need to clear profile overflow as it can't be deleted

            #write contact back
            j=0
            for i in contactlist:
                f.write(give(i["name"], 25, False))
                f.write(give(i["starred"]))
                f.seek(unknown+156+184*j+28)
                f.write(give(i["ownerid"], 4))
                f.write(give(i["comment"], 64, False))
                f.write(give(i["favourite"], 4))
                f.write(give(i["bronze"]))
                f.write(give(i["silver"]))
                f.write(give(i["gold"]))
                f.write(give(i["game"]))
                f.write(give(int(i["playtime"]*3600), 3)) #may cause problems
                f.seek(unknown+156+184*j+108)
                f.write(give(i["tunnel"], 4))
                f.write(give(i["face"], 4))
                f.write(give(i["hq"]))
                f.write(give(i["job"]))
                f.write(give(i["hobby"]))
                f.write(give(i["ambition"]))
                f.seek(unknown+156+184*j+121)
                #00 inbetween
                f.write(give(i["requests"]))
                f.write(give(i["arrested"]))
                f.write(give(i["medallium"]))
                f.write(give(i["bugs"]))
                f.write(give(i["fish"]))
                f.write(give(i["battles"]))
                f.seek(unknown+156+184*j+128)
                #something here?
                f.write(give(i["personal"], 2))
                f.write(give(i["public"], 2))
                f.write(give(i["rankl"], 2)) #ffff = master, 0000 = beginner
                f.write(give(i["local"], 2))
                f.write(give(i["rankr"], 2)) #120 >= master (maybe less)
                f.write(give(i["random"], 2))
                f.write(give(i["tagged"], 2))
                f.write(give(i["photographs"], 2))
                for k in i["yokai"]:
                    f.write(give(k, 4))
                for k in i["races"]:
                    f.write(give(k, 4, None))
                j+=1

            #clear contact overflow
            if original_contact_amount - len(contactlist) > 0:
                f.seek(unknown+156+184*j)
                f.write(b"\x00"*184*(original_contact_amount - len(contactlist)))

            #write medallium back
            f.seek(1460) # seen
            f.write(give(medalliumlist[0], 456, half=None))
            f.seek(1524) # befriended
            f.write(give(medalliumlist[1], 456, half=None))
            f.seek(1588) # new
            f.write(give(medalliumlist[2], 456, half=None))
            f.seek(1652) # camera
            f.write(give(medalliumlist[3], 456, half=None))

            #no need to clear medallium overflow as it can't be deleted
                
        f.seek(0)
        return f.read() #for the .yw files