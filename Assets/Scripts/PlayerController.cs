using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private Character character;

	public void SetCamera(CameraController cam)
	{
		character.SetCamera(cam);
	}
	public Character GetCharacter() { return character; }

	public void CharacterMove(Vector2 keyboardDirection)
	{
		if (keyboardDirection != Vector2.zero)
		{
			character.Move(keyboardDirection);
		}
		else
		{
			character.Stop();
		}
	}
	public void RotateSight(Vector2 mousePosition)
	{
		character.Look(mousePosition);
	}
	public void MosueDown()
	{
		character.MouseDown();
	}
	public void MouseUp()
	{ 
		character.MouseUp(); 
	}
}
