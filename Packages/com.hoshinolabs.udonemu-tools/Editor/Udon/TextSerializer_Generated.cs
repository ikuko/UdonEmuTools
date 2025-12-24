using VRC.SDK3.Data;

namespace HoshinoLabs.UdonEmuTools.Udon {
	public static class TextSerializer {
		public static string Serialize(global::System.Boolean v) {
			return v.ToString();
		}

		public static string Serialize(global::System.Byte v) {
			return $"0x{v:X8}";
		}

		public static string Serialize(global::System.Char v) {
			return v.ToString();
		}

		public static string Serialize(global::System.DateTime v) {
			return v.ToString();
		}

		public static string Serialize(global::System.DateTimeOffset v) {
			return v.ToString();
		}

		public static string Serialize(global::System.Decimal v) {
			return v.ToString();
		}

		public static string Serialize(global::System.Double v) {
			return v.ToString();
		}

		public static string Serialize(global::System.Guid v) {
			return v.ToString();
		}

		public static string Serialize(global::System.Int16 v) {
			return v.ToString();
		}

		public static string Serialize(global::System.Int32 v) {
			return v.ToString();
		}

		public static string Serialize(global::System.Int64 v) {
			return v.ToString();
		}

		public static string Serialize(global::System.SByte v) {
			return v.ToString();
		}

		public static string Serialize(global::System.Single v) {
			return v.ToString();
		}

		public static string Serialize(global::System.String v) {
			return v;
		}

		public static string Serialize(global::System.Text.RegularExpressions.RegexOptions v) {
			return v.ToString();
		}

		public static string Serialize(global::System.TimeSpan v) {
			return v.ToString();
		}

		public static string Serialize(global::System.UInt16 v) {
			return $"0x{v:X8}";
		}

		public static string Serialize(global::System.UInt32 v) {
			return $"0x{v:X8}";
		}

		public static string Serialize(global::System.UInt64 v) {
			return $"0x{v:X8}";
		}

		public static string Serialize(global::TMPro.HorizontalAlignmentOptions v) {
			return v.ToString();
		}

		public static string Serialize(global::TMPro.TextAlignmentOptions v) {
			return v.ToString();
		}

		public static string Serialize(global::TMPro.TextOverflowModes v) {
			return v.ToString();
		}

		public static string Serialize(global::TMPro.TextRenderFlags v) {
			return v.ToString();
		}

		public static string Serialize(global::TMPro.VertexSortingOrder v) {
			return v.ToString();
		}

		public static string Serialize(global::TMPro.VerticalAlignmentOptions v) {
			return v.ToString();
		}

		public static string Serialize(global::Unity.AI.Navigation.CollectObjects v) {
			return v.ToString();
		}

		public static string Serialize(global::UnityEngine.AI.NavMeshCollectGeometry v) {
			return v.ToString();
		}

		public static string Serialize(global::UnityEngine.Bounds v) {
			var d = new DataDictionary();
			var d0 = new DataDictionary();
			var center = v.center;
			d0["x"] = center.x;
			d0["y"] = center.y;
			d0["z"] = center.z;
			d["center"] = d0;
			var d1 = new DataDictionary();
			var extents = v.extents;
			d0["x"] = extents.x;
			d0["y"] = extents.y;
			d0["z"] = extents.z;
			d["extents"] = d1;
			if (!VRCJson.TrySerializeToJson(d, JsonExportType.Minify, out var result)) {
				return null;
			}
			return result.String;
		}

		public static string Serialize(global::UnityEngine.Color32 v) {
			var d = new DataDictionary();
			d["r"] = v.r;
			d["g"] = v.g;
			d["b"] = v.b;
			d["a"] = v.a;
			if (!VRCJson.TrySerializeToJson(d, JsonExportType.Minify, out var result)) {
				return null;
			}
			return result.String;
		}

		public static string Serialize(global::UnityEngine.Color v) {
			var d = new DataDictionary();
			d["r"] = v.r;
			d["g"] = v.g;
			d["b"] = v.b;
			d["a"] = v.a;
			if (!VRCJson.TrySerializeToJson(d, JsonExportType.Minify, out var result)) {
				return null;
			}
			return result.String;
		}

		public static string Serialize(global::UnityEngine.CubemapFace v) {
			return v.ToString();
		}

		public static string Serialize(global::UnityEngine.Matrix4x4 v) {
			var d = new DataDictionary();
			d["m00"] = v.m00;
			d["m10"] = v.m10;
			d["m20"] = v.m20;
			d["m30"] = v.m30;
			d["m01"] = v.m01;
			d["m11"] = v.m11;
			d["m21"] = v.m21;
			d["m31"] = v.m31;
			d["m02"] = v.m02;
			d["m12"] = v.m12;
			d["m22"] = v.m22;
			d["m32"] = v.m32;
			d["m03"] = v.m03;
			d["m13"] = v.m13;
			d["m23"] = v.m23;
			d["m33"] = v.m33;
			if (!VRCJson.TrySerializeToJson(d, JsonExportType.Minify, out var result)) {
				return null;
			}
			return result.String;
		}

		public static string Serialize(global::UnityEngine.Plane v) {
			var d = new DataDictionary();
			var d0 = new DataDictionary();
			var normal = v.normal;
			d0["x"] = normal.x;
			d0["y"] = normal.y;
			d0["z"] = normal.z;
			d["normal"] = d0;
			d["distance"] = v.distance;
			if (!VRCJson.TrySerializeToJson(d, JsonExportType.Minify, out var result)) {
				return null;
			}
			return result.String;
		}

		public static string Serialize(global::UnityEngine.Quaternion v) {
			var d = new DataDictionary();
			d["x"] = v.x;
			d["y"] = v.y;
			d["z"] = v.z;
			d["w"] = v.w;
			if (!VRCJson.TrySerializeToJson(d, JsonExportType.Minify, out var result)) {
				return null;
			}
			return result.String;
		}

		public static string Serialize(global::UnityEngine.Ray v) {
			var d = new DataDictionary();
			var d0 = new DataDictionary();
			var origin = v.origin;
			d0["x"] = origin.x;
			d0["y"] = origin.y;
			d0["z"] = origin.z;
			d["origin"] = d0;
			var d1 = new DataDictionary();
			var direction = v.direction;
			d0["x"] = direction.x;
			d0["y"] = direction.y;
			d0["z"] = direction.z;
			d["direction"] = d1;
			if (!VRCJson.TrySerializeToJson(d, JsonExportType.Minify, out var result)) {
				return null;
			}
			return result.String;
		}

		public static string Serialize(global::UnityEngine.Rect v) {
			var d = new DataDictionary();
			d["x"] = v.x;
			d["y"] = v.y;
			d["width"] = v.width;
			d["height"] = v.height;
			if (!VRCJson.TrySerializeToJson(d, JsonExportType.Minify, out var result)) {
				return null;
			}
			return result.String;
		}

		public static string Serialize(global::UnityEngine.SpritePackingMode v) {
			return v.ToString();
		}

		public static string Serialize(global::UnityEngine.SpritePackingRotation v) {
			return v.ToString();
		}

		public static string Serialize(global::UnityEngine.Vector2Int v) {
			var d = new DataDictionary();
			d["x"] = v.x;
			d["y"] = v.y;
			if (!VRCJson.TrySerializeToJson(d, JsonExportType.Minify, out var result)) {
				return null;
			}
			return result.String;
		}

		public static string Serialize(global::UnityEngine.Vector2 v) {
			var d = new DataDictionary();
			d["x"] = v.x;
			d["y"] = v.y;
			if (!VRCJson.TrySerializeToJson(d, JsonExportType.Minify, out var result)) {
				return null;
			}
			return result.String;
		}

		public static string Serialize(global::UnityEngine.Vector3Int v) {
			var d = new DataDictionary();
			d["x"] = v.x;
			d["y"] = v.y;
			if (!VRCJson.TrySerializeToJson(d, JsonExportType.Minify, out var result)) {
				return null;
			}
			return result.String;
		}

		public static string Serialize(global::UnityEngine.Vector3 v) {
			var d = new DataDictionary();
			d["x"] = v.x;
			d["y"] = v.y;
			d["z"] = v.z;
			if (!VRCJson.TrySerializeToJson(d, JsonExportType.Minify, out var result)) {
				return null;
			}
			return result.String;
		}

		public static string Serialize(global::UnityEngine.Vector4 v) {
			var d = new DataDictionary();
			d["x"] = v.x;
			d["y"] = v.y;
			d["z"] = v.z;
			d["w"] = v.w;
			if (!VRCJson.TrySerializeToJson(d, JsonExportType.Minify, out var result)) {
				return null;
			}
			return result.String;
		}

		public static string Serialize(global::VRC.Udon.Common.HandType v) {
			return v.ToString();
		}

		public static string Serialize(global::VRC.Udon.Common.UdonInputEventType v) {
			return v.ToString();
		}

		public static string Serialize(global::VRC.SDK3.Components.MirrorClearFlags v) {
			return v.ToString();
		}

		public static string Serialize(global::VRC.SDK3.Components.Video.VideoError v) {
			return v.ToString();
		}

		public static string Serialize(global::VRC.SDK3.Data.DataError v) {
			return v.ToString();
		}

		public static string Serialize(global::VRC.SDK3.Data.JsonExportType v) {
			return v.ToString();
		}

		public static string Serialize(global::VRC.SDK3.Data.TokenType v) {
			return v.ToString();
		}

		public static string Serialize(global::VRC.SDK3.Image.VRCImageDownloadError v) {
			return v.ToString();
		}

		public static string Serialize(global::VRC.SDK3.Image.VRCImageDownloadState v) {
			return v.ToString();
		}

		public static string Serialize(global::VRC.SDKBase.VRCInputMethod v) {
			return v.ToString();
		}

		public static string Serialize(object v) {
			switch (v.GetType().FullName) {
				case "System.Boolean": {
						return Serialize((global::System.Boolean)v);
					}
				case "System.Byte": {
						return Serialize((global::System.Byte)v);
					}
				case "System.Char": {
						return Serialize((global::System.Char)v);
					}
				case "System.DateTime": {
						return Serialize((global::System.DateTime)v);
					}
				case "System.DateTimeOffset": {
						return Serialize((global::System.DateTimeOffset)v);
					}
				case "System.Decimal": {
						return Serialize((global::System.Decimal)v);
					}
				case "System.Double": {
						return Serialize((global::System.Double)v);
					}
				case "System.Guid": {
						return Serialize((global::System.Guid)v);
					}
				case "System.Int16": {
						return Serialize((global::System.Int16)v);
					}
				case "System.Int32": {
						return Serialize((global::System.Int32)v);
					}
				case "System.Int64": {
						return Serialize((global::System.Int64)v);
					}
				case "System.SByte": {
						return Serialize((global::System.SByte)v);
					}
				case "System.Single": {
						return Serialize((global::System.Single)v);
					}
				case "System.String": {
						return Serialize((global::System.String)v);
					}
				case "System.Text.RegularExpressions.RegexOptions": {
						return Serialize((global::System.Text.RegularExpressions.RegexOptions)v);
					}
				case "System.TimeSpan": {
						return Serialize((global::System.TimeSpan)v);
					}
				case "System.UInt16": {
						return Serialize((global::System.UInt16)v);
					}
				case "System.UInt32": {
						return Serialize((global::System.UInt32)v);
					}
				case "System.UInt64": {
						return Serialize((global::System.UInt64)v);
					}
				case "TMPro.HorizontalAlignmentOptions": {
						return Serialize((global::TMPro.HorizontalAlignmentOptions)v);
					}
				case "TMPro.TextAlignmentOptions": {
						return Serialize((global::TMPro.TextAlignmentOptions)v);
					}
				case "TMPro.TextOverflowModes": {
						return Serialize((global::TMPro.TextOverflowModes)v);
					}
				case "TMPro.TextRenderFlags": {
						return Serialize((global::TMPro.TextRenderFlags)v);
					}
				case "TMPro.VertexSortingOrder": {
						return Serialize((global::TMPro.VertexSortingOrder)v);
					}
				case "TMPro.VerticalAlignmentOptions": {
						return Serialize((global::TMPro.VerticalAlignmentOptions)v);
					}
				case "Unity.AI.Navigation.CollectObjects": {
						return Serialize((global::Unity.AI.Navigation.CollectObjects)v);
					}
				case "UnityEngine.AI.NavMeshCollectGeometry": {
						return Serialize((global::UnityEngine.AI.NavMeshCollectGeometry)v);
					}
				case "UnityEngine.Bounds": {
						return Serialize((global::UnityEngine.Bounds)v);
					}
				case "UnityEngine.Color32": {
						return Serialize((global::UnityEngine.Color32)v);
					}
				case "UnityEngine.Color": {
						return Serialize((global::UnityEngine.Color)v);
					}
				case "UnityEngine.CubemapFace": {
						return Serialize((global::UnityEngine.CubemapFace)v);
					}
				case "UnityEngine.Matrix4x4": {
						return Serialize((global::UnityEngine.Matrix4x4)v);
					}
				case "UnityEngine.Plane": {
						return Serialize((global::UnityEngine.Plane)v);
					}
				case "UnityEngine.Quaternion": {
						return Serialize((global::UnityEngine.Quaternion)v);
					}
				case "UnityEngine.Ray": {
						return Serialize((global::UnityEngine.Ray)v);
					}
				case "UnityEngine.Rect": {
						return Serialize((global::UnityEngine.Rect)v);
					}
				case "UnityEngine.SpritePackingMode": {
						return Serialize((global::UnityEngine.SpritePackingMode)v);
					}
				case "UnityEngine.SpritePackingRotation": {
						return Serialize((global::UnityEngine.SpritePackingRotation)v);
					}
				case "UnityEngine.Vector2Int": {
						return Serialize((global::UnityEngine.Vector2Int)v);
					}
				case "UnityEngine.Vector2": {
						return Serialize((global::UnityEngine.Vector2)v);
					}
				case "UnityEngine.Vector3Int": {
						return Serialize((global::UnityEngine.Vector3Int)v);
					}
				case "UnityEngine.Vector3": {
						return Serialize((global::UnityEngine.Vector3)v);
					}
				case "UnityEngine.Vector4": {
						return Serialize((global::UnityEngine.Vector4)v);
					}
				case "VRC.Udon.Common.HandType": {
						return Serialize((global::VRC.Udon.Common.HandType)v);
					}
				case "VRC.Udon.Common.UdonInputEventType": {
						return Serialize((global::VRC.Udon.Common.UdonInputEventType)v);
					}
				case "VRC.SDK3.Components.MirrorClearFlags": {
						return Serialize((global::VRC.SDK3.Components.MirrorClearFlags)v);
					}
				case "VRC.SDK3.Components.Video.VideoError": {
						return Serialize((global::VRC.SDK3.Components.Video.VideoError)v);
					}
				case "VRC.SDK3.Data.DataError": {
						return Serialize((global::VRC.SDK3.Data.DataError)v);
					}
				case "VRC.SDK3.Data.JsonExportType": {
						return Serialize((global::VRC.SDK3.Data.JsonExportType)v);
					}
				case "VRC.SDK3.Data.TokenType": {
						return Serialize((global::VRC.SDK3.Data.TokenType)v);
					}
				case "VRC.SDK3.Image.VRCImageDownloadError": {
						return Serialize((global::VRC.SDK3.Image.VRCImageDownloadError)v);
					}
				case "VRC.SDK3.Image.VRCImageDownloadState": {
						return Serialize((global::VRC.SDK3.Image.VRCImageDownloadState)v);
					}
				case "VRC.SDKBase.VRCInputMethod": {
						return Serialize((global::VRC.SDKBase.VRCInputMethod)v);
					}
			}
			return null;
		}
	}
}
