using System;
using DoorSystem;
using System.Threading;

namespace PetDoorApplication;

public class PetSimuator
{
	public readonly string Name = nameof(PetSimuator);

	public event Action<Sound> OnMakeSound;

	public PetSimuator(string name = "Pet Simulator")
	{
		Name = name;
	}

	public void MakeSound(Sound sound)
	{
		Console.WriteLine($"Pet: makes sound [{sound.ToString()}]");
		OnMakeSound?.Invoke(sound);
	}
}