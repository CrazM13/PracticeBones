using Godot;
using System;
using System.Collections.Generic;

public partial class ObstacleManager : Node2D {

	[Export] private ObstaclePool pool;
	[Export] private float speed;

	private List<Node2D> activeObstacles;

	public override void _Ready() {
		base._Ready();

		activeObstacles = new List<Node2D>();
	}

	public void Spawn() {
		Node2D node = pool.Spawn();

		if (node != null) {
			AddChild(node);

			node.GlobalPosition = this.GlobalPosition;
			activeObstacles.Add(node);

			if (node is Obstacle obstacle) {
				obstacle.Manager = this;
			}
		}
	}

	public override void _Process(double delta) {
		base._Process(delta);


		for (int i = 0; i < activeObstacles.Count; i++) {
			activeObstacles[i].Position += (Vector2.Left * speed * (float) delta);
		}
	}

	public void Remove(Node2D obsticle) {
		if (activeObstacles.Contains(obsticle)) {
			activeObstacles.Remove(obsticle);
		}

		if (obsticle is Obstacle o) {
			o.Manager = null;
		}

		pool.Despawn(obsticle);
	}

}
