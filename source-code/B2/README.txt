# Yo-kai Editor B2

妖怪ウォッチバスターズ2 秘宝伝説バンバラヤー ソード・マグナムのセーブデータ編集ツール。
無保証です / 何が起こっても、作者は一切の責任を負いません。

バグの報告、質問や要望は、メールかGitHubのissuesにお願いします。

## 概要
妖怪ウォッチバスターズ2のセーブデータ編集ツールです。
GUIから編集するほか、バイナリエディタ(Ctrl+E または Cmd+E)で
編集することもできます。あるいは、復号済みセーブデータを一度書き出して
任意のバイナリエディタを使って編集することもできます。

このツールを使うには、Homebrewが実行できる3DS（あるいはCFW導入済みの3DS）が必要です。
（検証する環境がないので、CYBERセーブエディターはサポートしません）

## 使いかた
### Homebrew または CFW
1. svdt, JK's SaveManager, Checkpoint などのアプリケーションで、game*.ywとhead.ywをダンプする。
2. ツールを起動してgame*.ywを開く。
3. 変更する。
4. game*.ywを保存する。
5. 1. で使用したアプリケーションを使って、game*.ywを書き戻す。

## ビルド
Qt (5.6以降)、Crypto++、QHexEdit が必要です。QHexEdit はリポジトリに含まれています。
http://www.qt.io/
https://www.cryptopp.com
https://github.com/Dax89/QHexEdit

## 謝辞
See AUTHORS.txt for details.
このプログラムはQt (http://www.qt.io/) を使用しています。
Copyright (C) 2015 The Qt Company Ltd and other contributors.
Qt is licensed under the GNU LGPL version 3.

このプログラムはCrypto++ (https://www.cryptopp.com) を使用しています。
The Crypto++ Library (as a compilation) is licensed under the Boost Software License 1.0.
Compilation Copyright (c) 1995-2013 by Wei Dai.  All rights reserved.
This copyright applies only to this software distribution package 
as a compilation, and does not imply a copyright on any particular 
file in the package.

このプログラムはQHexEdit (https://github.com/Dax89/QHexEdit) を使用しています。
Copyright (c) 2014 Dax89
QHexEditは、MITライセンスのもとで公開されています。

## ライセンス
MIT license
Copyright (c) 2017 togenyan, nobody_fear
