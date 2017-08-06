using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DTDebugMenu.Internal {
	public interface IInspectorFieldView {
		void Init(IGenericInspectorField field);
	}
}