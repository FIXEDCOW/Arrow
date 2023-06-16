using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocking : MonoBehaviour
{
	[SerializeField] private float rigidness01 = 0.4f;
	private void OnCollisionEnter2D(Collision2D collision)
	{
		Projectile projectile;
		collision.gameObject.TryGetComponent(out projectile);
		if (projectile != null)
		{
			ProjectileHit(projectile);
		}
	}

	private void ProjectileHit(Projectile projectile)
	{
		float rand = Random.Range(0f, 1f);
		if (rand < rigidness01)
		{
			projectile.Stuck(this);
			projectile.DeactivateAfter(3000).Forget();
		}
		else
		{
			projectile.Bounced(this);
			projectile.DeactivateAfter(3000).Forget();
		}
	}
}
