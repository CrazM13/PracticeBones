using Godot;
using System;

public partial class Obstacle : Area2D {
	
	public ObstacleManager Manager {  get; set; }

	bool isOnScreen = false;

	private void OnLeaveScreen() {
		if (isOnScreen) Manager?.Remove(this);

		isOnScreen = false;
	}

	private void OnEnterScreen() {
		isOnScreen = true;
	}

	private void OnBodyEntered(Node2D body) {
		if (body is Player player) {
			player.OnDie();
		}
	}

}
