using System.Collections;
using UnityEngine;

namespace DTDebugMenu.Internal {
	public class MathUtil {
		public static byte ConvertToByte(float f) {
			f = Mathf.Clamp01(f);
			return (byte)(f * 255);
		}
	}
}