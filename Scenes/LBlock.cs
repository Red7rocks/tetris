using Godot;
using System;

public partial class LBlock : Area2D
{
	public override void _Ready()
	{
		Position = new Vector2(650,0);
	}
	public override void _Process(double delta)
	{
		Position += new Vector2(0, Global.speed * (float)delta);
	}
}
