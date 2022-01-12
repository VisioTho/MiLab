using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyDrops : MonoBehaviour
{
    public GameObject titrant1;
    public LiquidControllerScript liquidControllerScript;
    public void OnCollisionEnter(Collision collision)
    {

        Debug.Log("collision detected");
        if (collision.gameObject)
        {
            Destroy(collision.gameObject);
            titrant1.GetComponent<Image>().color = new Color32(233, 85, 188, 150);
            liquidControllerScript.analyteVariation.enabled = false;
            LiquidControllerScript.pipetteDrop = true;
            Destroy(collision.gameObject);
            titrant1.GetComponent<Image>().color = new Color32(233, 85, 188, 150);
        }
    }
}
