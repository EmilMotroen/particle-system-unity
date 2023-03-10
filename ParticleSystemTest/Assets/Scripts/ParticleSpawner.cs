using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _particle;
    [SerializeField] private GameObject _spawnBox;
	[SerializeField] private GameObject _floorBox;
	[SerializeField] private GameObject _pixel;

	public Material NoHit;
	public Material OnHit;
    public static int NumberOfParticles = 0;
    
	private int _maxParticles = 5;
	private readonly int numPixelsX = 5;
	private readonly int numPixelsZ = 5;
	private readonly int layers = 2;
	private float _distance = 10.0f;
	private float _sizeOfBoxX;
	private float _sizeOfBoxZ;
	private Vector3 _pixelPos;

	private void Start()
	{
		GetSizesOfPixels();
		PixelSetup();
		SetSpawnboxAndFloorboxSizesAndPositions();
	}

	/// <summary>
	/// Makes the spawn box and floor box be the same size as the alpide and positions them on the
	/// same x and z positions
	/// </summary>
	private void SetSpawnboxAndFloorboxSizesAndPositions()
	{
		float spawnBoxHeight = _pixelPos.y + _distance;
		float floorBoxHeight = _pixelPos.y - _distance;

		_spawnBox.transform.position = new Vector3(_pixelPos.x, spawnBoxHeight, _pixelPos.z);
		_floorBox.transform.position = new Vector3(_pixelPos.x, floorBoxHeight, _pixelPos.z);

		_spawnBox.transform.localScale = new Vector3(10 + _sizeOfBoxX * numPixelsX + 10,
			.2f, 10 + _sizeOfBoxZ * numPixelsZ + 10);
		_floorBox.transform.localScale = new Vector3(10 + _sizeOfBoxX * numPixelsX + 10,
			.2f, 10 + _sizeOfBoxZ * numPixelsZ + 10);
	}

	private void GetSizesOfPixels()
	{
		_sizeOfBoxX = _pixel.GetComponent<MeshRenderer>().bounds.size.x;
		_sizeOfBoxZ = _pixel.GetComponent<MeshRenderer>().bounds.size.z;
		_pixel.GetComponent<Transform>().position = new Vector3(_sizeOfBoxX, 0, _sizeOfBoxZ);
		_pixelPos = _pixel.GetComponent<Transform>().position;
	}

	private void Update()
    {
		if (NumberOfParticles < _maxParticles)
		{
			if (Input.GetButtonDown("newParticle"))
			{
				var position = new Vector3(Random.Range(0, _sizeOfBoxX * numPixelsX), 
					_distance, Random.Range(0, _sizeOfBoxZ * numPixelsZ));
				Instantiate(_particle, position, Quaternion.identity);
				++NumberOfParticles;
			}	
		}
	}

	/// <summary>
	/// Instantiate the pixels in a grid, including stacking them
	/// </summary>
	private void PixelSetup()
	{
		float layerDistance = 1.0f;
		for (int layer = 0; layer < layers; ++layer)
		{
			for (int pixelsXDirection = 0; pixelsXDirection < numPixelsX; ++pixelsXDirection)
			{
				for (int pixelsZDirection = 0; pixelsZDirection < numPixelsZ; ++pixelsZDirection)
				{
					var pixelPos = new Vector3(pixelsXDirection + _sizeOfBoxX,
						layerDistance - layer, pixelsZDirection + _sizeOfBoxZ);
					var pixelCopy = Instantiate(_pixel, pixelPos, Quaternion.identity);
					//pixelCopy.GetComponent<Renderer>().material = NoHit;
					pixelCopy.name = $"pixel_{pixelsXDirection}_{pixelsZDirection}_{layer}";
				}
			}
		}
	}
}
