from keyboard import *
from time import *

speed = 0.05

def p(keys, repeat=1, delay=0.02):
    if isinstance(keys, str):
        keys = [keys]
    for _ in range(repeat):
        for key in keys:
            press(key)
            sleep(delay)

def fill(books=True,extras=True,collectables=False):
    if books:
        p("tab",2)
        p(["h","i","tab","9","9"])
        p("tab",6)
        press_and_release("space")
        p("shift+tab",4)
        release("shift")
        p("down")

        p("tab",7)
        p(["h","i","tab","9","9"])
        p("tab",6)
        press_and_release("space")
        p("shift+tab",4)
        release("shift")
        p("down")

        p("tab",7)
        p(["h","i","down","tab","9","9"])
        p("tab",6)
        press_and_release("space")
        p("shift+tab",4)
        release("shift")
        p("down")

        p("tab",7)
        p(["h","i","down","tab","9","9"])
        p("tab",6)
        press_and_release("space")
        p("shift+tab",4)
        release("shift")
        p("down")

        p("tab",7)
        p(["h","i","down","down","tab","9","9"])
        p("tab",6)
        press_and_release("space")
        p("shift+tab",4)
        release("shift")
        p("down")

        p("tab",7)
        p(["h","i","down","down","tab","9","9"])
        p("tab",6)
        press_and_release("space")
        p("shift+tab",4)
        release("shift")
        p("down")

        p("tab",7)
        p(["h","i","down","down","down","tab","9","9"])
        p("tab",6)
        press_and_release("space")
        p("shift+tab",4)
        release("shift")
        p("down")

        p("tab",7)
        p(["h","i","down","down","down","tab","9","9"])
        p("tab",6)
        press_and_release("space")
        p("shift+tab",4)
        release("shift")
        p("down")

        
    if extras:
        p("tab",2)
        if books: p("tab",5)
        p(["h","o","tab","9","9"])
        p("tab",6)
        press_and_release("space")
        p("shift+tab",4)
        release("shift")
        p("down")

        p("tab",7)
        p(["h","o","tab","9","9"])
        p("tab",6)
        press_and_release("space")
        p("shift+tab",4)
        release("shift")
        p("down")

        p("tab",7)
        p(["s","t","a","m","down","tab","9","9"])
        p("tab",6)
        press_and_release("space")
        p("shift+tab",4)
        release("shift")
        p("down")

        p("tab",7)
        p(["g","e","t","a","tab","9","9"])
        p("tab",6)
        press_and_release("space")
        p("shift+tab",4)
        release("shift")
        p("down")

        p("tab",7)
        p(["v","o","tab","9","9"])
        p("tab",6)
        press_and_release("space")
        p("shift+tab",4)
        release("shift")
        p("down")

        p("tab",7)
        p(["m","a","r","b","tab","9","9"])
        p("tab",6)
        press_and_release("space")
        p("shift+tab",4)
        release("shift")
        p("down")

        p("tab",7)
        p(["m","i","g","tab","9","9"])
        p("tab",6)
        press_and_release("space")
        p("shift+tab",4)
        release("shift")
        p("down")

        p("tab",7)
        p(["p","l","a","tab","9","9"])
        p("tab",6)
        press_and_release("space")
        p("shift+tab",4)
        release("shift")
        p("down")

        p("tab",7)
        p(["m","u","s","down","down","down","tab","9","9"])
        p("tab",6)
        press_and_release("space")
        p("shift+tab",4)
        release("shift")
        p("down")

        p("tab",7)
        p(["f","i","s","tab","9","9"])
        p("tab",6)
        press_and_release("space")
        p("shift+tab",4)
        release("shift")
        p("down")

        p("tab",7)
        p(["f","i","s","down","tab","9","9"])
        p("tab",6)
        press_and_release("space")
        p("shift+tab",4)
        release("shift")
        p("down")

    if collectables:
        p("tab",2)
        if books or extras: p("tab",5)
        p(["g","a","tab","9","9"])
        p("tab",6)
        press_and_release("space")
        p("shift+tab",4)
        release("shift")
        p("down")

        p("tab",7)
        p(["g","a","up","tab","9","9"])
        p("tab",6)
        press_and_release("space")
        p("shift+tab",4)
        release("shift")
        p("down")

        p("tab",7)
        p(["m","u","s","tab","9","9"])
        p("tab",6)
        press_and_release("space")
        p("shift+tab",4)
        release("shift")
        p("down")

        p("tab",7)
        p(["d","a","tab","9","9"])
        p("tab",6)
        press_and_release("space")
        p("shift+tab",4)
        release("shift")
        p("down")

    if books or extras or collectables:
        p("tab",2)
        press_and_release("space")
        sleep(speed)
        p("tab",delay=speed)
        press_and_release("space")



#press play and put your curser on "#1"
sleep(3)

#books [True or False], extras [True or False], collectables [True or False]
fill(collectables=True)