using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
	[SerializeField] private float angularSpeed = 12f;

	public void SetAngularSpeed(float value) => angularSpeed = value;
	public void Look(Vector2 mousePosition)
	{
		Vector2 direction = mousePosition - (Vector2)transform.position;
		Quaternion targetRot = Quaternion.FromToRotation(Vector3.up, direction);
		transform.rotation = Quaternion.Euler(0, 0, Mathf.LerpAngle(transform.rotation.eulerAngles.z, targetRot.eulerAngles.z, angularSpeed * Time.deltaTime));
	}
}
