---
title: 変数の読み書き
---

# 変数の読み書き

UdonEmu では、変数を読み書きできます。  
これにより、プログラムにパラメータを渡したりできます。

---

## 基本的な使い方

### 変数を設定

```csharp
vm.SetUdonProgramVariable("myVariable", 42);
```

**使い方**：
- プログラムが参照する変数を事前に設定
- パラメータを渡す

**例**：プレイヤーの名前をプログラムに渡す

```csharp
vm.SetUdonProgramVariable("playerName", "Alice");
// プログラム内で playerName を参照できる
```

---

### 変数を取得

```csharp
var result = vm.GetUdonProgramVariable("myVariable");
Debug.Log(result); // 実行後の値
```

**使い方**：
- プログラムの実行結果を受け取る

**例**：スコアを取得

```csharp
vm.RunProgram("CalculateScore");
var score = vm.GetUdonProgramVariable("score");
Debug.Log($"Score: {score}");
```

---

### 安全に取得

```csharp
if (vm.TryGetUdonProgramVariable("myVariable", out var value)) {
    Debug.Log(value);
} else {
    Debug.LogWarning("Variable not found");
}
```

**使い方**：
- 変数が存在しない場合に例外を避ける
- オプショナルなパラメータを扱う

**例**：オプション設定の取得

```csharp
if (vm.TryGetUdonProgramVariable("optionalSetting", out var setting)) {
    // 設定が存在する場合の処理
    Debug.Log($"Setting: {setting}");
} else {
    // デフォルト値を使用
    Debug.Log("Using default setting");
}
```

---

## UdonAssembly での変数宣言

### 変数の定義

UdonAssembly で変数を宣言すると、Unity 側から読み書きできます。

```
.data_start
    myVariable: %SystemInt32, 0
    message: %SystemString, null
    isActive: %SystemBoolean, false
.data_end
```

**対応関係**：

| UdonAssembly | C# |
|--------------|-----|
| `myVariable: %SystemInt32, 0` | `vm.GetUdonProgramVariable("myVariable")` |
| `message: %SystemString, null` | `vm.GetUdonProgramVariable("message")` |
| `isActive: %SystemBoolean, false` | `vm.GetUdonProgramVariable("isActive")` |

:::caution 変数が存在しないとエラー
UdonAssembly 側で宣言されていない変数は、`GetUdonProgramVariable` で取得しようとすると例外が発生します。  
`TryGetUdonProgramVariable` を使うか、事前に変数が存在するか確認してください。
:::

---

## 実用例

### 例 1：Unity からパラメータを渡す

```csharp
void Start() {
    var uassembly = @"
    .data_start
        playerName: %SystemString, null
        playerLevel: %SystemInt32, 0
    .data_end
    .code_start
        .export _greet
        _greet:
            // playerName と playerLevel を使った処理
            JUMP, 0xFFFFFFFF
    .code_end
    ";

    ExecuteUdonAssembly(uassembly);

    // Unity 側から値を設定
    vm.SetUdonProgramVariable("playerName", "Alice");
    vm.SetUdonProgramVariable("playerLevel", 10);

    // イベント実行
    vm.RunProgram("_greet");
}
```

---

### 例 2：実行結果を Unity 側で受け取る

```csharp
void Start() {
    var uassembly = @"
    .data_start
        result: %SystemInt32, 0
    .data_end
    .code_start
        .export _calculate
        _calculate:
            // 計算処理（result に結果を格納）
            JUMP, 0xFFFFFFFF
    .code_end
    ";

    ExecuteUdonAssembly(uassembly);

    // イベント実行
    vm.RunProgram("_calculate");

    // 結果を取得
    var result = (int)vm.GetUdonProgramVariable("result");
    Debug.Log($"Result: {result}");
}
```

---

### 例 3：実行前後での変数の変化を確認

```csharp
void Start() {
    ExecuteUdonAssembly(uassembly);

    // 実行前の値を確認
    var before = (int)vm.GetUdonProgramVariable("counter");
    Debug.Log($"Before: {before}");

    // イベント実行
    vm.RunProgram("_increment");

    // 実行後の値を確認
    var after = (int)vm.GetUdonProgramVariable("counter");
    Debug.Log($"After: {after}");
}
```

---

:::tip 問題が起きたら
変数に関するエラーが発生した場合は [トラブルシューティング](/troubleshooting) を参照してください。
:::

---

## 次のステップ

### 実行フローを理解する

変数の読み書きがどのタイミングで行われるかを理解します。

**参照**：[実行フローの理解](/guides/execution-flow)
