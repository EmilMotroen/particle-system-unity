using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    [SerializeField] private ParticleSystem part;

    private void Start()
    {
        part = GetComponent<ParticleSystem>();
        Invoke("StartParticles", 3);
        Debug.Log("Waiting 3 seconds...");
    }

    private void StartParticles()
    {
        part.Play();
    }
}
