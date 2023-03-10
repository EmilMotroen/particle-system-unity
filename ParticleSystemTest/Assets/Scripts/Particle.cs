using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    private Particle _particle;
	[SerializeField] private TrailRenderer _trail;
	[SerializeField] private Rigidbody _rb;

	private float _particleLifetime = 10.0f;

	private void Start()
	{
		_particle = GetComponent<Particle>();
		//trail.transform.position = particle.transform.position;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Sensor"))
		{
			Debug.Log("Successful hit on sensor " + other.name);
		}
		if (other.CompareTag("Floor"))
		{
			// Freeze particle to prevent it from moving forever
			_rb.constraints = RigidbodyConstraints.FreezePositionX |
				RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
			Destroy(gameObject, _particleLifetime);
			ParticleSpawner.NumberOfParticles--;  // Create new particles when one hits the floor
		}
	}
}
