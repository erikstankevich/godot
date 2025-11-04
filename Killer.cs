using Godot;
using System;

public partial class Killer : CharacterBody2D
{
	public const float Speed = 150f;
	private Node2D survivor;

	public override void _Ready()
	{
		survivor = GetNode<Node2D>("../Survivor");
	}

	public override void _Process(double delta)
	{
		if (survivor == null)
		{
			return;
		}
		Vector2 direction = (survivor.GlobalPosition - GlobalPosition).Normalized();
		 
		GlobalPosition += direction * Speed * (float)delta;
		MoveAndSlide();
	}
}
