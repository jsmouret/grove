using System;
using UnityEngine;
using Grove.Common;
using Grove.Variables;

[Serializable]
public class PlayerOutput : OutputClass<Player>
{
}

[CreateAssetMenu(fileName = "C_Player", menuName = "TicTacToe/Player Constant")]
public class PlayerConstant : Constant<Player, PlayerConstant>
{
}
