using Godot;
using System;

public partial class Player : CharacterBody2D {

	[Export] private float jumpVelocity = -400.0f;

	[Signal]
	public delegate void OnDeathEventHandler();

	private Vector2 startingPosition;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _Ready() {
		base._Ready();

		startingPosition = this.GlobalPosition;
	}

	public override void _PhysicsProcess(double delta) {
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor()) {
			velocity.Y += gravity * (float) delta;
		}

		// Handle Jump.
		if (Input.IsActionPressed("ui_accept") && IsOnFloor()) {
			velocity.Y = jumpVelocity;
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	public void OnDie() {
		this.GlobalPosition = startingPosition;

		EmitSignal(SignalName.OnDeath);
	}

}
