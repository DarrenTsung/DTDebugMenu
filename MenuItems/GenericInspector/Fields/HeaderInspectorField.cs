using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DTDebugMenu.Internal {
	public class HeaderInspectorField : IGenericInspectorField {
		// PRAGMA MARK - IGenericInspectorField Implementation
		string IGenericInspectorField.DisplayName {
			get { return displayName_; }
		}

		Type IGenericInspectorField.Type {
			get { return typeof(HeaderInspectorField); }
		}


		// PRAGMA MARK - Public Interface
		public HeaderInspectorField(string displayName) {
			displayName_ = displayName;
		}


		// PRAGMA MARK - Internal
		private string displayName_;
	}
}