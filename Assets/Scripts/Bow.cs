using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;

public class Bow : Weapon
{
	[SerializeField] private Movement movement;
	private bool alreadySlow = false;
	[ShowInInspector] StatModifier slowByBowAiming;

	protected override void Start()
	{
		base.Start();
		slowByBowAiming = new StatModifier(this, 0.6f);
	}
	public override void MouseDown()
	{
		Aiming();
	}
	public override void MouseUp()
	{
		Fire();
	}
	private void Aiming()
	{
		if (cooldown)
			return;
		AddSlowMod();
		animator.SetBool("mouseDown", true);
		range.Aiming(data.initRangeAngle, data.finalRangeAngle, data.initRangeSize, data.finalRangeSize, data.timeToAim);
	}
	private void AddSlowMod()
	{
		if (alreadySlow)
			return;
		movement.speed.AddMods(slowByBowAiming);
		alreadySlow = true;
	}
	private void RemoveSlowMod()
	{
		movement.speed.RemoveModsFrom(this);
		alreadySlow = false;
	}
	private void Fire()
	{
		if (cooldown)
			return;
		RemoveSlowMod();
		animator.SetBool("mouseDown", false);
		float spread = range.Result();
		shot.Fire(spread);
		CoolDown(data.postDelay).Forget();
	}
}
