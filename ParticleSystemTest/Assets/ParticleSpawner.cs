using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _particle;
    [SerializeField] private GameObject _spawnBox;

    public static int _numberOfParticles = 0;
    private int _maxParticles = 5;

    private void Start()
    {
	}

    private void Update()
    {
		if (_numberOfParticles < _maxParticles)
		{
			if (Input.GetButtonDown("newParticle"))
			{
				Instantiate(_particle);
				++_numberOfParticles;
			}	
		}
	}
}
