---
title: シリアライズできる型
---

# シリアライズできる型

UdonEmuTools の UdonAssembly エクスポートでは、ヒープ上の値を **文字列にシリアライズ**して出力します。  
このとき対応していない型は **`null`** になり、実行時に外部から値を設定するなどの対応が必要です。

---

## 対応している型一覧

### System（プリミティブ/標準型）

- `System.Boolean`
- `System.Byte`
- `System.Char`
- `System.DateTime`
- `System.DateTimeOffset`
- `System.Decimal`
- `System.Double`
- `System.Guid`
- `System.Int16`
- `System.Int32`
- `System.Int64`
- `System.SByte`
- `System.Single`
- `System.String`
- `System.TimeSpan`
- `System.UInt16`
- `System.UInt32`
- `System.UInt64`

#### System（その他）
- `System.Text.RegularExpressions.RegexOptions`

---

### TMPro

- `TMPro.HorizontalAlignmentOptions`
- `TMPro.TextAlignmentOptions`
- `TMPro.TextOverflowModes`
- `TMPro.TextRenderFlags`
- `TMPro.VertexSortingOrder`
- `TMPro.VerticalAlignmentOptions`

---

### Unity

- `Unity.AI.Navigation.CollectObjects`
- `UnityEngine.AI.NavMeshCollectGeometry`
- `UnityEngine.CubemapFace`
- `UnityEngine.SpritePackingMode`
- `UnityEngine.SpritePackingRotation`

---

### VRC

- `VRC.Udon.Common.HandType`
- `VRC.Udon.Common.UdonInputEventType`
- `VRC.SDK3.Components.MirrorClearFlags`
- `VRC.SDK3.Components.Video.VideoError`
- `VRC.SDK3.Data.DataError`
- `VRC.SDK3.Data.JsonExportType`
- `VRC.SDK3.Data.TokenType`
- `VRC.SDK3.Image.VRCImageDownloadError`
- `VRC.SDK3.Image.VRCImageDownloadState`
- `VRC.SDKBase.VRCInputMethod`

---

## 関連ドキュメント

- [UdonAssembly のエクスポート](./export-assembly)
