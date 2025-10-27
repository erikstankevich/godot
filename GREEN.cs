using Godot;
using System;

public partial class GREEN : Area2D
{
	private float speed = 300f;	
	private Vector2 direction = new Vector2(0, -1);


	public override void _Ready()
	{
		Connect("area_entered", new Callable(this, nameof(OnAreaEntered)));	
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position += speed * direction * (float)delta;
		
		if (Position.Y < 0 || Position.Y > 1000)
		{
			direction.Y *= -1;
		}
	}
	private void OnAreaEntered(Node area)
	{
		if (area.Name == "Player")
		{
			area.Set("global_position", new Vector2(100,100));
		}
	}
}
