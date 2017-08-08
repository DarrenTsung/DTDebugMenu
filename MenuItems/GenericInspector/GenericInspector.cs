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

		public void RegisterHeader(string headerName) {
			RegisterField(new HeaderInspectorField(headerName));
		}

		public void RegisterField<T>(string displayName, Action<T> setter, Func<T> getter) {
			RegisterField(new GenericInspectorField<T>(displayName, setter, getter));
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
	}
}