using Godot;
using System;

public partial class SpriteRandomizer : AnimatedSprite2D {

	[Export] private string[] spriteNames;

	private RandomNumberGenerator rng;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		rng = new RandomNumberGenerator();
		this.Animation = spriteNames[rng.RandiRange(0, spriteNames.Length - 1)];

	}
}
