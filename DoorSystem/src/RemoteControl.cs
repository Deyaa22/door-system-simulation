namespace DoorSystem;

public class RemoteControl
{
	public void Press()
	{
		DoorSystem.Instance.Trigger();
	}
}