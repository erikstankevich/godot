using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export] public float Speed = 200f;
	//private Node2D player;
	//
	private float _currentSpeed;
	private bool _isInSlowZone = false;

	public override void _Ready()
	{
		_currentSpeed = Speed;
	}


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

		Velocity = direction.Normalized() * _currentSpeed;
		MoveAndSlide();

	}

	public void _on_slow_2d_body_entered(Node2D body)
	{
		if (body == this)
		{
			_isInSlowZone = true;
			_currentSpeed = Speed * 0.1f;
		}
	}
	
	public void _on_slow_2d_body_exited(Node2D body)
	{
		if (body == this)
		{
			_isInSlowZone = false;
			_currentSpeed = Speed;
		}
	}
	
}
