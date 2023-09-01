from dump1s import *

separator = "/" # or "\\" on windows
infile = "/Users/emilia/Documents/dev/ykw/20230716-140104 XAW7/new.ywd"
#infile = "/Volumes/UNTITLED/switch/Checkpoint/saves/0x0100C0000CEEA000 0x0100C0000CEEA000/temp/game1.yw"

def edit(yokailist, itemlist, equipmentlist, importantlist, medalliumlist):
    #helper functions defined in dump1s.py
    for i in range(len(yokailist)):
        edit_yokai(yokailist, i)  #max stats


    print(", ".join([yokais[i["id"]]for i in yokailist]))
    print(", ".join([items[i["item"]]for i in itemlist]))
    print(", ".join([equipments[i["equipment"]]for i in equipmentlist]))
    print(", ".join([importants[i["important"]]for i in importantlist]))

    print("\nseen yokai:")
    for i in range(246):
        if medalliumlist[0][i]: # medalliumlist[0][0] should never be true
            print(indexs[i], end=", ")
    print("\nbefriended yokai:")
    for i in range(224): #got rid of printing boss yokai to avoid confusion, since seen boss yokai show up as befriended because otherwise you wouldn't be able to see their profile
        if medalliumlist[1][i]: # medalliumlist[1][0] should never be true. the boss yokai are just weird i think
            print(indexs[i], end=", ")
    print("\nnew yokai:")
    for i in range(246):
        if medalliumlist[2][i]: # medalliumlist[2][0] should never be true. the boss yokai are just weird i think
            print(indexs[i], end=", ")
    print("\ncamera yokai:")
    for i in range(246):
        if medalliumlist[3][i]: # medalliumlist[3][0] should never be true. the boss yokai are just weird i think
            print(indexs[i], end=", ")
    
    return yokailist, itemlist, equipmentlist, importantlist, medalliumlist


if infile[-3:] == "ywd":
    main(infile, edit)
else:
    from pathlib import Path
    import sys
    sys.path.insert(0, str(Path(__file__).resolve().parent.parent.parent)+separator+"save-tools")
    import yw_save
    with open(infile, "r+b") as f:
        out = main(yw_save.yw_proc(f.read(), False), edit) #out is the edited binary data
        f.seek(0)
        f.write(yw_save.yw_proc(out, True))