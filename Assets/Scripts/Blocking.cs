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
		Vector2 point = collision.GetContact(0).point;
		collision.gameObject.TryGetComponent(out projectile);
		if (projectile != null)
		{
			ProjectileHit(projectile, point);
		}
	}

	private void ProjectileHit(Projectile projectile, Vector2 point)
	{
		float rand = Random.Range(0f, 1f);
		if (rand < rigidness01)
		{
			projectile.Stuck(this);
			projectile.DeactivateAfter(3000).Forget();
		}
		else
		{
			projectile.Bounced();
			projectile.DeactivateAfter(3000).Forget();
		}
	}
}
