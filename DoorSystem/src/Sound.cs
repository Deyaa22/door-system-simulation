using System;

namespace DoorSystem;

public readonly struct Sound : IEquatable<Sound>
{
	public readonly string SoundInfo { get; }

	public Sound(string soundInfo)
	{
		this.SoundInfo = soundInfo;
	}

	public override string ToString()
	{
		return SoundInfo;
	}

	public static implicit operator Sound(string soundInfo)
	{
		return new Sound(soundInfo);
	}

	public static bool operator ==(Sound sound1, Sound sound2) { return sound1.Equals(sound2); }
	public static bool operator !=(Sound sound1, Sound sound2) { return !sound1.Equals(sound2); }

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public bool Equals(Sound sound)
	{
		return this.GetHashCode() == sound.GetHashCode();
	}

	public override bool Equals(object other)
	{
		return other is not null && this.GetHashCode() == ((Sound)other).GetHashCode();
	}
}