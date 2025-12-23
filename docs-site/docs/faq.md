---
title: FAQ
---

# FAQ（よくある質問）

UdonEmu の使用中によくある質問と解決方法をまとめました。

## インストール / 導入

### Q. 依存関係のエラーが出る

**A.** UdonEmu は以下の環境を前提としています：

- Unity 2020.2.22f1 以降
- VRChat SDK3 - Worlds 3.8.2 以降
- Sardinject（VCC で導入） 0.8.10 以降

これらがインストールされているか確認してください。

## 実行 / 動作

### Q. イベントが実行されない

**A.** 以下を確認してください：

1. **イベント名が正しいか**
   - 大文字小文字を区別します

2. **初期化が完了しているか**
   - `InitializeUdonContent` などの初期化メソッドが呼ばれているか確認

3. **プログラムに該当のエントリポイントが存在するか**
   - `Dump()` を使ってプログラム構造を確認し、EntryPoints に該当のイベントが含まれているか確認

```csharp
var programJson = udonProgram.Dump();
Debug.Log(programJson);
// EntryPoints セクションを確認
```

### Q. 変数が取得できない / 設定できない

**A.** 以下を確認してください：

1. **変数名が正しいか**
   - 大文字小文字を区別します
   - スペースや特殊文字に注意

2. **変数が存在するか**
   - `Dump()` を使って VariableTable を確認

```csharp
var variablesJson = variables.Dump();
Debug.Log(variablesJson);
```

3. **型が一致しているか**
   - `TryGetUdonProgramVariable<T>` を使って型安全に取得

## 互換性 / 差異

### Q. 公式 VRChat と結果が違う

**A.** 以下の手順で原因を切り分けてください：

1. **プログラムを Dump**
   ```csharp
   var programJson = udonProgram.Dump();
   Debug.Log(programJson);
   ```

<!-- 2. **実行前後の変数を Dump**
   ```csharp
   var before = vm.GetUdonVariableTable().Dump();
   vm.RunProgram("_greet");
   var after = vm.GetUdonVariableTable().Dump();
   ``` -->

3. **最小再現コードを作成**
   - イベント1つのみ
   - 変数は最小限
   - 外部依存を排除

4. **GitHub Issues で報告**
   - UdonEmu のバージョン
   - Unity / VRChat SDK のバージョン
   - 最小再現コード
   - 期待される動作と実際の動作

詳細は [互換性と差異](/guides/compatibility) を参照してください。

### Q. 特定の Udon 機能が動作しない

**A.** UdonEmu は公式実装の模倣であり、以下の制約があります：

- VRChat 固有のネットワーク機能は完全には模倣できません
- 一部の VRChat API は Editor 環境では動作が異なります

動作しない機能を発見した場合は、GitHub Issues で報告してください。

---

## 実運用（動的差し替え）

### Q. 動的にコードを差し替えるのはセキュリティ上問題ないか？

**A.** **任意コード実行のリスクがあります**。  
以下のような対策を検討してください：

#### 必須対策

1. **URL ホワイトリスト**
   ```csharp
   var allowedDomains = { "example.com", "cdn.example.com" };
   if (!IsAllowedDomain(url, allowedDomains)) {
       Debug.LogError("Domain not whitelisted");
       return;
   }
   ```

2. **サイズ制限**
   ```csharp
   var MAX_SIZE = 1024 * 1024; // 1MB
   if (assemblyText.Length > MAX_SIZE) {
       Debug.LogError("Assembly too large");
       return;
   }
   ```

3. **署名検証（推奨）**
   - サーバー側で UdonAssembly に署名を付与
   - クライアント側で検証してから実行

---

### Q. 頻繁に差し替えるとパフォーマンスに影響するか？

**A.** **はい、影響します**。  
UdonAssembly のパース・VM 初期化にはコストがかかります。

#### 推奨事項

- ⛔ **フレームごとの差し替えは避ける**
- ✅ **起動時 or イベント駆動に留める**
- ✅ **キャッシュを活用する**

---

### Q. VRChat の利用規約・ガイドラインに抵触しないか？

**A.** **VRChat 公式の見解を確認してください**。

#### 現状（2025年12月時点）

- VRChat の公式ドキュメントでは、動的コード実行に関する明確な制限は示されていません
- ただし、**今後制限される可能性があります**

#### 推奨事項

1. **VRChat 公式のアナウンスを定期的に確認**
2. **悪用されるような使い方を避ける**（セキュリティ対策必須）

:::warning 規約違反のリスク
VRChat の利用規約は変更される可能性があります。  
動的コード実行が将来的に制限されるリスクを理解した上で使用してください。
:::

---

### Q. UdonSharp で書いたコードを動的に差し替えられるか？

**A.** **UdonSharp は UdonAssembly にコンパイルされる**ため、最終的な Assembly を差し替える形であれば可能です。

#### フロー

1. UdonSharp で C# コードを書く
2. Unity でコンパイル → UdonAssembly 生成
3. 生成された UdonAssembly をテキストでエクスポート
4. Web サーバーにアップロード
5. UdonEmu で取得 → 実行

:::info 注意
UdonSharp の **C# コードを直接実行時に差し替えることはできません**。  
必ず UdonAssembly にコンパイルしてから配信してください。
:::

---

## デバッグ / 解析

<!-- ### Q. デバッグログをもっと詳しく見たい

**A.** `Dump()` 機能を活用してください：

```csharp
using HoshinoLabs.UdonEmu.Udon;

// プログラム構造
var programJson = udonProgram.Dump();
Debug.Log(programJson);

// 変数の状態
var variablesJson = vm.GetUdonVariableTable().Dump();
Debug.Log(variablesJson);
```

出力された JSON を差分ツールで比較することで、問題を特定できます。

詳細は [Dump](/debug/dump) を参照してください。 -->

### Q. OpCode レベルでデバッグしたい

**A.** プログラムを Dump すると、OpCode の列が確認できます：

```csharp
var programJson = udonProgram.Dump();
Debug.Log(programJson);
```

JSON の `instructions` セクションに OpCode と引数が含まれています。

詳細は [OpCode](/debug/opcode) を参照してください。

## その他

### Q. 商用利用は可能？

**A.** ライセンスに従う限り可能です。

## さらにサポートが必要な場合

- [X: @magi_ikuko](https://twitter.com/magi_ikuko)
