using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

using DTDebugMenu.Internal;

namespace DTDebugMenu.DefaultMenuItems {
	public static class PlayerPrefsInspector {
		// PRAGMA MARK - Static Public Interface
		[RuntimeInitializeOnLoadMethod]
		private static void Initialize() {
			RefreshPlayerPrefsInspector();
		}

		private static void RefreshPlayerPrefsInspector() {
			var inspector = GenericInspectorRegistry.Get("Player Prefs");
			inspector.ResetFields();

			inspector.RegisterLabel("NOTE: This displays raw-text for the plist files, does not update during game.");
			string[] plistPaths = PlayerPrefsManager.GetPlistPaths();
			if (plistPaths == null) {
				inspector.RegisterLabel("No Player Prefs Found!");
			} else {
				foreach (string plistPath in plistPaths) {
					inspector.RegisterHeader(Path.GetFileName(plistPath));
					inspector.RegisterLabel(PlayerPrefsManager.GetDataForPlistPath(plistPath));
				}
			}

			inspector.RegisterButton("Clear Player Prefs", () => {
				PlayerPrefs.DeleteAll();
				RefreshPlayerPrefsInspector();
			});
		}
	}
}