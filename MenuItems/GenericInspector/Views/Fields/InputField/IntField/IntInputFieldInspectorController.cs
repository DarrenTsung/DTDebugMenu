using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

namespace DTDebugMenu.Internal {
	public class IntInputFieldInspectorController : IInputFieldInspectorController {
		// PRAGMA MARK - IInputFieldInspectorController Implementation
		string IInputFieldInspectorController.GetPlaceholderText() {
			return "101";
		}

		char IInputFieldInspectorController.ValidateInput(string input, int charIndex, char addedChar) {
			if (addedChar == '-') {
				if (charIndex != 0) {
					return '\0';
				}
			} else if (!intRegex_.IsMatch(addedChar.ToString())) {
				return '\0';
			}

			return addedChar;
		}

		void IInputFieldInspectorController.HandleInputChanged(string input) {
			// keep last input if invalid input
			if (string.IsNullOrEmpty(input) || (input.Length == 1 && input[0] == '-')) {
				return;
			}

			field_.Setter.Invoke(Convert.ToInt32(input));
		}

		string IInputFieldInspectorController.GetCurrentValue() {
			return field_.Getter.Invoke().ToString();
		}


		// PRAGMA MARK - Public Interface
		public IntInputFieldInspectorController(IGenericInspectorField field) {
			field_ = field as IGenericInspectorField<int>;
		}


		// PRAGMA MARK - Internal
		private IGenericInspectorField<int> field_;
		private Regex intRegex_ = new Regex("[0-9]");
	}
}