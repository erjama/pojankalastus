using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBlood : MonoBehaviour
{
    public ParticleSystem particleSystem; // Reference to the Particle System

    void Start()
    {
        // Ensure the particle system reference is assigned
        if (particleSystem != null)
        {
            //particleSystem.Play(); // Start the particle effect
        }
        else
        {
            Debug.LogWarning("ParticleSystem not assigned!");
        }
    }

    // Alternatively, you can call this method to start the particle effect at any time
    public void TriggerParticleEffect()
    {
        if (particleSystem != null)
        {
            particleSystem.Play();
        }
    }
}
