using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToDestroy : MonoBehaviour
{
    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
