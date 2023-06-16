using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatModifier
{
	public object origin;
	public float Value;

	public StatModifier(object origin, float value)
	{
		this.origin = origin;
		this.Value = value;
	}
}
