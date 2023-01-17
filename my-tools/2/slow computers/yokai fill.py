#VS Code: Alt+Z to turn off word wrap
#pip install keyboard
from keyboard import *
from time import *

#on fast computers delay can be 0.05 on slower ones set delay to 0.2
speed = 0.2

def p(keys, repeat=1, delay=0.02):
    if isinstance(keys, str):
        keys = [keys]
    for _ in range(repeat):
        for key in keys:
            press(key)
            sleep(delay)

def fill(yokai="", attitude=[], repeat=[1]):
    if isinstance(attitude, str):
        attitude = [attitude]
    k=0
    if yokai:
        l = 0
        if not isinstance(yokai, list):
            yokai = [yokai]
        if not isinstance(repeat, list):
            repeat = [repeat]
        for yoka in yokai:
            yoka = str(yoka)
            if yoka.isdigit():
                index = yoka.zfill(3)
                if int(yoka) % 10 == 0:
                    yoka = yoka[:2]
                if int(yoka) % 100 == 0:
                    yoka = yoka[:1]
            else:
                index = {'pandle': '001', 'undy': '0', 'tanbo': '003', 'cutta-nah': '004', 'cutta-nah-nah': '005', 'slacka-slash': '006', 'brushido': '007', 'washogun': '008', 'lie-in': '009', 'lie-in heart': '01', 'hissfit': '011', 'zerberker': '012', 'snartle': '013', 'mochismo': '014', 'minochi': '015', 'tublappa': '016', 'slicenrice': '017', 'slicenrice (rice and dice)': '017', 'slicenrice (bear care)': '017', 'flamurice': '018', 'flamurice (rice and dice)': '018', 'flamurice (firewall)': '018', 'helmsman': '019', 'reuknight': '02', 'corptain': '021', 'mudmunch': '022', 'sgt. burly': '023', 'blazion': '024', 'quaken': '025', 'siro': '026', 'chansin': '027', 'sheen': '028', 'snee': '029', 'gleam': '03', 'benkei': '031', 'b3-nk1': '032', 'sushiyama': '033', 'kapunki': '034', 'beetler': '035', 'beetler (too serious)': '035', 'beetler (lone soldier)': '035', 'beetall': '036', 'beetall (intimidation)': '036', 'beetall (lone soldier)': '036', 'cruncha': '037', 'demuncher': '038', 'devourer': '039', 'brokenbrella': '04', 'pittapatt': '041', 'snotsolong': '042', 'duchoo': '043', "d'wanna": '044', "n'more": '045', "q'wit": '046', 'wazzat': '047', 'houzzat': '048', 'dummkap': '049', 'faysoff': '05', 'lafalotta': '051', 'blips': '052', 'tattletell': '053', 'tattlecast': '054', 'skranny': '055', 'cupistol': '056', 'casanuva': '057', 'casanono': '058', 'so-sorree': '059', 'bowminos': '06', 'smogling': '061', 'smogmella': '062', 'signibble': '063', 'signiton': '064', 'statiking': '065', 'master oden': '066', 'failian': '067', 'apelican': '068', 'mirapo': '069', 'miradox': '07', 'mircle': '071', 'illoo': '072', 'elloo': '073', 'alloo': '074', 'espy': '075', 'infour': '076', 'verygoodsir': '077', 'tengu': '078', 'flengu': '079', 'kyubi': '08', 'frostail': '081', 'chymera': '082', 'kingmera': '083', 'terrorpotta': '084', 'dulluma': '085', 'darumacho': '086', 'goruma': '087', 'wotchagot': '088', 'pride shrimp': '089', 'no-go kart': '09', 'mistank': '091', 'noway': '092', 'noway (blocker)': '092', 'noway (endurance)': '092', 'impass': '093', 'impass (blocker)': '093', 'impass (rocky terrain)': '093', 'walldin': '094', 'roughraff': '095', 'badude': '096', 'bruff': '097', 'armsman': '098', 'mimikin': '099', 'blowkade': '10', 'ledballoon': '101', 'fidgephant': '102', 'touphant': '103', 'enduriphant': '104', 'zappary': '105', 'frazzel': '106', 'swelton': '107', 'mad mountain': '108', 'lava lord': '109', 'castelius iii': '11', 'castelius ii': '111', 'castelius i': '112', 'castelius max': '113', 'rhinoggin': '114', 'rhinoggin (guard break)': '114', 'rhinoggin (lone soldier)': '114', 'rhinormous': '115', 'rhinormous (guard break)': '115', 'rhinormous (lone soldier)': '115', 'hornaplenty': '116', 'robonyan': '117', 'goldenyan': '118', 'dromp': '119', 'swosh': '12', 'toadal dude': '121', 'uber geeko': '122', 'leggly': '123', 'dazzabel': '124', 'rattelle': '125', 'skelebella': '126', 'cadin': '127', 'cadable': '128', 'singcada': '129', 'pupsicle': '13', 'pupsicle (penetrate)': '13', 'pupsicle (fangsicles)': '13', 'chilhuahua': '131', 'chilhuahua (penetrate)': '131', 'chilhuahua (alpine wall)': '131', 'swelterrier': '132', 'jumbelina': '133', 'boyclops': '134', 'jibanyan': '135', 'thornyan': '136', 'baddinyan': '137', 'buchinyan': '138', 'walkappa': '139', 'walkappa (skilled loafer)': '139', 'walkappa (water play)': '139', 'appak': '14', 'appak (penetrate)': '14', "appak (fill 'er up)": '14', 'supyo': '141', 'komasan': '142', 'komane': '143', 'komajiro': '144', 'komajiro (omega)': '144', 'komajiro (lightning up!)': '144', 'komiger': '145', 'komiger (omega)': '145', 'komiger (lightning up!)': '145', 'baku': '146', 'bakulia': '147', 'whapir': '148', 'whapir (good fortune)': '148', 'whapir (free to be)': '148', 'drizzelda': '149', 'nekidspeed': '15', 'shmoopie': '151', 'pinkipoo': '152', 'pookivil': '153', 'harry barry': '154', 'frostina': '155', 'blizzaria': '156', 'damona': '157', 'faux kappa': '158', 'tigappa': '159', 'master nyada': '16', 'wantston': '161', 'grubsnitch': '162', 'wiglin': '163', 'kelpacabana': '164', 'steppa': '165', 'rhyth': '166', 'hungramps': '167', 'hungramps (starver)': '167', 'hungramps (bear care)': '167', 'hungorge': '168', 'hungorge (starver)': '168', 'hungorge (bear care)': '168', 'grainpa': '169', 'tongus': '17', 'nurse tongus': '171', 'sandmeh': '172', 'sandmeh (sand still)': '172', 'sandmeh (carefree spirit)': '172', 'mr. sandmeh': '173', 'mr. sandmeh (sand still)': '173', 'mr. sandmeh (carefree spirit)': '173', 'pallysol': '174', 'scarasol': '175', 'lodo': '176', 'supoor hero': '177', 'chippa': '178', 'gnomey': '179', 'high gnomey': '18', 'enerfly': '181', 'enefly': '182', 'betterfly': '183', 'peppillon': '184', 'predictabull': '185', 'smashibull': '186', 'don chan': '187', "ray o'light": '188', 'happierre': '189', 'reversa': '19', 'reversette': '191', "ol' saint trick": '192', "ol' fortune": '193', 'rollen': '194', 'dubbles': '195', 'papa bolt': '196', 'uncle infinite': '197', 'mama aura': '198', 'auntie heart': '199', 'kyryn': '20', 'unikirin': '201', 'leadoni': '202', 'mynimo': '203', 'ake': '204', 'payn': '205', 'agon': '206', 'wydeawake': '207', 'allnyta': '208', 'herbiboy': '209', 'carniboy': '21', 'negatibuzz': '211', 'moskevil': '212', 'scritchy': '213', 'dimmy': '214', 'dimmy (secrecy)': '214', 'dimmy (wavy body)': '214', 'blandon': '215', 'blandon (secrecy)': '215', 'blandon (wavy body)': '215', 'nul': '216', 'suspicioni': '217', 'suspicioni (suspicion)': '217', 'suspicioni (eyesight a)': '217', 'tantroni': '218', 'contrarioni': '219', 'hidabat': '22', 'abodabat': '221', 'belfree': '222', 'yoink': '223', 'gimme': '224', "k'mon-k'mon": '225', 'yoodooit': '226', 'count zapaway': '227', 'tyrat': '228', 'tengloom': '229', 'nird': '23', 'snobetty': '231', 'slimamander': '232', 'dracunyan': '233', 'negasus': '234', 'neighfarious': '235', 'timidevil': '236', 'beelzebold': '237', 'count cavity': '238', 'eyesoar': '239', 'eyellure': '24', 'greesel': '241', 'awevil': '242', 'wobblewok': '243', 'coughkoff': '244', 'hurchin': '245', 'droplette': '246', 'drizzle': '247', 'slush': '248', 'alhail': '249', 'gush': '25', 'peckpocket': '251', 'robbinyu': '252', 'rockabelly': '253', 'rockabelly (glossy skin)': '253', 'rockabelly (long lasting)': '253', 'squeeky': '254', 'rawry': '255', 'buhu': '256', 'flumpy': '257', 'skreek': '258', 'manjimutt': '259', 'multimutt': '26', 'sir berus': '261', 'furgus': '262', 'furdinand': '263', 'nosirs': '264', 'dismarelda': '265', 'chatalie': '266', 'nagatha': '267', 'nagatha (skilled loafer)': '267', 'nagatha (too serious)': '267', 'papa windbag': '268', 'ben tover': '269', 'cheeksqueek': '27', 'cuttincheez': '271', 'toiletta': '272', 'foiletta': '273', 'sproink': '274', 'compunzer': '275', 'lamedian': '276', 'grumples': '277', 'everfore': '278', 'eterna': '279', 'insomni': '28', 'sandi': '281', 'arachnus': '282', 'arachnia': '283', 'cricky': '284', 'noko': '285', 'bloominoko': '286', 'pandanoko': '287', 'snaggly': '288', 'whinona': '289', 'heheheel': '29', 'croonger': '291', 'urnaconda': '292', 'fishpicable': '293', 'rageon': '294', 'tunatic': '295', 'flushback': '296', 'vacuumory': '297', 'irewig': '298', 'firewig': '299', 'draggie': '30', 'dragon lord': '301', 'azure dragon': '302', 'mermaidyn': '303', 'mermadonna': '304', 'mermother': '305', 'lady longnek': '306', 'daiz': '307', 'confuze': '308', 'chummer': '309', 'shrook': '31', 'spenp': '311', 'almi': '312', 'babblong': '313', 'bananose': '314', 'draaagin': '315', 'sv snaggerjag': '316', 'copperled': '317', 'cynake': '318', 'slitheref': '319', 'venoct': '32', 'shad. venoct': '321', 'shogunyan': '322', 'komashura': '323', 'gilgaros': '324', 'spoilerina': '325', 'elder bloom': '326', 'poofessor': '327', 'dandoodle': '328', 'slurpent': '329', 'sapphinyan': '33', 'emenyan': '331', 'rubinyan': '332', 'topanyan': '333', 'dianyan': '334', 'melonyan': '335', 'oranyan': '336', 'kiwinyan': '337', 'grapenyan': '338', 'strawbnyan': '339', 'watermelnyan': '34', 'robokapp': '341', 'robokoma': '342', 'robogramps': '343', 'robomutt': '344', 'robonoko': '345', 'robodraggie': '346', 'wondernyan': '347', 'robonyan f': '348', 'sailornyan': '349', 'machonyan': '35', 'hovernyan': '351', 'darknyan': '352', 'jibakoma': '353', 'jetnyan': '354', 'unfairy': '355', 'unkaind': '356', 'untidy': '357', 'unpleasant': '358', 'unkeen': '359', 'grublappa': '36', 'madmunch': '361', 'badsmella': '362', 'mad kappa': '363', 'shamasol': '364', 'gnomine': '365', 'defectabull': '366', 'feargus': '367', 'scaremaiden': '368', 'wrongnek': '369', 'grumpus khan': '37', 'groupus khan': '371', 'slumberhog': '372', 'snortlehog': '373', 'panja pupil': '374', 'panja pro': '375', 'samureel': '376', 'time keeler': '377', 'takoyakid': '378', 'takoyaking': '379', 'danke sand': '38', 'no sandkyu': '381', 'sumodon': '382', 'yokozudon': '383', 'whateverest': '384', 'whatuption': '385', 'happycane': '386', 'starrycane': '387', 'snottle': '43', 'moximous n': '431', 'moximous k': '432', 'jibanyan s': '433', 'komasan s': '434', 'komajiro s': '435', 'darkyubi': '436', 'illuminoct': '437', 'gargaros': '438', 'ogralus': '439', 'orcanos': '44', 'rubeus j': '441', 'hardy hound': '442', 'hinozall': '443', 'bronzlow': '444', 'teastroyer': '445', 'infinipea': '446', 'headasteam': '447', 'kabuking': '448'}[yoka.lower()]
            p("shift + tab",2)
            release("shift")
            for _ in range(int(repeat[l])-1):
                p(list(index))
                p("tab",4)
                p("9",2)
                p(["tab","1","5","tab","0","tab"])
                if attitude: p({"grouchy":"g","logical":"l","careful":"c","gentle":["g","e"],"twisted":"t","helpful":"h","rough":"r","brainy":"b","calm":["c","a","l"],"tender":["t","e"],"cruel":["c","r"],"devoted":"d"}[attitude[k].lower()])
                p("tab",2)
                p(["8","0","tab"])
                p(["4","0","tab"],4)
                p(["1","2","7","tab"],5)
                p(["2","5","tab"],5)
                press_and_release("space")
                sleep(speed)
                p("tab",delay=speed)
                press_and_release("space")
                sleep(speed)
                p("tab",4)
                p("down")
                p("tab",5)
            p(list(index))
            p("tab",4)
            p("9",2)
            p(["tab","1","5","tab","0","tab"])
            if attitude: p({"grouchy":"g","logical":"l","careful":"c","gentle":["g","e"],"twisted":"t","helpful":"h","rough":"r","brainy":"b","calm":["c","a","l"],"tender":["t","e"],"cruel":["c","r"],"devoted":"d"}[attitude[k].lower()])
            p("tab",2)
            p(["8","0","tab"])
            p(["4","0","tab"],4)
            p(["1","2","7","tab"],5)
            p(["2","5","tab"],5)
            press_and_release("space")
            sleep(speed)
            p("tab",delay=speed)
            press_and_release("space")
            sleep(speed)
            p("tab",delay=speed)
            press_and_release("space")
            sleep(speed)
            p("tab",delay=speed)
            press_and_release("space")
            sleep(speed)
            p("tab",5)
            press_and_release("space")
            sleep(speed)
            p("tab",delay=speed)
            press_and_release("space")
            sleep(speed)
            p("shift + tab",2)
            release("shift")
            p("down")
            p("tab",7)
            if k != len(attitude)-1:
                k+=1
            if l != len(repeat)-1:
                l+=1
    else:
        if not isinstance(repeat, list):
            repeat = [repeat]
        for j in repeat:
            for i in range(int(j)):
                p("tab",2)
                p("9",2)
                p(["tab","1","5","tab","0","tab"])
                if attitude: p({"grouchy":"g","logical":"l","careful":"c","gentle":["g","e"],"twisted":"t","helpful":"h","rough":"r","brainy":"b","calm":["c","a","l"],"tender":["t","e"],"cruel":["c","r"],"devoted":"d"}[attitude[k].lower()])
                p("tab",2)
                p(["8","0","tab"])
                p(["4","0","tab"],4)
                p(["1","2","7","tab"],5)
                p(["2","5","tab"],5)
                p("tab",8)
                press_and_release("space")
                p("shift + tab",4)
                release("shift")
                p("down")
                p("tab",7)
            if k != len(attitude)-1:
                k+=1

#press play and put your curser on "#1"
sleep(3)

#yokai [can be list], attitude [can be list], repeat [amount for every yokai]
fill(yokai=["orcanos",322],attitude=["calm","rough"],repeat=["6",6])

#yokai can be medallium index or name

#calm is slowest attitude but that is unfixable