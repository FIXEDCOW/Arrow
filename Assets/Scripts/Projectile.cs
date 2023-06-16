using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Threading;

public abstract class Projectile : MonoBehaviour
{
	[SerializeField] protected SpriteRenderer sr;
	[SerializeField] protected Rigidbody2D rb;

	[ShowInInspector] private CancellationTokenSource cancellationTokenSource;

	private void OnDestroy()
	{
		cancellationTokenSource.Dispose();
	}
	protected virtual void OnEnable()
	{
		if (cancellationTokenSource != null)
		{
			cancellationTokenSource.Dispose();
		}
		cancellationTokenSource = new CancellationTokenSource();
		sr.DOFade(1, 0);
	}
	protected void OnDisable()
	{
		cancellationTokenSource.Cancel();
	}

	public void SetVelocity(Quaternion rot, float angle, float velocity)
	{
		transform.rotation = rot;
		transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + Random.Range(-angle, angle));
		rb.velocity = transform.up * velocity;
		DeactivateAfter(5000).Forget();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Character character;
		collision.TryGetComponent(out character);
		if(character != null)
		{
			Debug.Log("hit!");
		}
	}

	public abstract void Stuck(Blocking target);
	public abstract void Bounced(Blocking target);
	public virtual async UniTask DeactivateAfter(int milliseconds)
	{
		await UniTask.Delay(milliseconds, cancellationToken : cancellationTokenSource.Token);
		await sr.DOFade(0, 2f).WithCancellation(cancellationToken : cancellationTokenSource.Token);
		gameObject.SetActive(false);
	}
}
