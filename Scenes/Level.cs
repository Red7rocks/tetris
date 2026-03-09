using Godot;
using System;
using System.Collections.Generic;

public partial class Level : Node2D
{
	Dictionary<int, PackedScene> Blocks = new Dictionary<int, PackedScene>();
	RandomNumberGenerator rng = new RandomNumberGenerator();

	public void loadBlocks()
	{
		Blocks.Add(0, ResourceLoader.Load<PackedScene>("res://Scenes/j_block.tscn"));
		Blocks.Add(1, ResourceLoader.Load<PackedScene>("res://Scenes/i_block.tscn"));
		Blocks.Add(2, ResourceLoader.Load<PackedScene>("res://Scenes/s_block.tscn"));
		Blocks.Add(3, ResourceLoader.Load<PackedScene>("res://Scenes/z_block.tscn"));
		Blocks.Add(4, ResourceLoader.Load<PackedScene>("res://Scenes/l_block.tscn"));
		Blocks.Add(5, ResourceLoader.Load<PackedScene>("res://Scenes/t_block.tscn"));
		Blocks.Add(6, ResourceLoader.Load<PackedScene>("res://Scenes/square_block.tscn"));
	}
	public void GameTickTimerTimeout()
	{
		Area2D block = Blocks[rng.RandiRange(0,6)].Instantiate<Area2D>();
		GetNode<Node2D>("LiveBlocks").AddChild(block);
	}
	public override void _Ready()
	{
		rng.Randomize();
		loadBlocks();
		Area2D block = Blocks[3].Instantiate<Area2D>();
		GetNode<Node2D>("LiveBlocks").AddChild(block);
		GetNode<Timer>("GameTickTimer").WaitTime = Global.gameTick;	
	}
	/*public override void _Process(double delta)
	{
		direction = Vector2.Zero;				//Set initial input direction to 0
		Node2D liveBlocks = GetNode<Node2D>("LiveBlocks");
		Area2D liveBlock = liveBlocks.GetChild<Area2D>(liveBlocks.GetChildCount() - 1);		//The -1 makes sure to grab the most recent block spawned
		liveBlock.Position += direction;
	}*/
}
