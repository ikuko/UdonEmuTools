---
title: 実行フローの理解
---

# 実行フローの理解

UdonEmu で UdonAssembly を実行するには、**4つのステップ**を順番に実行する必要があります。  
このページでは、各ステップが「何をしているか」「なぜ必要か」を詳しく説明します。

---

## 全体の流れ

```csharp
// 1. プログラムを初期化
if (!UdonAssemblyAssembler.TryAssembleProgram(
    uassembly,
    typeResolver,
    programDescriptor,
    out var program
)) {
    Debug.LogError("Failed to assemble UdonProgram");
    return;
}

// 2. 変数テーブルを初期化
if (!UdonAssemblyAssembler.TryAssembleVariableTable(
    uassembly,
    typeResolver,
    out var variables
)) {
    Debug.LogError("Failed to assemble UdonVariableTable");
    return;
}

// 3. VM に設定
vm.AssignProgramAndVariables(program, variables);
vm.InitializeUdonContent();

// 4. イベントを実行
vm.RunProgram("PrintGreeting");
```

---

## ステップ 1：プログラムを初期化

```csharp
if (!UdonAssemblyAssembler.TryAssembleProgram(
    uassembly,
    typeResolver,
    programDescriptor,
    out var program
)) {
    Debug.LogError("Failed to assemble UdonProgram");
    return;
}
```

### 何をしているか

テキスト形式の UdonAssembly を **UdonProgram オブジェクト**に変換します。  
具体的には、命令列（`.code_start` 〜 `.code_end`）を VM が実行できる内部形式にパースします。

### なぜ必要か

VM はテキストを直接実行できません。内部形式（命令配列）に変換する必要があります。

### パラメータ

- **`uassembly`**：テキスト形式の UdonAssembly
- **`typeResolver`**：型情報を解決するためのオブジェクト
- **`programDescriptor`**：プログラム記述子
- **`out program`**：変換後の UdonProgram（出力パラメータ）

### 戻り値

- **`true`**：パース成功
- **`false`**：パース失敗（構文エラー等）

### 失敗する場合

- `.data_start` / `.code_start` のスペルミス
- `.export` でエントリポイントが宣言されていない
- `EXTERN` の関数名が不正
- 命令のオペランド（引数）が不足

### 例：正しい UdonAssembly

```
.code_start
    .export _start
    _start:
        PUSH, __const_SystemString_0
        EXTERN, "UnityEngineDebug.__Log__SystemObject__SystemVoid"
        JUMP, 0xFFFFFFFC
.code_end
```

---

## ステップ 2：変数テーブルを初期化

```csharp
if (!UdonAssemblyAssembler.TryAssembleVariableTable(
    uassembly, 
    typeResolver, 
    out var variables
)) {
    Debug.LogError("Failed to assemble UdonVariableTable");
    return;
}
```

### 何をしているか

変数定義（`.data_start` 〜 `.data_end`）を **UdonVariableTable** に変換します。  
定数の初期値も設定されます。

### なぜ必要か

プログラムが参照する変数・定数を事前に用意する必要があります。  
変数テーブルがないと、プログラムは変数にアクセスできません。

### パラメータ

- **`uassembly`**：テキスト形式の UdonAssembly
- **`typeResolver`**：型情報を解決するためのオブジェクト
- **`out variables`**：変換後の UdonVariableTable（出力パラメータ）

### 戻り値

- **`true`**：パース成功
- **`false`**：パース失敗（構文エラー等）

### 失敗する場合

- 型名が不正（`%SystemString` のスペルミス等）
- 定数の値が型に合わない（例：文字列に数値を設定）
- 変数名の構文エラー

### 例：正しい変数定義

```
.data_start
    __const_SystemString_0: %SystemString, ""Hello, UdonEmu!""
.data_end
```

---

## ステップ 3：VM に設定

```csharp
vm.AssignProgramAndVariables(program, variables);
vm.InitializeUdonContent();
```

### 何をしているか

#### `AssignProgramAndVariables`
プログラムと変数テーブルを VM に紐付けます。  
この時点で、VM は「どのプログラムを実行するか」「どの変数テーブルを使うか」を認識します。

#### `InitializeUdonContent`
VM の内部状態を初期化します。  
具体的には、スタック・ヒープ・プログラムカウンタ等の準備を行います。

### なぜ必要か

VM は紐付けられたプログラムしか実行できません。  
また、内部状態を初期化しないと、実行時に `NullReferenceException` やその他のエラーが発生します。

:::danger InitializeUdonContent は必須
`InitializeUdonContent()` を呼び忘れると、実行時にエラーになります。必ず呼んでください。
:::

### よくある間違い

```csharp
// ❌ InitializeUdonContent を呼び忘れ
vm.AssignProgramAndVariables(program, variables);
vm.RunProgram("PrintGreeting"); // エラー！
```

```csharp
// ✅ 正しい順序
vm.AssignProgramAndVariables(program, variables);
vm.InitializeUdonContent();
vm.RunProgram("PrintGreeting"); // OK
```

---

## ステップ 4：イベントを実行

```csharp
vm.RunProgram("PrintGreeting");
```

### 何をしているか

エントリポイント（`.export PrintGreeting`）から実行を開始します。  
Udon はイベント駆動のため、イベント名を指定して実行します。

### なぜ必要か

プログラムは自動的には実行されません。  
明示的にイベントを呼び出す必要があります。

### パラメータ

- **`eventName`**：実行するイベント名（文字列）

### 失敗する場合

- イベント名が `.export` で宣言されていない
- 存在しないイベント名を指定
- 大文字小文字の不一致

---

## まとめ：4ステップの役割

| ステップ | API | 役割 |
|---------|-----|------|
| 1 | `TryAssembleProgram` | テキスト → UdonProgram に変換 |
| 2 | `TryAssembleVariableTable` | テキスト → UdonVariableTable に変換 |
| 3 | `AssignProgramAndVariables`<br />`InitializeUdonContent` | VM に紐付け & 内部状態を初期化 |
| 4 | `RunProgram` | イベントを実行 |

この順序を守ることで、UdonAssembly を正しく実行できます。

---

:::tip 問題が起きたら
エラーが発生した場合は [トラブルシューティング](/troubleshooting) を参照してください。
:::

---

## 次のステップ

### 変数の読み書きを学ぶ

実行前後でデータを受け渡す方法を学びます。

**参照**：[変数の読み書き](/guides/variables)
