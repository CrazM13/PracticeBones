using Godot;
using System;

public partial class AnimationController : AnimationPlayer {

	[Export] private Player target;

	private bool wasGrounded = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		Play("Bot_Jump");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {

		bool isGrounded = target.IsOnFloor();

		if (!wasGrounded && isGrounded) {
			Play("Bot_Run");
		} else if (!isGrounded && wasGrounded) {
			Play("Bot_Jump");
			//this.Seek(0, true);
		}

		wasGrounded = isGrounded;

	}
}
