using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator))]
public abstract class Weapon : MonoBehaviour
{
	protected SpriteRenderer sr;
	protected Animator animator;
	[SerializeField] protected Sight sight;
	[SerializeField] protected RangeModule range;
	[SerializeField] protected ShotModule shot;
	[SerializeField] protected WeaponData data;

	protected bool cooldown;

	protected virtual void Start()
	{
		TryGetComponent(out sr);
		TryGetComponent(out animator);
	}
	private void Update()
	{
		FollowSight();
	}
	private void FollowSight()
	{
		transform.rotation = Quaternion.Euler(0, 0, Mathf.LerpAngle(transform.rotation.eulerAngles.z, sight.transform.rotation.eulerAngles.z, data.angularSpeed * Time.deltaTime));
		sr.sortingOrder = GetSortingOrderByAngle();
		sr.flipX = GetFlipXByAngle();
	}
	private int GetSortingOrderByAngle()
	{
		return transform.rotation.eulerAngles.z > 90 && transform.rotation.eulerAngles.z < 270 ? 1 : -1;
	}
	private bool GetFlipXByAngle()
	{
		return transform.rotation.eulerAngles.z > 180 && transform.rotation.eulerAngles.z < 360 ? true : false;
	}

	public abstract void MouseDown();
	public abstract void MouseUp();

	protected async UniTask CoolDown(int milliseconds)
	{
		cooldown = true;
		await UniTask.Delay(milliseconds);
		cooldown = false;
	}
}
