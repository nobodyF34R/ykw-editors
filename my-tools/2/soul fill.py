from keyboard import *
from time import *

speed = 0.05

def p(keys, repeat=1, delay=0.000000001):
    if isinstance(keys, str):
        keys = [keys]
    for _ in range(repeat):
        for key in keys:
            press(key)
            sleep(delay)

def fill(soul="",repeat=1):
    if isinstance(soul, str):
        soul = [soul]
    for s in soul:
        for i in range(repeat):
            p("tab",2)
            p(list(s.replace(" ",""))+["tab", '6', '5', '5', '3', '5',"tab","1","0"])
            p("tab",6)
            press_and_release("space")
            p("shift+tab",4)
            release("shift")
            p("down")
            p("tab",5)
    p("shift+tab",3)
    release("shift")
    press_and_release("space")
    sleep(speed)
    p("tab",delay=speed)
    press_and_release("space")


#run and put your curser on "#1"
sleep(3)

#soul [can be list], repeat
fill(soul=["mac"],repeat=12)