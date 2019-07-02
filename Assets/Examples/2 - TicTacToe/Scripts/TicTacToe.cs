using System;
using Grove.Behaviours;
using Grove.Containers;
using Grove.Maths;
using UnityEngine;

[Serializable]
public class Cell
{
	public PlayerOutput Owner;
	public Vector3Output Position;
}

[Serializable]
public class BoardOutput : ListOutput<Cell>
{
}

public class TicTacToe : GroveRoot
{
	public PlayerInput DefaultPlayer;

	public PlayerOutput Winner;
	public PlayerOutput CurrentPlayer;

	public BoardOutput Board;

	public void Start()
	{
		CurrentPlayer.Set(Get(DefaultPlayer));

		for (int j = 0; j < 3; ++j)
		{
			for (int i = 0; i < 3; ++i)
			{
				var cell = new Cell()
				{
					Owner = new PlayerOutput(),
					Position = new Vector3(i, j, 0),
				};
				Board.Add(cell);

				cell.Owner.Subscribe(CheckWinner);
			}
		}
	}

	private void CheckWinner()
	{
		Winner.Set(FindWinner());
	}

	private Player Get(int i, int j)
	{
		return Board[j * 3 + i].Owner;
	}

	public Player FindWinner()
	{
		Player p;

		// Rows
		for (int j = 0; j < 3; ++j)
		{
			if ((p = Get(0, j)) != null && p == Get(1, j) && p == Get(2, j))
			{
				return p;
			}
		}

		// Columns
		for (int i = 0; i < 3; ++i)
		{
			if ((p = Get(i, 0)) != null && p == Get(i, 1) && p == Get(i, 2))
			{
				return p;
			}
		}

		// Diagonals
		if ((p = Get(0, 0)) != null && p == Get(1, 1) && p == Get(2, 2))
		{
			return p;
		}
		if ((p = Get(0, 2)) != null && p == Get(1, 1) && p == Get(2, 0))
		{
			return p;
		}

		return null;
	}
}
