using Cysharp.Threading.Tasks;
using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Projectile
{
	private const float distortionAmount = 0.7f;
	private const float distortionDuration = 0.2f;
	protected override void OnEnable()
	{
		base.OnEnable();
		rb.bodyType = RigidbodyType2D.Kinematic;
		transform.SetParent(null);
	}
	public override void Stuck(Blocking target)
	{
		rb.bodyType = RigidbodyType2D.Static;
		transform.parent = target.transform;
		transform.DOMove(transform.position, distortionDuration).From(transform.position + transform.up * ((1 - distortionAmount) / 2));
		transform.DOScaleY(1f, distortionDuration).From(distortionAmount);
	}
	public override void Bounced(Blocking target)
	{
		rb.velocity = Vector2.zero;
		Vector2 dir = transform.position - target.transform.position;
		dir = dir.normalized;
		transform.DOJump(dir * 0.6f + new Vector2(Random.Range(-0.2f,0.2f), Random.Range(-0.2f, 0.2f)), Random.Range(0.4f, 0.6f), 1, 0.6f).SetRelative();
		int sign = Random.value < 0.5 ? 1 : -1;
		transform.DORotate(transform.rotation.eulerAngles + sign * new Vector3(0, 0, Random.Range(30, 80)), Random.Range(0.4f, 0.6f));
	}
}
