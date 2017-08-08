using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DTDebugMenu.Internal {
	public static class IEnumerableExtensions {
		public static int Sum<T>(this IEnumerable<T> enumerable, Func<T, int> transformation) {
			int sum = 0;
			foreach (T elem in enumerable) {
				sum += transformation.Invoke(elem);
			}

			return sum;
		}
	}
}
