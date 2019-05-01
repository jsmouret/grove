using System;
using UnityEngine;
using Grove.Common;

namespace Grove.Events
{
	[Serializable]
	public class EventVariant : Variant<EventBase>
	{
		[Serializable]
		public struct Behaviours
		{
			public Grove.Behaviours.OnEnable[] m_OnEnable;
			public Grove.Behaviours.OnDisable[] m_OnDisable;
		}

		[Serializable]
		public struct Properties
		{
			public Grove.Properties.Changed[] m_Changed;
		}

		[Serializable]
		public struct UI
		{
			public Grove.UI.ButtonClicked[] m_ButtonClicked;
		}

		public Behaviours[] m_Behaviours;
		public Properties[] m_Properties;
		public UI[] m_UI;
	}
}
