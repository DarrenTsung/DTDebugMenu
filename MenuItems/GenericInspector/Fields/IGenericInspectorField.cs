using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DTDebugMenu.Internal {
	public interface IGenericInspectorField<T> : IGenericInspectorField {
		// PRAGMA MARK - IGenericInspectorField<T> Implementation
		Action<T> Setter {
			get;
		}

		Func<T> Getter {
			get;
		}
	}

	public interface IGenericInspectorField {
		// PRAGMA MARK - IGenericInspectorField Implementation
		string DisplayName {
			get;
		}

		Type Type {
			get;
		}
	}
}