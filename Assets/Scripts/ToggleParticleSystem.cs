using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZombieRun
{
    public class ToggleParticleSystem : ToggleByDistance
    {
        private ParticleSystem mParticleSystem;

        void Start()
        {
            mParticleSystem = GetComponent<ParticleSystem>();
        }

        void Update()
        {
                CheckForDistance();
                ParticleSystem.EmissionModule em = mParticleSystem.emission;
                em.enabled = Toggle;
        }
    }
}
