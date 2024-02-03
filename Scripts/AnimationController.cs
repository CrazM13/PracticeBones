using Godot;
using System;

public partial class AnimationController : AnimationPlayer {

	[Export] private Player target;

	private bool wasGrounded = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		// TODO play "Jump"
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {

		bool isGrounded = target.IsOnFloor();

		if (!wasGrounded && isGrounded) {
			// TODO play "Walk"
		} else if (!isGrounded && wasGrounded) {
			// TODO play "Jump"
		}

	}
}
