using System.Collections;
using System.Linq;
using UnityEngine;

using DTDebugMenu.Internal;

namespace DTDebugMenu {
	[CreateAssetMenu(fileName = "DebugMenuItem", menuName = "DTDebugMenu/DebugMenuItem")]
	public class DebugMenuItem : ScriptableObject {
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

		public virtual void HandleViewCreated(GameObject createdView) {
			// stub
		}


		// PRAGMA MARK - Internal
		[Header("Required Properties")]
		[SerializeField]
		protected string displayTitle_;
		[SerializeField]
		protected GameObject activeViewPrefab_;

		[Header("Optional")]
		[SerializeField]
		protected int priority_ = 0;
	}
}