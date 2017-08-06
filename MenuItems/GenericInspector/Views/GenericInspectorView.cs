using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DTDebugMenu.Internal {
	public class GenericInspectorView : MonoBehaviour {
		// PRAGMA MARK - Public Interface
		public void Init(GenericInspector inspector) {
			foreach (IGenericInspectorField field in inspector.Fields) {
				IInspectorFieldView fieldView = null;
				if (field.Type == typeof(Color)) {
					fieldView = GameObject.Instantiate(colorInspectorPrefab_, parent: container_.transform).GetComponent<IInspectorFieldView>();
				}

				if (fieldView == null) {
					Debug.LogWarning("Failed to find prefab for IGenericInspectorField with type: " + field.Type);
					return;
				}
				fieldView.Init(field);
			}
		}



		// PRAGMA MARK - Internal
		[Header("Prefabs")]
		[SerializeField]
		private GameObject colorInspectorPrefab_;


		[Header("Outlets")]
		[SerializeField]
		private GameObject container_;
	}
}