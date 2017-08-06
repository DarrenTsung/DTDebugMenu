using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DTDebugMenu.Internal {
	public abstract class InputFieldInspector<T> : FieldInspector<T> {
		// PRAGMA MARK - Internal
		[Header("InputFieldInspector Outlets")]
		[SerializeField]
		private InputField inputField_;

		protected override void InternalInit() {
			inputField_.onValueChanged.AddListener(HandleValueChanged);
			inputField_.text = GetCurrentValue();
		}

		private void HandleValueChanged(string inputValue) {
			HandleInputChanged(inputValue);
		}

		protected abstract void HandleInputChanged(string input);
		protected abstract string GetCurrentValue();
	}
}