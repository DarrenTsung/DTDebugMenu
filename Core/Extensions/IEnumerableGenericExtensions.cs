using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DTDebugMenu.Internal {
	public static class IEnumerableGenericExtensions {
		public static int Sum<T>(this IEnumerable<T> enumerable, Func<T, int> transformation) {
			int sum = 0;
			foreach (T elem in enumerable) {
				sum += transformation.Invoke(elem);
			}

			return sum;
		}

		public static List<T> ToList<T>(this IEnumerable<T> enumerable) {
			return new List<T>(enumerable);
		}

		public static Dictionary<TKey, T> ToMapWithKeys<TKey, T>(this IEnumerable<T> enumerable, Func<T, TKey> keyTransformation) {
			Dictionary<TKey, T> map = new Dictionary<TKey, T>();
			foreach (T element in enumerable) {
				TKey key = keyTransformation.Invoke(element);
				if (map.ContainsKey(key)) {
					Debug.LogWarning("ToMapWithKeys - key (" + key + ") appears twice, will override the previous value: " + map[key]);
				}
				map[key] = element;
			}
			return map;
		}

		public static Dictionary<T, TValue> ToMapWithValues<T, TValue>(this IEnumerable<T> enumerable, Func<T, TValue> valueTransformation) {
			Dictionary<T, TValue> map = new Dictionary<T, TValue>();
			foreach (T key in enumerable) {
				TValue value = valueTransformation.Invoke(key);
				if (map.ContainsKey(key)) {
					Debug.LogWarning("ToMapWithValues - key (" + key + ") appears twice, will override the previous value: " + map[key]);
				}
				map[key] = value;
			}
			return map;
		}
	}
}
