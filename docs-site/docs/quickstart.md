---
title: クイックスタート
---

# クイックスタート

文字列で用意した **UdonAssembly 形式のコード** を実行します。

---

## 最小の動作例

以下のコードを `ExampleUdonEmu.cs` として保存し、シーンに配置してください。

```csharp
using HoshinoLabs.UdonEmu.Udon;
using UdonSharp;
using UnityEngine;

[AddComponentMenu("")]
[UdonBehaviourSyncMode(BehaviourSyncMode.None)]
public class ExampleUdonEmu : UdonSharpBehaviour {
    [SerializeField]
    UdonVM vm;

    [SerializeField, HideInInspector]
    UdonTypeResolver typeResolver;
    [SerializeField, HideInInspector]
    UdonProgramDescriptor programDescriptor;

    private void Start() {
        // テキストで UdonAssembly を用意
        var uassembly = @"
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
        ";

        // UdonAssembly を実行
        ExecuteUdonAssembly(uassembly);
    }

    void ExecuteUdonAssembly(string uassembly) {
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
    }
}
```

:::info UdonTypeResolver / UdonProgramDescriptor について
これらは UdonEmu が自動生成するアセットです。  
自動的にセットされるのでフィールドを用意すれば問題ありません。
:::

---

## 実行手順

### 1. GameObject を作成してコンポーネントを追加

1. Unity で新規シーンを作成
2. 空の GameObject を作成（名前は任意、例: `UdonEmuTest`）
3. **`UdonVM` コンポーネントを GameObject にアタッチ**
4. **`ExampleUdonEmu` コンポーネントを同じ GameObject にアタッチ**

### 2. Inspector で vm を設定

Inspector の `ExampleUdonEmu` コンポーネントで、`vm` フィールドに **同じ GameObject の `UdonVM`** をドラッグ＆ドロップで設定してください。

### 3. Play して確認

Unity の Play ボタンを押すと、Console に以下が表示されます：

```
Hello, UdonEmu!
```

これで UdonAssembly の実行が成功です 🎉

---

:::tip 問題が起きたら
詳しいトラブルシューティングは [トラブルシューティング](/troubleshooting) を参照してください。
:::

---

## 次のステップ

### 独自の UdonAssembly を作成する

UdonSharp で書いたプログラムから UdonAssembly を取得する方法。

**参照**：[UdonAssembly のエクスポート](/guides/export-assembly)

### 実行フローを理解する

4つのステップ（プログラム初期化 → 変数テーブル → VM設定 → イベント実行）の役割を詳しく理解します。

**参照**：[実行フローの理解](/guides/execution-flow)

### 変数の読み書きを学ぶ

実行前後でデータを受け渡す方法を学びます。

**参照**：[変数の読み書き](/guides/variables)
