using System;
using DoorSystem;

namespace PetDoorApplication;

public class UserSimulator : IListner<Sound>
{
	public bool IsAvailable { get; set; } = false;

	public RemoteControl remoteControl { get; set; }

	public void Lestin(Sound sound)
	{
		if (!IsAvailable)
			return;

		Console.WriteLine($"User hears pet's sound [{sound}]");
		if (remoteControl is not null)
		{
			Console.WriteLine("User presses the controller's button.");
			remoteControl.Press();
		}
	}
}