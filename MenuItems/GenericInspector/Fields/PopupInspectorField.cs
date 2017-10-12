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

		public int GetStartIndex() {
			return startIndexDelegate_.Invoke();
		}

		public PopupInspectorField(string displayName, Func<int> startIndexDelegate, PopupItemConfig[] itemConfigs) {
			displayName_ = displayName;
			startIndexDelegate_ = startIndexDelegate;
			itemConfigs_ = itemConfigs;
		}


		// PRAGMA MARK - Internal
		private string displayName_;
		private Func<int> startIndexDelegate_;
		private PopupItemConfig[] itemConfigs_;
	}
}