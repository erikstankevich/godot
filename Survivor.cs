using Godot;
using System;

public partial class Survivor : CharacterBody2D
{
	[Export] public float Speed = 200f;
	[Export] public float CollisionMargin = 0.5f; // tiny offset to avoid sticking

	private CollisionShape2D shape;

	public override void _Ready()
	{
		shape = GetNode<CollisionShape2D>("CollisionShape2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 input = Vector2.Zero;
		if (Input.IsKeyPressed(Key.W)) input.Y -= 1;
		if (Input.IsKeyPressed(Key.S)) input.Y += 1;
		if (Input.IsKeyPressed(Key.A)) input.X -= 1;
		if (Input.IsKeyPressed(Key.D)) input.X += 1;
		input = input.Normalized();

		Vector2 desiredMove = input * Speed * (float)delta;
		if (desiredMove == Vector2.Zero)
			return;

		var spaceState = GetWorld2D().DirectSpaceState;
		var shapeOwner = shape.Shape;

		PhysicsShapeQueryParameters2D query = new()
		{
			Shape = shapeOwner,
			Transform = new Transform2D(0, GlobalPosition),
			Motion = desiredMove,
			Margin = CollisionMargin
		};

		// Cast the shape forward
		float[] castResult = spaceState.CastMotion(query);

		// Safe fraction is the first element
		float safeFraction = castResult[0];
		Vector2 safeMove = desiredMove * safeFraction;
		GlobalPosition += safeMove;

		// Handle sliding if collision occurs
		if (safeFraction < 0.5f)
		{
			var coll = spaceState.GetRestInfo(query);
			if (coll.Count > 0 && coll.ContainsKey("normal"))
			{
				Vector2 normal = (Vector2)coll["normal"];
				Vector2 remainder = desiredMove.Slide(normal) * (1f - safeFraction);
				GlobalPosition += remainder;
			}
		}
	}
}
