using Godot;
using System;

public partial class Parralax : Node2D {

	[Export] private ObstacleManager obstacleManager;
	[Export] private float speedModifier = 1;
	[Export] private Node2D[] parralaxObjects;

	[Export] private float maxDistance;


	public override void _Process(double delta) {
		base._Process(delta);

		float speed = obstacleManager.GetCurrentSpeed() * speedModifier;
		Vector2 change = Vector2.Left * speed * (float) delta;

		foreach (Node2D node in parralaxObjects) {
			node.Position += change;
			HandleOffscreen(node);
		}

	}

	private void HandleOffscreen(Node2D node) {
		if (node.Position.X < -maxDistance) {
			node.Position = new Vector2(maxDistance, node.Position.Y);
		}
	}

}
