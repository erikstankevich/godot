using Godot;
using System;

public partial class Door : Area2D
{
	private CollisionShape2D _collisionShape;

	public override void _Ready()
	{
		BodyEntered += OnBodyEntered;

		_collisionShape = GetNode <CollisionShape2D>("CollisionShape2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public void OnBodyEntered(Node2D body)
	{
		float width = 0;
		var shape = _collisionShape.Shape;
		

		if (shape is RectangleShape2D rect)
			width = rect.Size.X;


		float direction = Math.Sign(GlobalPosition.X - body.GlobalPosition.X);

 

		if (body.Name == "Survivor")
		{
			body.GlobalPosition += new Vector2(direction * width*2 , 0);
		}
	}
}
