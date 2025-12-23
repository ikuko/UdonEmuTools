---
title: OpCode
---

# OpCode

UdonAssembly の命令セット（OpCode）について説明します。

## OpCode とは

OpCode（Operation Code）は、Udon 仮想マシンが実行する個々の命令を表します。

## 主要な OpCode

UdonEmu が対応している主要な OpCode は以下の通りです。

### スタック操作

- **PUSH**: 値をスタックにプッシュ
- **POP**: スタックから値をポップ

### 制御フロー

- **JUMP**: 無条件ジャンプ
- **JUMP_IF_FALSE**: 条件付きジャンプ（false の場合）
- **JUMP_INDIRECT**: 間接ジャンプ

### 変数操作

- **COPY**: 変数のコピー
- **EXTERN**: 外部メソッド呼び出し

### UdonEmu 独自拡張

:::caution STORE / LOAD は VRChat 公式の UdonAssembly 命令セットには存在しない、UdonEmu の拡張独自命令です。  
主に `EXTERN` 呼び出し時の引数・戻り値の受け渡し（内部的な変数操作）に使われます。
:::

- **STORE**: 指定の変数へ値を格納
- **LOAD**: 指定の変数から値を読み出し

### その他

- **NOP**: 何もしない
- **ANNOTATION**: 何もしない

## OpCode の確認方法

プログラムに含まれる OpCode は、Dump 機能を使って確認できます。

```csharp
using HoshinoLabs.UdonEmu.Udon;

// プログラムを Dump
var programJson = udonProgram.Dump();
Debug.Log(programJson);
```

出力された JSON の `instructions` セクションに OpCode の列が含まれます。

## OpCode のデバッグ

### 実行フローの追跡

OpCode レベルで実行フローを追跡する場合：

1. プログラムを Dump して OpCode の列を確認
2. EntryPoints から開始アドレスを確認
3. JUMP 命令を追跡して制御フローを理解

### トラブルシューティング

- **無限ループ**: JUMP 命令の飛び先を確認
- **予期しない動作**: EXTERN 呼び出しの引数を確認
- **スタックオーバーフロー**: PUSH/POP のバランスを確認

## より詳しい情報

OpCode の詳細な仕様については、VRChat の公式ドキュメントや Udon の仕様書を参照してください。
https://creators.vrchat.com/worlds/udon/vm-and-assembly/
