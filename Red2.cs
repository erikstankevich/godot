using Godot;
using System;

public partial class Red2 : Area2D
{
	public override void _Ready()
	{
		// Correct signal connection
		Connect("area_entered", new Callable(this, nameof(OnAreaEntered)));
	}

	private void OnAreaEntered(Node area)
	{
		if (area.Name == "Player")
		{
			GD.Print("Player touched red square!");
			area.Set("global_position", new Vector2(0, 0));
		}
	}
}
