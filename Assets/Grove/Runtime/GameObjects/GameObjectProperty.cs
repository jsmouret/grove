using System;
using UnityEngine;
using Grove.Properties;

namespace Grove.GameObjects
{
	[Serializable]
	public class GameObjectInput : Input<GameObject, GameObjectProperty, GameObjectConstant>
	{
	}

	[CreateAssetMenu(fileName = "MyGameObject", menuName = "Grove/GameObjects/GameObject Property", order = 49)]
	public class GameObjectProperty : Property<GameObject>
	{
	}
}
