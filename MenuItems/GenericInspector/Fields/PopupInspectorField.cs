using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DTDebugMenu.Internal {
	public class PopupInspectorField : IGenericInspectorField {
		// PRAGMA MARK - IGenericInspectorField Implementation
		string IGenericInspectorField.DisplayName {
			get { return displayName_; }
		}

		Type IGenericInspectorField.Type {
			get { return typeof(PopupInspectorField); }
		}


		// PRAGMA MARK - Public Interface
		public IList<PopupItemConfig> PopupItemConfigs {
			get { return itemConfigs_; }
		}

		public int StartIndex {
			get { return startIndex_; }
		}

		public PopupInspectorField(string displayName, int startIndex, PopupItemConfig[] itemConfigs) {
			displayName_ = displayName;
			startIndex_ = startIndex;
			itemConfigs_ = itemConfigs;
		}


		// PRAGMA MARK - Internal
		private string displayName_;
		private int startIndex_;
		private PopupItemConfig[] itemConfigs_;
	}
}