---
title: UdonAssembly のエクスポート
---

# UdonAssembly のエクスポート

実行時差し替えや Web 配信を行うには、**テキスト形式の UdonAssembly** が必要です。

このページでは、Unity エディタ上で UdonSharp で書いたプログラムから、テキスト形式の UdonAssembly を取得する手順を説明します。

---

## 前提条件

- Unity プロジェクトに **UdonEmu Tools** がインストールされていること（[UdonEmu Tools のインストール](/guides/installation-tools) 参照）
- UdonSharp でプログラムを作成済みであること

---

## 手順

### 1. UdonSharpProgramAsset を選択

Unity の **Project ウィンドウ**で、エクスポートしたい **UdonSharpProgramAsset（`.asset` ファイル）** を選択します。

:::info UdonSharpProgramAsset とは
UdonSharp で C# スクリプトを書くと、対応する `.asset` ファイルが自動生成されます。  
このファイルには、コンパイルされた UdonProgram が格納されています。
:::

---

### 2. メニューから「Copy Assembly To Clipboard With Heap」を実行

Unity のメニューバーから以下を選択します：

```
Tools > HoshinoLabs > UdonEmu > Copy Assembly To Clipboard With Heap
```

---

### 3. クリップボードにコピーされる

実行すると、選択した UdonSharpProgramAsset の **UdonAssembly がテキスト形式でクリップボードにコピー**されます。

:::tip 確認方法
確認メッセージ等は表示されないため、次の手順でテキストエディタに貼り付けて確認してください。
:::

---

### 4. テキストエディタに貼り付けて保存

クリップボードの内容を **テキストエディタ**（VS Code / メモ帳等）に貼り付けます。

以下のような形式のテキストが取得できます：

```assembly
.data_start
    __const_SystemString_0: %SystemString, "Hello, UdonEmu!"
.data_end
.code_start
    .export PrintGreeting
    PrintGreeting:
        PUSH, __const_SystemString_0
        EXTERN, "UnityEngineDebug.__Log__SystemObject__SystemVoid"
        JUMP, 0xFFFFFFFC
.code_end
```

このテキストを `.txt` または `.uasm` ファイルとして保存してください（例: `MyProgram.txt`）。

:::info 「With Heap」の意味
メニュー名に含まれる「With Heap」は、**変数の初期値やデータも含めてエクスポートする**ことを意味します。  
これにより、完全な状態でプログラムを実行時に復元できます。
:::

---

## トラブルシューティング

エクスポート時の問題については [トラブルシューティング](/troubleshooting#udonassembly-のエクスポート関連) ページを参照してください。

---

### エクスポートした UdonAssembly が実行時にエラーになる

パース時にエラーが出る場合、UdonAssembly のフォーマットが正しくない可能性があります。

**対処法**:
1. エクスポート操作を再度実行して、最新の状態を取得
2. テキストエディタで余計な改行や文字が入っていないか確認
3. [デバッグ / 解析](/debug/dump) で UdonProgram の構造を確認

:::danger エクスポートでシリアライズできる型
エクスポートを行う際に値を文字列にシリアライズします。  
一部のプリミティブ型や構造体型のみシリアライズに対応していることに注意してください。  
シリアライズされない値は **`null`** になるため外部スクリプトから設定するか何らかの手段で自力取得する必要があります。

対応している型の一覧: [シリアライズできる型](/guides/serializable-types)
:::
