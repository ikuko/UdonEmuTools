---
title: 互換性と差異
---

# 互換性と差異

UdonEmu は VRChat 公式の Udon 実装を模倣していますが、環境（Unity/SDK）や未実装領域により差異が出る可能性があります。

## 互換性の考え方

### 対応範囲

UdonEmu は以下の範囲で公式実装との互換性を目指しています：

- ✅ UdonAssembly の命令セット（OpCode）
- ✅ 変数の読み書き
- ✅ エントリポイント（イベント）の実行
- ✅ 基本的な制御フロー

### 制約・既知の差異

- **Editor 専用機能**: 一部の機能は Unity エディタでのみ動作します（`#if UNITY_EDITOR` によるもの）
- **VRChat 固有 API**: ネットワーク関連など、VRChat 環境に強く依存する機能は模倣に限界があります
- **パフォーマンス特性**: 実行速度や最適化は公式実装と異なる場合があります

## 差異が出たときの切り分け手順

公式の VRChat と UdonEmu で挙動が異なる場合、以下の手順で原因を切り分けることができます。

### 1. プログラム構造の確認

実行対象の `UdonProgram` を Dump して構造を確認します。

```csharp
using HoshinoLabs.UdonEmu.Udon;

// プログラムの構造を JSON で出力
var programJson = udonProgram.Dump();
Debug.Log(programJson);
```

**参照**: [Dump](/debug/dump)

### ~~2. 変数の状態確認~~

<!-- 実行前後の VariableTable を Dump して差分を確認します。

```csharp
// 実行前
var beforeJson = vm.GetUdonVariableTable().Dump();

// イベント実行
vm.RunProgram("_greet");

// 実行後
var afterJson = vm.GetUdonVariableTable().Dump();
``` -->

### 3. 最小再現コードの作成

問題を最小限に再現できるコードを作成します：

- イベント1つのみ
- 変数は最小限
- 外部依存を排除

### 4. Issue 報告

最小再現コードができたら、GitHub の Issues で報告してください：

- UdonEmu のバージョン
- Unity / VRChat SDK のバージョン
- 最小再現コード
- 期待される動作と実際の動作

## 互換性を高めるためのヒント

### エラーハンドリング

VRChat では無視されるエラーが、UdonEmu では例外として表示される場合があります。

### ログ出力

`Debug.Log` を活用して、実行フローと変数の状態を確認してください。

## 参照

- [デバッグ / 解析](/debug/dump) - 詳細な解析方法
- [FAQ](/faq) - よくある問題と解決方法
