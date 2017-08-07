using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DTDebugMenu.Internal {
	public class ButtonFieldInspector : FieldInspector {
		// PRAGMA MARK - Internal
		[Header("ButtonFieldInspector Outlets")]
		[SerializeField]
		private Button button_;

		private ButtonInspectorField buttonField_;

		protected override void InternalInit() {
			buttonField_ = Field_ as ButtonInspectorField;
			if (buttonField_ == null) {
				Debug.LogWarning("ButtonFieldInspector - failed to cast to ButtonInspectorField! Field_: " + Field_);
				return;
			}

			button_.onClick.AddListener(HandleButtonClicked);
		}

		private void HandleButtonClicked() {
			buttonField_.ButtonCallback.Invoke();
		}
	}
}