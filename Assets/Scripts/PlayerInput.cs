using FunkyCode.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerInput : MonoBehaviour
{
	[SerializeField] private CameraController cam;
	private PlayerController playerController;

	public Vector2 mousePosition
	{
		get { return cam.mousePosition; }
	}
	[SerializeField] private bool mouseLeftDown;
	[SerializeField] private bool mouseRightDown;
	private bool mouseLeftUp;
	private bool mouseRightUp;
	[SerializeField] private Vector2 keyboardDirection;

	private void Start()
	{
		InitializeSetting();
	}
	private void InitializeSetting()
	{
		TryGetComponent(out playerController);
		cam.SetTargetCharacter(playerController.GetCharacter());
		playerController.SetCamera(cam);
	}
	private void Update()
	{
		GetMouseInput();
		GetKeyboardInput();

		SetMouseAction();
		SetKeyboardAction();
	}

	private void GetMouseInput()
	{
		if(Input.GetMouseButtonDown(0))
		{
			mouseLeftDown = true;
		}
		if(Input.GetMouseButtonUp(0))
		{
			mouseLeftDown = false;
			mouseLeftUp = true;
		}
		if(Input.GetMouseButtonDown(1))
		{
			mouseRightDown = true;
		}
		if(Input.GetMouseButtonUp(1))
		{
			mouseRightDown = false;
			mouseRightUp = true;
		}
	}
	private void GetKeyboardInput()
	{
		int x = (int)Input.GetAxisRaw("Horizontal");
		int y = (int)Input.GetAxisRaw("Vertical");

		if (x != 0 || y != 0)
		{
			keyboardDirection = new Vector2(x, y);
		}
		else
		{
			keyboardDirection = Vector2.zero;
		}
	}
	private void SetMouseAction()
	{
		if(mouseLeftDown)
		{
			playerController.MosueDown();
		}
		if(mouseLeftUp)
		{
			playerController.MouseUp();
			mouseLeftUp = false;
		}
		if (mouseRightDown)
		{

		}
		if (mouseRightUp)
		{

			mouseLeftUp = false;
		}
	}
	private void SetKeyboardAction()
	{
		playerController.CharacterMove(keyboardDirection);
		playerController.RotateSight(mousePosition);
	}
}
