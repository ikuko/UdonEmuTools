---
title: 対応イベント
---

# 対応イベント（Unity Events / Udon Events）

このページでは、UdonEmu が対応しているイベントを一覧化しています。

参照：[UdonSharp Events Documentation](https://udonsharp.docs.vrchat.com/events#unity-events)

---

## Unity Events

Unity 標準のライフサイクル・物理イベントです。

| Unity / UdonSharp のイベント | 説明 |
|---|---|
| `Start` | 初回フレームの開始時 |
| `Update` | 毎フレーム呼ばれる |
| `LateUpdate` | Update の後に呼ばれる |
| `FixedUpdate` | 物理演算のタイミングで呼ばれる |
| `OnDestroy` | オブジェクト破棄時 |
| `OnDisable` | オブジェクト無効化時 |
| `OnEnable` | オブジェクト有効化時 |
| `OnCollisionEnter` | Collision 開始時 |
| `OnCollisionExit` | Collision 終了時 |
| `OnCollisionStay` | Collision 継続中 |
| `OnTriggerEnter` | Trigger 開始時 |
| `OnTriggerExit` | Trigger 終了時 |
| `OnTriggerStay` | Trigger 継続中 |
| `OnControllerColliderHit` | CharacterController の衝突時 |

---

## Udon Events

VRChat / Udon 固有のイベントです。

| VRChat / UdonSharp のイベント | 説明 |
|---|---|
| `PostLateUpdate` | LateUpdate の後に呼ばれる |
| `Interact` | プレイヤーがインタラクトした時 |
| `OnDrop` | Pickup オブジェクトをドロップした時 |
| `OnPickup` | Pickup オブジェクトを拾った時 |
| `OnPickupUseDown` | Pickup 使用ボタンを押した時 |
| `OnPickupUseUp` | Pickup 使用ボタンを離した時 |
| `OnPlayerJoined` | プレイヤーが参加した時 |
| `OnPlayerLeft` | プレイヤーが退出した時 |
| `OnPlayerTriggerEnter` | プレイヤーが Trigger に入った時 |
| `OnPlayerTriggerExit` | プレイヤーが Trigger から出た時 |
| `OnPlayerTriggerStay` | プレイヤーが Trigger 内にいる間 |
| `OnPlayerCollisionEnter` | プレイヤーとの Collision 開始時 |
| `OnPlayerCollisionExit` | プレイヤーとの Collision 終了時 |
| `OnPlayerCollisionStay` | プレイヤーとの Collision 継続中 |
| `OnControllerColliderHitPlayer` | CharacterController がプレイヤーと衝突した時 |

---

## 関連ドキュメント

- [実行フローの理解](/guides/execution-flow) - 初期化と実行の流れ
- [互換性と差異](/guides/compatibility) - VRChat 公式との違い
- [FAQ](/faq) - よくある質問
