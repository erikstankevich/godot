using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export] public float Speed = 200f;
	//private Node2D player;


	public override void _Process(double delta)
	{
		Vector2 direction = Vector2.Zero;

		if (Input.IsKeyPressed(Key.W))
		{
			direction.Y -= 1;
		}

		if (Input.IsKeyPressed(Key.S))
		{ 
			direction.Y += 1;
		}

		if (Input.IsKeyPressed(Key.A))
		{
			direction.X -= 1;
		}

		if (Input.IsKeyPressed(Key.D))
		{
			direction.X += 1;
		}

		Velocity = direction.Normalized() * Speed;


		MoveAndSlide();

	}
}
