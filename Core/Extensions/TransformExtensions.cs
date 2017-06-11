using System.Collections;
using UnityEngine;

namespace DTDebugMenu.Internal {
	public static class TransformExtensions {
		public static void DestroyAllChildren(this Transform transform, bool immediate = false) {
			GameObject[] children = new GameObject[transform.childCount];

			int index = 0;
			foreach (Transform child in transform) {
				children[index++] = child.gameObject;
			}

			for (int i = children.Length - 1; i >= 0; i--) {
				if (immediate) {
					GameObject.DestroyImmediate(children[i]);
				} else {
					GameObject.Destroy(children[i]);
				}
			}
		}
	}
}
