using Godot;
using System;

public partial class Survivor : CharacterBody2D
{
	[Export] public float Speed = 200f;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 direction = Vector2.Zero;

		if (Input.IsKeyPressed(Key.W))
			direction.Y -= 1;
		if (Input.IsKeyPressed(Key.S))
			direction.Y += 1;
		if (Input.IsKeyPressed(Key.A))
			direction.X -= 1;
		if (Input.IsKeyPressed(Key.D))
			direction.X += 1;

		direction = direction.Normalized();

		// Set the velocity based on input
		Velocity = direction * Speed;

		// Move the player manually using MoveAndCollide
		MoveAndCollide(Velocity * (float)delta);
	}
}
