using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace DTDebugMenu.Internal {
	public class DebugMenuViewTab : MonoBehaviour {
		// PRAGMA MARK - Public Interface
		public void Init(DebugMenuItem menuItem, Action<DebugMenuItem> callback) {
			menuItem_ = menuItem;
			callback_ = callback;

			titleText_.text = menuItem.DisplayTitle;
		}

		public void HandleNewActiveItem(DebugMenuItem activeItem) {
			bool isActive = activeItem == menuItem_;
			if (isActive) {
				canvasGroup_.alpha = 1.0f;
			} else {
				bool isEven = this.transform.GetSiblingIndex() % 2 == 0;
				canvasGroup_.alpha = isEven ? 0.66f : 0.6f;
			}
		}


		// PRAGMA MARK - Internal
		[Header("Outlets")]
		[SerializeField]
		private Text titleText_;
		[SerializeField]
		private Button button_;
		[SerializeField]
		private CanvasGroup canvasGroup_;

		private DebugMenuItem menuItem_;
		private Action<DebugMenuItem> callback_;

		private void OnEnable() {
			button_.onClick.AddListener(HandleSelected);
		}

		private void OnDisable() {
			button_.onClick.RemoveListener(HandleSelected);
		}

		private void HandleSelected() {
			callback_.Invoke(menuItem_);
		}
	}
}