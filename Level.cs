using Godot;
using System;
using System.Collections.Generic;

public partial class Level : Node2D
{
	RandomNumberGenerator rng = new RandomNumberGenerator();
	TileMapLayer blockTileMap;
	
	Board board;
	BoardRenderer tileRenderer;
	Piece activePiece;

	void readInput(){
		if (Input.IsActionJustPressed("left"))
		{
		if (board.IsValidMove(activePiece, activePiece.piecePosition + Vector2I.Left))
			activePiece.piecePosition += Vector2I.Left;
		}
		if (Input.IsActionJustPressed("right"))
		{
			if (board.IsValidMove(activePiece, activePiece.piecePosition + Vector2I.Right))
				activePiece.piecePosition += Vector2I.Right;
		}
		if (Input.IsActionJustPressed("down"))
		{
			activePiece = board.MoveDown(activePiece);
		}
	}
	void _on_timer_timeout(){
		activePiece = board.MoveDown(activePiece);
	}
	public override void _Ready()
	{
		board = new Board(10, 20);
		blockTileMap = GetNode<TileMapLayer>("TileMapLayer");
		tileRenderer = new BoardRenderer(blockTileMap);
		tileRenderer.DrawBoard(board.Grid, board.Width, board.Height);
		
		board.rng.Randomize();
		activePiece = new Piece(rng.RandiRange(0,6));
	}
	public override void _Process(double delta)
	{
		tileRenderer.DrawBoard(board.Grid, board.Width, board.Height);
		activePiece.DrawActivePiece(blockTileMap);
		readInput();
	}
}
