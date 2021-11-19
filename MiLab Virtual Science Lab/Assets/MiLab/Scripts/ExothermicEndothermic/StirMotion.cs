using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StirMotion : MonoBehaviour
{
    public GameObject[] objectsToStir;
    
    public void Stir()
    {
        foreach(GameObject i in objectsToStir)
        {
            i.LeanMoveLocalX(0.2f, 0.2f).setOnComplete(StirBack);
        }
    }

    void StirBack()
    {
        foreach (GameObject i in objectsToStir)
        {
            i.LeanMoveLocalX(0.2f, 0.2f);
        }
    }
}
