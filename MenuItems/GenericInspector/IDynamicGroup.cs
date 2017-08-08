using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using DTDebugMenu.Internal;

namespace DTDebugMenu {
	public interface IDynamicGroup {
		bool Enabled {
			get; set;
		}
	}
}