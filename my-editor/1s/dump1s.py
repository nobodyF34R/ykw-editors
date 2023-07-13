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
                # "stats": { # 64 - 78
                #     "IV_HP": get(yokai, 64), 
                #     "IV_Str": get(yokai, 65), 
                #     "IV_Spr": get(yokai, 66), 
                #     "IV_Def": get(yokai, 67), 
                #     "IV_Spd": get(yokai, 68), 
                #     "EV_HP": get(yokai, 69), 
                #     "EV_Str": get(yokai, 70), 
                #     "EV_Spr": get(yokai, 71), 
                #     "EV_Def": get(yokai, 72), 
                #     "EV_Spd": get(yokai, 73), 
                #     "SC_HP": get(yokai, 74), 
                #     "SC_Str": get(yokai, 75), 
                #     "SC_Spr": get(yokai, 76), 
                #     "SC_Def": get(yokai, 77), 
                #     "SC_Spd": get(yokai, 78)
                # }, 
                "level": get(yokai, 116),
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
                "item": items[get(item, 4, 4)], #4
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
                "equipment": equipments[get(equipment, 4, 4)], #4
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
                "important": importants[get(important, 4, 4)], #4
            })

            index += 1
        original_important_amount = index

        medalliumlist = [] # the way this works is weird. the first bit is always False (because there is no 0th yokai) and it's still in big endian so the bytes are backwards. the last 7 bits are unused (False) because the are no more yokai. maybe the unused space is the for updates?
        f.seek(1476)
        medalliumlist.append(get(f.read(32), 0, 32, half=None)) # seen
        medalliumlist.append(get(f.read(32), 0, 32, half=None)) # befriended
        medalliumlist.append(get(f.read(32), 0, 32, half=None)) # seen
        medalliumlist.append(get(f.read(32), 0, 32, half=None)) # camera

        #print data 
        if 1:
            #print(", ".join([yokais[i["id"]]for i in yokailist]))

            print("\nseen yokai:")
            for i in range(246):
                if medalliumlist[0][i]: # medalliumlist[0][0] should never be true
                    print(indexs[i], end=", ")
            print("\nbefriended yokai:")
            for i in range(224): #got rid of printing boss yokai to avoid confusion. may remove
                if medalliumlist[1][i]: # medalliumlist[1][0] should never be true. the boss yokai are just weird i think
                    print(indexs[i], end=", ")
            print("\new yokai:")
            for i in range(246):
                if medalliumlist[2][i]: # medalliumlist[2][0] should never be true. the boss yokai are just weird i think
                    print(indexs[i], end=", ")
            print("\ncamera yokai:")
            for i in range(246):
                if medalliumlist[3][i]: # medalliumlist[3][0] should never be true. the boss yokai are just weird i think
                    print(indexs[i], end=", ")

        #write everything back to file
        if 0:
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
                f.seek(20744+92*j)
                f.write(i["num1"].to_bytes(2, "little"))
                f.seek(20744+92*j+2)
                f.write(i["num2"].to_bytes(2, "little"))
                f.seek(20744+92*j+4)
                f.write(i["id"].to_bytes(4, "little"))
                f.seek(20744+92*j+8)
                f.write((bytearray([k in i["nickname"].encode('utf-8')])+bytearray(24))[:24])
                j+=1

            #clear yokai overflow
            if original_yokai_amount - len(yokailist) > 0:
                f.seek(20744+92*j)
                f.write(b"\x00"*92*(original_yokai_amount - len(yokailist)))

            #write medallium back
            f.seek(1460) # seen
            f.write(bytearray([int(''.join('1' if bit else '0' for bit in medalliumlist[0][i:i+8][::-1]), 2) for i in range(0, len(medalliumlist[0]), 8)]))
            f.seek(1524) # befriended
            f.write(bytearray([int(''.join('1' if bit else '0' for bit in medalliumlist[1][i:i+8][::-1]), 2) for i in range(0, len(medalliumlist[1]), 8)]))
            f.seek(1588) # new
            f.write(bytearray([int(''.join('1' if bit else '0' for bit in medalliumlist[2][i:i+8][::-1]), 2) for i in range(0, len(medalliumlist[2]), 8)]))
            f.seek(1652) # camera
            f.write(bytearray([int(''.join('1' if bit else '0' for bit in medalliumlist[3][i:i+8][::-1]), 2) for i in range(0, len(medalliumlist[3]), 8)]))

            

#infile = "/Volumes/UNTITLED/switch/Checkpoint/saves/0x0100C0000CEEA000 0x0100C0000CEEA000/20230703-114220 XAW7/game1.yw"
infile = "/Users/emilia/Documents/dev/ykw/20230703-114220 XAW7/game1.ywd"

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