using System.Collections;
using System.Linq;
using UnityEngine;

using DTDebugMenu.Internal;

namespace DTDebugMenu {
	[CreateAssetMenu(fileName = "DebugMenuItem", menuName = "DTDebugMenu/DebugMenuItem")]
	public sealed class DebugMenuItem : ScriptableObject {
		// PRAGMA MARK - Public Interface
		public string DisplayTitle {
			get { return displayTitle_; }
		}

		public GameObject ActiveViewPrefab {
			get { return activeViewPrefab_; }
		}

		public int Priority {
			get { return priority_; }
		}


		// PRAGMA MARK - Internal
		[Header("Required Properties")]
		[SerializeField]
		private string displayTitle_;
		[SerializeField]
		private GameObject activeViewPrefab_;

		[Header("Optional")]
		[SerializeField]
		private int priority_ = 0;
	}
}