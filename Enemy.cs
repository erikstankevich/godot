using Godot;
using System;

public partial class Enemy : CharacterBody2D
{
	[Export] public float Speed = 90.0f;
	private Node2D player;

	public override void _Ready()
	{
		player = GetNode<Node2D>("../Player");
	}

	public override void _PhysicsProcess(double delta)
	{
		if (player == null)
		{
			return;
		}

		Vector2 direction = (player.GlobalPosition - GlobalPosition).Normalized();

		Velocity = direction * Speed;
		MoveAndSlide();
	}
}
