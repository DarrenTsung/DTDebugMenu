using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DTDebugMenu.Internal {
	public class InputFieldInspector : FieldInspector {
		public void Init(IInputFieldInspectorController controller) {
			controller_ = controller;
		}


		// PRAGMA MARK - Internal
		[Header("InputFieldInspector Outlets")]
		[SerializeField]
		private InputField inputField_;

		private IInputFieldInspectorController controller_;

		protected override void InternalInit() {
			inputField_.onValueChanged.AddListener(HandleValueChanged);
			inputField_.text = controller_.GetCurrentValue();
		}

		private void HandleValueChanged(string inputValue) {
			controller_.HandleInputChanged(inputValue);
		}
	}
}