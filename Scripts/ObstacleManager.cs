using Godot;
using System;
using System.Collections.Generic;

public partial class ObstacleManager : Node2D {

	[Export] private ObstaclePool pool;
	[Export] private Timer spawnTimer;
	[Export] private float speed;

	[ExportGroup("Difficulty Scale")]
	[Export] private int easeLength = 5;
	[Export] private float difficultyTimeScale = 0.1f;
	[Export] private float difficultyBoost = 2f;
	[Export] private float maxSpeed = 1000f;

	private List<Node2D> activeObstacles;

	private int spawnCount;

	private float initialSpawnTime;

	public override void _Ready() {
		base._Ready();

		activeObstacles = new List<Node2D>();

		initialSpawnTime = (float)spawnTimer.TimeLeft;
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

			spawnCount++;

			spawnTimer.Start(initialSpawnTime * (speed / GetRealSpeed(spawnCount)));
		}
	}

	public override void _Process(double delta) {
		base._Process(delta);


		for (int i = 0; i < activeObstacles.Count; i++) {
			activeObstacles[i].Position += (Vector2.Left * GetRealSpeed(spawnCount) * (float) delta);
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

	private float GetRealSpeed(int count) {
		if (count < easeLength) return speed;

		float x = count * difficultyTimeScale;
		float y = Mathf.Pow(x - easeLength, difficultyBoost);

		if (y + speed > maxSpeed) return maxSpeed;

		return y + speed;
	}

	public float GetCurrentSpeed() {
		return GetRealSpeed(spawnCount);
	}

}
