using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowderShakeController : MonoBehaviour
{
    [SerializeField] private ParticleSystem powderParticles;
    private bool spoonIsInPosition; // is in position to drop some nitrate
    private bool canEmitPowder;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Spoon Area Pottasium")
        {
            spoonIsInPosition = true;

            if (canEmitPowder && spoonIsInPosition)
            {
                if (!powderParticles.isPlaying)
                {
                    powderParticles.Emit(5);
                    TemperatureReaction.numberOfSpoons += 1;
                    canEmitPowder = false;
                }
            }
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Petri Dish Pottasium")
        {
            canEmitPowder = true;
            Debug.Log("can emit");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Spoon Area Pottasium")
        {
            spoonIsInPosition = false;

        }

    }

    private void OnMouseDrag()
    {
        
        
    }
    private void OnMouseUp()
    {
        
        
    }
}
