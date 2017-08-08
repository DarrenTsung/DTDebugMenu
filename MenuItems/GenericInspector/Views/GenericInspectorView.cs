using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DTDebugMenu.Internal {
	public class GenericInspectorView : MonoBehaviour {
		// PRAGMA MARK - Public Interface
		public void Init(GenericInspector inspector) {
			inspector_ = inspector;
			RefreshInspectorFields();
		}


		// PRAGMA MARK - Internal
		[Header("Prefabs")]
		[SerializeField]
		private GameObject inputFieldInspectorPrefab_;
		[SerializeField]
		private GameObject toggleInspectorPrefab_;
		[SerializeField]
		private GameObject buttonInspectorPrefab_;
		[SerializeField]
		private GameObject headerInspectorPrefab_;

		[Header("Outlets")]
		[SerializeField]
		private GameObject container_;

		private GenericInspector inspector_;

		private void OnEnable() {
			RefreshInspectorFields();
		}

		private void RefreshInspectorFields() {
			container_.transform.DestroyAllChildren();

			foreach (IGenericInspectorField field in inspector.Fields) {
				IInspectorFieldView fieldView = null;
				if (field.Type == typeof(Color)) {
					GameObject inputFieldObject = GameObject.Instantiate(inputFieldInspectorPrefab_, parent: container_.transform);
					fieldView = inputFieldObject.GetComponent<IInspectorFieldView>();
					inputFieldObject.GetComponent<InputFieldInspector>().Init(new ColorInputFieldInspectorController(field));
				} else if (field.Type == typeof(bool)) {
					fieldView = GameObject.Instantiate(toggleInspectorPrefab_, parent: container_.transform).GetComponent<IInspectorFieldView>();
				} else if (field.Type == typeof(ButtonInspectorField)) {
					fieldView = GameObject.Instantiate(buttonInspectorPrefab_, parent: container_.transform).GetComponent<IInspectorFieldView>();
				} else if (field.Type == typeof(HeaderInspectorField)) {
					fieldView = GameObject.Instantiate(headerInspectorPrefab_, parent: container_.transform).GetComponent<IInspectorFieldView>();
				}

				if (fieldView == null) {
					Debug.LogWarning("Failed to find prefab for IGenericInspectorField with type: " + field.Type);
					return;
				}
				fieldView.Init(field);
			}
		}
	}
}