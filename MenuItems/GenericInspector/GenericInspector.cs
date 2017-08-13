using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using DTDebugMenu.Internal;

namespace DTDebugMenu {
	public class GenericInspector {
		// PRAGMA MARK - Public Interface
		public event Action OnInspectorDirty = delegate {};

		public IEnumerable<IGenericInspectorField> Fields {
			get { return fields_; }
		}

		public int Priority {
			get; set;
		}

		public void ResetFields() {
			dynamicGroup_ = null;
			fields_.Clear();
			DirtySelf();
		}

		public void RegisterHeader(string headerName) {
			RegisterField(new HeaderInspectorField(headerName));
		}

		public void RegisterLabel(string label) {
			RegisterField(new LabelInspectorField(label));
		}

		public void RegisterColorField(string displayName, Func<Color> getter, Action<Color> setter) {
			RegisterField<Color>(displayName, getter, setter);
		}

		public void RegisterStringField(string displayName, Func<string> getter, Action<string> setter) {
			RegisterField<string>(displayName, getter, setter);
		}

		public void RegisterIntField(string displayName, Func<int> getter, Action<int> setter) {
			RegisterField<int>(displayName, getter, setter);
		}

		public void RegisterToggle(string displayName, Func<bool> getter, Action<bool> setter) {
			RegisterField<bool>(displayName, getter, setter);
		}

		public void RegisterToggleButton(Func<bool, string> displayNameGetter, Func<bool> getter, Action<bool> setter) {
			RegisterField(new ToggleButtonInspectorField(displayNameGetter, getter, setter));
		}

		public void RegisterButton(string displayName, Action buttonCallback) {
			RegisterField(new ButtonInspectorField(displayName, buttonCallback));
		}

		public void BeginDynamic() {
			if (dynamicGroup_ != null) {
				Debug.LogWarning("Dynamic group already exists, can't BeginDynamic!");
				return;
			}

			dynamicGroup_ = new DynamicGroupInspectorField();
			dynamicGroup_.OnEnabledChanged += DirtySelf;
		}

		public IDynamicGroup EndDynamic() {
			if (dynamicGroup_ == null) {
				Debug.LogWarning("Dynamic group doesn't exist, can't EndDynamic!");
				return null;
			}

			IDynamicGroup dynamicGroup = dynamicGroup_;
			fields_.Add(dynamicGroup_);
			dynamicGroup_ = null;

			return dynamicGroup;
		}



		// PRAGMA MARK - Internal
		private readonly List<IGenericInspectorField> fields_ = new List<IGenericInspectorField>();

		private DynamicGroupInspectorField dynamicGroup_;

		private void RegisterField(IGenericInspectorField field) {
			if (dynamicGroup_ != null) {
				dynamicGroup_.Add(field);
			} else {
				fields_.Add(field);
			}
		}

		private void DirtySelf() {
			OnInspectorDirty.Invoke();
		}

		private void RegisterField<T>(string displayName, Func<T> getter, Action<T> setter) {
			RegisterField(new GenericInspectorField<T>(displayName, getter, setter));
		}
	}
}