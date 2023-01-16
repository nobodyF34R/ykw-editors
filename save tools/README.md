# yw_save

This python script decrypts and encrypts save data of Yo-kai Watch.

* You should make a backup before injecting new savedata.

## Requirements

* Python 3.x
* PyCrypto (Optional)

PyCrypto is necessary for handling save data of Yo-kai Watch 2, Busters, and 3.

## Supported games
| game                             | decryption | encryption | head.yw needed | option           |
| -------------------------------- | ---------- | ---------- | -------------- | ---------------- |
| Yo-kai Watch                     | yes        | yes        | no             | --game yw        |
| Yo-kai Watch 2 Ganso / Honke 1.X | yes        | yes        | no             | --game yw2       |
| Yo-kai Watch 2 Ganso / Honke 2.X | yes        | yes        | yes            | --game yw2x      |
| Yo-kai Watch 2 Shin'uchi         | yes        | yes        | no             | --game yw2       |
| Yo-kai Watch Busters             | yes        | yes        | yes            | --game ywb       |
| Yo-kai Watch Busters Getto-gumi  | yes        | yes        | yes            | --game ywb_getto |
| Yo-kai Watch 3                   | yes        | yes        | yes            | --game yw3       |

## Usage

First dump game1.yw with svdt (for Getto-gumi, use extdata_dump).
Note the number depends on your save slot (1, 2 or 3).

Decrypt game1.yw:

    python3 ./yw_save.py --game yw --decrypt game1.yw game1_decrypted.yw

Edit decrypted game1.yw using your favorite hex editor.

Re-encrypt edited game1.yw:

    python3 ./yw_save.py --game yw --encrypt game1_decrypted.yw game1_encrypted.yw

then inject it with svdt.

Decrypting, encrypting and injecting work with:

* Yo-kai Watch
* Yo-kai Watch 2 Ganso / Honke
* Yo-kai Watch 2 Shin'uchi
* Yo-kai Watch Busters
* Yo-kai Watch Busters Getto-gumi
* Yo-kai Watch 3

You can specify the game with "--game" option.

* --game yw (default) : Yo-kai Watch 1
* --game yw2 : Yo-kai Watch 2 Ganso / Honke version 1.X and Shin'uchi
* --game yw2x : Yo-kai Watch 2 Ganso / Honke version 2.X
* --game ywb : Yo-kai Watch Busters
* --game ywb_getto : Yo-kai Watch Busters Getto-gumi
* --game yw3 : Yo-kai Watch 3

### Getto-gumi
Example config.txt for Yo-kai Watch Busters Akanekodan Getto-gumi

```
; Akanekodan
DUMP "000016c6:/yw-b_ca/head.yw" "dumps/000016c6/yw-b_ca/head.yw"
DUMP "000016c6:/yw-b_ca/game1.yw" "dumps/000016c6/yw-b_ca/game1.yw"

RESTORE "dumps/000016c6/yw-b_ca/game1.yw" "000016c6:/yw-b_ca/game1.yw"
RESTORE "dumps/000016c6/yw-b_ca/game1.yw" "000016c6:/yw-b_da/game1.yw"
```

## Tools
### tools/dump.py

Print some data extracted from *decrypted* save data of Yo-kai Watch 1

    === Player ===
    name: あいうえお
    money: 63
    === Items ===
    Green Cicada 2
    Black Syrup 3
    Plum Rice Ball 1
    === Equipments ===
    === Key Items ===
    Bug Net
    Yo-kai Watch
    Yo-kai Medallium
    === Yo-kai ===
    Cadin Lv.2
     IV_A:   0-0-0-0-4
     IV_B_1: 2-2-5-1-0
     IV_B_2: 0-0-0-0-0
     EV:     0-0-0-0-0
     rawEV:  1
    Buhu (あいうえおＡＢＣ) Lv.2
     IV_A:   0-4-2-0-0
     IV_B_1: 3-0-2-2-3
     IV_B_2: 0-0-0-0-0
     EV:     0-0-0-0-0
     rawEV:  0
    === Medallium ===
    No. seen befriended new photo
    001 False False False False
    002 False False False False
    003 False False False False
    004 False False False False
    005 False False False False
    ...

dump.py has --thornyan option, which changes all of your Yo-kai into Thornyan.

    === Yo-kai ===
    Cadin -> Thornyan
    Buhu -> Thornyan

## License

MIT License
