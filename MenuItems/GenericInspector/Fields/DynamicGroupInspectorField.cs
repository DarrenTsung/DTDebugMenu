using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DTDebugMenu.Internal {
	public class DynamicGroupInspectorField : IGenericInspectorField, IDynamicGroup {
		// PRAGMA MARK - IGenericInspectorField Implementation
		string IGenericInspectorField.DisplayName {
			get { return null; }
		}

		Type IGenericInspectorField.Type {
			get { return typeof(DynamicGroupInspectorField); }
		}


		// PRAGMA MARK - IDynamicGroup Implementation
		public event Action OnEnabledChanged = delegate {};

		public bool Enabled {
			get { return enabled_; }
			set {
				if (enabled_ == value) {
					return;
				}

				enabled_ = value;
				OnEnabledChanged.Invoke();
			}
		}


		// PRAGMA MARK - Public Interface
		public IEnumerable<IGenericInspectorField> Fields {
			get { return fields_; }
		}

		public void Add(IGenericInspectorField field) {
			fields_.Add(field);
		}


		// PRAGMA MARK - Internal
		private readonly List<IGenericInspectorField> fields_ = new List<IGenericInspectorField>();
		private bool enabled_ = true;
	}
}