using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DTDebugMenu.Internal {
	public class ToggleButtonInspectorField : IGenericInspectorField<bool> {
		// PRAGMA MARK - IGenericInspectorField Implementation
		string IGenericInspectorField.DisplayName {
			get { return null; }
		}

		Type IGenericInspectorField.Type {
			get { return typeof(ToggleButtonInspectorField); }
		}


		// PRAGMA MARK - IGenericInspectorField<bool> Implementation
		public Func<bool> Getter {
			get { return getter_; }
		}

		public Action<bool> Setter {
			get { return setter_; }
		}


		// PRAGMA MARK - Public Interface
		public string GetDisplayNameFor(bool value) {
			return displayNameGetter_.Invoke(value);
		}

		public ToggleButtonInspectorField(Func<bool, string> displayNameGetter, Func<bool> getter, Action<bool> setter) {
			displayNameGetter_ = displayNameGetter;
			getter_ = getter;
			setter_ = setter;
		}


		// PRAGMA MARK - Internal
		private Func<bool, string> displayNameGetter_;
		private Func<bool> getter_;
		private Action<bool> setter_;
	}
}