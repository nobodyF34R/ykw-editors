#!/opt/local/bin/python3
# coding: utf-8

"""
dump2.py (SHINNUCHI)

======

The MIT License (MIT)

Copyright (c) 2023 QWERTYUIOPASDFGHJKLZXCVBNM

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
"""

import json

yokais = {
    2046011958: "Pandle", 
    1799751128: "Undy", 
    1918710937: "Tanbo", 
    3827602063: "Cutta-nah", 
    1553528298: "Cutta-nah-nah", 
    1166263467: "Slacka-slash", 
    2859601318: "Brushido", 
    2104724135: "Washogun", 
    3100090952: "Lie-in", 
    2992314685: "Lie-in Heart", 
    315517635: "Hissfit", 
    1643699290: "Zerberker", 
    2028203291: "Snartle", 
    4136713569: "Mochismo", 
    4018801696: "Minochi", 
    933573919: "Tublappa", 
    2400801402: "Slicenrice (Rice and Dice)", 
    4067337791: "Slicenrice (Bear Care)", 
    182943320: "Flamurice (Rice and Dice)", 
    2005961245: "Flamurice (Firewall)", 
    1150518150: "Helmsman", 
    1445342312: "Reuknight", 
    1329405225: "Corptain", 
    2645360020: "Mudmunch", 
    3318738370: "Sgt. Burly", 
    4003089165: "Blazion", 
    4152457804: "Quaken", 
    3702270351: "Siro", 
    83617212: "Chansin", 
    3158803161: "Sheen", 
    4230997219: "Snee", 
    2774315928: "Gleam", 
    3645160255: "Benkei", 
    3227486846: "B3-NK1", 
    294016696: "Sushiyama", 
    144533497: "Kapunki", 
    1934455732: "Beetler (Too Serious)", 
    238716913: "Beetler (Lone Soldier)", 
    3421574353: "Beetall (Intimidation)", 
    3062292628: "Beetall (Lone Soldier)", 
    3538560400: "Cruncha", 
    408080822: "Demuncher", 
    21618935: "Devourer", 
    2699998931: "Brokenbrella", 
    4067932905: "Pittapatt", 
    966511628: "Snotsolong", 
    545324365: "Duchoo", 
    3556401853: "D'wanna", 
    1311595012: "N'more", 
    1463184197: "Q'wit", 
    3146751539: "Wazzat", 
    2012164562: "Houzzat", 
    2727653234: "Dummkap", 
    1431073508: "Faysoff", 
    53737814: "Lafalotta", 
    438880279: "Blips", 
    2354146817: "Tattletell", 
    2665791983: "Tattlecast", 
    2504679232: "Skranny", 
    2839163357: "Cupistol", 
    887949668: "Casanuva", 
    771110949: "Casanono", 
    2240145679: "So-Sorree", 
    931616744: "Bowminos", 
    1027182186: "Smogling", 
    3478345399: "Smogmella", 
    2117842652: "Signibble", 
    3330789817: "Signiton", 
    3751600376: "Statiking", 
    2403020941: "Master Oden", 
    797712772: "Failian", 
    3250302461: "Apelican", 
    2263857027: "Mirapo", 
    624097286: "Miradox", 
    2683602626: "Mircle", 
    1045680358: "Illoo", 
    659087783: "Elloo", 
    207991396: "Alloo", 
    2166860649: "Espy", 
    2554108456: "Infour", 
    4133838287: "Verygoodsir", 
    1801742127: "Tengu", 
    1920947822: "Flengu", 
    160243924: "Kyubi", 
    278270357: "Frostail", 
    2643369827: "Chymera", 
    2224401954: "Kingmera", 
    5875674: "Terrorpotta", 
    2972796849: "Dulluma", 
    2743396447: "Darumacho", 
    3131037982: "Goruma", 
    3102064831: "Wotchagot", 
    3365620317: "Pride Shrimp", 
    1250891874: "No-Go Kart", 
    1881615672: "Mistank", 
    886008723: "Noway (Blocker)", 
    1236836310: "Noway (Endurance)", 
    2356350198: "Impass (Blocker)", 
    4043634867: "Impass (Rocky Terrain)", 
    2506636727: "Walldin", 
    2352466200: "Roughraff", 
    3428822818: "Badude", 
    4268346784: "Bruff", 
    645579901: "Armsman", 
    2536523489: "Mimikin", 
    2663818008: "Blowkade", 
    2279445081: "Ledballoon", 
    3245191076: "Fidgephant", 
    3631652581: "Touphant", 
    4282759791: "Enduriphant", 
    317458484: "Zappary", 
    1207557386: "Frazzel", 
    2857398097: "Swelton", 
    3148741828: "Mad Mountain", 
    2729889157: "Lava Lord", 
    2953011819: "Castelius III", 
    2603495848: "Castelius II", 
    2836943658: "Castelius I", 
    2184511721: "Castelius Max", 
    51485601: "Rhinoggin (Guard Break)", 
    2120642532: "Rhinoggin (Lone Soldier)", 
    295973967: "Rhinormous (Guard Break)", 
    1825816586: "Rhinormous (Lone Soldier)", 
    146736398: "Hornaplenty", 
    1047638545: "Robonyan", 
    661291856: "Goldenyan", 
    4051387260: "Dromp", 
    3898634813: "Swosh", 
    3991934337: "Toadal Dude", 
    4109051072: "Uber Geeko", 
    3046311383: "Leggly", 
    1130078060: "Dazzabel", 
    4226283529: "Rattelle", 
    3808217416: "Skelebella", 
    1237787673: "Cadin", 
    162480675: "Cadable", 
    280261474: "Singcada", 
    3825660024: "Pupsicle (Penetrate)", 
    2574320701: "Pupsicle (Fangsicles)", 
    1555732253: "Chilhuahua (Penetrate)", 
    567108440: "Chilhuahua (Alpine Wall)", 
    1168221788: "Swelterrier", 
    1609739110: "Jumbelina", 
    221209266: "Boyclops", 
    2745600680: "Jibanyan", 
    454749645: "Thornyan", 
    2261636468: "Baddinyan", 
    1806853494: "Buchinyan", 
    2490923674: "Walkappa (Skilled Loafer)", 
    3910110943: "Walkappa (Water Play)", 
    3424348876: "Appak (Penetrate)", 
    2976685705: "Appak (Fill 'Er Up)", 
    3573570445: "Supyo", 
    1957105065: "Komasan", 
    1309620467: "Komane", 
    1841052904: "Komajiro (Omega)", 
    164690412: "Komajiro (Lightning Up!)", 
    2084133489: "Komiger (Omega)", 
    863554742: "Komiger (Lightning Up!)", 
    643344010: "Baku", 
    3880700931: "Bakulia", 
    1061394379: "Whapir (Good Fortune)", 
    1529828047: "Whapir (Free to Be)", 
    1296499848: "Drizzelda", 
    4126893037: "Nekidspeed", 
    1152508273: "Shmoopie", 
    1443122847: "Pinkipoo", 
    1327464414: "Pookivil", 
    1048957631: "Harry Barry", 
    753303304: "Frostina", 
    2488932461: "Blizzaria", 
    2369857836: "Damona", 
    2056910010: "Faux Kappa", 
    1669514747: "Tigappa", 
    3257242591: "Master Nyada", 
    3989993334: "Wantston", 
    4106831415: "Grubsnitch", 
    4228744724: "Wiglin", 
    1696488402: "Kelpacabana", 
    3843471189: "Steppa", 
    3460031638: "Rhyth", 
    3554148426: "Hungramps (Starver)", 
    2930766863: "Hungramps (Bear Care)", 
    2344292380: "Hungorge (Starver)", 
    4140622937: "Hungorge (Bear Care)", 
    3401789707: "Grainpa", 
    3499113521: "Tongus", 
    4173947755: "Nurse Tongus", 
    810502914: "Sandmeh (Sand Still)", 
    1295564615: "Sandmeh (Carefree Spirit)", 
    1081410574: "Mr. Sandmeh (Sand Still)", 
    1023602763: "Mr. Sandmeh (Carefree Spirit)", 
    1747737428: "Pallysol", 
    1388358624: "Scarasol", 
    1879396303: "Lodo", 
    2988432595: "Supoor Hero", 
    1763606158: "Chippa", 
    3474428761: "Gnomey", 
    3934047365: "High Gnomey", 
    3647396296: "Enerfly", 
    3229477001: "Enefly", 
    1641725613: "Betterfly", 
    2025951212: "Peppillon", 
    2007757884: "Predictabull", 
    178502582: "Smashibull", 
    2297637991: "Don Chan", 
    3718397111: "Ray O'Light", 
    4005046778: "Happierre", 
    3067820460: "Reversa", 
    2948597997: "Reversette", 
    241655497: "Ol' Saint Trick", 
    394030984: "Ol' Fortune", 
    2043791553: "Rollen", 
    1623914880: "Dubbles", 
    1233379831: "Papa Bolt", 
    1352192182: "Uncle Infinite", 
    4047472274: "Mama Aura", 
    3894720467: "Auntie Heart", 
    1254874508: "Kyryn", 
    1406201037: "Unikirin", 
    3562330446: "Leadoni", 
    3444566031: "Mynimo", 
    1530285593: "Ake", 
    3817482620: "Payn", 
    4203812925: "Agon", 
    3770815751: "Wydeawake", 
    876284733: "Allnyta", 
    3316206299: "Herbiboy", 
    3660506547: "Carniboy", 
    2120028613: "Negatibuzz", 
    3336664736: "Moskevil", 
    3757721569: "Scritchy", 
    1367906203: "Dimmy (Secrecy)", 
    754934750: "Dimmy (Wavy Body)", 
    166430669: "Blandon (Secrecy)", 
    1956410248: "Blandon (Wavy Body)", 
    284210828: "Nul", 
    3658254148: "Suspicioni (Suspicion)", 
    2809885441: "Suspicioni (Eyesight A)", 
    3273111045: "Tantroni", 
    3896174022: "Contrarioni", 
    1433276435: "Hidabat", 
    3367577770: "Abodabat", 
    3517061611: "Belfree", 
    1484681826: "Yoink", 
    4063461127: "Gimme", 
    2098539966: "K'mon-K'mon", 
    1872790096: "Yoodooit", 
    3608995125: "Count Zapaway", 
    2030553752: "Tyrat", 
    1655758881: "Tengloom", 
    2074857824: "Nird", 
    935563782: "Snobetty", 
    2407527779: "Slimamander", 
    2357685336: "Dracunyan", 
    1961084999: "Negasus", 
    1845033222: "Neighfarious", 
    2188351250: "Timidevil", 
    986968183: "Beelzebold", 
    600359222: "Count Cavity", 
    1653768918: "Eyesoar", 
    2072621975: "Eyellure", 
    2059114061: "Greesel", 
    1671472908: "Awevil", 
    646882515: "Wobblewok", 
    456691514: "Coughkoff", 
    35896955: "Hurchin", 
    2975326376: "Droplette", 
    1205583869: "Drizzle", 
    2823606761: "Slush", 
    1589677756: "Alhail", 
    2204205610: "Gush", 
    1827192363: "Peckpocket", 
    1228096695: "Robbinyu", 
    1978896234: "Rockabelly (Glossy Skin)", 
    295651950: "Rockabelly (Long Lasting)", 
    741375313: "Squeeky", 
    2984723944: "Rawry", 
    2970821958: "Buhu", 
    2819101703: "Flumpy", 
    2200258500: "Skreek", 
    856127353: "Manjimutt", 
    1936658755: "Multimutt", 
    1785995266: "Sir Berus", 
    2654127030: "Furgus", 
    156967565: "Furdinand", 
    65403663: "Nosirs", 
    4284995736: "Dismarelda", 
    881569405: "Chatalie", 
    764452668: "Nagatha (Skilled Loafer)", 
    1241274936: "Nagatha (Too Serious)", 
    3143212138: "Papa Windbag", 
    290477281: "Ben Tover", 
    1128085621: "Cheeksqueek", 
    1512442164: "Cuttincheez", 
    2850829188: "Toiletta", 
    468618595: "Foiletta", 
    4052689874: "Sproink", 
    4219559696: "Compunzer", 
    3801771601: "Lamedian", 
    1716938665: "Grumples", 
    3739877580: "Everfore", 
    3354472845: "Eterna", 
    3912560894: "Insomni", 
    4029661631: "Sandi", 
    2740120070: "Arachnus", 
    3125402439: "Arachnia", 
    2251929050: "Cricky", 
    3255300392: "Noko", 
    3501350598: "Bloominoko", 
    3676094569: "Pandanoko", 
    2492209716: "Snaggly", 
    3542900964: "Whinona", 
    3419633190: "Heheheel", 
    3536340839: "Croonger", 
    4192539812: "Urnaconda", 
    1298491007: "Fishpicable", 
    1607518609: "Rageon", 
    1187772624: "Tunatic", 
    1951624455: "Flushback", 
    3248082698: "Vacuumory", 
    4131864376: "Irewig", 
    2032511087: "Firewig", 
    1745762723: "Draggie", 
    4124639514: "Dragon Lord", 
    3972149339: "Azure Dragon", 
    1325095005: "Mermaidyn", 
    1804601217: "Mermadonna", 
    1921726144: "Mermother", 
    1548679091: "Lady Longnek", 
    4138950550: "Daiz", 
    4020793047: "Confuze", 
    3882659572: "Chummer", 
    4269252533: "Shrook", 
    3205480098: "Spenp", 
    2786365411: "Almi", 
    129227207: "Babblong", 
    514386054: "Bananose", 
    3841102038: "Draaagin", 
    3438217826: "SV Snaggerjag", 
    1025240221: "Copperled", 
    254643743: "Cynake", 
    604036572: "Slitheref", 
    2242350072: "Venoct", 
    2629614265: "Shad. Venoct", 
    2534548502: "Shogunyan", 
    799949683: "Komashura", 
    410039105: "Gilgaros", 
    2337239218: "Spoilerina", 
    180690095: "Elder Bloom", 
    3408336520: "Poofessor", 
    2994305994: "Dandoodle", 
    1939567085: "Slurpent", 
    903818430: "Sapphinyan", 
    519208829: "Emenyan", 
    132730428: "Rubinyan", 
    1219025147: "Topanyan", 
    751050239: "Dianyan", 
    1510509852: "Melonyan", 
    1125366877: "Oranyan", 
    1748955038: "Kiwinyan", 
    1898307295: "Grapenyan", 
    1046759448: "Strawbnyan", 
    662665561: "Watermelnyan", 
    1467893876: "Robokapp", 
    1842773294: "Robokoma", 
    3580500555: "Robogramps", 
    3353327013: "Robomutt", 
    2137248448: "Robonoko", 
    3803507321: "Robodraggie", 
    1147659048: "Wondernyan", 
    1322859178: "Robonyan F", 
    1550619972: "Sailornyan", 
    3838898721: "Machonyan", 
    621845233: "Hovernyan", 
    3540910611: "Darknyan", 
    3165905527: "Jibakoma", 
    68125970: "Jetnyan", 
    4244235962: "Unfairy", 
    3997976916: "Unkaind", 
    1458581041: "Untidy", 
    244530791: "Unpleasant", 
    3056556290: "Unkeen", 
    829356020: "Grublappa", 
    2607234943: "Madmunch", 
    3382219868: "Badsmella", 
    2085762641: "Mad Kappa", 
    1860671935: "Shamasol", 
    3386659250: "Gnomine", 
    1902130903: "Defectabull", 
    2566455645: "Feargus", 
    1211144886: "Scaremaiden", 
    1518679384: "Wrongnek", 
    2947172651: "Grumpus Khan", 
    3172984517: "Groupus Khan", 
    94601632: "Slumberhog", 
    2557786393: "Snortlehog", 
    550035068: "Panja Pupil", 
    847081874: "Panja Pro", 
    2327910135: "Samureel", 
    3533833889: "Time Keeler", 
    1780376004: "Takoyakid", 
    712378366: "Takoyaking", 
    2462736539: "Danke Sand", 
    2155859829: "No Sandkyu", 
    952346640: "Sumodon", 
    2769588393: "Yokozudon", 
    497612748: "Whateverest", 
    253581346: "Whatuption", 
    3080798023: "Happycane", 
    4022480657: "Starrycane", 
    2454454409: "Gutsy Bones", 
    871569367: "Meganyan", 
    1521258489: "Cap'n Crash", 
    1741465161: "Eyeclone", 
    3901510633: "Kin", 
    4198104071: "Gin", 
    2938906937: "Dame Dedtime", 
    544005273: "Dame Demona", 
    3750011266: "Slimamander", 
    3332346051: "Eyedra", 
    3806627890: "Sproink", 
    4227840371: "Hoggles", 
    2772759266: "SV Snaggerjag", 
    3160392611: "Styx Mk.VI", 
    2552552274: "Massiface", 
    2168449555: "Clipso", 
    704907074: "Phantasmurai", 
    857683459: "Spooklunk", 
    392441586: "Tarantutor", 
    1355043874: "Dr. Maddiman", 
    1239377251: "Dr. Nogut", 
    1839496594: "McKraken", 
    4025805379: "McKraken", 
    4142914306: "Squisker", 
    1494274860: "Duwheel", 
    1685125788: "Chirpster", 
    3532964851: "Wobblewok", 
    3589044825: "Hans Full", 
    2128058120: "Eyephoon", 
    487388457: "Mallice", 
    1136115384: "Cap'n Rex", 
    4053230248: "Flippa", 
    3810708806: "Floppa", 
    3057064056: "Dame Dredful", 
    2721860424: "Kat Kraydel", 
    2337747400: "Goldy Bones", 
    2692375051: "Glitzy Bones", 
    3438758680: "Hans Galore", 
    1442497739: "Retinado", 
    349729319: "Gargaros", 
    107863497: "Ogralus", 
    3201415852: "Orcanos", 
    1456622790: "Snottle", 
    3406132351: "Moximous N", 
    1941508890: "Moximous K", 
    2893525287: "Jibanyan S", 
    2071344678: "Komasan S", 
    1651312487: "Komajiro S", 
    1002127958: "Darkyubi", 
    3079793018: "Illuminoct", 
    63412728: "Gargaros", 
    3145465501: "Ogralus", 
    2848870771: "Orcanos", 
    3370732257: "Rubeus J", 
    4119421777: "Hardy Hound", 
    2060031729: "Hinozall", 
    1116052322: "Bronzlow", 
    2403938353: "Teastroyer", 
    2989037953: "Infinipea", 
    1202306881: "Headasteam", 
    640401: "Kabuking"
}

reverse_yokais = {v.lower(): k for k, v in yokais.items()}

items = {
    2170728737: "Chocobar", 
    1803927674: "Plum Rice Ball", 
    4069298624: "Leaf Rice Ball", 
    2240520534: "Roe Rice Ball", 
    468661493: "Shrimp Rice Ball", 
    1783081549: "Sandwich", 
    4082039799: "Custard Bread", 
    1831497300: "Curry Bread", 
    2219428705: "Baguette", 
    439180994: "Blehgel", 
    1744901140: "10-Cent Gum", 
    4043851182: "Gooey Candy", 
    2249159992: "Giant Cracker", 
    409723035: "Fruit Drops", 
    1869402125: "Shaved Ice", 
    4133847479: "Candy Apple", 
    1774419491: "Milk", 
    4039782297: "Coffee Milk", 
    2278366991: "Fruit Milk", 
    430541484: "Amazing Milk", 
    1821141158: "Y-Cola", 
    4119148828: "Soul Tea", 
    2189560202: "Spiritizer Y", 
    484875305: "VoltXtreme", 
    1833829009: "Hamburger", 
    4098315051: "Cheeseburger", 
    2202035133: "Double Burger", 
    488961566: "Nom Burger", 
    1858787071: "Ramen Cup", 
    4156786501: "Pork Ramen", 
    2160375763: "Deluxe Ramen", 
    513811056: "Everything Ramen", 
    1704366530: "Cucumber Roll", 
    4238327928: "Shrimp Sushi", 
    2342056174: "Salmon Sushi", 
    368862541: "Fatty Tuna Sushi", 
    1683291125: "Pot Stickers", 
    4250774095: "Liver & Chives", 
    2321193689: "Crab Omelet", 
    339611514: "Chili Shrimp", 
    1664696300: "Mapo Tofu", 
    3539717416: "Carrot", 
    1274190994: "Cucumber", 
    1022733316: "Bamboo Shoot", 
    2727426471: "Matsutake", 
    3502076785: "Chicken Thigh", 
    1236542155: "Slab Bacon", 
    1051923037: "Beef Tongue", 
    2698479614: "Marbled Beef", 
    3514767686: "Dried Mackerel", 
    1215711484: "Yellowtail", 
    1064401002: "Fresh Urchin", 
    2702568905: "Choice Tuna", 
    3559919555: "Chicken Curry", 
    1295605369: "Lamb Curry", 
    977170159: "Seafood Curry", 
    2757425996: "Buster Curry", 
    3546139610: "Veggie Curry", 
    3589432820: "Cheesecake", 
    1291531342: "Shortcake", 
    1006372056: "Royal Pancakes", 
    2778239355: "Jumbo Parfait", 
    3533677037: "Sweet Rice Cake", 
    1268183127: "Spirit Doughnut", 
    1016185025: "Soul Doughnut", 
    3618954157: "Steamed Daikon", 
    1321044503: "Boiled Egg", 
    968538753: "Beef Skewers", 
    2816356130: "Top-Class Oden", 
    3598102938: "Soba Noodles", 
    3710580391: "Potato Chips", 
    1143187229: "Tasty Nibbles", 
    858036107: "Cheesy Chips", 
    2906653224: "Snow-Pea Snack", 
    2370076515: "Mini Exporb", 
    320924352: "Small Exporb", 
    2317990778: "Medium Exporb", 
    4247686124: "Large Exporb", 
    1665801807: "Mega Exporb", 
    340602585: "Holy Exporb", 
    397252210: "Staminum", 
    2393163720: "Staminum Alpha", 
    279199406: "Hidden Hits", 
    2309844756: "Top Techniques", 
    4272578434: "Soul Secrets", 
    469268883: "A Serious Life", 
    2196842537: "Think Karate", 
    4126546111: "Use Karate", 
    1804766492: "Skill Compendium", 
    479575434: "Skill Encyclopedia", 
    2241653808: "Get Guarding", 
    4070300838: "Guard Gloriously", 
    1646575927: "Li'l Angel Heals", 
    354677153: "Bye, Li'l Angel", 
    1977907268: "The Pest's Quest", 
    48449746: "The Perfect Pest", 
    2615810408: "Support Life #7", 
    3974965758: "Support Special", 
    367732779: "Str. Talisman", 
    2363652497: "Spirit Talisman", 
    4226107655: "Def. Talisman", 
    1703009444: "Speed Talisman", 
    338248220: "Nasty Medicine", 
    2367689638: "Bitter Medicine", 
    4196868912: "Mighty Medicine", 
    376437829: "Getaway Plush", 
    1628217366: "Iron Doll", 
    291919001: "Bronze Doll", 
    2288977187: "Silver Doll", 
    4285019573: "Golden Doll", 
    369856640: "Platinum Doll", 
    2908180302: "Fish Bait", 
    878583540: "Black Syrup", 
    2895455609: "Dancing Star", 
    899445955: "Lottery Ticket", 
    1117471829: "Music Card", 
    1535145236: "Bronze Tag", 
    3320111287: "Silver Tag", 
    3001274401: "Gold Tag", 
    747062658: "Essence of Evil", 
    440013732: "Legendary Blade", 
    2201174558: "Cursed Blade", 
    2220787207: "Holy Blade", 
    4097077896: "General's Soul", 
    1783686955: "Love Buster", 
    492296125: "GHz Orb", 
    1676061440: "Unbeatable Soul", 
    2586342239: "Platinum Bar", 
    350329750: "Snowstorm Cloak", 
    1948652147: "Love Scepter", 
    4082742929: "Glacial Clip", 
    52503269: "Buff Weight", 
    1934349930: "Shard of Evil", 
    3979297737: "Ageless Powder", 
    2638591814: "Dragon Orb", 
    1098757352: "Raging Blade", 
    913998974: "Sand Suit", 
    2943604164: "Ethereal Water", 
    3631539538: "Cursed Journal", 
    1221327043: "Horn", 
    1070385237: "Mem-o-Vac", 
    156362294: "Mermaid Pearl", 
    1771466707: "Love-Packed Rice Ball", 
    2119620256: "Broken Bell", 
    2033914553: "Battered Blade", 
    3761390339: "Rough Whetstone", 
    2536862613: "Sinister Whetstone", 
    126512644: "Sublime Whetstone", 
    273340279: "Carved Bear", 
    1733158881: "Goldfish Lantern", 
    4265915995: "Master's Lantern", 
    2302904013: "Gold Emblem", 
    388436846: "Takoyaki Tray", 
    1612719096: "Dune Sand", 
    4180243010: "Vintage Parasol", 
    2385396436: "Terracotta Figure", 
    512843589: "Red Hibiscus", 
    3881797402: "Healing Herb", 
    2421733260: "Stinky Herb", 
    238821935: "Bitter Herb", 
    2592718716: "Red Coin", 
    58781382: "Yellow Coin", 
    1955061328: "Orange Coin", 
    3940764659: "Pink Coin", 
    2648996709: "Green Coin", 
    82651871: "Blue Coin", 
    1944721993: "Purple Coin", 
    3814000600: "Light-Blue Coin", 
    3411442988: "Five-Star Coin", 
    1542021309: "Special Coin", 
    753815595: "Yo Mystery Coin", 
    1277811150: "Kai Mystery Coin", 
    992930136: "Sum Mystery Coin", 
    2720512226: "Mon Mystery Coin", 
    905273706: "Flower Excitement Coin", 
    1728350733: "Bird Excitement Coin", 
    268679835: "Wind Excitement Coin", 
    2299194145: "Moon Excitement Coin", 
    4262321079: "Glitzy Coin", 
    1617514004: "Traveler's Coin North", 
    393117314: "Traveler's Coin Northeast", 
    2389126968: "Traveler's Coin East", 
    4183826350: "Traveler's Coin Central", 
    1776222783: "Traveler's Coin West", 
    517485225: "Traveler's Coin Mountain", 
    2116008780: "Traveler's Coin South", 
    152603610: "Traveler's Coin Midwest", 
    2417089120: "Traveler's Coin Island", 
    3877038838: "Mystery Coin", 
    2037546837: "Boar Mystery Coin", 
    242569155: "Deer Mystery Coin", 
    2541493881: "Butterfly Mystery Coin", 
    3766169327: "Cheerful Coin", 
    3707752950: "Red Coin Fragment", 
    2885214560: "Yellow Coin Fragment", 
    854700250: "Orange Coin Fragment", 
    1173782604: "Pink Coin Fragment", 
    3578371549: "Green Coin Fragment", 
    2723065163: "Blue Coin Fragment", 
    3263767726: "Purple Coin Fragment", 
    3045987384: "Light-Blue Fragment", 
    1200047969: "Red Box", 
    1178938710: "Gate Globe", 
    2285637778: "Noko Orb", 
    288702760: "Kyubi Orb", 
    3493734398: "Green Cicada", 
    1753366683: "★Green Cicada", 
    1228371524: "Brown Cicada", 
    4052422945: "★Brown Cicada", 
    1702355358: "Large Cicada", 
    3721103099: "★Large Cicada", 
    4236161060: "African Cicada", 
    1153619777: "★African Cicada", 
    1043351250: "Evening Cicada", 
    2257330615: "★Evening Cicada", 
    2339995826: "Asian Cicada", 
    868607959: "★Asian Cicada", 
    1314566749: "Sawtooth Stag", 
    4142323000: "★Sawtooth Stag", 
    858605080: "Giant Stag", 
    2341544317: "★Giant Stag", 
    354227473: "Miyama Stag", 
    2913038964: "★Miyama Stag", 
    3612599271: "Dorcus Stag", 
    1877968002: "★Dorcus Stag", 
    2689913713: "Rhino Beetle", 
    417903636: "★Rhino Beetle", 
    2350138539: "White Moth", 
    883434446: "★White Moth", 
    3374651071: "Swallowtail", 
    1905881562: "★Swallowtail", 
    2063668422: "Peacock Butterfly", 
    3283973027: "★Peacock Butterfly", 
    541504394: "Violet Butterfly", 
    2566575343: "★Violet Butterfly", 
    3662603053: "Whitetail", 
    1660060744: "★Whitetail", 
    2907296699: "Blue Emperor", 
    368424158: "★Blue Emperor", 
    2969153051: "Big Dragonfly", 
    138791294: "★Big Dragonfly", 
    3189909033: "Firefly", 
    111034700: "★Firefly", 
    3109020208: "Ladybug", 
    32736597: "★Ladybug", 
    962429643: "Grasshopper", 
    2179065262: "★Grasshopper", 
    1463911196: "Rice Grasshopper", 
    4026393721: "★Rice Grasshopper", 
    3739594700: "Locust", 
    1717160105: "★Locust", 
    2455941619: "Cricket", 
    719246998: "★Cricket", 
    2087506143: "Bell Cricket", 
    3302012858: "★Bell Cricket", 
    201729104: "Bush Cricket", 
    3032105781: "★Bush Cricket", 
    1563510735: "Asian Mantis", 
    3851231402: "★Asian Mantis", 
    2850201434: "Praying Mantis", 
    291436607: "★Praying Mantis", 
    1345079045: "Longhorn", 
    3901759584: "★Longhorn", 
    3448658526: "Stick Insect", 
    1966226747: "★Stick Insect", 
    3710068532: "Mole Cricket", 
    1704935505: "★Mole Cricket", 
    2614427096: "Wood Louse", 
    594057917: "★Wood Louse", 
    657160083: "Flower Scarab", 
    2677477622: "★Flower Scarab", 
    3848634725: "Scarab Beetle", 
    1574561280: "★Scarab Beetle", 
    2500818410: "Drone Beetle", 
    766710415: "★Drone Beetle", 
    3792192892: "Stinkbug", 
    1521754649: "★Stinkbug", 
    4123589647: "Diving Beetle", 
    1299487594: "★Diving Beetle", 
    3025330938: "Water Bug", 
    216958367: "★Water Bug", 
    191619145: "Jewel Beetle", 
    3017246508: "★Jewel Beetle", 
    3973303630: "Grass Lizard", 
    1416604203: "★Grass Lizard", 
    2854492066: "Lizard", 
    311980231: "★Lizard", 
    2194656409: "Fire-Belly Newt", 
    980659196: "★Fire-Belly Newt", 
    1516012502: "Tadpole Shrimp", 
    3806389427: "★Tadpole Shrimp", 
    708212569: "Pond Snail", 
    2458521660: "★Pond Snail", 
    1143633550: "Apple Snail", 
    4237693419: "★Apple Snail", 
    3355352717: "Snail", 
    2135095784: "★Snail", 
    3460879014: "Tree Frog", 
    1995748803: "★Tree Frog", 
    4212356157: "Toad", 
    1135547224: "★Toad", 
    3522973129: "Turtle", 
    1765812908: "★Turtle", 
    3325883578: "Softshell Turtle", 
    2122355679: "★Softshell Turtle", 
    230968935: "Crab", 
    3044550914: "★Crab", 
    2496471005: "Crayfish", 
    745633976: "★Crayfish", 
    2108603112: "Lobster", 
    3306347917: "★Lobster", 
    3321527362: "Shrimp", 
    2101746471: "★Shrimp", 
    3002944724: "Starfish", 
    172043185: "★Starfish", 
    350191398: "Sea Horse", 
    2892175427: "★Sea Horse", 
    2711009606: "Carp", 
    422239779: "★Carp", 
    3599862224: "Sweetfish", 
    1848503989: "★Sweetfish", 
    748280183: "Mullet", 
    2485501458: "★Mullet", 
    2476792772: "Cherry Salmon", 
    723303585: "★Cherry Salmon", 
    2973484076: "Koi", 
    159884105: "★Koi", 
    1224023155: "Black Bass", 
    4031347478: "★Black Bass", 
    2059632369: "Salmon", 
    3263109524: "★Salmon", 
    1072835813: "Giant Huchen", 
    2270055296: "★Giant Huchen", 
    178883198: "Sardine", 
    2987781403: "★Sardine", 
    950003964: "Mackerel", 
    2149814169: "★Mackerel", 
    4208008714: "Chub Mackerel", 
    1114470767: "★Chub Mackerel", 
    2379624092: "Whiting", 
    896158201: "★Whiting", 
    3683420442: "Barracuda", 
    1664151167: "★Barracuda", 
    2327571077: "Flying Fish", 
    839355872: "★Flying Fish", 
    1335416938: "Snakehead", 
    4146380559: "★Snakehead", 
    3481974929: "Rockfish", 
    2000084980: "★Rockfish", 
    1537141217: "Grunt", 
    3810692740: "★Grunt", 
    1559440888: "Sea Bass", 
    3830401693: "★Sea Bass", 
    2884009365: "Blackfish", 
    324672240: "★Blackfish", 
    3977357177: "Filefish", 
    1437450268: "★Filefish", 
    1689619369: "Halibut", 
    3691637964: "★Halibut", 
    3264723035: "Flounder", 
    2049695550: "★Flounder", 
    2820732269: "Red Snapper", 
    278696456: "★Red Snapper", 
    1451485483: "Beakfish", 
    3997142606: "★Beakfish", 
    3705752835: "Porgy", 
    1683827302: "★Porgy", 
    330480447: "Amberjack", 
    2869877850: "★Amberjack", 
    4257012243: "Porcupine Fish", 
    1157676406: "★Porcupine Fish", 
    562354621: "Loach", 
    2570632920: "★Loach", 
    737418606: "Beltfish", 
    2471000587: "★Beltfish", 
    3836210002: "Conger Eel", 
    1545309239: "★Conger Eel", 
    3821678411: "Eel", 
    1534478382: "★Eel", 
    3096283143: "Catfish", 
    3272546: "★Catfish", 
    3370613896: "Jellyfish", 
    1885019117: "★Jellyfish", 
    1675120560: "Octopus", 
    3680774357: "★Octopus", 
    2894838156: "Reef Squid", 
    339205865: "★Reef Squid", 
    4094334520: "Cuttlefish", 
    1287057757: "★Cuttlefish", 
    1374563634: "Firefly Squid", 
    3914484311: "★Firefly Squid", 
    3046148301: "Squid", 
    221048744: "★Squid", 
    897771574: "Spear Squid", 
    2369687379: "★Spear Squid", 
    1116068000: "Anglerfish", 
    4198088645: "★Anglerfish", 
    2585171951: "Stingray", 
    581628042: "★Stingray", 
    3219147806: "Marlin", 
    123480955: "★Marlin", 
    2198709934: "Tuna", 
    1001505227: "★Tuna"
}

reverse_items = {v.lower(): k for k, v in items.items()}

equipments = {
    1158785574: "Worn Bangle", 
    3681894277: "Cheap Bracelet", 
    3692624796: "Rocker Wrist", 
    2893156115: "Power Bracelet", 
    2870987530: "Brute Bracer", 
    1020072578: "Grand Bracelet", 
    897277609: "Sun Bracelet", 
    1271538196: "Comet Bracelet", 
    1115450943: "Fiend Band", 
    722316273: "Legend Bracelet", 
    1154727953: "Rusty Ring", 
    3669448114: "Ugly Ring", 
    3722088875: "Pretty Ring", 
    2914018596: "Rainbow Ring", 
    2866651453: "Illusion Ring", 
    1024424117: "Fairy Ring", 
    884552862: "Lunar Ring", 
    1242056739: "Ring of Fate", 
    1136526344: "Fiend Ring", 
    718258630: "Legend Ring", 
    1184202312: "Aged Charm", 
    3639733227: "Old Charm", 
    3751555058: "Runic Charm", 
    2952190845: "Protective Charm", 
    2828738404: "Armor Charm", 
    1061799660: "Lucky Charm", 
    922716871: "Galaxy Charm", 
    1213134458: "Earth Charm", 
    1106819665: "Fiend Charm", 
    680099743: "Legend Charm", 
    1196889215: "Simple Badge", 
    3644031452: "Black Badge", 
    3730720197: "Shiny Badge", 
    2922688842: "Cute Badge", 
    2841212243: "Hermes Badge", 
    1049341147: "Aurora Badge", 
    926802160: "Meteor Badge", 
    1233951821: "Lightning Badge", 
    1077596262: "Fiend Badge", 
    692786600: "Legend Badge", 
    1108869882: "Cicada Sword", 
    3675345728: "Beefy Bell", 
    2887148502: "Spell Bell", 
    846394997: "Tough Bell", 
    1165346531: "Speed Bell", 
    3699152729: "Big Bottle", 
    2877007823: "Tengu Fan", 
    1002748510: "Cheery Coat", 
    1287883464: "Nail Bat", 
    1550776226: "Drumsticks", 
    3311904280: "Robovitamin E", 
    2992674446: "Burly's Wristband", 
    585075487: "Memory Chime", 
    3037549207: "Bony Band", 
    728352564: "Fleshy Band", 
    738460461: "Reversword", 
    1526936507: "Turnabeads", 
    3255460353: "Reflector", 
    1440267145: "Paradise Ball", 
    1138387149: "Sinister Screed", 
    3671275895: "Cursed Sword", 
    2916354529: "Cursed Staff", 
    867212354: "Cursed Shield", 
    1152888020: "Cursed Robe", 
    1100797588: "Restraint Belt", 
    2945628088: "Monkey Circlet", 
    4256025923: "General's Medal", 
    1688509689: "Lt. Gen's Medal", 
    329493615: "Maj. Gen. Medal", 
    2378643916: "Colonel's Medal", 
    4206889306: "Major's Medal", 
    1674139872: "Captain's Medal", 
    349071478: "CDR.'s Medal", 
    2222028263: "Lt.'s Medal"
}

reverse_equipments = {v.lower(): k for k, v in equipments.items()}

importants = {
    1332445335: "Yo-kai Watch", 
    3596800301: "Yo-kai Watch", 
    496659440: "Model Zero", 
    917977139: "Curious Clock", 
    1102055589: "Curious Clock", 
    2707808699: "Yo-kai Medallium", 
    1208370318: "Bug Net", 
    3507426612: "Fishing Rod", 
    2785551778: "Museum Ticket", 
    1450226134: "Breeze Cycle", 
    3480871020: "Spring Cycle", 
    2270540466: "Sunset Cycle", 
    4031939108: "Seaside Cycle", 
    1626185653: "Sakura Cycle", 
    401256227: "Forest Cycle", 
    1999447750: "Cirrus Cycle", 
    2758224: "Sunshine Cycle", 
    2569226218: "Splendid Cycle", 
    3995367292: "Sinister Cycle", 
    1883300575: "Sparkling Cycle", 
    122147401: "Sunset Cycle", 
    2655945715: "Seaside Cycle", 
    3913921381: "Sakura Cycle", 
    2046209780: "Forest Cycle", 
    250715746: "Cirrus Cycle", 
    4038408713: "Sunshine Cycle", 
    2276592287: "Splendid Cycle", 
    515595045: "Sinister Cycle", 
    1773956019: "Sparkling Cycle", 
    2471723833: "Select-A-Coin", 
    561480000: "Select-A-Coin +", 
    2487109408: "Day Pass", 
    2049975820: "Free 'n' Easy Pass", 
    323085250: "Stamp Card", 
    3095318778: "Extra Homework", 
    639255897: "Ancient Herbs", 
    1360885199: "Pro Screwdriver", 
    3356763253: "Spirit Doughnuts", 
    3205698787: "Soul Doughnuts", 
    799803762: "Mom's Directions", 
    1487616484: "School Keys", 
    2320020088: "Komasan's Letter", 
    338438107: "Swirly Bell", 
    1663768397: "Heckapeño", 
    4196550391: "Top-Notch Watch", 
    2368042593: "Mysterious Marble", 
    1788697446: "Rockaway Extract", 
    1543533829: "Milk Bottle Tops", 
    721896851: "Moximous Game", 
    3830756271: "Shack Key", 
    221714074: "Mega Watch", 
    1057059864: "Hose", 
    173724291: "Back Door Key", 
    1682363220: "Large Fancy Key", 
    4249846510: "Small Fancy Key", 
    3812194230: "Yo-kai World Key", 
    75586225: "Spooky Key", 
    2009767659: "Boar Key", 
    3883238266: "Deer Key", 
    1938188839: "Butterfly Key", 
    2103304725: "Payn Oil", 
    3261391014: "Next HarMEOWny Pic 1", 
    1390148919: "Next HarMEOWny Pic 2", 
    635227553: "Next HarMEOWny Pic 3", 
    1159414852: "Next HarMEOWny Pic 4", 
    840725714: "Next HarMEOWny Pic 5", 
    2870289768: "Next HarMEOWny Pic 6", 
    3692172798: "Next HarMEOWny Pic 7", 
    1115062365: "Next HarMEOWny Pic 8", 
    896643275: "Next HarMEOWny Pic 9", 
    2893603185: "Next HarMEOWny Pic 10", 
    3682587111: "Derriera Dragon", 
    1270926454: "Key to Apt. C-302", 
    1019739360: "Key to Apt. A-201", 
    1849038727: "Key to Apt. A-203", 
    422651665: "Key to Apt. B-102", 
    2151184043: "Key to Apt. B-204", 
    4148119101: "Key to Apt. B-301", 
    1767625630: "Key to Apt. C-101", 
    509403912: "Key to Apt. C-303", 
    4158193168: "Movie Poster", 
    2162151046: "Rockin' Jumpsuit", 
    433495868: "Hero Cutout", 
    1859235754: "Film Reel", 
    4268667451: "Curry-Shop Sign", 
    2305393325: "Famous Frock", 
    3920497480: "Otterina", 
    2661891038: "Y-Cola Bottle", 
    127953508: "Waddle Potty", 
    1890015986: "Snap-Turtle Doll", 
    4005810001: "Nyaight Scroll", 
    2579824583: "Victory Scroll", 
    13479549: "Nyext Scroll", 
    4158121970: "Bun of Oneness", 
    1860089416: "Critical Lost Item", 
    2277315453: "Ghostly Goo", 
    4038730731: "Red Card Key", 
    1773367889: "Blue Card Key", 
    515130055: "Gold Card Key", 
    2383109974: "Muscle Belt", 
    4178341824: "Blunt Sword", 
    2580276773: "New Retro Robot", 
    4006401715: "Old Retro Robot", 
    2009433865: "Treasure Map", 
    12760991: "Soggy Map", 
    2661687868: "Crumpled Map", 
    3919647402: "Stained Map", 
    1890075408: "New Treasure Map", 
    128938886: "Treasure Room Key", 
    2534436375: "Final Treasure Map", 
    3759627905: "Strange Handle", 
    3001464294: "B&W Camera", 
    3319891312: "School Photo", 
    1558762698: "Galleria Blvd Pic", 
    737141852: "Gourdzilla Photo", 
    3045814783: "Autograph Card", 
    3263971689: "Fluffy Towel", 
    3848423452: "Sharp-Toothed Comb", 
    2087393702: "Dance Revolution", 
    191637808: "Hexpress Pass", 
    2500377747: "Gera Gera Land Ticket", 
    3792669701: "Paradise Springs Ticket", 
    2064047551: "Wolfit Down Ticket", 
    201452841: "Heavenly Bath Pass", 
    2629759160: "Mountain Bath Pass", 
    3954819118: "Hill Bath Pass", 
    2340309451: "Wanderer's Bath Pass", 
    4235819357: "Forest Bath Pass", 
    1701849319: "Lucky Bath Pass", 
    309794929: "Treasure Bath Pass", 
    2350091730: "Utility Belt", 
    4212440388: "Cloak of Secrecy", 
    1646128382: "Brake Handle", 
    354081896: "Happy-Go-Lucky Pass", 
    2242232825: "Lucky Crank-a-Coin", 
    4070764911: "Moxie Mark", 
    2689800712: "Important Item 20", 
    3612617374: "Important Item 21", 
    1314749220: "Important Item 22", 
    962218930: "Important Item 23", 
    2805915153: "Important Item 24", 
    3493457543: "Important Item 25", 
    3503128323: "Melon Seeds", 
    2815053717: "Orange Seeds", 
    930435588: "Kiwi Seeds", 
    1081238162: "Grape Seeds", 
    548793207: "Berry Seeds", 
    1471339489: "Watermelon Sds.", 
    3468397147: "Walkappa Cog", 
    3116153549: "Komasan Cog", 
    668479342: "Hungramps Cog", 
    1356799992: "Manjimutt Cog", 
    3386265154: "Noko Cog", 
    3201400532: "Draggie Cog", 
    778986309: "F-Series Bell", 
    1500074963: "Sailor Bell", 
    194558132: "Macho Bell", 
    2090829858: "Wonderer's Bell", 
    3851868568: "Jet Bell", 
    2459035918: "Boo Bundle", 
    217414829: "Keepsake Cap", 
    2079476795: "Dark Bell"
}

reverse_importants = {v.lower(): k for k, v in importants.items()}

souls = {
    284256326: "Pandle", 
    1744197840: "Undy", 
    4278126954: "Tanbo", 
    2314746364: "D'wanna", 
    396143711: "N'more", 
    1620810953: "Q'wit", 
    4187147635: "Mochismo", 
    2392194533: "Minochi", 
    506126452: "Cutta-nah", 
    1764610274: "Cutta-nah-nah", 
    166353159: "Slacka-slash", 
    2129488273: "Chansin", 
    3890493483: "Sheen", 
    2430798013: "Gleam", 
    243768606: "Snee", 
    2038476168: "Helmsman", 
    3767139378: "Reuknight", 
    2542718116: "Corptain", 
    120705333: "Blazion", 
    1882644899: "Quaken", 
    583469764: "Siro", 
    1438661202: "Beetler", 
    3435752424: "Beetall", 
    3150863230: "Beetall", 
    631951069: "Cruncha", 
    1387134539: "Benkei", 
    3416567793: "B3-NK1", 
    3164839783: "Zerberker", 
    740066038: "Snartle", 
    1528541792: "Snotsolong", 
    1004288901: "Duchoo", 
    1289423635: "Espy", 
    3587332777: "Infour", 
    2731895359: "Wazzat", 
    1018298268: "Dummkap", 
    1270271754: "Lafalotta", 
    3535773360: "Blips", 
    2780343846: "Sushiyama", 
    889697207: "Kapunki", 
    1107329825: "Cupistol", 
    1956490562: "Casanuva", 
    60464596: "Casanono", 
    2593377390: "Tattletell", 
    3985964280: "Skranny", 
    1945135451: "Tattlecast", 
    83319245: "Baku", 
    2650671223: "Whapir", 
    3942201569: "Signibble", 
    2051417456: "Signiton", 
    222369254: "Statiking", 
    1837538307: "Mirapo", 
    444705941: "Mircle", 
    2206793007: "Illoo", 
    4103065017: "Elloo", 
    1793808410: "Alloo", 
    502032524: "Frostina", 
    2229614902: "Blizzaria", 
    4091677088: "Damona", 
    1667044401: "Kyubi", 
    341451943: "Frostail", 
    1185664960: "Dulluma", 
    833421142: "Darumacho", 
    2829430508: "Goruma", 
    3751976570: "Coughkoff", 
    1103498201: "Hurchin", 
    918633295: "Dazzabel", 
    2949147381: "Rattelle", 
    3637467747: "Skelebella", 
    1215318002: "Noway", 
    1064793956: "Impass", 
    1605435009: "Walldin", 
    683134487: "Blowkade", 
    2982059949: "Ledballoon", 
    3334057787: "Armsman", 
    1490893464: "Mad Mountain", 
    802818574: "Lava Lord", 
    3067304884: "Rhinoggin", 
    3251923746: "Rhinormous", 
    1365997235: "Hornaplenty", 
    644630053: "Castelius I", 
    3626558030: "Castelius III", 
    2939146968: "Castelius II", 
    908493666: "Castelius Max", 
    1092727796: "Dromp", 
    3745850967: "Swosh", 
    2822903489: "Cadin", 
    827017083: "Cadable", 
    1179416557: "Singcada", 
    3606276732: "Buhu", 
    2717145834: "Flumpy", 
    3241399055: "Skreek", 
    3056919449: "Jibanyan", 
    792572451: "Thornyan", 
    1480229557: "Baddinyan", 
    3328055062: "Robonyan", 
    2975410048: "Goldenyan", 
    676361786: "Dianyan", 
    1599555244: "Sapphinyan", 
    3488111421: "Emenyan", 
    3102698411: "Rubinyan", 
    288555633: "Topanyan", 
    1714696935: "Walkappa", 
    4282213213: "Appak", 
    2285523915: "Supyo", 
    375309928: "Komasan", 
    1633285886: "Komajiro", 
    4166035268: "Komane", 
    2404882386: "Komiger", 
    535333443: "Daiz", 
    1760541397: "Confuze", 
    136852272: "Pupsicle", 
    2133787558: "Chilhuahua", 
    3861271068: "Swelterrier", 
    2434884234: "Fidgephant", 
    256243497: "Touphant", 
    2017642431: "Rollen", 
    3779827205: "Dubbles", 
    2521605779: "Tengu", 
    116636418: "Flengu", 
    1911851924: "Hungramps", 
    587555059: "Grainpa", 
    1409437797: "Hungorge", 
    3440050655: "Manjimutt", 
    3121361225: "Multimutt", 
    610837738: "Sir Berus", 
    1399821436: "Heheheel", 
    3395732934: "Croonger", 
    3177313616: "Urnaconda", 
    769583297: "Enerfly", 
    1524226135: "Enefly", 
    975065522: "Betterfly", 
    1293508900: "Peppillon", 
    3557830814: "Wiglin", 
    2736193544: "Steppa", 
    1030985131: "Rhyth", 
    1249158461: "Shmoopie", 
    3548247175: "Pinkipoo", 
    2759509009: "Pookivil", 
    885381504: "Happierre", 
    1136847126: "Reversa", 
    1969211253: "Reversette", 
    39385059: "Ol' Saint Trick", 
    2605819481: "Ol' Fortune", 
    3965097679: "Mama Aura", 
    1915880300: "Auntie Heart", 
    87372794: "Papa Bolt", 
    2621203008: "Uncle Infinite", 
    3946533590: "Ake", 
    2072268615: "Payn", 
    209944529: "Agon", 
    1816458804: "Negatibuzz", 
    457426594: "Moskevil", 
    2185926424: "Scritchy", 
    4115507086: "Leadoni", 
    1797861933: "Mynimo", 
    472777403: "Peckpocket", 
    2233946881: "Rockabelly", 
    4062208919: "Chatalie", 
    1654619654: "Nagatha", 
    362303120: "Roughraff", 
    1198106103: "Badude", 
    812553569: "Bruff", 
    2842150107: "Negasus", 
    3730895949: "Neighfarious", 
    1074029038: "Grumples", 
    922964344: "Everfore", 
    2919891138: "Eterna", 
    3641520212: "Cheeksqueek", 
    1236413893: "Cuttincheez", 
    1052056915: "Compunzer", 
    1584567478: "Lamedian", 
    695575584: "Insomni", 
    2960979354: "Sandi", 
    3346777356: "Dimmy", 
    1495224495: "Blandon", 
    773349433: "Nul", 
    3071357315: "Droplette", 
    3222667541: "Slush", 
    1353260164: "Gush", 
    665725970: "Drizzle", 
    3656026233: "Alhail", 
    2934814959: "Dismarelda", 
    937748821: "Wantston", 
    1088674243: "Grubsnitch", 
    3733408864: "Hidabat", 
    2843770102: "Abodabat", 
    814296396: "Belfree", 
    1200496090: "Lodo", 
    3610312779: "Chippa", 
    2687906013: "Tengloom", 
    3237067064: "Nird", 
    3086387630: "Suspicioni", 
    788518932: "Tantroni", 
    1509484674: "Contrarioni", 
    3348921633: "Timidevil", 
    2962967991: "Beelzebold", 
    697441293: "Count Cavity", 
    1586834587: "Greesel", 
    3458871562: "Awevil", 
    3106734492: "Noko", 
    326482984: "Pandanoko", 
    1685228734: "Bloominoko", 
    4252753156: "Draggie", 
    2323443090: "Dragon Lord", 
    337147953: "Azure Dragon", 
    1662994599: "Fishpicable", 
    4195752221: "Rageon", 
    2366712203: "Tunatic", 
    497955866: "Chummer", 
    1789461644: "Shrook", 
    175017321: "Spenp", 
    2104081919: "Almi", 
    3831557189: "Babblong", 
    2473057491: "Bananose", 
    218319216: "Copperled", 
    2047113702: "Slitheref", 
    3809290332: "Cynake", 
    2483689674: "Venoct", 
    78972251: "Shad. Venoct", 
    1941059021: "Shogunyan", 
    558096042: "Komashura", 
    1447358012: "Dandoodle", 
    3477979014: "Elder Bloom", 
    3091894032: "Gilgaros", 
    640555699: "Lie-in", 
    1361652261: "Brushido", 
    3357571999: "Hissfit", 
    3207023369: "Slicenrice", 
    798512792: "Tublappa", 
    1486841358: "Grublappa", 
    945352683: "Hovernyan", 
    1331683197: "Mudmunch", 
    3595996871: "Madmunch", 
    2706488913: "Sgt. Burly", 
    1060449266: "Washogun", 
    1211243364: "Lie-in Heart", 
    3510323934: "Flamurice", 
    2788981320: "Demuncher", 
    914581465: "Devourer", 
    1099192143: "Brokenbrella", 
    1998158124: "Smogling", 
    1984954: "So-Sorree", 
    2568427520: "Mimikin", 
    3994036374: "Failian", 
    1886698805: "Houzzat", 
    125013411: "Smogmella", 
    2658851865: "Badsmella", 
    3917343887: "Master Oden", 
    2042818846: "Bowminos", 
    247841160: "Miradox", 
    1845643373: "Chymera", 
    419789051: "Kingmera", 
    2148280641: "Terrorpotta", 
    4144699863: "Wotchagot", 
    1768918132: "Swelton", 
    510180578: "Zappary", 
    2271341912: "No-Go Kart", 
    4033273294: "Gimme", 
    1624883295: "Pride Shrimp", 
    400486601: "Mistank", 
    1160715182: "Eyesoar", 
    841493304: "Eyellure", 
    2871097986: "Carniboy", 
    3693496852: "Frazzel", 
    1111678903: "Enduriphant", 
    893775649: "Toadal Dude", 
    2890710683: "Uber Geeko", 
    3679161869: "Faysoff", 
    1274319772: "Boyclops", 
    1022599946: "Leggly", 
    1546922735: "Nekidspeed", 
    724769401: "Drizzelda", 
    2990164931: "Jumbelina", 
    3309140821: "Bakulia", 
    1532620534: "Faux Kappa", 
    744414816: "Tigappa", 
    3042414554: "Mad Kappa", 
    3260071756: "Master Nyada", 
    1391436509: "Tongus", 
    635998795: "Pallysol", 
    3685496352: "Shamasol", 
    2896889526: "Sandmeh", 
    899831564: "Don Chan", 
    1118136218: "Predictabull", 
    3703697977: "Defectabull", 
    2881929903: "Gnomey", 
    852464405: "Gnomine", 
    1170776963: "Ray O'Light", 
    3581394450: "Kelpacabana", 
    2725285508: "Nurse Tongus", 
    3266774881: "Mr. Sandmeh", 
    3048224759: "Scarasol", 
    750347853: "High Gnomey", 
    1539200731: "Supoor Hero", 
    3319448440: "Smashibull", 
    3000890350: "Kyryn", 
    735355476: "Unikirin", 
    1557369538: "Pittapatt", 
    3429666643: "Wydeawake", 
    3144400837: "Yoink", 
    314037791: "Herbiboy", 
    1706092169: "K'mon-K'mon", 
    4240029491: "Yoodooit", 
    2344519589: "Count Zapaway", 
    366612998: "Slimamander", 
    1658659472: "Snobetty", 
    4225004330: "Dracunyan", 
    2362655676: "Allnyta", 
    476864045: "Wobblewok", 
    1802202811: "Furgus", 
    195880798: "Feargus", 
    2091636680: "Nosirs", 
    3852633714: "Papa Windbag", 
    2460333796: "Toiletta", 
    213984071: "Ben Tover", 
    2076578769: "Robbinyu", 
    3805233771: "Sproink", 
    2512941821: "Rawry", 
    91713388: "Furdinand", 
    1919967226: "Foiletta", 
    545371293: "Arachnus", 
    1468433419: "Arachnia", 
    3465532849: "Harry Barry", 
    3112756519: "Cricky", 
    669806724: "Snaggly", 
    1357594642: "Squeeky", 
    3387036072: "Flushback", 
    3202687294: "SV Snaggerjag", 
    777665711: "Irewig", 
    1499270201: "Mermaidyn", 
    966428124: "Scaremaiden", 
    1318958410: "Lady Longnek", 
    3616859376: "Wrongnek", 
    2694042726: "Draaagin", 
    1056391621: "Firewig", 
    1240494419: "Vacuumory", 
    3505987817: "Whinona", 
    2818445439: "Mermadonna", 
    927010286: "Mermother", 
    1078345080: "Spoilerina", 
    1994068763: "Poofessor", 
    31204237: "Slurpent", 
    2564125239: "Unfairy", 
    4023534241: "Unkaind", 
    1907808002: "Untidy", 
    112322452: "Unpleasant", 
    2679682606: "Unkeen", 
    3904865976: "Tyrat", 
    2013305641: "Apelican", 
    252160959: "Darknyan", 
    1874862682: "Buchinyan", 
    415699660: "Verygoodsir", 
    2177778550: "Robonyan F", 
    4140397536: "Sailornyan", 
    1756227139: "Machonyan", 
    531289813: "Jibakoma", 
    2258863983: "Grumpus Khan", 
    4054104057: "Groupus Khan", 
    1629203048: "Slumberhog", 
    370973438: "Snortlehog", 
    1156411801: "Panja Pupil", 
    870990095: "Panja Pro", 
    2867007669: "Samureel", 
    3722715171: "Time Keeler", 
    1132508544: "Takoyakid", 
    881296662: "Takoyaking", 
    2911818924: "Danke Sand", 
    3666469946: "No Sandkyu", 
    1245116843: "Sumodon", 
    1026672957: "Yokozudon", 
    1576419544: "Whateverest", 
    720465998: "Whatuption", 
    3019383284: "Happycane", 
    3305050466: "Starrycane", 
    1520141505: "Robokapp", 
    765244503: "Robokoma", 
    3029722605: "Robogramps", 
    3281180027: "Robomutt", 
    1395509482: "Robonoko", 
    606795900: "Robodraggie", 
    3664665623: "Melonyan", 
    2909367425: "Oranyan", 
    878722363: "Kiwinyan", 
    1130827181: "Grapenyan", 
    3708000270: "Strawbnyan", 
    2852432024: "Watermelnyan", 
    856553762: "Jetnyan", 
    1141557684: "Wondernyan", 
    2823622435: "Stealth Soul", 
    3746185141: "Soldier's Soul", 
    1178824207: "Stout Soul", 
    826564249: "Stubborn Soul", 
    2938161978: "Scatter Soul", 
    3626498988: "Stinging Soul", 
    1093577238: "Speed Soul", 
    908696192: "Slippery Soul", 
    2794882833: "Surly Soul", 
    3515987847: "Scorching Soul", 
    2975219298: "Soaking Soul", 
    3327201012: "Sparking Soul", 
    1599627086: "Spacedust Soul", 
    677343192: "Subzero Soul", 
    3057384059: "Spin Soul", 
    1479908183: "Searing Soul", 
    791849921: "Sodden Soul", 
    3213735504: "Storm Soul", 
    3364521670: "Sprouting Soul", 
    2591780257: "Snow Soul", 
    3984350519: "Squall Soul", 
    1953827981: "Supernatural Soul", 
    57818139: "Sinister Soul", 
    2635508152: "Shielding Soul", 
    3927021870: "Summoner's Soul", 
    1931004052: "Surrender Soul", 
    69203970: "Superstar Soul"
}

reverse_souls = {v.lower(): k for k, v in souls.items()}

attitudes = ["", "grouchy", "logical", "careful", "gentle", "twisted", "helpful", "rough", "brainy", "calm", "tender", "cruel", "devoted"]


#functions
def get(read, place, length=1, integer=True, half=False):
    finished = ""
    if half:
        return [int(f'{read[place]:08b}'[:4], 2), int(f'{read[place]:08b}'[4:], 2)] 
    else:
        if integer == None:
            for i in read[place:place+length][-1::-1]:
                finished += f'{i:08b}'
            return finished
        elif integer:
            for i in read[place:place+length][-1::-1]:
                finished += f'{i:08b}'
            return int(finished, 2)
        else:
            if read[place:place+length][0]==0:
                return ""
            for i in read[place:place+length]:
                if i == 0:
                    break
                finished += chr(i)
            return finished

def fix_dict(dict,ownerid=None): #works for equipment too
    for i in range(len(dict)):
        dict[i]["num1"]=i
        dict[i]["num2"]=i+1
        if ownerid:
            dict[i]["ownerid"]=ownerid
    return dict

def edit_yokai(yokaidict, ownerid, index, yokai=None, attitude=None, nickname=None):
    try:
        yokaidict[index]
    except:
        yokaidict[index] = {}
    yokaidict[index]["num1"] = index
    yokaidict[index]["num2"] = index+1
    if yokai != None:
        try:
            yokaidict[index]["id"] = reverse_yokais[yokai]
        except:
            yokaidict[index]["id"] = yokai
    if nickname != None:
        yokaidict[index]["nickname"] = nickname
    yokaidict[index]["attack"] = 255 #10
    yokaidict[index]["technique"] = 255 #10
    yokaidict[index]["soultimate"] = 255 #10
    yokaidict[index]["xp"] = 4294967295 #0
    yokaidict[index]["ownerid"] = ownerid
    yokaidict[index]["stats"] = {
        "IV_HP": 255, #need to find out maxes TODO
        "IV_Str": 255, 
        "IV_Spr": 255, 
        "IV_Def": 255, 
        "IV_Spd": 255, 
        "CB_HP": 255, 
        "CB_Str": 255, 
        "CB_Spr": 255, 
        "CB_Def": 255, 
        "CB_Spd": 255, 
        "SC_HP": 255, 
        "SC_Str": 255, 
        "SC_Spr": 255, 
        "SC_Def": 255, 
        "SC_Spd": 255
    }
    yokaidict[index]["level"] = 255 #99
    yokaidict[index]["loaflevel"] = 15 #2
    if attitude != None:
        try:
            yokaidict[index]["attitude"] = attitudes.index(attitude)
        except:
            yokaidict[index]["attitude"] = attitudes[attitude]

    return yokaidict

def edit_item(itemdict, index, item=None, amount=None):
    try:
        itemdict[index]
    except:
        itemdict[index] = {}
    itemdict[index]["num1"] = index
    itemdict[index]["num2"] = index+1
    if item:
        try:
            itemdict[index]["item"] = reverse_items[item]
        except:
            itemdict[index]["item"] = item
    if amount:
        itemdict[index]["amount"] = amount
    return itemdict

def edit_equipment(equipmentdict, index, equipment=None, amount=None):
    try:
        equipmentdict[index]
    except:
        equipmentdict[index] = {}
    equipmentdict[index]["num1"] = index
    equipmentdict[index]["num2"] = index+1
    if equipment:
        try:
            equipmentdict[index]["equipment"] = reverse_equipments[equipment]
        except:
            equipmentdict[index]["equipment"] = equipment
    if amount:
        equipmentdict[index]["amount"] = amount
    equipmentdict[index]["used"] = 0
    return equipmentdict

def edit_important(importantdict, index, important):
    try:
        importantdict[index]
    except:
        importantdict[index] = {}
    importantdict[index]["num1"] = index #made redundant by fix_dict
    importantdict[index]["num2"] = index+1
    try:
        importantdict[index]["important"] = reverse_importants[important]
    except:
        importantdict[index]["important"] = important
    return importantdict

def edit_soul(souldict, index, soul):
    try:
        souldict[index]
    except:
        souldict[index] = {}
    souldict[index]["num1"] = index #made redundant by fix_dict
    souldict[index]["num2"] = index+1
    try:
        souldict[index]["soul"] = reverse_souls[soul]
    except:
        souldict[index]["soul"] = soul
    souldict[index]["xp"] = 65535
    souldict[index]["level"] = 255 #10
    souldict[index]["used"] = 0 #TODO fix this
    return souldict

#main
file = "/Users/emilia/Documents/dev/ykw/ykw-editors/my-editor/2/game check copy.ywd"
with open(file, "r+b") as f:
    #money offset: 67808

    yokaidict = {}
    index = 0
    f.seek(20744) # 20744 is yokai info location. 1 yokai takes up 92 bytes
    while True:
        yokai = f.read(92)
        if get(yokai, 0) == 0 and index != 0: #could be broken
            break

        yokaidict[index] = {
            "num1": get(yokai, 0), #0
            "num2": get(yokai, 2), #2
            "id": get(yokai, 4, 4), #4-07
            "nickname": get(yokai, 8, 24, False), #8-32 maybe broken
            "attack": get(yokai, 42), #42
            "technique": get(yokai, 46), #46
            "soultimate": get(yokai, 50), #50
            "xp": get(yokai, 52, 4), #52 - 55
            "ownerid": get(yokai, 60, 4), #60 - 63
            "stats": { # 64 - 78
                "IV_HP": get(yokai, 64), 
                "IV_Str": get(yokai, 65), 
                "IV_Spr": get(yokai, 66), 
                "IV_Def": get(yokai, 67), 
                "IV_Spd": get(yokai, 68), 
                "CB_HP": get(yokai, 69), 
                "CB_Str": get(yokai, 70), 
                "CB_Spr": get(yokai, 71), 
                "CB_Def": get(yokai, 72), 
                "CB_Spd": get(yokai, 73), 
                "SC_HP": get(yokai, 74), 
                "SC_Str": get(yokai, 75), 
                "SC_Spr": get(yokai, 76), 
                "SC_Def": get(yokai, 77), 
                "SC_Spd": get(yokai, 78)
            }, 
            "level": get(yokai, 79), #79
            "loaflevel": get(yokai, 84, half=True)[0], #84
            "attitude": get(yokai, 84, half=True)[0] #84 (shared byte)
        }

        index += 1
    ownerid = yokaidict[0]["ownerid"]
    yokaidict = fix_dict(yokaidict, ownerid)

    itemdict = {}
    index = 0
    f.seek(11452) # 11452 is item info location. 1 item takes up 12 bytes
    while True:
        item = f.read(12)

        if get(item, 0) == 0 and index != 0: #could be broken
            break

        itemdict[index] = {
            "num1": get(item, 0), #0
            "num2": get(item, 2), #2
            "item": get(item, 4, 4), #4
            "amount": get(item, 8, 4) #8
        }

        index += 1
    itemdict = fix_dict(itemdict)

    equipmentdict = {}
    index = 0
    f.seek(16624) # 16624 is equipment info location. 1 equipment takes up 16 bytes
    while True:
        equipment = f.read(16)

        if get(equipment, 0) == 0 and index != 0: #could be broken
            break

        equipmentdict[index] = {
            "num1": get(equipment, 0), #0
            "num2": get(equipment, 2), #2
            "equipment": get(equipment, 4, 4), #4
            "amount": get(equipment, 8, 4), #8 #maybe 1 byte
            "used": get(equipment, 12, 4) #i think this is how many are currently equipped
        }

        index += 1
    equipmentdict = fix_dict(equipmentdict)

    importantdict = {}
    index = 0
    f.seek(18076) # 18076 is important info location. 1 important takes up 8 bytes
    while True:
        important = f.read(8)

        if get(important, 0) == 0 and index != 0: #could be broken
            break

        importantdict[index] = {
            "num1": get(important, 0), #0
            "num2": get(important, 2), #2 unsure.
            "important": get(important, 4, 4), #4
        }

        index += 1
    importantdict = fix_dict(importantdict) #probably broken
    
    souldict = {}
    index = 0
    f.seek(19528) # 19528 is soul info location. 1 soul takes up 12 bytes
    while True:
        soul = f.read(12)

        if get(soul, 0) == 0 and index != 0: #could be broken
            break

        souldict[index] = {
            "num1": get(soul, 0), #0
            "num2": get(soul, 2), #2
            "soul": get(soul, 4, 4), #4
            "xp": get(soul, 8, 2), #8
            "level": get(soul, 10), #8
            "used": get(soul, 11) #11 true or false need to figure out if 00 means used or not used
        }

        index += 1
    souldict = fix_dict(souldict)

    # TODO add important and souls


    #editor goes here
    if False:
        #to append yokai: make index len(yokaidict). must include yokai, attitude & nickname if appending. (can all be "" except for yokai)
        #append a pandle
        yokaidict = edit_yokai(yokaidict, ownerid, len(yokaidict), "pandle", "", "bob")
        #change to a rough ake
        yokaidict = edit_yokai(yokaidict, ownerid, len(yokaidict)-1, "ake", "rough")

        #to append item: make index len(itemdict). must include item & amount if appending.
        #append 60 sandwitch
        itemdict = edit_item(itemdict, len(itemdict), "sandwitch", 60)
        #change to milk
        itemdict = edit_item(itemdict, len(itemdict)-1, "milk") 

        #to append equipment: make index len(equipmentdict). must include equipment & amount if appending.
        #append 60 cheap bracelet
        equipmentdict = edit_equipment(equipmentdict, len(equipmentdict), "cheap bracelet", 60)
        #change to power bracelet
        equipmentdict = edit_equipment(equipmentdict, len(equipmentdict)-1, "power bracelet") #if you get the index wrong it will mess everything up

        #if removing, must dict = fix_dict(dict) afterwards

    #print data
    print(json.dumps(yokaidict, indent=2))
    print(", ".join([yokais[yokaidict[index]["id"]] for index in yokaidict]))
    print(", ".join([items[itemdict[index]["item"]] for index in itemdict]))
    print(", ".join([equipments[equipmentdict[index]["equipment"]] for index in equipmentdict]))
    print(", ".join([importants[importantdict[index]["important"]] for index in importantdict]))
    print(", ".join([souls[souldict[index]["soul"]] for index in souldict]))

    #write yokais back
    j=0
    for i in yokaidict:
        f.seek(20744+92*int(j))
        f.write(yokaidict[i]["num1"].to_bytes(1, "little"))
        f.seek(20744+92*int(j)+2)
        f.write(yokaidict[i]["num2"].to_bytes(1, "little"))
        f.seek(20744+92*int(j)+4)
        f.write(yokaidict[i]["id"].to_bytes(4, "little"))
        f.seek(20744+92*int(j)+8)
        f.write((bytearray([ord(k)for k in yokaidict[i]["nickname"]])+bytearray(24))[:24]) # to be more accurate to game could just append
        f.seek(20744+92*int(j)+42)
        f.write(yokaidict[i]["attack"].to_bytes(1, "little"))
        f.seek(20744+92*int(j)+46)
        f.write(yokaidict[i]["technique"].to_bytes(1, "little"))
        f.seek(20744+92*int(j)+50)
        f.write(yokaidict[i]["soultimate"].to_bytes(1, "little"))
        f.seek(20744+92*int(j)+52)
        f.write(yokaidict[i]["xp"].to_bytes(4, "little"))
        f.seek(20744+92*int(j)+60)
        f.write(yokaidict[i]["ownerid"].to_bytes(4, "little"))
        statnum = 64
        for stat in yokaidict[i]["stats"]:
            f.seek(20744+92*int(j)+statnum)
            f.write(yokaidict[i]["stats"][stat].to_bytes(1, "little"))
            statnum +=1
        f.seek(20744+92*int(j)+79)
        f.write(yokaidict[i]["level"].to_bytes(1, "little"))
        f.seek(20744+92*int(j)+84)
        f.write(int(f'{yokaidict[i]["loaflevel"]:04b}'+f'{yokaidict[i]["attitude"]:04b}', 2).to_bytes(1, "little"))
        j+=1

    #write items back
    j=0
    for i in itemdict:
        f.seek(11452+12*int(j))
        f.write(itemdict[i]["num1"].to_bytes(1, "little"))
        f.seek(11452+12*int(j)+2)
        f.write(itemdict[i]["num2"].to_bytes(1, "little"))
        f.seek(11452+12*int(j)+4)
        f.write(itemdict[i]["item"].to_bytes(4, "little"))
        f.seek(11452+12*int(j)+8)
        f.write(itemdict[i]["amount"].to_bytes(4, "little"))
        j+=1
    
    #write equipment back
    j=0
    for i in equipmentdict:
        f.seek(16624+16*int(j))
        f.write(equipmentdict[i]["num1"].to_bytes(1, "little"))
        f.seek(16624+16*int(j)+1)
        f.write(b"\x10") # i don't know what this does, may be unnecessary
        f.seek(16624+16*int(j)+2)
        f.write(equipmentdict[i]["num2"].to_bytes(1, "little"))
        f.seek(16624+16*int(j)+4)
        f.write(equipmentdict[i]["equipment"].to_bytes(4, "little"))
        f.seek(16624+16*int(j)+8)
        f.write(equipmentdict[i]["amount"].to_bytes(4, "little"))
        f.seek(16624+16*int(j)+12)
        f.write(equipmentdict[i]["used"].to_bytes(4, "little"))
        j+=1

    #write important back
    j=0
    for i in importantdict:
        f.seek(18076+8*int(j))
        f.write(importantdict[i]["num1"].to_bytes(1, "little"))
        f.seek(18076+8*int(j)+1)
        f.write(b"\x20") # i don't know what this does, may be unnecessary
        f.seek(18076+8*int(j)+2)
        f.write(importantdict[i]["num2"].to_bytes(1, "little"))
        f.seek(18076+8*int(j)+4)
        f.write(importantdict[i]["important"].to_bytes(4, "little"))
        j+=1

    #write soul back
    j=0
    for i in souldict:
        f.seek(19528+12*int(j))
        f.write(souldict[i]["num1"].to_bytes(1, "little"))
        f.seek(19528+12*int(j)+1)
        f.write(b"\x30") # i don't know what this does, may be unnecessary
        f.seek(19528+12*int(j)+2)
        f.write(souldict[i]["num2"].to_bytes(1, "little"))
        f.seek(19528+12*int(j)+4)
        f.write(souldict[i]["soul"].to_bytes(4, "little"))
        f.seek(19528+12*int(j)+8)
        f.write(souldict[i]["xp"].to_bytes(2, "little"))
        f.seek(19528+12*int(j)+10)
        f.write(souldict[i]["level"].to_bytes(1, "little"))
        f.seek(19528+12*int(j)+11)
        f.write(souldict[i]["used"].to_bytes(1, "little"))
        j+=1