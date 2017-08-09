using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DTDebugMenu.Internal {
	public class InputFieldInspector : FieldInspector {
		// PRAGMA MARK - Public Interface
		public void Init(IInputFieldInspectorController controller) {
			controller_ = controller;
		}


		// PRAGMA MARK - Internal
		[Header("InputFieldInspector Outlets")]
		[SerializeField]
		private InputField inputField_;

		private IInputFieldInspectorController controller_;

		protected override void InternalInit() {
			inputField_.text = controller_.GetCurrentValue();
			inputField_.onValueChanged.AddListener(HandleValueChanged);
			inputField_.onValidateInput += ValidateInput;
		}

		private void HandleValueChanged(string inputValue) {
			controller_.HandleInputChanged(inputValue);
		}

		private char ValidateInput(string input, int charIndex, char addedChar) {
			return controller_.ValidateInput(input, charIndex, addedChar);
		}
	}
}