#!/opt/local/bin/python3
# coding: utf-8

"""
util.py

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

class Xorshift:
    def __init__(self, seed):
        self.states = [0x6C078966, 0xDD5254A5, 0xB9523B81, 0x03DF95B3]

        # initialize internal states
        if seed == 0:
            return
        seed = seed ^ (seed >> 30)
        seed = (seed * (0x6C078966 - 1)) & 0xFFFFFFFF
        seed = seed + 1
        self.states[0] = seed

        seed = seed ^ (seed >> 30)
        seed = (seed * (0x6C078966 - 1)) & 0xFFFFFFFF
        seed = seed + 2
        self.states[1] = seed

        seed = seed ^ (seed >> 30)
        seed = (seed * (0x6C078966 - 1)) & 0xFFFFFFFF
        seed = seed + 3
        self.states[2] = seed

    def xorshift(self, arg):
        x = self.states[0]
        y = self.states[3]

        self.states[0] = self.states[1]
        self.states[1] = self.states[2]
        self.states[2] = self.states[3]
        x = x ^ ((x << 11) & 0xFFFFFFFF)
        x = x ^ ((x >> 8) & 0xFFFFFFFF)
        y = y ^ ((y >> 19) & 0xFFFFFFFF)
        self.states[3] = x ^ y
        if arg == 0:
            return self.states[3]
        return self.states[3] % arg
