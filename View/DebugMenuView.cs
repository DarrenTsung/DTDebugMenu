using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DTDebugMenu.Internal {
	public class DebugMenuView : MonoBehaviour {
		// PRAGMA MARK - Public Interface
		public void Init(DebugMenuItem[] menuItems) {
			if (menuItems.Length <= 0) {
				return;
			}

			var tabs = new List<DebugMenuViewTab>();

			// remove duplicates / nulls
			var menuItemsSet = new HashSet<DebugMenuItem>(menuItems.Where(i => i != null));
			// higher priority == top of the list
			menuItems = menuItemsSet.OrderBy(i => -i.Priority).ToArray();

			foreach (DebugMenuItem item in menuItems) {
				GameObject menuTab = GameObject.Instantiate(menuTabPrefab_, menuTabsContainer_);
				DebugMenuViewTab tab = menuTab.GetComponent<DebugMenuViewTab>();
				tab.Init(item, HandleItemSelected);

				tabs.Add(tab);
			}

			tabs_ = tabs.ToArray();

			HandleItemSelected(menuItems[0]);
		}


		// PRAGMA MARK - Internal
		[Header("Outlets")]
		[SerializeField]
		private RectTransform menuTabsContainer_;
		[SerializeField]
		private RectTransform activeItemContainer_;

		[Space]
		[SerializeField]
		private GameObject menuTabPrefab_;

		private DebugMenuViewTab[] tabs_;

		private void OnEnable() {

		}

		private void OnDisable() {

		}

		private void HandleItemSelected(DebugMenuItem item) {
			activeItemContainer_.DestroyAllChildren();

			GameObject.Instantiate(item.ActiveViewPrefab, activeItemContainer_);
			foreach (var tab in tabs_) {
				tab.HandleNewActiveItem(item);
			}
		}
	}
}