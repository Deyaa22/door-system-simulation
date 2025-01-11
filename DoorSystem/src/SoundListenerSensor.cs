using System;
using System.Collections.Generic;

namespace DoorSystem;

public class SoundListenerSensor : IListner<Sound>
{
	public bool IsAvailable { get; set; } = true;

	public readonly Dictionary<string, Sound> Sounds = new Dictionary<string, Sound>();

	/// <summary>
	/// Should be called or Subscribed from outside.
	/// </summary>
	/// <param name="sound"></param>
	public void Lestin(Sound sound)
	{
		if (!IsAvailable)
			return;

		Console.WriteLine($"Sensor: Listen to sound [{sound}]");
		if (!RecognizeSound(sound))
			return;

		DoorSystem.Instance.Trigger();
	}

	private bool RecognizeSound(Sound sound)
	{
		bool soundRecognized = Sounds.ContainsKey(sound.SoundInfo);

		if (!soundRecognized)
			Console.WriteLine($"Sensor: sound isn't recognized, it does not match any registered sound.");
		else
			Console.WriteLine($"Sensor: sound recognized.");

		return soundRecognized;
	}
}