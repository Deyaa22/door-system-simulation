using System;
using System.Threading;
using System.Threading.Tasks;

namespace DoorSystem;

public class DoorSystem
{
	public static DoorSystem Instance { get; } = new DoorSystem();
	public Door Door { get; set; }
	public int OpenDoorDurationInSeconds { get; set; } = 1;

	private CancellationTokenSource cts = new CancellationTokenSource();
	private Task task = null;

	private DoorSystem() { }

	public void Trigger()
	{
		if (Door == null)
		{
			Console.WriteLine("No Door Detected !!");
			return;
		}
		task = TriggerAsync();
	}

	private async Task TriggerAsync()
	{
		if (Door.IsOpen)
		{
			cts.Cancel();
			cts = new CancellationTokenSource();
		}
		else
		{
			Console.WriteLine("System: Open the Door");
			Door.Open();
			Task task = null;
			await Task.Delay(OpenDoorDurationInSeconds * 1000, cts.Token).ContinueWith((t) => { task = t; });
			if (task.IsCanceled)
				return;
			Console.WriteLine($"{OpenDoorDurationInSeconds} Seconds finished");
		}

		Console.WriteLine("System: Close the Door");
		Door.Close();
	}
}