---
title: UdonEmu Tools のインストール
---

# UdonEmu Tools のインストール

**UdonAssembly のエクスポート機能**を利用するには、**UdonEmu Tools** をプロジェクトにインストールする必要があります。

:::info UdonEmu との違い
- **UdonEmu**: エミュレーター本体（BOOTH で販売）
- **UdonEmu Tools**: エクスポート等の開発者向けツール（無料、VCC でインストール可能）

エクスポート機能には **UdonEmu Tools** が必要です。
:::

---

## 前提条件

Unity 2022.3+ が必要です

---

## VCC を利用したインストール

### 1. VPM リポジトリを追加する

次のリンクをクリックして VCC へインストールします。

**[VCC へ追加](vcc://vpm/addRepo?url=https://vpm.hoshinolabs.com/vpm.json)**

または、次の手順で手動追加できます：

1. VCC を開く
2. `Settings` タブを開く
3. `Add Repository` をクリック
4. 以下の URL を入力:
   ```
   https://vpm.hoshinolabs.com/vpm.json
   ```

### 2. プロジェクトに追加する

1. VCC で `Manage Project` を押す
2. `HoshinoLabs - UdonEmu Tools` の横の `+` ボタンを押す

---

## Install commandline (using VPM CLI)

```bash
vpm add repo https://vpm.hoshinolabs.com/vpm.json
cd /your-unity-project
vpm add com.hoshinolabs.udonemu-tools
```

---

## Install manually (using .unitypackage)

1. Download the .unitypackage from [releases](https://github.com/ikuko/UdonEmuTools/releases) page.
2. Open .unitypackage

---

## Install manually (UPM)

以下を UPM でインストールします。

```
https://github.com/ikuko/UdonEmuTools.git?path=Packages/com.hoshinolabs.udonemu-tools
```

UdonEmu Tools はリリースタグを使用するので以下のようにバージョンを指定できます。

```
https://github.com/ikuko/UdonEmuTools.git?path=Packages/com.hoshinolabs.udonemu-tools#1.0.0
```

---

## インストール確認

インストール後、以下を確認してください：

1. Unity エディタを開く
2. Unity のメニューバーに `Tools > HoshinoLabs > UdonEmu` が表示される
3. Package Manager に `HoshinoLabs - UdonEmu Tools` が表示される

---

## 次のステップ

インストールが完了したら、[UdonAssembly のエクスポート](/guides/export-assembly)に進んでください。
