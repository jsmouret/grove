using System;
using UnityEngine;
using Grove.Texts;
using Grove.Variables;

[CreateAssetMenu(fileName = "MyPlayer", menuName = "TicTacToe/Player")]
public class Player : Data
{
	public StringOutput Symbol;
	public StringOutput Name;
}
