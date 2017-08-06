using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DTDebugMenu.Internal {
	public class ToggleFieldInspector : FieldInspector {
		// PRAGMA MARK - Internal
		[Header("ToggleFieldInspector Outlets")]
		[SerializeField]
		private Toggle toggle_;

		private IGenericInspectorField<bool> boolField_;

		protected override void InternalInit() {
			boolField_ = Field_ as IGenericInspectorField<bool>;
			if (boolField_ == null) {
				Debug.LogWarning("ToggleFieldInspector - failed to cast to IGenericInspectorField<bool>!");
				return;
			}

			toggle_.onValueChanged.AddListener(HandleValueChanged);
			toggle_.isOn = boolField_.Getter.Invoke();
		}

		private void HandleValueChanged(bool onValue) {
			boolField_.Setter.Invoke(onValue);
		}
	}
}