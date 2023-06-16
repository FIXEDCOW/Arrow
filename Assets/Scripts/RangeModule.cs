using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Material), typeof(SpriteRenderer))]
public class RangeModule : MonoBehaviour
{
	[SerializeField] private Material mat;
	private SpriteRenderer rangeRenderer;

	private float angle;
	private float size;
	private bool alreadyCalled;

	private void Start()
	{
		TryGetComponent(out rangeRenderer);
		rangeRenderer.enabled = false;
	}
	public void InitValue(int initAngle, int initSize)
	{
		rangeRenderer.enabled = true;
		angle = initAngle;
		size = initSize;
		transform.localScale = Vector3.one;
		alreadyCalled = true;
	}
	public void Aiming(int initRangeAngle, int finalRangeAngle, int initRangeSize, int finalRangeSize, int milliSecond)
	{
		if (!alreadyCalled)
			InitValue(initRangeAngle, initRangeSize);
		float t = ((float)milliSecond / 1000);
		angle = Mathf.MoveTowards(angle, finalRangeAngle, initRangeAngle / t * Time.deltaTime);
		angle = Mathf.Clamp(angle, finalRangeAngle, initRangeAngle);
		mat.SetFloat("_Arc1", 180 - angle);
		mat.SetFloat("_Arc2", 180 - angle);
		size = Mathf.MoveTowards(size, finalRangeSize, initRangeSize / t * Time.deltaTime);
		transform.localScale = size * Vector3.one;
	}
	public float Result()
	{
		rangeRenderer.enabled = false;
		alreadyCalled = false;
		return angle;
	}
}