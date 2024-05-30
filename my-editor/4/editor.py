from dump4 import * #get specific ids from data.py

infile = "/Users/user/Documents/dev/ykw/ykw-editors/my-editor/4/0/USERDATA00/data copy.bin" #on windows change any "/" or "\" into "\\"

def edit(position, location, money, namelist, gatcharemaining, gatchamax, characterlist, yokailist, itemlist, speciallist, soullist, equipmentlist):
    #helper functions defined in dump4.py
    # namelist = {'nate': 'Nate', 'katie': 'Katie', 'summer': 'Summer', 'cole': 'Cole', 'bruno': 'Bruno', 'jack': 'Jack'} #fix names
    
    # for i in range(len(yokailist)): #example: setting all yokai to shogunyan
    #     yokailist = edit_yokai(yokailist, i, "shogunyan", "") #get id/name from data.py

    # for i in range(6): 
    #     characterlist = edit_yokai(characterlist, i) #max stats


    print(", ".join([characters[i["type"]]for i in characterlist]))
    print(", ".join([characters[i["type"]]for i in yokailist]))
    print(", ".join([items[i["type"]]for i in itemlist]))
    print(", ".join([equipments[i["type"]]for i in equipmentlist]))
    print(locations[location])

    return position, location, money, namelist, gatcharemaining, gatchamax, characterlist, yokailist, itemlist, speciallist, soullist, equipmentlist #all editable


main(infile, edit)