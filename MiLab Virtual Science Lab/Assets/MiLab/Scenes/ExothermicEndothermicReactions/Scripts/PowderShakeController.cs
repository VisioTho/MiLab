using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowderShakeController : MonoBehaviour
{
    [SerializeField] private ParticleSystem powderParticles;
    public GameObject arrows;

    private void OnMouseDrag()
    {
        if(!powderParticles.isPlaying)
        {
            arrows.SetActive(false);
            powderParticles.Play();    
        }
        
    }
    private void OnMouseUp()
    {
        arrows.SetActive(true);
        powderParticles.Stop();
    }
}
