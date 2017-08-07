using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DTDebugMenu.Internal {
	public class ButtonInspectorField : IGenericInspectorField {
		// PRAGMA MARK - IGenericInspectorField Implementation
		string IGenericInspectorField.DisplayName {
			get { return displayName_; }
		}

		Type IGenericInspectorField.Type {
			get { return typeof(ButtonInspectorField); }
		}


		// PRAGMA MARK - Public Interface
		public Action ButtonCallback {
			get { return buttonCallback_; }
		}

		public ButtonInspectorField(string displayName, Action buttonCallback) {
			displayName_ = displayName;
			buttonCallback_ = buttonCallback;
		}


		// PRAGMA MARK - Internal
		private string displayName_;
		private Action buttonCallback_;
	}
}