using Godot;
using System;
using System.Collections.Generic;

public partial class Level : Node2D
{
	RandomNumberGenerator rng = new RandomNumberGenerator();
	int width = 10;
	int height = 20;
	int [,] board;
	TileMapLayer boardMap;
	
	Vector2I[] activeShape;
	Vector2I piecePosition;
	int pieceType;

	Dictionary<int, Vector2I[]> shape = new Dictionary<int, Vector2I[]>()
	{
		{0, new Vector2I[]{			//L Piece
			new Vector2I(0,0),
			new Vector2I(0,-1),
			new Vector2I(0,-2),
			new Vector2I(1,0)
		}},
		{1, new Vector2I[]{			//S Piece
			new Vector2I(0,0),
			new Vector2I(0,1),
			new Vector2I(1,1),
			new Vector2I(-1,0)
		}},
		{2, new Vector2I[]{			//J Piece
			new Vector2I(0,0),
			new Vector2I(0,1),
			new Vector2I(0,2),
			new Vector2I(1,0)
		}},
		{3, new Vector2I[]{			//T Piece
			new Vector2I(0,0),
			new Vector2I(-1,0),
			new Vector2I(1,0),
			new Vector2I(0,1)
		}},
		{4, new Vector2I[]{			//Z Piece
			new Vector2I(0,0),
			new Vector2I(0,1),
			new Vector2I(-1,1),
			new Vector2I(1,0)
		}},
		{5, new Vector2I[]{			//I Piece
			new Vector2I(0,0),
			new Vector2I(0,1),
			new Vector2I(0,2),
			new Vector2I(0,-1)
		}},
		{6, new Vector2I[]{			//Square Piece
			new Vector2I(0,0),
			new Vector2I(0,1),
			new Vector2I(1,0),
			new Vector2I(1,1)
		}}
	};
	void SpawnPiece()
	{
		int shapeNum = rng.RandiRange(0,6);
		activeShape = shape[shapeNum];
		piecePosition = new Vector2I(5, 0);
		pieceType = shapeNum;
	}
	bool IsValidMove(Vector2I newPos)
	{
		foreach (Vector2I block in activeShape)
		{
			Vector2I tile = newPos + block;
			if (tile.X < 0 || tile.X >= width)
			{
				return false;
			}
			if (tile.Y >= height)
			{
				return false;
			}
			if (tile.Y >= 0 && board[tile.X, tile.Y] != 0)
			{
				return false;
			}
		}
		return true;
	}
	void MoveDown()
	{
		Vector2I newPos = piecePosition + Vector2I.Down;
		if (IsValidMove(newPos))
		{
			piecePosition = newPos;
		}
		else
		{
			LockPiece();
		}
	}
	void LockPiece()
	{
		foreach (Vector2I block in activeShape)
		{
			Vector2I tile = piecePosition + block;
			if (tile.Y >= 0)
				board[tile.X, tile.Y] = pieceType;
		}
		ClearLines();
		SpawnPiece();
	}
	void ClearLines()
	{
		for (int y = height - 1; y >= 0; y--)
		{
			bool full = true;
			for (int x = 0; x < width; x++)
			{
				if (board[x,y] == 0)
				{
					full = false;
					break;
				}
			}
			if (full)
			{
				for (int yy = y; yy > 0; yy--)
				{
					for (int x = 0; x < width; x++)
						board[x,yy] = board[x,yy-1];
				}
				y++;
			}
		}
	}
	void DrawBoard()
	{
		boardMap.Clear();
		for (int x = 0; x < width; x++)
		{
			for (int y = 0; y < height; y++)
			{
				if (board[x,y] != 0)
				{
				boardMap.SetCell(new Vector2I(x,y), board[x,y], Vector2I.Zero);
				}
			}
		}
	}
	void DrawActivePiece()
	{
		foreach (Vector2I block in activeShape)
		{
			Vector2I tile = piecePosition + block;
			boardMap.SetCell(tile, pieceType, Vector2I.Zero);
		}
	}
	void readInput(){
		if (Input.IsActionJustPressed("left"))
		{
		if (IsValidMove(piecePosition + Vector2I.Left))
			piecePosition += Vector2I.Left;
		}
		if (Input.IsActionJustPressed("right"))
		{
			if (IsValidMove(piecePosition + Vector2I.Right))
				piecePosition += Vector2I.Right;
		}
		if (Input.IsActionJustPressed("down"))
		{
			MoveDown();
		}
	}
	void _on_timer_timeout(){
		MoveDown();
	}
	public override void _Ready()
	{
		rng.Randomize();
		board = new int[width, height];
		boardMap = GetNode<TileMapLayer>("TileMapLayer");
		GetNode<Timer>("Timer").Timeout += _on_timer_timeout;
		GetNode<Timer>("Timer").Start();
		SpawnPiece();
		boardMap.SetCell(new Vector2I(5,5), 1, Vector2I.Zero);
	}
	public override void _Process(double delta)
	{
		DrawBoard();
		DrawActivePiece();
		readInput();
	}
}
