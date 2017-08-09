using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

namespace DTDebugMenu.Internal {
	public class ColorInputFieldInspectorController : IInputFieldInspectorController {
		// PRAGMA MARK - IInputFieldInspectorController Implementation
		string IInputFieldInspectorController.GetPlaceholderText() {
			return "#D8D8D8";
		}

		char IInputFieldInspectorController.ValidateInput(string input, int charIndex, char addedChar) {
			if (!charRegex_.IsMatch(addedChar.ToString())) {
				return '\0';
			}

			return addedChar;
		}

		void IInputFieldInspectorController.HandleInputChanged(string input) {
			if (!ColorUtil.IsStringValidHexColor(input)) {
				return;
			}

			field_.Setter.Invoke(ColorUtil.HexStringToColor(input));
		}

		string IInputFieldInspectorController.GetCurrentValue() {
			return field_.Getter.Invoke().ToHexString();
		}


		// PRAGMA MARK - Public Interface
		public ColorInputFieldInspectorController(IGenericInspectorField field) {
			field_ = field as IGenericInspectorField<Color>;
		}


		// PRAGMA MARK - Internal
		private IGenericInspectorField<Color> field_;
		private Regex charRegex_ = new Regex("[0-9a-fA-F]");
	}
}