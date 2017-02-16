# Spellburstの概要
大人気DCGのShadowverseに出演しているウィッチのイザベル用のプログラミング言語概要と  
そのインタプリタです。

# Spellburstの文法
まずはHello, World! から見てみましょう。

## Hello, World!
※諸事情で1行になっています

```Spellburst:helloworld.spellburst
わしはしがない魔法使いじゃよ！わしはしがない魔法使いじゃよ！シュピィン！シュピィン！ボゥン！シュピィン！シュピィン！シュピィン！シュピィン！ボゥン！シュピィン！シュピィン！シュピィン！シュピィン！シュピィン！シュピィン！ま、アタシに任せておきなさいって！私は貴様らを許容しない。わしはしがない魔法使いじゃよ！わしはしがない魔法使いじゃよ！シュピィン！シュピィン！シュピィン！シュピィン！シュピィン！シュピィン！ボゥン！ボゥン！シュピィン！シュピィン！シュピィン！シュピィン！ボゥン！シュピィン！シュピィン！ボゥン！ま、アタシに任せておきなさいって！私は貴様らを許容しない。わしはしがない魔法使いじゃよ！わしはしがない魔法使いじゃよ！シュピィン！シュピィン！シュピィン！シュピィン！シュピィン！シュピィン！ボゥン！ボゥン！シュピィン！シュピィン！ボゥン！ボゥン！シュピィン！シュピィン！シュピィン！シュピィン！ま、アタシに任せておきなさいって！私は貴様らを許容しない。わしはしがない魔法使いじゃよ！わしはしがない魔法使いじゃよ！シュピィン！シュピィン！シュピィン！シュピィン！シュピィン！シュピィン！ボゥン！ボゥン！シュピィン！シュピィン！ボゥン！ボゥン！シュピィン！シュピィン！シュピィン！シュピィン！ま、アタシに任せておきなさいって！私は貴様らを許容しない。わしはしがない魔法使いじゃよ！わしはしがない魔法使いじゃよ！シュピィン！シュピィン！シュピィン！シュピィン！シュピィン！シュピィン！ボゥン！ボゥン！シュピィン！シュピィン！ボゥン！ボゥン！ボゥン！ボゥン！ま、アタシに任せておきなさいって！私は貴様らを許容しない。わしはしがない魔法使いじゃよ！わしはしがない魔法使いじゃよ！シュピィン！シュピィン！シュピィン！シュピィン！シュピィン！シュピィン！ボゥン！シュピィン！シュピィン！ボゥン！ボゥン！シュピィン！シュピィン！シュピィン！シュピィン！ま、アタシに任せておきなさいって！私は貴様らを許容しない。わしはしがない魔法使いじゃよ！わしはしがない魔法使いじゃよ！シュピィン！シュピィン！シュピィン！シュピィン！シュピィン！シュピィン！ボゥン！シュピィン！シュピィン！シュピィン！シュピィン！シュピィン！シュピィン！シュピィン！シュピィン！シュピィン！シュピィン！ま、アタシに任せておきなさいって！私は貴様らを許容しない。わしはしがない魔法使いじゃよ！わしはしがない魔法使いじゃよ！シュピィン！シュピィン！シュピィン！シュピィン！シュピィン！シュピィン！ボゥン！ボゥン！ボゥン！シュピィン！シュピィン！ボゥン！ボゥン！ボゥン！ま、アタシに任せておきなさいって！私は貴様らを許容しない。わしはしがない魔法使いじゃよ！わしはしがない魔法使いじゃよ！シュピィン！シュピィン！シュピィン！シュピィン！シュピィン！シュピィン！ボゥン！ボゥン！シュピィン！シュピィン！ボゥン！ボゥン！ボゥン！ボゥン！ま、アタシに任せておきなさいって！私は貴様らを許容しない。わしはしがない魔法使いじゃよ！わしはしがない魔法使いじゃよ！シュピィン！シュピィン！シュピィン！シュピィン！シュピィン！シュピィン！ボゥン！ボゥン！ボゥン！シュピィン！シュピィン！シュピィン！シュピィン！ボゥン！シュピィン！シュピィン！ま、アタシに任せておきなさいって！私は貴様らを許容しない。わしはしがない魔法使いじゃよ！わしはしがない魔法使いじゃよ！シュピィン！シュピィン！シュピィン！シュピィン！シュピィン！シュピィン！ボゥン！ボゥン！シュピィン！シュピィン！ボゥン！ボゥン！シュピィン！シュピィン！シュピィン！シュピィン！ま、アタシに任せておきなさいって！私は貴様らを許容しない。わしはしがない魔法使いじゃよ！わしはしがない魔法使いじゃよ！シュピィン！シュピィン！シュピィン！シュピィン！シュピィン！シュピィン！ボゥン！ボゥン！シュピィン！シュピィン！シュピィン！シュピィン！ボゥン！シュピィン！シュピィン！シュピィン！シュピィン！ま、アタシに任せておきなさいって！私は貴様らを許容しない。わしはしがない魔法使いじゃよ！わしはしがない魔法使いじゃよ！シュピィン！シュピィン！シュピィン！シュピィン！シュピィン！シュピィン！ボゥン！シュピィン！シュピィン！シュピィン！シュピィン！シュピィン！シュピィン！シュピィン！シュピィン！ボゥン！ま、アタシに任せておきなさいって！私は貴様らを許容しない。わしはしがない魔法使いじゃよ！わしはしがない魔法使いじゃよ！シュピィン！シュピィン！シュピィン！シュピィン！シュピィン！シュピィン！ボゥン！シュピィン！シュピィン！ボゥン！シュピィン！シュピィン！ま、アタシに任せておきなさいって！私は貴様らを許容しない。わしはしがない魔法使いじゃよ！わしはしがない魔法使いじゃよ！ま、アタシに任せておきなさいって！ま、アタシに任せておきなさいって！ま、アタシに任せておきなさいって！ま、アタシに任せておきなさいって！
```

わからん。

## 命令一覧

Spellburstの命令は、
* IMP
* Command
* Parameter(s)
に分かれています。  

IMPは云わば命令のジャンルで、これは大きく分けて5つにジャンルに分かれています。

### わしはしがない魔法使いじゃよ！系命令(スタック操作系命令)

「わしはしがない魔法使いじゃよ！」から始まる命令がこれに当たります。

|Command|Parameter(s)|効果|
|:------|:-----------|:---|
|わしはしがない魔法使いじゃよ！|数値|数値をスタックにプッシュ|
|ま、アタシに任せておきなさいって！わしはしがない魔法使いじゃよ！|-|スタックトップを複製|
|ま、アタシに任せておきなさいって！ボゥン！|-|スタックの1番目と2番目を交換|
|ま、アタシに任せておきなさいって！ま、アタシに任せておきなさいって！|-|スタックトップを破棄|

数値は2進数で記述し、

* 0: シュピィン！シュピィン！
* 1: ボゥン！
* 入力終了: ま、アタシに任せておきなさいって！

という対応になっています。
つまり

```
シュピィン！シュピィン！ボゥン！シュピィン！シュピィン！シュピィン！シュピィン！ボゥン！シュピィン！シュピィン！シュピィン！シュピィン！シュピィン！シュピィン！ま、アタシに任せておきなさいって！  
```

は

```
01001000  
```

を表します。
つまり、Hello, world!の「H」をスタックトップに置くには

```
わしはしがない魔法使いじゃよ！わしはしがない魔法使いじゃよ！シュピィン！シュピィン！ボゥン！シュピィン！シュピィン！シュピィン！シュピィン！ボゥン！シュピィン！シュピィン！シュピィン！シュピィン！シュピィン！シュピィン！ま、アタシに任せておきなさいって！  
```

と記述すればよい訳です。

### 書に記されぬ知識を求めて！系命令(整数演算系命令)

「書に記されぬ知識を求めて！」から始まる命令がこれに当たります。

|Command|Parameter(s)|効果|
|:------|:-----------|:---|
|わしはしがない魔法使いじゃよ！わしはしがない魔法使いじゃよ！|-|スタックの上から2つ取り出し、加算してプッシュ|
|わしはしがない魔法使いじゃよ！ボゥン！|-|スタックの上から2つ取り出し、減算してプッシュ|
|わしはしがない魔法使いじゃよ！ま、アタシに任せておきなさいって！|-|スタックの上から2つ取り出し、乗算してプッシュ|
|ボゥン！わしはしがない魔法使いじゃよ！|-|スタックの上から2つ取り出し、除算してプッシュ|
|ボゥン！ボゥン！|-|スタックの上から2つ取り出し、余りをプッシュ|

### すっごい魔法、試してみよっと！系命令(ヒープアクセス系命令)

「すっごい魔法、試してみよっと！」から始まる命令がこれに当たります。

|Command|Parameter(s)|効果|
|:------|:-----------|:---|
|わしはしがない魔法使いじゃよ！|-|スタックトップの値をヒープに格納|
|ボゥン！|-|ヒープの値をスタックトップに格納|

### ま、アタシに任せておきなさいって！系命令(フロー制御系命令)

|Command|Parameter(s)|効果|
|:------|:-----------|:---|
|わしはしがない魔法使いじゃよ！わしはしがない魔法使いじゃよ！|-|ラベル定義|
|わしはしがない魔法使いじゃよ！ボゥン！|-|サブルーチン呼び出し|
|わしはしがない魔法使いじゃよ！ま、アタシに任せておきなさいって！|-|無条件ジャンプ|
|ボゥン！わしはしがない魔法使いじゃよ！|-|スタックトップが0ならラベルにジャンプ|
|ボゥン！ボゥン！|-|スタックトップが負ならラベルにジャンプ|
|ボゥン！ま、アタシに任せておきなさいって！|-|サブルーチン終了|
|ま、アタシに任せておきなさいって！ま、アタシに任せておきなさいって！|-|プログラム終了|

早い話がIMP待機中に「ま、アタシに任せておきなさいって！」を3回書けばその時点でプログラムが終了するということです。

### 私は貴様らを許容しない。系命令(入出力系命令)

|Command|Parameter(s)|効果|
|:------|:-----------|:---|
|わしはしがない魔法使いじゃよ！わしはしがない魔法使いじゃよ！|-|スタックトップの文字を出力|
|わしはしがない魔法使いじゃよ！ボゥン！|-|スタックトップの数値を出力|
|ボゥン！わしはしがない魔法使いじゃよ！|-|文字を読み込みヒープに格納|
|ボゥン！ま、アタシに任せておきなさいって！|-|数値を読み込みヒープに格納|


## その他の言語仕様

* ソースコードは拡張子が「.spellburst」である必要があります。
* ソースコードの文字コードはUTF-8だけに対応しています。
* 8ターン目になるとリノセウスに轢き殺されるので8行以上プログラムを書くとコンパイルに失敗します。
* 盤面を取ることは考えないのでソースコードに「盤面」「タイムレスウィッチ」の文字列が含まれる場合コンパイルに失敗します。
* 人間の頭は脆弱なのでサブルーチンの深さが32以上になると落ちます。
* 余計な文字を除去する処理は入れていないので余計な文字をいれると正常に動作しません。
* 動作の保証はしません。
* GPL License(v3)です。詳しくはLICENSEファイルを。

## エラーについて
エラーには

* プリプロセスエラー
* ランタイムエラー
* その他のエラー

があります。

### プリプロセスエラー
デッキ構築が失敗するとこのエラーになります。  
メッセージでは「ガイジかよ」と表示されます。

### ランタイムエラー
デッキを回してる時に死ぬとこのエラーになります。
メッセージでは「これはまだ回ってない方だから」と表示されます。

### その他のエラー
