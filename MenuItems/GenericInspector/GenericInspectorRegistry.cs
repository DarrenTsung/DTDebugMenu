using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using DTDebugMenu.Internal;

namespace DTDebugMenu {
	public static class GenericInspectorRegistry {
		// PRAGMA MARK - Public Interface
		public static IEnumerable<KeyValuePair<string, GenericInspector>> RegisteredInspectors {
			get { return inspectorMap_; }
		}

		public static GenericInspector Get(string inspectorName) {
			return inspectorMap_.GetAndCreateIfNotFound(inspectorName);
		}


		// PRAGMA MARK - Internal
		private static readonly Dictionary<string, GenericInspector> inspectorMap_ = new Dictionary<string, GenericInspector>();
	}
}