---
title: Dump
---

# Dump

UdonEmu には、プログラム構造や変数の状態を JSON として出力するための拡張メソッドが用意されています。

## UdonProgram の Dump

`UdonProgram` の内部構造を JSON 形式で出力できます。

### 使い方

```csharp
using HoshinoLabs.UdonEmu.Udon;

// UdonProgram を Dump
var programJson = udonProgram.Dump();
Debug.Log(programJson);
```

### 出力内容

Dump された JSON には以下の情報が含まれます：

- **EntryPoints**: イベント名とそのアドレス
- **Instructions**: OpCode と引数の一覧
- **Heap**: 定数データ
- **Extern**: 外部メソッド参照

### ユースケース

- プログラムの構造確認
- イベントの存在確認
- OpCode レベルでの実行フローの追跡
- 複数バージョンの構造比較

## ~~VariableTable の Dump~~

<!-- `UdonVariableTable` の変数状態を JSON 形式で出力できます。

### 使い方

```csharp
using HoshinoLabs.UdonEmu.Udon;

// VariableTable を Dump
var variablesJson = vm.GetUdonVariableTable().Dump();
Debug.Log(variablesJson);
```

### 出力内容

Dump された JSON には以下の情報が含まれます：

- 変数名
- 変数の型
- 変数の値（JSON でシリアライズ可能な形式）

### ユースケース

- 実行前後の変数の変化を追跡
- 特定の変数の値を確認
- テスト用のスナップショット作成
- 状態の差分比較

## 実行前後の比較

Dump を活用した典型的なデバッグパターンです。

### 例: 実行前後の変数比較

```csharp
using HoshinoLabs.UdonEmu.Udon;

// 実行前の状態を記録
var beforeDump = vm.GetUdonVariableTable().Dump();
System.IO.File.WriteAllText("before.json", beforeDump);

// イベント実行
vm.RunProgram("_greet");

// 実行後の状態を記録
var afterDump = vm.GetUdonVariableTable().Dump();
System.IO.File.WriteAllText("after.json", afterDump);

// JSON 差分ツールで比較
```

### 例: 複数実行の追跡

```csharp
var dumps = new List<string>();

for (int i = 0; i < 10; i++) {
    vm.RunProgram("_increment");
    dumps.Add(vm.GetUdonVariableTable().Dump());
}

// 各実行時点での状態を記録
for (int i = 0; i < dumps.Count; i++) {
    System.IO.File.WriteAllText($"state_{i}.json", dumps[i]);
}
``` -->

## JSON の活用

出力された JSON は以下の用途に使えます：

- **差分ツールでの比較**: `git diff` や専用の JSON 差分ツール
- **自動テスト**: 期待される状態と実際の状態の比較
- **ドキュメント**: プログラム構造の可視化
- **デバッグログ**: Issue 報告時の添付資料
