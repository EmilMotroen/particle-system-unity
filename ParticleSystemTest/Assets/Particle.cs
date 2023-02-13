using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    [HideInInspector] private Particle particle;
	[SerializeField]  private TrailRenderer trail;

	private void Start()
	{
		particle = GetComponent<Particle>();
		trail.transform.position = particle.transform.position;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Sensor"))
		{
			Debug.Log("Successful hit");
		}
	}
}
