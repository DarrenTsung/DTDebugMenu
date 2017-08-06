using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DTDebugMenu.Internal {
	public interface IInputFieldInspectorController {
		// PRAGMA MARK - Internal
		void HandleInputChanged(string input);
		string GetCurrentValue();
	}
}