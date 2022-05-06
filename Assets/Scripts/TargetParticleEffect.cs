using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;


public class TargetParticleEffect : MonoBehaviour
{
    [SerializeField] ParticleSystem BlueEffect = null;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "projectile")
        {
            BlueEffect.Play();
            
        }
    }
}
