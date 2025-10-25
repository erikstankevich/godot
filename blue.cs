using Godot;
using System;

public partial class blue : Area2D
{


	private float velocity = 300f;
	private Vector2 axis = new Vector2(0, -1);


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		 Connect("area_entered", new Callable(this, nameof(OnAreaEntered)));
		// InputPickable = true;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position += axis * velocity * (float)delta;

		if (Position.Y < 0  || Position.Y > 1000)
		{	
			axis.Y *= -1;
		}
	}

	private void OnAreaEntered(Node area)
	{
		if (area.Name == "Player")
		{
			area.Set("global_position", new Vector2(0, 0));
		}
	}
}
