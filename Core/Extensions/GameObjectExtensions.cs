using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DTDebugMenu.Internal {
	public static class GameObjectExtensions {
		public static void ToggleActive(this GameObject g) {
			g.SetActive(!g.activeSelf);
		}
	}
}
