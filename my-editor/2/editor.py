from dump2 import *

separator = "/" # or "\\" on windows
infile = "/Users/emilia/Documents/dev/ykw/ykw-editors/my-editor/2/game check copy.ywd"
#infile = "/Volumes/3DS/3ds/Checkpoint/saves/0x01B28 YO-KAI WATCH 2  PSYCHIC …/20230410-142023/game1.yw"

def edit(yokailist, itemlist, equipmentlist, importantlist, soullist, medalliumlist, profile, contactlist):
    #to append yokai make index None. must include yokai, attitude & nickname if appending. (can all be "" except for yokai)
    #append a pandle
    yokailist = edit_yokai(yokailist, None, profile["ownerid"], "pandle", "", "bob") #if you get the index wrong it will mess everything up
    #change to a rough ake
    yokailist = edit_yokai(yokailist, -1, profile["ownerid"], "ake", "rough") #broken
    #append 60 milk
    itemlist = edit_item(itemlist, None, "milk", 60) #currently broken, max is 255, 65535 or 99
    #append 60 cheap bracelet
    equipmentlist = edit_equipment(equipmentlist, None, "cheap bracelet", 60) #255 works, testing 65535
    #append a swosh soul
    soullist = edit_soul(soullist, None, "snartle")

    importantlist = edit_important(importantlist, None, "hose")

    profile = edit_contact(profile, None)


    print(", ".join([yokais[i["id"]]for i in yokailist]))
    print(", ".join([items[i["item"]]for i in itemlist]))
    print(", ".join([equipments[i["equipment"]]for i in equipmentlist]))
    print(", ".join([importants[i["important"]]for i in importantlist]))
    print(", ".join([souls[i["soul"]]for i in soullist]))
    # print(profile)
    # print(contactlist)

    print("\nseen yokai:")
    for i in range(449):
        if medalliumlist[0][i]: # medalliumlist[0][0] should never be true
            print(indexs[i], end=", ")
    print("\nbefriended yokai:")
    for i in range(449):
        if medalliumlist[1][i]: # medalliumlist[1][0] should never be true
            print(indexs[i], end=", ")
    print("\nnew yokai:")
    for i in range(449):
        if medalliumlist[2][i]: # medalliumlist[2][0] should never be true
            print(indexs[i], end=", ")
    print("\ncamera yokai:")
    for i in range(449):
        if medalliumlist[3][i]: # medalliumlist[2][0] should never be true
            print(indexs[i], end=", ")

    return yokailist, itemlist, equipmentlist, importantlist, soullist, medalliumlist, profile, contactlist


if infile[-3:] == "ywd":
    main(infile, edit)
else:
    from pathlib import Path
    import sys
    sys.path.insert(0, str(Path(__file__).resolve().parent.parent.parent)+separator+"save-tools")
    import yw_save
    with open(infile, "r+b") as f:
        if 0:
            with open(infile+"b", "r+b") as g: #TODO fix backup system
                g.write(f.read())
                f.seek(0)
        
        out = main(yw_save.yw2_proc(f.read(), False, head=infile[-1::-1].split(separator,1)[1][-1::-1]+"head.yw"), edit) #out is the edited binary data
        f.seek(0)
        f.write(yw_save.yw2_proc(out, True, head=infile[-1::-1].split(separator,1)[1][-1::-1]+"head.yw"))