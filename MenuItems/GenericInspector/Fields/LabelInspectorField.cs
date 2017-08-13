using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DTDebugMenu.Internal {
	public class LabelInspectorField : IGenericInspectorField {
		// PRAGMA MARK - IGenericInspectorField Implementation
		string IGenericInspectorField.DisplayName {
			get { return displayName_; }
		}

		Type IGenericInspectorField.Type {
			get { return typeof(LabelInspectorField); }
		}


		// PRAGMA MARK - Public Interface
		public LabelInspectorField(string displayName) {
			displayName_ = displayName;
		}


		// PRAGMA MARK - Internal
		private string displayName_;
	}
}