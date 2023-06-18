using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Material), typeof(SpriteRenderer))]
public class RangeModule : MonoBehaviour
{
	private Renderer r;
	private MaterialPropertyBlock mpb;
	private SpriteRenderer rangeRenderer;

	private float angle;
	private float size = 1;
	private bool alreadyCalled;
	[SerializeField] private bool alwaysShowRange;

	private void Awake()
	{
		TryGetComponent(out rangeRenderer);
		TryGetComponent(out r);
		mpb = new MaterialPropertyBlock();
		SetMPBTexture();
	}
	private void SetMPBTexture()
	{
		SpriteRenderer sr;
		TryGetComponent(out sr);
		Texture2D tex = sr.sprite.texture;
		mpb.SetTexture("_MainTex", tex);
		r.SetPropertyBlock(mpb);
	}
	private void Start()
	{
		if (!alwaysShowRange)
			rangeRenderer.enabled = false;
	}
	public void InitValue(int initAngle, int initSize)
	{
		rangeRenderer.enabled = true;
		angle = initAngle;
		size = initSize;
		transform.localScale = Vector3.one;
		ChangeRange(angle);
		alreadyCalled = true;
	}
	public void Aiming(int initRangeAngle, int finalRangeAngle, int initRangeSize, int finalRangeSize, int milliSecond)
	{
		if (!alreadyCalled)
			InitValue(initRangeAngle, initRangeSize);
		float t = ((float)milliSecond / 1000);
		angle = Mathf.MoveTowards(angle, finalRangeAngle, initRangeAngle / t * Time.deltaTime);
		angle = Mathf.Clamp(angle, finalRangeAngle, initRangeAngle);
		ChangeRange(angle);
		size = Mathf.MoveTowards(size, finalRangeSize, initRangeSize / t * Time.deltaTime);
		transform.localScale = size * Vector3.one;
	}
	public float Result()
	{
		if(!alwaysShowRange)
			rangeRenderer.enabled = false;
		alreadyCalled = false;
		return angle;
	}
	private void ChangeRange(float angle)
	{
		mpb.SetFloat("_Arc1", 180 - angle);
		mpb.SetFloat("_Arc2", 180 - angle);
		r.SetPropertyBlock(mpb);
	}
}