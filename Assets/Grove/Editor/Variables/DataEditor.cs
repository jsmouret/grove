using UnityEditor;
using UnityEngine;
using Grove.Common.Editor;

namespace Grove.Variables.Editor
{
	[CustomEditor(typeof(Data), true)]
	public class DataEditor : UnityEditor.Editor
	{
		// Because Data inherits from Constant, create this dummy editor
		// to avoid Data being rendered by ConstantEditor which expects Options.
	}
}