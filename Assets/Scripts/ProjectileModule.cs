using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileModule : ShotModule
{
	[SerializeField] private GameObject bullet;
	private List<GameObject> bullets = new List<GameObject>();
	[SerializeField] private float projectileVelocity = 30;
	public override void Fire(float spreadRange)
	{
		InstantiateBullet(spreadRange);
	}
	private void InstantiateBullet(float spreadRange)
	{
		Projectile projectile;
		GameObject cur = null;
		for(int i = 0; i < bullets.Count; ++i)
		{
			if (!bullets[i].activeSelf)
			{
				cur = bullets[i];
				break;
			}
		}
		if (cur != null)
		{
			cur.transform.position = transform.position;
			cur.SetActive(true);
			cur.TryGetComponent(out projectile);
			projectile.SetVelocity(transform.rotation, spreadRange, projectileVelocity);
		}
		else
		{
			cur = Instantiate(bullet) as GameObject;
			cur.transform.position = transform.position;
			cur.TryGetComponent(out projectile);
			projectile.SetVelocity(transform.rotation, spreadRange, projectileVelocity);
			bullets.Add(cur);
		}
	}
}
