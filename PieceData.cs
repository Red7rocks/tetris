using Godot;
using System;
using System.Collections.Generic;

public static class PieceData
{
	public static Dictionary<int, Vector2I[]> shape = new Dictionary<int, Vector2I[]>()
	{
		{1, new Vector2I[]{			//L Piece
			new Vector2I(0,1),
			new Vector2I(1,1),
			new Vector2I(2,1),
			new Vector2I(2,0)
		}},
		{2, new Vector2I[]{			//S Piece
			new Vector2I(0,0),
			new Vector2I(1,0),
			new Vector2I(1,1),
			new Vector2I(2,1)
		}},
		{3, new Vector2I[]{			//J Piece
			new Vector2I(0,1),
			new Vector2I(1,1),
			new Vector2I(2,1),
			new Vector2I(0,0)
		}},
		{4, new Vector2I[]{			//T Piece
			new Vector2I(0,1),
			new Vector2I(1,0),
			new Vector2I(1,1),
			new Vector2I(2,1)
		}},
		{5, new Vector2I[]{			//Z Piece
			new Vector2I(1,0),
			new Vector2I(0,1),
			new Vector2I(1,1),
			new Vector2I(2,0)
		}},
		{6, new Vector2I[]{			//I Piece
			new Vector2I(0,0),
			new Vector2I(0,1),
			new Vector2I(0,2),
			new Vector2I(0,3)
		}},
		{7, new Vector2I[]{			//Square Piece
			new Vector2I(0,0),
			new Vector2I(0,1),
			new Vector2I(1,0),
			new Vector2I(1,1)
		}}
	};
}
