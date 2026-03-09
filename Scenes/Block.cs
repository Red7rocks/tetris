using Godot;
using System;

public partial class Block : Area2D
{
	Vector2 direction;
	public void readInput()
	{
		if (Input.IsActionJustPressed("left")){
			direction -= new Vector2(Global.tileSize * 3 , 0);
		}
		if (Input.IsActionJustPressed("right")){
			direction += new Vector2(Global.tileSize * 3, 0);	
		}
	}
	public override void _Ready()
	{
		Position = Global.spawnPosition;
	}
	public override void _Process(double delta)
	{
		direction = Vector2.Zero;
		readInput();
		Position += Vector2.Down * Global.speed * (float)delta;
		Position += direction;
	}
}
