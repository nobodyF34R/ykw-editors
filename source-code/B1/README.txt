Yo-kai Editor B1

妖怪ウォッチバスターズ 赤猫団・白犬隊・月兎組のセーブデータ編集ツール．
無保証です / 何が起こっても，作者は一切の責任を負いません

使いかた
A. 月兎組のアップデートを適用していない場合
1. Checkpoint、JKSVなどのツールでセーブデータを抽出する
2. ツールを起動して`game*.yw`を開く
3. 変更する
4. `game*.yw(_g)`を保存する
5. セーブデータを書き戻す。

B. 月兎組のアップデートを適用している場合
B-1. 日本版、韓国版の場合
1. extdata_dumpやFBIで月兎組のセーブデータを抽出する(`head.yw(_g)`も抽出すること※)。一度全部ダンプしたほうが分かりやすい
2. ツールを起動して`game*.yw`を開く。ただし、韓国版は`game*.yw_g`。
3. 変更する
4. `game*.yw(_g)`を保存する
5. extdata_dumpやFBIで`game*.yw(_g)`を書き戻す。`head.yw`は書き戻さなくてよい。
※head.ywは一段目の復号のために必要。

B-2. 米国版、欧州版の場合
A. と同様の手順だが、`game*.yw`の代わりに`game*.yw_g`を抽出する。

Usage
(English)
A. If you are playing without Moon Rabbit Crew update,
1. Dump the save data using homebrew tools, like Checkpoint or JKSV.
2. Launch the editor and open `game*.yw`.
3. Save modified `game*.yw`.
4. Inject modified data using the same tool you used to dump the save data.

B. If you are playing Moon Rabbit Crew update,
B-1. If the your game region is JP or KR,
1. Dump the extdata using extdata_dump or FBI. Do not forget to dump `head.yw(_g)` file.
2. Launch the editor and open `game*.yw` (If your game is KR open `game*.yw_g` instead).
3. Save modified `game*.yw(_g)`.
4. Inject modified data using the same tool you used to dump the extdata.

B-2. If your game is EU or US,
Follow the instruction in the section "A. If you are playing without Moon Rabbit Crew update", but replace `game*.yw` with `game*.yw_g`.


ビルド
Qt 5.5，Crypto++，QHexEdit が必要です．QHexEdit はリポジトリに含まれています．
http://www.qt.io/
https://www.cryptopp.com
https://github.com/Dax89/QHexEdit

謝辞
See AUTHORS.txt for details.
このプログラムはQt (http://www.qt.io/) を使用しています．
Copyright (C) 2015 The Qt Company Ltd and other contributors.
Qt is licensed under the GNU LGPL version 3.

このプログラムはCrypto++ (https://www.cryptopp.com) を使用しています．
The Crypto++ Library (as a compilation) is licensed under the Boost Software License 1.0.
Compilation Copyright (c) 1995-2013 by Wei Dai.  All rights reserved.
This copyright applies only to this software distribution package 
as a compilation, and does not imply a copyright on any particular 
file in the package.

このプログラムはQHexEdit (https://github.com/Dax89/QHexEdit) を使用しています．
Copyright (c) 2014 Dax89
QHexEditは、MITライセンスのもとで公開されています。

ライセンス
MIT license
Copyright (c) 2016-2018 togenyan, nobody_fear
