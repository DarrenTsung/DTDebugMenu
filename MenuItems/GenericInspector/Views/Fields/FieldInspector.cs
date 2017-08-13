using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DTDebugMenu.Internal {
	public abstract class FieldInspector : MonoBehaviour, IInspectorFieldView {
		// PRAGMA MARK - IInspectorFieldView Implementation
		void IInspectorFieldView.Init(IGenericInspectorField field) {
			Field_ = field;

			if (displayNameText_ != null) {
				displayNameText_.text = Field_.DisplayName;
			}

			InternalInit();
		}


		// PRAGMA MARK - Internal
		[Header("Field Inspector Outlets")]
		[SerializeField]
		#if DT_VALIDATOR
		[DTValidator.Optional]
		#endif
		private Text displayNameText_;

		protected IGenericInspectorField Field_ {
			get; private set;
		}

		protected abstract void InternalInit();
	}
}