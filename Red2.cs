using Godot;
using System;

public partial class Red2 : Area2D
{
	public override void _Ready()
	{
		// Correct signal connection
		Connect("area_entered", new Callable(this, nameof(OnAreaEntered)));
		InputPickable = true;
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
}
