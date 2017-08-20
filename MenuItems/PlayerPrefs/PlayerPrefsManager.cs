using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

using DTDebugMenu.Internal;

namespace DTDebugMenu.DefaultMenuItems {
	// NOTE (darren): this only works and is tested on mac
	public static class PlayerPrefsManager {
		// PRAGMA MARK - Static Public Interface
		public static string[] GetPlistPaths() {
			#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
			return Directory.GetFiles(kHomePreferencesPath, string.Format("unity.{0}.*.plist", Application.companyName), SearchOption.TopDirectoryOnly);
			#else
			return null;
			#endif
		}

		public static string GetDataForPlistPath(string plistPath) {
			if (string.IsNullOrEmpty(plistPath)) {
				return null;
			}

			return File.ReadAllText(plistPath);
		}


		// PRAGMA MARK - Static Internal
		private static readonly string kMacHomePath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
		private static readonly string kHomePreferencesPath = Path.Combine(kMacHomePath, "Library/Preferences");
	}
}