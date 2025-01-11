using System;
using DoorSystem;
using System.Threading;

namespace PetDoorApplication;

public class Program
{
	static void Main(string[] args)
	{
        Simulation1();
        Console.WriteLine("----------------------\n");
		Simulation2();
    }

	static void Simulation1()
	{
		// Simluators
		Sound petSound = new Sound("Cat - Bella - Meow Meaw");
		PetSimuator pet = new PetSimuator();
		RemoteControl controller = new RemoteControl();

		// System Configuation
		var system = DoorSystem.DoorSystem.Instance;
		system.OpenDoorDurationInSeconds = 3; 
		system.Door = new Door();

		// Sensor Configuration
		var sensor = new SoundListenerSensor();
		sensor.Sounds.Add(petSound.SoundInfo, petSound);
		pet.OnMakeSound += sensor.Lestin;


		// Simualtion
		pet.MakeSound(petSound); // open
		controller.Press();		 // close
		controller.Press();		 // open
		Thread.Sleep(5000);		 // after 3 seconds, Door closes automatically.
		Console.WriteLine("Simulation Finished !!\n\n----------------------");
	}

	static void Simulation2()
	{
		// Simluators
		Sound petSound = new Sound("Cat - Bella - Meow Meaw");
		PetSimuator pet = new PetSimuator();
		UserSimulator user = new UserSimulator();
		user.IsAvailable = true;
		RemoteControl controller = new RemoteControl();
		user.remoteControl = controller;

		// System Configuation
		var system = DoorSystem.DoorSystem.Instance;
		system.OpenDoorDurationInSeconds = 3;
		system.Door = new Door();

		// User Configuration
		pet.OnMakeSound += user.Lestin; ;

		// Simualtion
		pet.MakeSound(petSound); // Open
		pet.MakeSound(petSound); // Close
		pet.MakeSound(petSound); // Open
		Thread.Sleep(5000);      // after 3 seconds, Door closes automatically.
		Console.WriteLine("Simulation Finished !!\n\n----------------------");
	}
}