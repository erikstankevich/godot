using Godot;

public partial class Player : Area2D
{
	[Export] public float Speed { get; set; } = 200.0f;

	private Vector2 axis = new Vector2(0, -1);

	private Vector2 originalScale;

	public override void _Ready()
	{
		originalScale = Scale;

		Connect("mouse_entered", new Callable(this, nameof(OnMouseEntered)));
		Connect("mouse_exited", new Callable(this, nameof(OnMouseExited)));
	}

	public override void _Process(double delta)
	{

		Vector2 velocity = Vector2.Zero;

		if (Input.IsPhysicalKeyPressed(Key.W)) velocity.Y -= 1;
		if (Input.IsPhysicalKeyPressed(Key.S)) velocity.Y += 1;
		if (Input.IsPhysicalKeyPressed(Key.A)) velocity.X -= 1;
		if (Input.IsPhysicalKeyPressed(Key.D)) velocity.X += 1;

		if (velocity != Vector2.Zero)
			Position += velocity.Normalized() * Speed * (float)delta;
	}

	public override void _InputEvent(Viewport viewport, InputEvent @event, int shapeIdx)
	{
		if (@event is InputEventMouseButton mouseEvent)
		{
			if (mouseEvent.Pressed && mouseEvent.ButtonIndex == MouseButton.Left)
			{
				GD.Print("Player was clicked!");
			}
		}
	}

	public void OnMouseEntered()
	{
		GD.Print("Hovered Player");
		Scale = originalScale * 1.1f;

	}
	public void OnMouseExited()
	{
		GD.Print("Mouse left Red2.");
		Scale = originalScale;
	}
}
