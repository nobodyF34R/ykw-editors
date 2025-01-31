#!/opt/local/bin/python3
# coding: utf-8

"""
yw_save.py - decrypt and encrypt save data of Yo-kai Watch.

======

The MIT License (MIT)

Copyright (c) 2016 togenyan

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

import struct
import binascii
import argparse
import logging
import gamefix.gansohonke
import gamefix.shinuchi
import gamefix.busters
import gamefix.yw3
from util import Xorshift

haveCrypto = False

try:
    from Crypto.Cipher import AES
    from Crypto.Util import Counter
    haveCrypto = True
except:
    pass

# first 256 odd prime numbers
odd_primes = [
       3,    5,    7,   11,   13,   17,   19,   23,   29,   31,   37,   41,   43,   47,   53,   59,
      61,   67,   71,   73,   79,   83,   89,   97,  101,  103,  107,  109,  113,  127,  131,  137,
     139,  149,  151,  157,  163,  167,  173,  179,  181,  191,  193,  197,  199,  211,  223,  227,
     229,  233,  239,  241,  251,  257,  263,  269,  271,  277,  281,  283,  293,  307,  311,  313,
     317,  331,  337,  347,  349,  353,  359,  367,  373,  379,  383,  389,  397,  401,  409,  419,
     421,  431,  433,  439,  443,  449,  457,  461,  463,  467,  479,  487,  491,  499,  503,  509,
     521,  523,  541,  547,  557,  563,  569,  571,  577,  587,  593,  599,  601,  607,  613,  617,
     619,  631,  641,  643,  647,  653,  659,  661,  673,  677,  683,  691,  701,  709,  719,  727,
     733,  739,  743,  751,  757,  761,  769,  773,  787,  797,  809,  811,  821,  823,  827,  829,
     839,  853,  857,  859,  863,  877,  881,  883,  887,  907,  911,  919,  929,  937,  941,  947,
     953,  967,  971,  977,  983,  991,  997, 1009, 1013, 1019, 1021, 1031, 1033, 1039, 1049, 1051,
    1061, 1063, 1069, 1087, 1091, 1093, 1097, 1103, 1109, 1117, 1123, 1129, 1151, 1153, 1163, 1171,
    1181, 1187, 1193, 1201, 1213, 1217, 1223, 1229, 1231, 1237, 1249, 1259, 1277, 1279, 1283, 1289,
    1291, 1297, 1301, 1303, 1307, 1319, 1321, 1327, 1361, 1367, 1373, 1381, 1399, 1409, 1423, 1427,
    1429, 1433, 1439, 1447, 1451, 1453, 1459, 1471, 1481, 1483, 1487, 1489, 1493, 1499, 1511, 1523,
    1531, 1543, 1549, 1553, 1559, 1567, 1571, 1579, 1583, 1597, 1601, 1607, 1609, 1613, 1619, 1621,
]

class YWCipher(Xorshift):
    def __init__(self, seed, count):
        self.table = [x for x in range(0x100)]
        super().__init__(seed)

        # generate table
        for i in range(count):
            r = self.xorshift(0x10000)
            r1, r2 = r & 0xFF, (r >> 8) & 0xFF
            if r1 != r2:
                a, b = self.table[r1], self.table[r2]
                self.table[a], self.table[b] = self.table[b], self.table[a]

    def encrypt(self, data):
        out = bytearray()
        for i, x in enumerate(data):
            if i % 0x100 == 0:
                #print("block {}".format((i & 0xff00) >> 8))
                ka = odd_primes[self.table[(i & 0xff00) >> 8]]
            kb = self.table[ka * (i + 1) & 0xff]
            out.append(data[i] ^ kb)
        return out

    def decrypt(self, data):
        return self.encrypt(self, data)

class CCMCipher:
    """
    Counter with CBC-MAC (CCM)

    You can use MODE_CCM instead of this class if you have the latest experimental version of PyCrypto
    """
    def __init__(self, key):
        if not haveCrypto:
            raise Exception("You need to have Crypto installed")

        self.M = 16
        self.M_prime = (self.M - 2) // 2
        self.L = None
        self.L_prime = None
        self.N = None
        self.nonce = None

        self.aes_ecb = AES.new(key, mode=AES.MODE_ECB)
        self.aes_ctr = None
        self.key = key

    def resetCTR(self, nonce):
        self.L = 15 - len(nonce)
        self.L_prime = self.L - 1
        self.N = len(nonce)
        self.nonce = nonce

        data = bytes([self.L_prime]) + nonce
        ctr = Counter.new((0x10 - len(data)) * 8, prefix=data, initial_value=0)
        self.aes_ctr = AES.new(self.key, mode=AES.MODE_CTR, counter=ctr)

    def calculateMAC(self, blocks):
        # calculate authentication field
        flag = self.M_prime * 8 + self.L_prime
        lengthOfMessage = sum([len(x) for x in blocks])
        lengthOfMessageBytes = struct.pack(">I", lengthOfMessage)

        B_0 = bytes([flag,]) + self.nonce + lengthOfMessageBytes[1:]

        x = self.aes_ecb.encrypt(B_0)
        for b in blocks:
            if len(b) != 0x10:
                b = b + b"\x00" * (0x10 - len(b))
            x = self.aes_ecb.encrypt(bytes([a ^ b for a, b in zip(x, b)]))
        return x

    def encrypt(self, data, nonce):
        message = []
        self.resetCTR(nonce)
        mac = self.calculateMAC([data[i:i+self.M] for i in range(0, len(data), self.M)])
        i = 0x0

        # encryption
        mac = self.aes_ctr.encrypt(mac)
        while i < len(data):
            message.append(self.aes_ctr.encrypt(bytes(data[i:i+0x10])))
            i += 0x10

        # nonce padding
        if len(self.nonce) != 0x10:
            nonce = self.nonce + b"\x00" * (0x10 - len(self.nonce))
        else:
            nonce = self.nonce

        return nonce + mac + b"".join(message)

    def decrypt(self, data, nonce):
        message = []
        self.resetCTR(nonce)
        mac = self.aes_ctr.encrypt(data[:0x10])
        i = 0x10

        # decryption
        while i < len(data):
            message.append(self.aes_ctr.decrypt(data[i:i+0x10]))
            i += 0x10

        # authentication
        if self.calculateMAC(message) != mac:
            logging.error("CCM authentication failed")
            return None
        return b"".join(message)

def yw_proc(data, isEncrypt, key=None, head=None, validator=None):
    out = bytearray()
    length = len(data)
    new_crc32 = struct.unpack("<I", data[-8:-4])[0]
    seed = struct.unpack("<I", data[-4:])[0]
    if not isEncrypt:
        if binascii.crc32(data[:-8]) != new_crc32:
            logging.error("Checksum does not match")
            return None
    c = YWCipher(seed, 0x1000)
    out += c.encrypt(data[:-8])
    out += data[-8:]
    if isEncrypt:
        new_crc32 = binascii.crc32(out[:-8])
        struct.pack_into("<I", out, length - 8, new_crc32)
    return bytes(out)

def yw2_proc(data, isEncrypt, key=b"5+NI8WVq09V7LI5w", head=None, validator=gamefix.shinuchi.validate):
    """
    tested with Shin'uchi
    also works with Ganso / Honke 1.x
    """
    ccm = CCMCipher(key) # could use AES.new(key, AES.MODE_CCM)
    nonce = data[:12]
    mac = data[0x10:0x20]
    if not isEncrypt:
        # decrypt
        out = ccm.decrypt(data[0x10:], nonce)
        if not out:
            return None
        out = yw_proc(out, isEncrypt)
        # output = nonce + MAC + decrypted body (for compatibility with CYBER save editor)
        out = nonce + b"\x00\x00\x00\x00" + mac + out
    else:
        # encrypt
        if len(nonce) != 12:
            logging.error("Invalid length of nonce")
            return None
        # validate and fix
        if validator:
            result = validator(data[0x20:])
        else:
            result = data[0x20:]
        if not result:
            logging.error("Invalid savedata")
            return None
        # encrypt except header
        out = yw_proc(result, isEncrypt)
        if not out:
            return None
        out = ccm.encrypt(out, nonce)
    return out

def yw2x_proc(data, isEncrypt, key=None, head=None, validator=gamefix.gansohonke.validate):
    """
    Ganso / Honke version 2.x
    """
    key = bytearray()

    if not head:
        logging.error("You need head.yw to process Yo-kai Watch Ganso / Honke ver.2.x save data."
                      "Please specify the file with --head option.")
        return None
    with open(head, "rb") as f:
        # decrypt head.yw
        headData = yw_proc(f.read(), isEncrypt=False)

        a = struct.unpack("<I", headData[0x0C:0x0C+4])[0]

        for i in range(0x10):
            key.append(Xorshift(a).xorshift(0x100))
    return yw2_proc(data, isEncrypt, key=bytes(key), validator=validator)

def ywb_proc(data, isEncrypt, key=None, head=None, validator=gamefix.busters.validate, getto=False):
    def sub(data, r1):
        r2 = struct.unpack("<I", data[0x10:0x10+4])[0]
        if r2 != 0:
            r2 = r2 - 1
        pos = r2 * 0x78 + 0x39C8
        if pos != 0:
            pos = pos + r1 * 4 + 0x18
            return struct.unpack("<I", data[pos:pos+4])[0]
        return 0

    key = bytearray()

    if not head:
        logging.error("You need head.yw to process Yo-kai Watch Busters save data."
                      "Please specify the file with --head option.")
        return None

    with open(head, "rb") as f:
        # decrypt head.yw
        headData = yw_proc(f.read(), isEncrypt=False)

        a = struct.unpack("<I", headData[0x0C:0x0C+4])[0]
        a ^= sub(headData, 0x0C)

        # Getto-gumi
        if getto:
            if sub(headData, 0) & 0x4000:
                a = ~a & 0xFFFFFFFF

        for i in range(0x10):
            key.append(YWCipher(a, sub(headData, 0x0A) & 0xFF).xorshift(0x100))
    return yw2_proc(data, isEncrypt, key=bytes(key), validator=validator)

def ywb_getto_proc(data, isEncrypt, key=None, head=None, validator=gamefix.busters.validate, getto=True):
    return ywb_proc(data, isEncrypt, key=key, head=head, validator=validator, getto=getto)

def yw3_proc(data, isEncrypt, key=None, head=None, validator=gamefix.yw3.validate):
    def sub(data):
        r2 = struct.unpack("<I", data[0x10:0x10+4])[0]
        if r2 != 0:
            r2 = r2 - 1
        pos = r2 * 0xA8 + 0x20
        if pos == 0:
            return 0
        pos = pos + 8 + 0x30
        return struct.unpack("<I", data[pos:pos+4])[0]
    def sub2(data):
        r2 = struct.unpack("<I", data[0x10:0x10+4])[0]
        if r2 != 0:
            r2 = r2 - 1
        pos = r2 * 0xA8 + 0x20
        if pos == 0:
            return 0
        pos = pos + 0x40
        return sum(struct.unpack("<6I", data[pos:pos+4*6])) & 0xFF

    key = bytearray()

    if not head:
        logging.error("You need head.yw to process Yo-kai Watch 3 save data."
                      "Please specify the file with --head option.")
        return None

    with open(head, "rb") as f:
        # decrypt head.yw
        headData = yw_proc(f.read(), isEncrypt=False)

        a = struct.unpack("<I", headData[0x0C:0x0C+4])[0]
        a ^= sub(headData)

        for i in range(0x10):
            key.append(YWCipher(a, sub2(headData) & 0xFF).xorshift(0x100))
    return yw2_proc(data, isEncrypt, key=bytes(key), validator=validator)

def process(infile, outfile, gameType, isEncrypt, head=None):
    with open(infile, "rb") as f:
        data = f.read()
        if gameType in games:
            out = games[gameType](data, isEncrypt, head=head)
        if out:
            with open(outfile, "w+b") as g: #xb
                g.write(out)
            return 0
        return 1

games = {"yw": yw_proc, "yw2": yw2_proc, "yw2x": yw2x_proc, "ywb": ywb_proc, "ywb_getto": ywb_getto_proc, "yw3": yw3_proc}

def main():
    logging.basicConfig(format="%(levelname)s: [%(funcName)s] %(message)s")
    parser = argparse.ArgumentParser(description='encrypt or decrypt save data of Yo-kai Watch')
    group = parser.add_mutually_exclusive_group(required=True)
    group.add_argument("--decrypt", action="store_true", help="decrypt file")
    group.add_argument("--encrypt", action="store_true", help="encrypt file")
    parser.add_argument("--game", dest="game", action="store", default="yw",
                        choices=games, help="game (default: yw)")
    parser.add_argument("--head", dest="head", action="store", default=None,
                        help="head.yw (only needed for Ganso / Honke 2.X and Busters)")
    parser.add_argument("input_file", help="file to encrypt or decrypt")
    parser.add_argument("output_file", help="ouput file name")
    args = parser.parse_args()
    if process(args.input_file, args.output_file, args.game, args.encrypt, args.head):
        print("Processing failed.")

if __name__ == "__main__":
    main()
