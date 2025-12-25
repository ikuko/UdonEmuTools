---
title: インストール
---

# インストール

UdonEmu は **unitypackage** で導入します。

:::caution VCC 非対応
現時点では **VCC（VRChat Creator Companion）での導入には対応していません**。
:::

---

## 1. Sardinject を VCC で導入する

:::info 先に Sardinject を導入してください
UdonEmu は [Sardinject](https://github.com/ikuko/Sardinject) に依存しているため、**先に [Sardinject](https://github.com/ikuko/Sardinject) を導入する必要があります**。
:::

[Sardinject](https://github.com/ikuko/Sardinject) の導入手順は以下を参照してください：

**[Sardinject - インストール方法](https://ikuko.github.io/Sardinject/docs/tutorial-basics/installation)**

---

## 2. UdonEmu の unitypackage を入手する

BOOTH から `UdonEmu-<version>.unitypackage` をダウンロードしてください。

**👉 [BOOTH 商品ページ](https://hoshinolabs.booth.pm/items/7795035)**

- ファイル名にはバージョンが含まれるため固定ではありません（例: `UdonEmu-1.0.0.unitypackage`）
- BOOTH から最新版をダウンロードしてください

---

## 3. Unity に unitypackage をインポートする

### インポート手順

1. Unity で対象プロジェクトを開く
2. メニューから `Assets > Import Package > Custom Package...` を選択
3. ダウンロードした `UdonEmu-*.unitypackage` を選択
4. インポート一覧を確認して `Import` をクリック

---

## 4. 導入確認（任意）

この確認は**任意**です。インポート後に Console にエラーが出ていないなど、特に問題がなければ **スキップしてクイックスタートに進んでも構いません**。

以下のいずれかで導入を確認できます：

- ✅ Project ウィンドウに `Packages/com.hoshinolabs.udonemu` が存在する
- ✅ スクリプトから `HoshinoLabs.UdonEmu` 名前空間を参照できる

```csharp
using HoshinoLabs.UdonEmu.Udon;

// UdonEmu などが参照できれば導入成功
```

導入できたら [クイックスタート](/quickstart) に進んでください。

---

## 更新・削除

### 更新する場合

1. 新しい `UdonEmu-*.unitypackage` をダウンロード
2. 同様に `Import Package` で取り込む
3. 上書き確認が出た場合は更新意図に応じて選択

### 削除する場合

1. `Packages/` 配下の HoshinoLabs - UdonEmu フォルダを削除
2. 依存関係（Sardinject）も不要な場合は、Sardinject 側の手順に従って削除

---

## トラブルシューティング

### インポート後にエラーが出る

**Sardinject が導入されていない可能性があります**。

- 手順 1 に戻り、先に Sardinject を VCC で導入してください
- Sardinject が正しく導入されているか Package Manager で確認

### Packages に表示されない

- Unity エディタを再起動してください
- Project ウィンドウで `Packages/` が折りたたまれていないか確認
- インポート時にエラーが出ていなかったか Console を確認

### 依存関係のエラー

UdonEmu は以下の環境を前提としています：

- Unity 2020.2.22f1 以降
- VRChat SDK3 - Worlds 3.8.2 以降
- Sardinject（VCC で導入） 0.8.10 以降

これらがすべて揃っているか確認してください。
