using Godot;
using System;

public partial class Red2 : Area2D
{
	private float speed = 100.0f;
	private Vector2 direction = new Vector2(0, 1);



	public override void _Ready()
	{
		// Correct signal connection
		Connect("area_entered", new Callable(this, nameof(OnAreaEntered)));
		InputPickable = true;


		Connect("mouse_entered", new Callable(this, nameof(OnMouseEntered)));
		Connect("mouse_exited", new Callable(this, nameof(OnMouseExited)));
	}

	

	public override void _InputEvent(Viewport viewport, InputEvent @event, int shapeIdx)
	{
		if (@event is InputEventMouseButton mouseEvent)
		{
			if (mouseEvent.Pressed && mouseEvent.ButtonIndex == MouseButton.Left)
			{
				GD.Print("Red2 was clicked!");


				var player = GetNode<Node2D>("/root/Node2D/Player");
				player.GlobalPosition = new Vector2(0, 0);


				

			}
		}
	}



	private void OnAreaEntered(Node area)
	{
		if (area.Name == "Player")
		{
			GD.Print("Player touched red square!");
			area.Set("global_position", new Vector2(0, 0));
		}
	}

	private void OnMouseEntered()
	{
		GD.Print("Hovering over Red2!");
	}
	private void OnMouseExited()
	{
		GD.Print("Mouse left Red2.");
	}


	public override void _Process(double delta)
	{
		Position += direction * speed * (float)delta;

		if (Position.Y > 300 || Position.Y < 0)
		{
			direction.Y *= -1;
		}
	}
}
