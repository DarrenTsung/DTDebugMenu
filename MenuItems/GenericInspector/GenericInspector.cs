using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using DTDebugMenu.Internal;

namespace DTDebugMenu {
	public class GenericInspector {
		// PRAGMA MARK - Public Interface
		public IEnumerable<IGenericInspectorField> Fields {
			get { return fields_; }
		}

		public int Priority {
			get; set;
		}

		public void RegisterField<T>(string displayName, Action<T> setter, Func<T> getter) {
			fields_.Add(new GenericInspectorField<T>(displayName, setter, getter));
		}

		public void RegisterButton(string displayName, Action buttonCallback) {
			fields_.Add(new ButtonInspectorField(displayName, buttonCallback));
		}



		// PRAGMA MARK - Internal
		private readonly List<IGenericInspectorField> fields_ = new List<IGenericInspectorField>();
	}
}