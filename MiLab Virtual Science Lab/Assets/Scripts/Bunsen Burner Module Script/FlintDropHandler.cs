using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class FlintDropHandler : MonoBehaviour, IDropHandler
{
    // reference to flame particle system
    [SerializeField] private ParticleSystem flame;
    [SerializeField] private AudioSource flintFlick;

    //tells if flint object has been dropped over bunsen burner
    public static bool isFlint;
    void Start()
    {
      
    }

    /* start emitting after flint is dragged over bunsen burner
    */
    public void OnDrop(PointerEventData data)
    {
        Debug.Log("dropped");
        if (data.pointerDrag != null)
        {      
            flintFlick.Play();
            if(data.pointerDrag.name == "flint" && FlameController.isOpened)
            {
                flame.Play();  
                isFlint = true;
            }
        }
    }
}
