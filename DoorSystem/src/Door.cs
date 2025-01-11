using System;

namespace DoorSystem;

public class Door
{
	public bool IsOpen { get; private set; } = false;

	public event Action<bool> OnDoorOpen;
	public event Action<bool> OnDoorClose;

	public void Open()
	{
		IsOpen = true;
		OnDoorOpen?.Invoke(IsOpen);
	}

	public void Close()
	{
		if (!IsOpen)
			return;
		IsOpen = false;
		OnDoorClose?.Invoke(IsOpen);
	}
}