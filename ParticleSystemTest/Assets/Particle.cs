using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    private Particle particle;
	[SerializeField] private TrailRenderer trail;
	[SerializeField] private Rigidbody rb;

	private void Start()
	{
		particle = GetComponent<Particle>();
		//trail.transform.position = particle.transform.position;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Sensor"))
		{
			Debug.Log("Successful hit on sensor " + other.name);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Floor"))
		{
			rb.constraints = RigidbodyConstraints.FreezePositionX |
				RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
		}
	}
}
