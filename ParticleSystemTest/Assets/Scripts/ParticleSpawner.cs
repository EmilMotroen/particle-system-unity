using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _particle;
    [SerializeField] private GameObject _spawnBox;
	[SerializeField] private GameObject _floorBox;
	[SerializeField] private GameObject _alpide;

    public static int _numberOfParticles = 0;
    
	private int _maxParticles = 5;
	private float _distance = 15.0f;
	private float _sizeOfBoxX;
	private float _sizeOfBoxZ;
	private Vector3 _alpidePos;

	private void Start()
	{
		SetSpawnboxAndFloorboxSizesAndPositions();
	}

	/// <summary>
	/// Makes the spawn box and floor box be the same size as the alpide and positions them on the
	/// same x and z positions
	/// </summary>
	private void SetSpawnboxAndFloorboxSizesAndPositions()
	{
		_sizeOfBoxX = _alpide.GetComponent<MeshRenderer>().bounds.size.x;
		_sizeOfBoxZ = _alpide.GetComponent<MeshRenderer>().bounds.size.z;
		_alpide.GetComponent<Transform>().position = new Vector3(_sizeOfBoxX / 2, 0, _sizeOfBoxZ / 2);
		_alpidePos = _alpide.GetComponent<Transform>().position;

		float spawnBoxHeight = _alpidePos.y + _distance;
		float floorBoxHeight = _alpidePos.y - _distance;

		_spawnBox.transform.position = new Vector3(_alpidePos.x, spawnBoxHeight, _alpidePos.z);
		_floorBox.transform.position = new Vector3(_alpidePos.x, floorBoxHeight, _alpidePos.z);

		_spawnBox.transform.localScale = new Vector3(_sizeOfBoxX, .2f, _sizeOfBoxZ);
		_floorBox.transform.localScale = new Vector3(_sizeOfBoxX * 10, .2f, _sizeOfBoxZ * 10);
	}

	private void Update()
    {
		if (_numberOfParticles < _maxParticles)
		{
			if (Input.GetButtonDown("newParticle"))
			{
				var position = new Vector3(Random.Range(0, _sizeOfBoxX), _distance, Random.Range(0, _sizeOfBoxZ));
				Instantiate(_particle, position, Quaternion.identity);
				++_numberOfParticles;
			}	
		}
	}
}
