using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DTDebugMenu.Internal {
	public abstract class FieldInspector<T> : MonoBehaviour, IInspectorFieldView {
		// PRAGMA MARK - IInspectorFieldView Implementation
		void IInspectorFieldView.Init(IGenericInspectorField field) {
			var castedField = field as IGenericInspectorField<T>;
			if (castedField == null) {
				Debug.LogWarning("Failed to convert field into IGenericInspectorField<" + typeof(T).Name + ">!");
				return;
			}

			Field_ = castedField;
			displayNameText_.text = field.DisplayName;

			InternalInit();
		}


		// PRAGMA MARK - Internal
		[Header("Field Inspector Outlets")]
		[SerializeField]
		private Text displayNameText_;

		protected IGenericInspectorField<T> Field_ {
			get; private set;
		}

		protected abstract void InternalInit();
	}
}