using System.Collections;
using UnityEngine;

namespace DTDebugMenu.Internal {
	public static class RichTextUtil {
		public static string WrapWithColorTag(string text, Color color) {
			string hexString = color.ToHexString();
			return string.Format("<color={0}>{1}</color>", hexString, text);
		}
	}
}