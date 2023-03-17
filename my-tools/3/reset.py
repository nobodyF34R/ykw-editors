from keyboard import *
from time import *

speed = 0.1

def p(keys, repeat=1, delay=0.05):
    if isinstance(keys, str):
        keys = [keys]
    for _ in range(repeat):
        for key in keys:
            press(key)
            sleep(delay)

def clear(amount):
    if amount > 0:
        p("shift + tab",3)
        release("shift")
        press_and_release("space")
        sleep(speed)
        p("tab",delay=speed)
        press_and_release("space")
        sleep(speed)
        p("shift + tab",3)
        release("shift")
        p("down")
        if amount > 1:
            for i in range(amount-1):
                p("tab",3)
                press_and_release("space")
                sleep(speed)
                p("tab",delay=speed)
                press_and_release("space")
                sleep(speed)
                p("shift + tab",3)
                release("shift")
                p("down")

#run and put your curser on "#1"
sleep(3)

#set amount to number of yokai you want to clear
clear(500)