from dump1s import * #get specific ids from data.py

infile = "path" #on windows change any "/" or "\" into "\\"

def edit(time, sun, position, location, money, yokailist, itemlist, equipmentlist, importantlist, medalliumlist):
    #helper functions defined in dump1s.py
    # position = [0, 0, 4294967295]
    # location = 13564018647118196
    
    # for i in range(len(yokailist)):
    #     yokailist = edit_yokai(yokailist, i) #max stats

    print(", ".join([yokais[i["id"]]for i in yokailist]))
    print(", ".join([items[i["id"]]for i in itemlist]))
    print(", ".join([equipments[i["id"]]for i in equipmentlist]))
    print(", ".join([importants[i["id"]]for i in importantlist]))

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

    return time, sun, position, location, money, yokailist, itemlist, equipmentlist, importantlist, medalliumlist

f = open(infile, "r+b")

if infile.endswith(".yw"):
    from pathlib import Path
    import sys
    sys.path.insert(0, str(Path(__file__).resolve().parent.parent.parent)+"/save-tools")
    import yw_save

    import io
    decrypted = io.BytesIO(yw_save.yw_proc(f.read(), False))
    f.seek(0)
    f.write(yw_save.yw_proc(main(decrypted, edit), True))
    decrypted.close() #redundant?
else:
    main(f, edit)

f.close()