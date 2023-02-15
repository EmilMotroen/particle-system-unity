using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _particle;
    [SerializeField] private GameObject _spawnBox;


    private int _numberOfParticles = 0;
    private int _maxParticles = 1;
    private float _particleLifetime = 1.5f;

    private void Start()
    {
		if (_numberOfParticles < _maxParticles)
		{
            var particleCopy = Instantiate(_particle);
			++_numberOfParticles;
		}
	}
}
