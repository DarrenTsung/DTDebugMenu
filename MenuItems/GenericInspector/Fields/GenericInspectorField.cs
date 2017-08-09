using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DTDebugMenu.Internal {
	public class GenericInspectorField<T> : IGenericInspectorField<T> {
		// PRAGMA MARK - IGenericInspectorField<T> Implementation
		string IGenericInspectorField.DisplayName {
			get { return displayName_; }
		}

		Func<T> IGenericInspectorField<T>.Getter {
			get { return getter_; }
		}

		Action<T> IGenericInspectorField<T>.Setter {
			get { return setter_; }
		}

		Type IGenericInspectorField.Type {
			get { return typeof(T); }
		}


		// PRAGMA MARK - Public Interface
		public GenericInspectorField(string displayName, Func<T> getter, Action<T> setter) {
			displayName_ = displayName;
			getter_ = getter;
			setter_ = setter;
		}


		// PRAGMA MARK - Internal
		private string displayName_;
		private Action<T> setter_;
		private Func<T> getter_;
	}
}