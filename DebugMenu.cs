using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using DTDebugMenu.Internal;

#if IN_CONTROL
using InControl;
#endif

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace DTDebugMenu {
	public class DebugMenu : MonoBehaviour {
		// PRAGMA MARK - Internal
		[Header("Outlets")]
		[SerializeField]
		private DebugMenuItem[] menuItems_;
		[SerializeField]
		private GameObject viewPrefab_;

		[Header("Properties")]
		[SerializeField]
		private KeyCode toggleKey_ = KeyCode.G;

		[Space]
		[SerializeField]
		private int numberOfFingersToToggle_ = 3;

		#if IN_CONTROL
		[Space]
		[SerializeField]
		private InputControlType toggleControl_ = InputControlType.DPadLeft;
		#endif

		private GameObject view_;

		private void Start() {
			if (!Debug.isDebugBuild) {
				this.enabled = false;
				return;
			}

			var menuItems = new List<DebugMenuItem>(menuItems_);
			foreach (var kvp in GenericInspectorRegistry.RegisteredInspectors) {
				string inspectorName = kvp.Key;
				GenericInspector inspector = kvp.Value;

				var genericMenuItem = ScriptableObject.CreateInstance<GenericDebugMenuItem>();
				genericMenuItem.Init(inspectorName, inspector);

				menuItems.Add(genericMenuItem);
			}

			GameObject.DontDestroyOnLoad(this.gameObject);

			view_ = GameObject.Instantiate(viewPrefab_, this.transform);
			view_.GetComponent<DebugMenuView>().Init(menuItems.ToArray());
			view_.gameObject.SetActive(false);

			StartCoroutine(UpdateToggleView());
		}

		#if UNITY_EDITOR
		private void Reset() {
			viewPrefab_ = AssetDatabaseUtil.LoadSpecificAssetNamed<GameObject>("DebugMenuView");
			menuItems_ = new DebugMenuItem[] {
				AssetDatabaseUtil.LoadSpecificAssetNamed<DebugMenuItem>("ConsoleLogDebugMenuItem"),
			};
		}
		#endif

		private void OnDestroy() {
			if (view_ != null) {
				GameObject.Destroy(view_);
				view_ = null;
			}
		}

		private IEnumerator UpdateToggleView() {
			int previousNumberOfTouches = 0;

			while (true) {
				int numberOfTouches = Input.touches.Length;
				if (numberOfTouches != previousNumberOfTouches) {
					if (Input.touches.Length == numberOfFingersToToggle_) {
						view_.ToggleActive();
					}
				}

				if (Input.GetKeyDown(toggleKey_)) {
					view_.ToggleActive();
				}

				#if IN_CONTROL
				foreach (InputDevice device in InputManager.Devices) {
					if (device.GetControl(toggleControl_).WasPressed) {
						view_.ToggleActive();
					}
				}
				#endif

				previousNumberOfTouches = numberOfTouches;
				yield return null;
			}
		}
	}
}