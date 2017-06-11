using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using DTDebugMenu.Internal;

namespace DTDebugMenu.DefaultMenuItems {
	public class DebugConsoleLogView : MonoBehaviour {
		// PRAGMA MARK - Internal
		[Header("Outlets")]
		[SerializeField]
		private Text logOutlet_;

		private void OnEnable() {
			RefreshLogText();
			DebugConsoleLog.OnLogUpdated += RefreshLogText;
		}

		private void OnDisable() {
			DebugConsoleLog.OnLogUpdated -= RefreshLogText;
		}

		private void RefreshLogText() {
			logOutlet_.text = DebugConsoleLog.GetLogTextToDisplay();
		}
	}
}