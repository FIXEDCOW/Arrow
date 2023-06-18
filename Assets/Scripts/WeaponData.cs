using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Weapon Data", menuName ="Scriptable Object/Weapon Data")]
public class WeaponData : ScriptableObject
{
	public float angularSpeed = 6;
	public int initRangeAngle = 50;
	public int finalRangeAngle = 0;
	public int initRangeSize = 1;
	public int finalRangeSize = 1;
	public int timeToAim = 800;
	public int postDelay = 400;
}
