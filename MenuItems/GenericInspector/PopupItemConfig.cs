using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using DTDebugMenu.Internal;

namespace DTDebugMenu {
	public class PopupItemConfig {
		public string DisplayName { get; private set; }
		public Action Callback { get; private set; }

		public PopupItemConfig(string displayName, Action callback) {
			DisplayName = displayName;
			Callback = callback;
		}
	}
}