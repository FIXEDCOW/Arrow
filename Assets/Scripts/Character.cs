using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
	[SerializeField] protected CameraController cam;
	[SerializeField] private CharacterData data;

	[SerializeField] protected Movement movement;
	[SerializeField] protected Sight sight;
	[SerializeField] protected Auditory auditory;
	[SerializeField] protected Weapon weapon;

	private void Start()
	{
		movement.SetSpeed(data.movementSpeed);
		sight.SetAngularSpeed(data.sightAngularSpeed);
	}
	public void SetCamera(CameraController cameraController)
	{
		cam = cameraController;
	}

	public void Move(Vector2 direction)
	{
		movement.Move(direction);
	}
	public void Stop()
	{
		movement.Stop();
	}
	public void Look(Vector2 mousePosition)
	{
		Vector2 direction = mousePosition - (Vector2)transform.position;
		sight.Look(mousePosition);
		movement.SetSpriteDirection(direction);
	}
	public void MouseDown()
	{
		weapon.MouseDown();
	}
	public void MouseUp()
	{
		weapon.MouseUp();
	}
}
