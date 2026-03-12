using Godot;
using System;
using System.Collections.Generic;

public partial class Level : Node2D
{
	TileMapLayer blockTileMap;
	
	Board board;
	BoardRenderer tileRenderer;
	Piece activePiece;

	void readInput(){
		bool moved = false;
		if (Input.IsActionJustPressed("left"))
		{
		if (board.IsValidMove(activePiece, activePiece.piecePosition + Vector2I.Left))
			activePiece.piecePosition += Vector2I.Left;
			moved = true;
		}
		if (Input.IsActionJustPressed("right"))
		{
			if (board.IsValidMove(activePiece, activePiece.piecePosition + Vector2I.Right)){
				activePiece.piecePosition += Vector2I.Right;
				moved = true;
			}
		}
		if (Input.IsActionJustPressed("up"))
		{
			while(board.IsValidMove(activePiece, activePiece.piecePosition + Vector2I.Down)){
				activePiece = board.MoveDown(activePiece);
			}
			moved = true;
		}
		if (Input.IsActionJustPressed("down"))
		{
			activePiece = board.MoveDown(activePiece);
			moved = true;
		}
		if (Input.IsActionJustPressed("rotateLeft"))
		{
			board.rotateCounterClockwise(activePiece);
			moved = true;
		}
		if (Input.IsActionJustPressed("rotateRight"))
		{
			board.rotateClockwise(activePiece);
			moved = true;
		}
		if(moved){
			updateBoardAndPiece();
		}
	}
	void _on_timer_timeout(){
		activePiece = board.MoveDown(activePiece);
		updateBoardAndPiece();
	}
	void updateBoardAndPiece(){
		tileRenderer.DrawBoard(board.Grid, board.Width, board.Height);
		tileRenderer.DrawActivePiece(activePiece);
	}

	
	public override void _Ready()
	{
		board = new Board(10, 20);
		blockTileMap = GetNode<TileMapLayer>("TileMapLayer");
		tileRenderer = new BoardRenderer(blockTileMap);
		
		board.rng.Randomize();
		activePiece = new Piece(board.rng.RandiRange(1,7));
		board.MoveDown(activePiece);
		updateBoardAndPiece();
	}
	public override void _Process(double delta)
	{
		readInput();
	}
}
