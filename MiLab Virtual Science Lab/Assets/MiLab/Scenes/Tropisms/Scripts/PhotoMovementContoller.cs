using System.Collections;
using System.Collections.Generic;
using UnityEngine;


///<summary>
/// A class for envoking the directional change methods of the 
/// bones scriptable object
/// using it for the button press event so the buttons won't have to have a direct
/// contact with the bones controller scriptable object 
/// so each button envokes a different method as named
///</summary>
public class PhotoMovementContoller : MonoBehaviour
{
    [SerializeField]
    private bonesScriptableObject movementManager;

    public void Right()
    {
        movementManager.moveToRight();
    }


    public void Left()
    {
        movementManager.moveToLeft();
    }

    public void Center()
    {
        movementManager.moveToCenter();
    }


}
