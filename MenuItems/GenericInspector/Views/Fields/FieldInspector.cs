using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DTDebugMenu.Internal {
	public abstract class FieldInspector : MonoBehaviour, IInspectorFieldView {
		// PRAGMA MARK - IInspectorFieldView Implementation
		void IInspectorFieldView.Init(IGenericInspectorField field) {
			displayNameText_.text = field.DisplayName;

			InternalInit();
		}


		// PRAGMA MARK - Internal
		[Header("Field Inspector Outlets")]
		[SerializeField]
		private Text displayNameText_;

		protected abstract void InternalInit();
	}
}