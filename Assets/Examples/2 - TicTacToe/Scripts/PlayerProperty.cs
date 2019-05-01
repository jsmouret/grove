using System;
using UnityEngine;
using Grove.Properties;

[Serializable]
public class PlayerInput : Input<Player, PlayerProperty, PlayerConstant>
{
}

[CreateAssetMenu(fileName = "MyPlayerProperty", menuName = "TicTacToe/Player Property")]
public class PlayerProperty : Property<Player>
{
}
