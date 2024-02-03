using Godot;
using System;

public partial class Camera : Camera2D {

	[Export] private float decay = 0.9f;
	[Export] private float intensity = 0.9f;

	private float shakeStrength;

	private float shakeTime = 0;

	public void Shake(float strength) {
		shakeStrength = MathF.Max(shakeStrength, strength);
	}

	public override void _Process(double delta) {
		base._Process(delta);

		if (shakeStrength > float.Epsilon) {
			shakeTime += (float) delta * intensity;

			float x = Mathf.Sin(shakeTime * 0.7f) * shakeStrength;
			float y = Mathf.Cos(shakeTime * 0.3f) * shakeStrength;

			this.Position = new Vector2(x, y);

			shakeStrength *= decay;

			if (shakeStrength <= float.Epsilon) {
				shakeTime = 0;
			}
		}
	}

}
