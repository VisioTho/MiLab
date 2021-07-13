using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class ItemDropHandler : MonoBehaviour, IDropHandler
{
    // reference to flame particle system
    public ParticleSystem flame;

    
    void Start()
    {
        //no emission of flame particles on wake
        flame.Stop();
    }

    /* start emitting after flint is dragged over bunsen burner
    */
    public void OnDrop(PointerEventData data)
    {
        if (data.pointerDrag != null)
        {
            Debug.Log ("Dropped object was: "  + data.pointerDrag);
            if(data.pointerDrag.name == "flint")
            {
                Debug.Log("hhh");
                flame.Play();
            }
        }
    }
}
