using System;
using UnityEngine;
using Grove.Common;
using Grove.Variables;

namespace Grove.Events
{
	public interface IEventContext : IContext
	{
		void OnEvent();
	}
}
