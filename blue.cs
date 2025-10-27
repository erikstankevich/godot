using Godot;
using System;

public partial class blue : Area2D
{


	private float velocity = 300f;
	private Vector2 axis = new Vector2(0, -1);

	private Vector2 originalScale;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		originalScale = Scale;

		 Connect("area_entered", new Callable(this, nameof(OnAreaEntered)));
		// InputPickable = true;
		//
		Connect("mouse_entered", new Callable(this, nameof(OnMouseEntered)));
		Connect("mouse_exited", new Callable(this, nameof(OnMouseExited)));
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

	private void OnMouseEntered()
	{
		GD.Print("Hovered");
		Scale = originalScale * 1.1f;
	}
	private void OnMouseExited()
	{
		GD.Print("Exited");
		Scale = originalScale;
	}
}
