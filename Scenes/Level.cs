using Godot;
using System;

public partial class Level : Node2D
{
	PackedScene jBlockScene = ResourceLoader.Load<PackedScene>("res://Scenes/ jblock.tscn");
	public override void _Ready()
	{
		Jblock jblock = jBlockScene.Instantiate<Jblock>();
		GetNode<Node2D>("LiveBlocks").AddChild(jblock);
	}
}
