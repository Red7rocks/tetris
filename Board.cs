using Godot;
using System;

public class Board
{
	public RandomNumberGenerator rng = new RandomNumberGenerator();
	public int Width = 10;
	public int Height = 20;
	public int [,] Grid;
	
	public Board(int width, int height)
	{
		Width = width;
		Height = height;
		Grid = new int[width,height];
	}
	public bool IsCellOccupied(int x, int y)
	{
		return Grid[x,y] != 0;
	}
	public bool IsValidMove(Piece piece, Vector2I newPos)
	{
		foreach (Vector2I block in piece.activeShape)
		{
			Vector2I tile = newPos + block;
			if (tile.X < 0 || tile.X >= Width)
			{
				return false;
			}
			if (tile.Y >= Height)
			{
				return false;
			}
			if (tile.Y >= 0 && IsCellOccupied(tile.X, tile.Y))
			{
				return false;
			}
		}
		return true;
	}
	public void ClearLines()
	{
		for (int y = Height - 1; y >= 0; y--)
		{
			bool full = true;
			for (int x = 0; x < Width; x++)
			{
				if (Grid[x,y] == 0)
				{
					full = false;
					break;
				}
			}
			if (full)
			{
				for (int yy = y; yy > 0; yy--)
				{
					for (int x = 0; x < Width; x++)
						Grid[x,yy] = Grid[x,yy-1];
				}
				y++;
			}
		}
	}
	public void LockPiece(Piece activePiece)
	{
		foreach (Vector2I block in activePiece.activeShape)
		{
			Vector2I tile = activePiece.piecePosition + block;
			if (tile.Y >= 0)
				Grid[tile.X, tile.Y] = activePiece.pieceType;
		}
		ClearLines();
	}
	public Piece MoveDown(Piece activePiece)
	{
		Vector2I newPos = activePiece.piecePosition + Vector2I.Down;
		if (IsValidMove(activePiece, newPos))
		{
			activePiece.piecePosition = newPos;
		}
		else
		{
			LockPiece(activePiece);
			activePiece = new Piece(rng.RandiRange(1,7));
			MoveDown(activePiece);
		}
		return activePiece;
	}
	public void rotateClockwise(Piece piece)
	{
		
	}
	public void rotateCounterClockwise(Piece piece)
	{
		
	}
}
