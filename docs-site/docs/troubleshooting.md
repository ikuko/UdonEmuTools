---
title: トラブルシューティング
---

# トラブルシューティング

UdonEmu でよくあるエラー・問題と解決策をまとめています。

:::tip エラーメッセージで検索
このページで Ctrl+F（Command+F on Mac）を使って、エラーメッセージを検索してください。
:::

---

## セットアップ関連

### ❌ メニューに「HoshinoLabs」が表示されない

**原因**：UdonEmu が正しくインストールされていない

**対処**：
1. [インストール手順](/install) を再確認
2. Unity を再起動してメニューを再読み込み
3. Package Manager で UdonEmu が表示されているか確認
4. `Packages/com.hoshinolabs.udonemu` フォルダが存在するか確認

---

### ❌ `NullReferenceException` at `typeResolver` または `programDescriptor`

**エラーメッセージ例**：
```
NullReferenceException: Object reference not set to an instance of an object
HoshinoLabs.UdonEmu.Udon.UdonAssemblyAssembler.TryAssembleProgram
```

**原因**：
- `typeResolver` または `programDescriptor` が `null`

**対処**：
1. **Sardinject が導入されているか確認**（[インストール](/install)）
2. `[SerializeField]` 属性が正しく付いているか確認
   ```csharp
   [SerializeField, HideInInspector]
   UdonTypeResolver typeResolver;
   ```
3. Unity を再起動してみる
4. UdonSharp のコンパイルエラーがないか確認

**参考**：
- [実行フローの理解 - ステップ 1](/guides/execution-flow#ステップ-1プログラムを初期化)

---

### ❌ `NullReferenceException` at `vm.AssignProgramAndVariables`

**エラーメッセージ例**：
```
NullReferenceException: Object reference not set to an instance of an object
ExampleUdonEmu.ExecuteUdonAssembly (vm.AssignProgramAndVariables)
```

**原因**：
- `vm` フィールドが設定されていない

**対処**：
1. Inspector で `vm` フィールドに `UdonEmu` を設定したか確認
2. `UdonEmu` コンポーネントが同じ GameObject にアタッチされているか確認
3. SerializeField 属性が付いているか確認
   ```csharp
   [SerializeField]
   UdonEmu vm;
   ```

**参考**：
- [クイックスタート - 実行手順](/quickstart#実行手順)

---

## UdonAssembly の実行関連

### ❌ `Failed to assemble UdonProgram`

**エラーメッセージ例**：
```
Failed to assemble UdonProgram
```

**原因**：
- UdonAssembly のテキスト形式に構文エラーがある

**対処**：
1. `.data_start` / `.code_start` のスペルを確認
2. `.export` でエントリポイントを宣言しているか確認
   ```
   .export _start
   ```
3. `EXTERN` の関数名が正しいか確認
   ```
   EXTERN, "UnityEngineDebug.__Log__SystemObject__SystemVoid"
   ```
4. カンマ（`,`）が正しく入っているか確認
5. 命令のオペランド（引数）が不足していないか確認

**参考**：
- [実行フローの理解 - ステップ 1](/guides/execution-flow#ステップ-1プログラムを初期化)

---

### ❌ `Failed to assemble UdonVariableTable`

**エラーメッセージ例**：
```
Failed to assemble UdonVariableTable
```

**原因**：
- 変数定義（`.data_start` 〜 `.data_end`）に構文エラーがある

**対処**：
1. `.data_start` / `.data_end` のスペルを確認
2. 型名が正しいか確認（`%SystemString`, `%SystemInt32` 等）
3. 定数の値が型に合っているか確認
   ```
   // ✅ 正しい
   message: %SystemString, "Hello"
   count: %SystemInt32, 42
   
   // ❌ 間違い
   message: %SystemString, 42  // 型が合わない
   ```

**参考**：
- [実行フローの理解 - ステップ 2](/guides/execution-flow#ステップ-2変数テーブルを初期化)

---

### ❌ Console に何も表示されない（イベントが実行されない）

**原因**：
- イベント名が `.export` で宣言されていない
- `InitializeUdonContent()` を呼び忘れている
- イベント名の大文字小文字が一致していない

**対処**：
1. `RunProgram("_greet")` のイベント名が、`.export` で宣言した名前と **完全に一致**しているか確認
   ```
   .code_start
       .export _greet  // ← この名前と
   
   vm.RunProgram("_greet");  // ← この名前が一致
   ```
2. `InitializeUdonContent()` を呼んでいるか確認
   ```csharp
   vm.AssignProgramAndVariables(program, variables);
   vm.InitializeUdonContent();  // ← 必須
   vm.RunProgram("_greet");
   ```
3. Console のエラーログを確認（他のエラーが出ていないか）

**参考**：
- [実行フローの理解 - ステップ 4](/guides/execution-flow#ステップ-4イベントを実行)

---

### ❌ `InitializeUdonContent()` を呼び忘れた

**エラーメッセージ例**：
```
NullReferenceException が RunProgram 実行時に発生
```

**原因**：
- `InitializeUdonContent()` を呼ばずに `RunProgram()` を実行した

**対処**：
```csharp
// ❌ 間違い
vm.AssignProgramAndVariables(program, variables);
vm.RunProgram("_greet");  // エラー！

// ✅ 正しい
vm.AssignProgramAndVariables(program, variables);
vm.InitializeUdonContent();  // ← 必須
vm.RunProgram("_greet");
```

**参考**：
- [実行フローの理解 - ステップ 3](/guides/execution-flow#ステップ-3vm-に設定)

---

## 変数の読み書き関連

### ❌ `Could not find symbol`（変数が見つからない）

**エラーメッセージ例**：
```
Could not find symbol XXX.
```

**原因**：
- 変数が UdonAssembly で宣言されていない
- 変数名のスペルミス

**対処**：
1. UdonAssembly で変数が宣言されているか確認
   ```
   .data_start
       myVariable: %SystemInt32, 0  // ← 宣言が必要
   .data_end
   ```
2. 変数名のスペルを確認（大文字小文字を含めて完全一致）
3. `TryGetUdonProgramVariable` を使って安全に取得
   ```csharp
   if (vm.TryGetUdonProgramVariable("myVariable", out var value)) {
       Debug.Log(value);
   } else {
       Debug.LogWarning("Variable not found");
   }
   ```

**参考**：
- [変数の読み書き](/guides/variables)

---

### ❌ `InvalidCastException`（型が合わない）

**エラーメッセージ例**：
```
InvalidCastException: Cannot cast from source type to destination type.
```

**原因**：
- `GetUdonProgramVariable` で取得した値を誤った型にキャストしている

**対処**：
1. UdonAssembly での型宣言を確認
   ```
   .data_start
       count: %SystemInt32, 0  // ← Int32
       message: %SystemString, null  // ← String
   .data_end
   ```
2. キャストを型に合わせる
   ```csharp
   // ✅ 正しい
   var count = (int)vm.GetUdonProgramVariable("count");
   var message = (string)vm.GetUdonProgramVariable("message");
   
   // ❌ 間違い
   var count = (string)vm.GetUdonProgramVariable("count");  // int を string にキャスト不可
   ```

**参考**：
- [変数の読み書き](/guides/variables)

---

### ❌ 変数が `null` になる

**原因**：
- 変数に初期値が設定されていない
- 変数が初期化されていない

**対処**：
1. UdonAssembly で初期値を設定
   ```
   .data_start
       message: %SystemString, null  // null は明示的に設定
       message2: %SystemString, "Default"  // デフォルト値を設定
   .data_end
   ```
2. `null` チェックを追加
   ```csharp
   var value = vm.GetUdonProgramVariable("message");
   if (value != null) {
       Debug.Log(value);
   } else {
       Debug.LogWarning("Variable is null");
   }
   ```

**参考**：
- [変数の読み書き](/guides/variables)

---

## UdonAssembly のエクスポート関連

### ❌ クリップボードに何もコピーされない

**原因**：
- 選択している `.asset` ファイルが UdonSharpProgramAsset ではない
- UdonSharp のコンパイルが完了していない

**対処**：
1. Inspector で `.asset` の型を確認（`UdonSharpProgramAsset` と表示されるか）
2. UdonSharp のコンパイルが完了しているか確認（Console にエラーが出ていないか）
3. 別の UdonSharpProgramAsset で試してみる
4. Unity を再起動してみる

**参考**：
- [UdonAssembly のエクスポート](/guides/export-assembly)

---

### ❌ 貼り付けたテキストが空 / 一部しかコピーされない

**原因**：
- クリップボードのサイズ制限に引っかかっている（プログラムが非常に大きい場合）
- 他のアプリがクリップボードを上書きした

**対処**：
1. プログラムを分割して複数の `.asset` に分ける
2. 小さなテストプログラムで動作確認する
3. エクスポート後、**すぐに**テキストエディタに貼り付ける（他のコピー操作を挟まない）

**参考**：
- [UdonAssembly のエクスポート](/guides/export-assembly)

---

### ❌ エクスポートした UdonAssembly が実行時にエラーになる

**原因**：
- エクスポート時に何らかの問題が発生した
- テキストエディタで余計な改行や文字が入った

**対処**：
1. エクスポート操作を再度実行して、最新の状態を取得
2. テキストエディタで余計な改行や文字が入っていないか確認
3. BOM なしの UTF-8 で保存しているか確認
4. [デバッグ / 解析](/debug/dump) で UdonProgram の構造を確認

---

## セットアップチェックリスト

問題が起きたら、以下を順番に確認してください。

### インストール

- [ ] **Sardinject が導入されている**（VCC 経由）
- [ ] **UdonEmu が導入されている**（unitypackage）
- [ ] `Packages/com.hoshinolabs.udonemu` フォルダが存在する
- [ ] Unity メニューに「HoshinoLabs」が表示される

### コンポーネントの設定

- [ ] **`UdonEmu` コンポーネント**が GameObject にアタッチされている
- [ ] **スクリプトコンポーネント**が同じ GameObject にアタッチされている
- [ ] Inspector で **`vm` フィールド**が設定されている
- [ ] `typeResolver` と `programDescriptor` に **`[SerializeField]` 属性**が付いている

### UdonAssembly

- [ ] **`.data_start` 〜 `.data_end`** が正しく記述されている
- [ ] **`.code_start` 〜 `.code_end`** が正しく記述されている
- [ ] **`.export`** でエントリポイントが宣言されている
- [ ] 命令のカンマ（`,`）が正しく入っている

### 実行フロー

- [ ] **`TryAssembleProgram`** が成功している（エラーログ確認）
- [ ] **`TryAssembleVariableTable`** が成功している（エラーログ確認）
- [ ] **`AssignProgramAndVariables`** を呼んでいる
- [ ] **`InitializeUdonContent()`** を呼んでいる
- [ ] **`RunProgram()`** のイベント名が `.export` と一致している

---

## その他の問題

### Unity エディタが重い / クラッシュする

**原因**：
- 非常に大きなプログラムを実行している
- 無限ループが発生している

**対処**：
1. 小さなテストプログラムで動作確認
2. Profiler でパフォーマンスを確認
3. 無限ループが発生していないか確認（JUMP 命令の飛び先）

---

## 関連ページ

- [クイックスタート](/quickstart) - 最小の動作例
- [実行フローの理解](/guides/execution-flow) - 4ステップの詳細
- [変数の読み書き](/guides/variables) - データの扱い方
- [FAQ](/faq) - よくある質問
