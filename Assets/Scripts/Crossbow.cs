using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbow : Weapon
{
	public override void MouseDown()
	{
		Fire();
	}
	public override void MouseUp()
	{

	}
	private void Fire()
	{
		if (cooldown)
			return;
		animator.SetTrigger("fire");
		range.InitValue(data.initRangeAngle, data.initRangeSize);
		float spread = range.Result();
		shot.Fire(spread);
		CoolDown(data.postDelay).Forget();
	}
	protected override async UniTask CoolDown(int milliseconds)
	{
		await base.CoolDown(milliseconds);
		animator.SetTrigger("reload");
	}
}
