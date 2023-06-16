using FunkyCode.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
	private Camera cam;
	private Character character;

	public Vector2 mousePosition
	{
		get { return cam.ScreenToWorldPoint(Input.mousePosition); }
	}
	private Vector2 characterPosition
	{
		get { return character.transform.position; }
	}
	[SerializeField] private float maxDistance = 3; //TODO Scriptable Object cameraData;
	private const float MIN_DISTANCE = 0;
	[SerializeField] private float maxMouseDistance = 9;

	private void Start()
	{
		TryGetComponent(out cam);
	}
	private void Update()
	{
		FollowCursor();
	}
	private void FollowCursor()
	{
		Vector3 charPos = characterPosition;
		charPos.z = -10;
		Vector3 camPos = characterPosition + (GetDirection() * Mathf.Clamp(GetDistance(), MIN_DISTANCE, maxDistance));
		camPos.z = -10;
		transform.position = Vector3.Lerp(charPos, camPos, GetDistance() / maxMouseDistance);
	}
	private Vector2 GetDirection()
	{
		return (mousePosition - characterPosition).normalized;
	}
	private float GetDistance()
	{
		float distance = Vector3.Distance(characterPosition, mousePosition);
		return distance;
	}
	public void SetTargetCharacter(Character character)
	{
		this.character = character;
	}
}
