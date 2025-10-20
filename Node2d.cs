using Godot;

public partial class Node2d : Node2D
{
	[Export] public float Speed { get; set; } = 200.0f;

	public override void _Ready()
	{
		GD.Print("✅ Node2d script running!");
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
}
