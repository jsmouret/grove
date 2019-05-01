using System;
using Grove.Common;

namespace Grove.Actions
{
	[Serializable]
	public class ActionVariant : Variant<ActionBase>
	{
		[Serializable]
		public struct Actions
		{
			public Grove.Actions.Include[] m_Include;
			public Grove.Actions.SetAction[] m_SetAction;
		}

		[Serializable]
		public struct Animations
		{
			public Grove.Animations.SetBool[] m_SetBool;
			public Grove.Animations.SetInt[] m_SetInt;
			public Grove.Animations.SetFloat[] m_SetFloat;
			public Grove.Animations.SetTrigger[] m_SetTrigger;
		}

		[Serializable]
		public struct Behaviours
		{
			public Grove.Behaviours.SetEnabled[] m_SetEnabled;
		}

		[Serializable]
		public struct Containers
		{
			public Grove.Containers.SetList[] m_SetList;
		}

		[Serializable]
		public struct GameObjects
		{
			public Grove.GameObjects.SetActive[] m_SetActive;
		}

		[Serializable]
		public struct Maths
		{
			public Grove.Maths.SetBool[] m_SetBool;
			public Grove.Maths.SetFloat[] m_SetFloat;
			public Grove.Maths.SetInt[] m_SetInt;
			public Grove.Maths.SetQuaternion[] m_SetQuaternion;
			public Grove.Maths.SetVector2[] m_SetVector2;
			public Grove.Maths.SetVector3[] m_SetVector3;
			public Grove.Maths.SetVector4[] m_SetVector4;
		}

		[Serializable]
		public struct Properties
		{
			public Grove.Properties.SetProperty[] m_SetProperty;
		}

		[Serializable]
		public struct Texts
		{
			public Grove.Texts.DebugLog[] m_DebugLog;
			public Grove.Texts.SetString[] m_SetString;
			public Grove.Texts.SetStringFormat[] m_SetStringFormat;
		}

		[Serializable]
		public struct UI
		{
			public Grove.UI.SetTextColor[] m_SetTextColor;
			public Grove.UI.SetTextFormat[] m_SetTextFormat;
		}

		[Serializable]
		public struct Visuals
		{
			public Grove.Visuals.SetColor[] m_SetColor;
		}

		public Actions[] m_Actions;
		public Animations[] m_Animations;
		public Behaviours[] m_Behaviours;
		public Containers[] m_Containers;
		public GameObjects[] m_GameObjects;
		public Maths[] m_Maths;
		public Properties[] m_Properties;
		public Texts[] m_Texts;
		public UI[] m_UI;
		public Visuals[] m_Visuals;
	}
}
