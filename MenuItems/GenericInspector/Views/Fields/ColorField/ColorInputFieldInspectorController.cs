using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DTDebugMenu.Internal {
	public class ColorInputFieldInspectorController : IInputFieldInspectorController {
		// PRAGMA MARK - IInputFieldInspectorController Implementation
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
	}
}