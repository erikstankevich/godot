using Godot;
using System;

public partial class Skype : Area2D
{
	[Export] public float Speed = 100f;
	private Node2D player;



	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = GetNode<Node2D>("../Player");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (player == null)
		{
			return;
		}

		Vector2 direction = (player.GlobalPosition - GlobalPosition).Normalized();

		GlobalPosition += direction * Speed * (float)delta;

	}

}
