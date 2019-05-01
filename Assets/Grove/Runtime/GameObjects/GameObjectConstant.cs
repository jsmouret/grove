using System;
using UnityEngine;
using Grove.Variables;

namespace Grove.GameObjects
{
	[Serializable]
	public class GameObjectOutput : OutputClass<GameObject>
	{
	}

	[CreateAssetMenu(fileName = "C_GameObject", menuName = "Grove/GameObjects/GameObject Constant", order = 48)]
	public class GameObjectConstant : Constant<GameObject, GameObjectConstant>
	{
	}
}
