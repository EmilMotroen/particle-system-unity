using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _particle;
    [SerializeField] private GameObject _spawnBox;
	[SerializeField] private GameObject _floorBox;
	[SerializeField] private GameObject _alpide;

    public static int _numberOfParticles = 0;
    private int _maxParticles = 5;
	private float _sizeOfBoxX;
	private float _sizeOfBoxZ;

	private void Start()
	{
		SetSpawnboxAndFloorboxSizes();
	}

	/// <summary>
	/// Makes the spawn box and floor box be the same size as the alpide
	/// </summary>
	private void SetSpawnboxAndFloorboxSizes()
	{
		_sizeOfBoxX = _alpide.GetComponent<MeshRenderer>().bounds.size.x;
		_sizeOfBoxZ = _alpide.GetComponent<MeshRenderer>().bounds.size.z;

		_spawnBox.transform.localScale = new Vector3(_sizeOfBoxX, .2f, _sizeOfBoxZ);
		_floorBox.transform.localScale = new Vector3(_sizeOfBoxX, .2f, _sizeOfBoxZ);
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
