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
	public void BlockSpawnTimerTimeout()
	{
		Area2D block = Blocks[rng.RandiRange(0,6)].Instantiate<Area2D>();
		GetNode<Node2D>("LiveBlocks").AddChild(block);
	}
	public override void _Ready()
	{
		loadBlocks();
		GetNode<Timer>("BlockSpawnTimer").WaitTime = Global.spawnTime;
	}
	/*public override void _Process(double delta)
	{
		Area2D block = Blocks[0].Instantiate<Area2D>();
		GetNode<Node2D>("LiveBlocks").AddChild(block);
	}*/
}
