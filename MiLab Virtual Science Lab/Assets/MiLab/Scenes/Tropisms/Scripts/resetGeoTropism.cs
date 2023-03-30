using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetGeoTropism : MonoBehaviour
{
   [SerializeField]
    private TreeRotateScriptableObject resetGeotropism;

    public void resetGame()
    {
        resetGeotropism.resetButtonGeo();
    }

}
