using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace DTDebugMenu.Internal {
	public class PopupFieldInspector : FieldInspector {
		// PRAGMA MARK - Internal
		[Header("PopupFieldInspector Outlets")]
		[SerializeField]
		private Dropdown dropdown_;

		private PopupInspectorField popupField_;

		protected override void InternalInit() {
			popupField_ = Field_ as PopupInspectorField;
			if (popupField_ == null) {
				Debug.LogWarning("PopupFieldInspector - failed to cast to PopupInspectorField! Field_: " + Field_);
				return;
			}

			dropdown_.ClearOptions();
			dropdown_.AddOptions(popupField_.PopupItemConfigs.Select(c => new Dropdown.OptionData(c.DisplayName)).ToList());
			dropdown_.value = popupField_.StartIndex;
			dropdown_.onValueChanged.AddListener(HandleDropdownValueChanged);
		}

		private void HandleDropdownValueChanged(int index) {
			var itemConfig = popupField_.PopupItemConfigs[index];
			if (itemConfig == null) {
				return;
			}

			itemConfig.Callback.Invoke();
		}
	}
}