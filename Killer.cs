using Godot;
using System;

public partial class Killer : CharacterBody2D
{
	[Export] public float Speed = 150f;
	[Export] public float CollisionMargin = 0.5f;

	private CollisionShape2D shape;
	private Node2D survivor;

	public override void _Ready()
	{
		shape = GetNode<CollisionShape2D>("CollisionShape2D");
		survivor = GetNodeOrNull<Node2D>("../Survivor");

		if (survivor == null)
			GD.PrintErr("Survivor not found!");
	}

	public override void _PhysicsProcess(double delta)
	{
		if (survivor == null || shape == null)
			return;

		// Direction toward survivor
		Vector2 direction = (survivor.GlobalPosition - GlobalPosition).Normalized();
		Vector2 desiredMove = direction * Speed * (float)delta;

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

		// Use CastMotion like Survivor
		float[] castResult = spaceState.CastMotion(query);

		float safeFraction = castResult[0];
		Vector2 safeMove = desiredMove * safeFraction;
		GlobalPosition += safeMove;

		// Sliding along collision
		if (safeFraction < 1.0f)
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
