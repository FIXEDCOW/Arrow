using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Stat
{
	[ShowInInspector] public float Value
	{
		get
		{
			if (isChanged)
			{
				float result = baseValue;
				foreach (StatModifier m in mods)
				{
					result *= m.Value;
				}
				lastValue = result;
				isChanged = false;
				return result;
			}
			else
				return lastValue;
		}
	}
	public float baseValue;
	private float lastValue;
	public bool isChanged = true;

	[SerializeField] private List<StatModifier> mods = new List<StatModifier>();

	public void RemoveModsFrom(object origin)
	{
		for(int i = 0; i < mods.Count;)
		{
			if (mods[i].origin == origin)
			{
				mods.RemoveAt(i);
			}
			else
				++i;
		}
		isChanged = true;
	}
	public void AddMods(StatModifier mod)
	{
		mods.Add(mod);
		isChanged = true;
	}
}
