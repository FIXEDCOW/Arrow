using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footprint : MonoBehaviour
{
	[SerializeField] private Sight sight;
	private ParticleSystem ps;
	private ParticleSystem.MainModule main;

	private void Awake()
	{
		TryGetComponent(out ps);
		main = ps.main;
	}

	private void Update()
	{
		main.startRotation = sight.transform.rotation.eulerAngles.z;
	}
}
