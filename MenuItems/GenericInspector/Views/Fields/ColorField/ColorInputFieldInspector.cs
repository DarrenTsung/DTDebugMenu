using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DTDebugMenu.Internal {
	public class ColorInputFieldInspector : InputFieldInspector<Color> {
		// PRAGMA MARK - Internal
		protected override void HandleInputChanged(string input) {
			if (!ColorUtil.IsStringValidHexColor(input)) {
				return;
			}

			Field_.Setter.Invoke(ColorUtil.HexStringToColor(input));
		}

		protected override string GetCurrentValue() {
			return Field_.Getter.Invoke().ToHexString();
		}
	}
}