using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    [SerializeField] private ParticleSystem part;

    private void Start()
    {
        part = GetComponent<ParticleSystem>();
        StartParticles();
    }

    /// <summary>
    /// Starts the particle simulation
    /// </summary>
    private void StartParticles()
    {
        part.Play();
    }
}
