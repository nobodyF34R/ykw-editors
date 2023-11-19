from dump2 import * #get specific ids from data.py

separator = "/" # or "\\" on windows

infile = "/Users/emilia/Documents/dev/ykw/ykw-editors/my-editor/2/game check copy.ywd" #on windows change any "/" or "\" into "\\"

def edit(yokailist, itemlist, equipmentlist, importantlist, soullist, medalliumlist, profile, contactlist):
    #helper functions defined in dump2.py
    # #append 60 milk
    # itemlist = edit_item(itemlist, None, "milk", 60) #currently broken, max is 255, 65535 or 99
    # #append 60 cheap bracelet
    # equipmentlist = edit_equipment(equipmentlist, None, "cheap bracelet", 60) #max is 255
    # #append a swosh soul
    # soullist = edit_soul(soullist, None, "snartle")

    profile = edit_contact(profile, None, False) #maxes out your online battling stats. your name is not editable here remove if you don't want to be found cheating (could also set to private). changing your owner id may have unknown consequences 
    for i in range(len(yokailist)):
        yokailist = edit_yokai(yokailist, i, profile["ownerid"])
    for i in range(len(itemlist)):
        itemlist = edit_item(itemlist, i, amount=255)
    for i in range(len(equipmentlist)):
        equipmentlist = edit_equipment(equipmentlist, i, amount=255)


    print(", ".join([yokais[i["id"]]for i in yokailist]))
    print(", ".join([items[i["id"]]for i in itemlist]))
    print(", ".join([equipments[i["id"]]for i in equipmentlist]))
    print(", ".join([importants[i["id"]]for i in importantlist]))
    print(", ".join([souls[i["id"]]for i in soullist]))
    print(profile) #look at what the numbers mean in data.py
    # print(contactlist)

    # print("\nseen yokai:") #print medallium 
    # for i in range(449):
    #     if medalliumlist[0][i]: # medalliumlist[0][0] should never be true
    #         print(indexs[i], end=", ")
    # print("\nbefriended yokai:")
    # for i in range(449):
    #     if medalliumlist[1][i]: # medalliumlist[1][0] should never be true
    #         print(indexs[i], end=", ")
    # print("\nnew yokai:")
    # for i in range(449):
    #     if medalliumlist[2][i]: # medalliumlist[2][0] should never be true
    #         print(indexs[i], end=", ")
    # print("\ncamera yokai:")
    # for i in range(449):
    #     if medalliumlist[3][i]: # medalliumlist[2][0] should never be true
    #         print(indexs[i], end=", ")

    return yokailist, itemlist, equipmentlist, importantlist, soullist, medalliumlist, profile, contactlist


if infile[-3:] == "ywd":
    main(infile, edit)
else:
    from pathlib import Path
    import sys
    sys.path.insert(0, str(Path(__file__).resolve().parent.parent.parent)+"/save-tools")
    import yw_save
    with open(infile, "r+b") as f:
        out = main(yw_save.yw2_proc(f.read(), False, head=infile[-1::-1].split(separator,1)[1][-1::-1]+"head.yw"), edit) #out is the edited binary data
        f.seek(0)
        f.write(yw_save.yw2_proc(out, True, head=infile[-1::-1].split(separator,1)[1][-1::-1]+"head.yw"))