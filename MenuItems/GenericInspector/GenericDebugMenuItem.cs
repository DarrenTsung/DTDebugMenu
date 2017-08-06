using System.Collections;
using System.Linq;
using UnityEngine;

namespace DTDebugMenu.Internal {
	public class GenericDebugMenuItem : DebugMenuItem {
		// PRAGMA MARK - Public Interface
		public void Init(string inspectorName, GenericInspector inspector) {
			displayTitle_ = inspectorName;
			activeViewPrefab_ = Resources.Load<GameObject>("GenericInspectorViewPrefab");

			inspector_ = inspector;
		}

		public override void HandleViewCreated(GameObject createdView) {
			createdView.GetComponent<GenericInspectorView>().Init(inspector_);
		}



		// PRAGMA MARK - Internal
		private GenericInspector inspector_;
	}
}