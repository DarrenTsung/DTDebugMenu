using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

namespace DTDebugMenu.Internal {
	public class StringInputFieldInspectorController : IInputFieldInspectorController {
		// PRAGMA MARK - IInputFieldInspectorController Implementation
		string IInputFieldInspectorController.GetPlaceholderText() {
			return "";
		}

		char IInputFieldInspectorController.ValidateInput(string input, int charIndex, char addedChar) {
			// no validation
			return addedChar;
		}

		void IInputFieldInspectorController.HandleInputChanged(string input) {
			field_.Setter.Invoke(input);
		}

		string IInputFieldInspectorController.GetCurrentValue() {
			return field_.Getter.Invoke();
		}


		// PRAGMA MARK - Public Interface
		public StringInputFieldInspectorController(IGenericInspectorField field) {
			field_ = field as IGenericInspectorField<string>;
		}


		// PRAGMA MARK - Internal
		private IGenericInspectorField<string> field_;
	}
}