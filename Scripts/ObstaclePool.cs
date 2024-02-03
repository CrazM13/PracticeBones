using Godot;
using System;
using System.Collections;
using System.Collections.Generic;

public partial class ObstaclePool : Node2D {

	[Export] private PackedScene obstaclePrefab;
	[Export] private int maxObjects = 10;

	private Queue<Node2D> inactiveObjects;

	public override void _Ready() {
		base._Ready();

		inactiveObjects = new Queue<Node2D>();
		
		for (int i = 0; i < maxObjects; i++) {
			Node2D newObject = obstaclePrefab.Instantiate<Node2D>();
			inactiveObjects.Enqueue(newObject);
		}
	}

	public Node2D Spawn() {
		if (inactiveObjects.Count > 0) {
			Node2D newObject = inactiveObjects.Dequeue();

			return newObject;
		} else return null;
	}

	public void Despawn(Node2D obj) {
		obj.GetParent().RemoveChild(obj);

		inactiveObjects.Enqueue(obj);
	}

}
