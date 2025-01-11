using System;

namespace DoorSystem;

public interface IListner<T> where T : IEquatable<Sound>
{
	public void Lestin(T sound);
}