# Yo-kai Editor 3

妖怪ウォッチ3 スシ・テンプラ・スキヤキのセーブデータ編集ツール．
無保証です / 何が起こっても，作者は一切の責任を負いません．

バグの報告，質問や要望は，メールかGitHubのissuesにお願いします．

## 概要
妖怪ウォッチ3 スシ・テンプラ・スキヤキのセーブデータ編集ツールです．
GUIから編集するほか，バイナリエディタ(Ctrl+E または Cmd+E)で
編集することもできます．あるいは，復号済みセーブデータを一度書き出して
任意のバイナリエディタを使って編集することもできます．

このツールを使うには，
1. Homebrewが実行できる3DS．CFW導入済みの3DSでもよい．
2. CYBER セーブエディター2 (3DS用) (サイバーガジェット)
のいずれかが必要です．

## 使いかた
### Homebrew または CFW
1. svdt，JK's SaveManagerなどのアプリケーションで，game*.ywとhead.ywをダンプする．
2. ツールを起動してgame*.ywを開く．
3. 変更する．
4. game*.ywを保存する．
5. 1. で使用したアプリケーションを使って，game*.ywを書き戻す．

### CYBER セーブエディター2 (サイバーガジェット)
1. セーブエディターのアドバンスモードを開く．
2. キャッシュを作成する．
3. %HOMEPATH%\Documents\3DSSaveBank\cache\BY*J\日付 時刻\game*.yw を，
   「復号済みファイルを開く...」(Ctrl+Shift+O)で開く．
4. 変更し，「復号済みファイルを別名で保存...」(Ctrl+Shift+S)で上書き保存する．
5. セーブエディターのアドバンスモードでキャッシュを読み込む．
6. 適当な箇所で編集し，適用ボタンを押せるようにする．例えば00のバイトを00で上書きすればよい．
7. 適用する．

## ビルド
Qt (5.5以降)，Crypto++，QHexEdit が必要です．QHexEdit はリポジトリに含まれています．
http://www.qt.io/
https://www.cryptopp.com
https://github.com/Dax89/QHexEdit

## 謝辞
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

## ライセンス
MIT license
Copyright (c) 2016 togenyan
