using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine;

namespace DTDebugMenu.Internal {
	public static class ColorUtil {
		public static bool IsStringValidHexColor(string hexInput) {
			hexInput = SanitizeHexInput(hexInput);

			if (hexInput.Length != 6 && hexInput.Length != 8) {
				return false;
			}

			return kHexRegex.IsMatch(hexInput);
		}

		public static Color HexStringToColor(string hexInput) {
			hexInput = SanitizeHexInput(hexInput);

			byte a = 255;                        // assume fully visible unless specified in hexInput
			byte r = byte.Parse(hexInput.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
			byte g = byte.Parse(hexInput.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
			byte b = byte.Parse(hexInput.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
			// Only use alpha if the string has enough characters
			if (hexInput.Length == 8) {
				a = byte.Parse(hexInput.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
			}

			return new Color32(r, g, b, a);
		}


		// PRAGMA MARK - Internal
		private static readonly Regex kHexRegex = new Regex(@"\A\b[0-9a-fA-F]+\b\Z");

		private static string SanitizeHexInput(string hexInput) {
			hexInput = hexInput.Replace("0x", "");        // in case the string is formatted 0xFFFFFF
			hexInput = hexInput.Replace("#", "");         // in case the string is formatted #FFFFFF
			return hexInput;
		}
	}
}
