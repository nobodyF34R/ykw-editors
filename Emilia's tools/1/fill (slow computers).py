from keyboard import *
from time import *

speed = 0.2

#on slow computers make delay 0.02 (else 0.0001)
def p(keys, repeat=1, delay=0.02):
    if isinstance(keys, str):
        keys = [keys]
    for _ in range(repeat):
        for key in keys:
            press(key)
            sleep(delay)

def fill(yokai="",repeat=1):
    if repeat == 1:
        p("shift + tab",2)
        release("shift")
        if yokai:
            p("shift + tab",2)
            release("shift")
            p(list(yokai))
            p("tab",2)
        p(["2","5","5","tab"])
        p(["3","0","0","tab"])
        p("tab",2)
        p(["1","2","7","tab"],10)
        p(["1","5","tab"],10)
        p("tab")
        press_and_release("space")
        sleep(speed)
        p("tab",delay=speed)
        press_and_release("space")
        sleep(speed)
        p("tab",4)
        p("down")
        p("tab",5)
        
    else:
        if yokai:
            p("shift + tab",4)
            release("shift")
            for _ in range(repeat):
                p(list(yokai))
                p("tab",2)
                p(["2","5","5","tab"])
                p(["3","0","0","tab"])
                p("tab",2)
                p(["1","2","7","tab"],10)
                p(["1","5","tab"],10)
                p("tab")
                press_and_release("space")
                sleep(speed)
                p("tab",delay=speed)
                press_and_release("space")
                sleep(speed)
                p("tab",4)
                p("down")
                p("tab")
            p("tab",4)
        else:
            p("shift + tab",2)
            release("shift")
            for _ in range(repeat):
                p(["2","5","5","tab"])
                p(["3","0","0","tab"])
                p("tab",2)
                p(["1","2","7","tab"],10)
                p(["1","5","tab"],10)
                p("tab",3)
                press_and_release("space")
                p("tab",2)
                p("down")
                p("tab",3)
            p("tab",2)

#select the yokai you want, then press play and put your curser on "#1"
sleep(3)

#yokai, repeat
fill(yokai="shogunyan", repeat=6)

#name of yokai (not medallium index)

#note: "Auto numbering" is broken in yke1 (will maybe try fix it at some point)

#to make script faster only use begining of name of name. e.g. "p" for pandle or "te" for tengu