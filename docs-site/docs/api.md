---
title: API リファレンス
---

# API リファレンス

UdonEmu の主要な API について説明します。

## 主要なクラスとメソッド

利用者が直接触る頻度が高い API は以下です。

### UdonVM

UdonAssembly を実行する仮想マシンの中核クラスです。

#### 主要メソッド

##### 初期化

```csharp
void InitializeUdonContent()
```

Udon コンテンツを初期化します。

##### プログラム実行

```csharp
void RunProgram(string entryPoint)
```

指定されたエントリポイント（イベント名）を実行します。

##### 変数操作

```csharp
void SetUdonProgramVariable(string name, object value)
object GetUdonProgramVariable(string name)
bool TryGetUdonProgramVariable<T>(string name, out T value)
```

変数の設定・取得を行います。

### UdonProgram

Udon プログラムの構造を表すクラスです。

#### 主要メソッド

```csharp
string Dump(this UdonProgram program)
```

UdonProgram の構造を JSON 形式で出力します。

### UdonVariableTable

Udon の変数テーブルを表すクラスです。

#### 主要メソッド

```csharp
string Dump(this UdonVariableTable table)
```

VariableTable の状態を JSON 形式で出力します。

### UdonTypeResolver

Udon の型情報を解決するためのクラスです。

### UdonProgramDescriptor

Udon プログラムのディスクリプタです。

## 次のステップ

- [クイックスタート](/quickstart) - 実際の使い方を確認
- [デバッグ / 解析](/debug/dump) - Dump 機能の活用方法
