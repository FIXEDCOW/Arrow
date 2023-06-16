using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Movement : MonoBehaviour
{
	[SerializeField] private SpriteRenderer sr;
	[SerializeField] private Animator anim;
	[SerializeField] private Rigidbody2D rb;

	[SerializeField] private Vector2 direction;
	[ShowInInspector] public Stat speed = new Stat();

	public void SetSpeed(float value) => speed.baseValue = value;
	public void Move(Vector2 direction)
	{
		this.direction = direction.normalized;
		SetAniamationMove(true);
		MovePosition();
	}
	public void Stop()
	{
		SetAniamationMove(false);
	}
	public void SetSpriteDirection(Vector2 direction)
	{
		if (direction.x > 0)
		{
			sr.flipX = true;
		}
		else
		{
			sr.flipX = false;
		}

		if (direction.y <= 0)
		{
			anim.SetBool("up", false);
		}
		else if (direction.y > 0)
		{
			anim.SetBool("up", true);
		}
	}

	private void MovePosition()
	{
		rb.MovePosition(rb.position + direction * speed.Value * Time.deltaTime);
	}
	private void SetAniamationMove(bool isMove)
	{
		anim.SetFloat("moveMult", speed.Value / speed.baseValue);
		anim.SetBool("move", isMove);
	}


}
