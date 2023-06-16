using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character Data", menuName = "Scriptable Object/Character Data")]
public class CharacterData : ScriptableObject
{
	public WeaponData weaponData;
	public float sightAngularSpeed = 12f;
	public float movementSpeed = 6f;
}
