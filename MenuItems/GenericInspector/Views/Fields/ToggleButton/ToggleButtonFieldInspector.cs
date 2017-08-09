using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DTDebugMenu.Internal {
	public class ToggleButtonFieldInspector : FieldInspector {
		// PRAGMA MARK - Internal
		[Header("ToggleButtonFieldInspector Outlets")]
		[SerializeField]
		private Button button_;
		[SerializeField]
		private Text buttonText_;

		private ToggleButtonInspectorField toggleButtonField_;
		private bool currentValue_;
		private bool CurrentValue_ {
			get { return currentValue_; }
			set {
				currentValue_ = value;
				buttonText_.text = toggleButtonField_.GetDisplayNameFor(currentValue_);
			}
		}

		protected override void InternalInit() {
			toggleButtonField_ = Field_ as ToggleButtonInspectorField;
			if (toggleButtonField_ == null) {
				Debug.LogWarning("ToggleButtonFieldInspector - failed to cast to ToggleButtonInspectorField! Field_: " + Field_);
				return;
			}

			CurrentValue_ = toggleButtonField_.Getter.Invoke();
			button_.onClick.AddListener(HandleButtonClicked);
		}

		private void HandleButtonClicked() {
			CurrentValue_ = !CurrentValue_;
			toggleButtonField_.Setter.Invoke(CurrentValue_);
		}
	}
}