using Godot;
using System;
public class Piece
{
	public Vector2I[] activeShape;
	public Vector2I piecePosition;
	public int pieceType;
	public Piece(int type)
	{
		pieceType = type;
		activeShape = PieceData.shape[type];
		piecePosition = new Vector2I(5,0);
	}
	public void DrawActivePiece(TileMapLayer tilemap)
	{
		foreach (Vector2I block in activeShape)
		{
			Vector2I tile = piecePosition + block;
			tilemap.SetCell(tile + Global.imageOffset, pieceType, Vector2I.Zero);
		}
	}
}
