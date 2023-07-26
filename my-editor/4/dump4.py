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
        pass

infile = ""
#infile = "/Volumes/UNTITLED/switch/Checkpoint/saves/........"

main(infile)