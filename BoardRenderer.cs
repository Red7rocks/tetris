using Godot;
using System;
public class BoardRenderer
{
	TileMapLayer tilemap;

	public BoardRenderer(TileMapLayer map)
	{
		tilemap = map;
	}

	public void DrawBoard(int[,] board, int width, int height)
	{
		tilemap.Clear();
		for(int x=0;x<width;x++)
		{
			for(int y=0;y<height;y++)
			{
				if(board[x,y] != 0)
				tilemap.SetCell(new Vector2I(x,y) + Global.imageOffset, board[x,y], Vector2I.Zero);
			}
		}
	}

}
