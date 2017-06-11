using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using DTDebugMenu.Internal;

namespace DTDebugMenu.DefaultMenuItems {
	public static class DebugConsoleLog {
		// PRAGMA MARK - Static Public Interface
		public static event Action OnLogUpdated = delegate {};

		public static string GetLogTextToDisplay() {
			return string.Join("\n", bufferedLines_.ToArray());
		}


		// PRAGMA MARK - Static Internal
		private const int kBufferLimit = 100;

		private static Queue<string> bufferedLines_ = new Queue<string>();

		[RuntimeInitializeOnLoadMethod]
		private static void Initialize() {
			Application.logMessageReceived += HandleLogReceived;
		}

		private static void HandleLogReceived(string condition, string stackTrace, LogType type) {
			Color logColor = ColorForLogType(type);
			bufferedLines_.Enqueue(RichTextUtil.WrapWithColorTag(condition, logColor));

			if (bufferedLines_.Count >= kBufferLimit) {
				bufferedLines_.Dequeue();
			}
			OnLogUpdated.Invoke();
		}

		private static Color ColorForLogType(LogType type) {
			switch (type) {
				case LogType.Warning:
					return Color.yellow;
				case LogType.Error:
					return Color.red;
				default:
					return Color.white;
			}
		}
	}
}