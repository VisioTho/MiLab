using UnityEngine;
using UnityEngine.EventSystems;



public class FlintDropHandler : MonoBehaviour, IDropHandler
{
   
    public ParticleSystem flame;
    public AudioSource flintFlick;

 
    public static bool isFlint;
   
    public void OnDrop(PointerEventData data)
    {

        if (data.pointerDrag != null)
        {
            flintFlick.Play();
            if (data.pointerDrag.name == "flint" && FlameController.gasOn)
            {
                flame.Play();

                isFlint = true;
            }
        }

    }
}
