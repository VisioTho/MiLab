using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyDrops : MonoBehaviour
{
    public GameObject titrant1;
    // public IndicatorDrops indicatorDrops;
    public LiquidControllerScript liquidControllerScript;
    public void OnCollisionEnter(Collision collision)
    {

        Debug.Log("collision detected");
        if (collision.gameObject)
        {
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
            titrant1.GetComponent<Image>().color = new Color32(233, 85, 188, 150);
            liquidControllerScript.analyteVariation.enabled = false;
            liquidControllerScript.pipetteDrop = true;

        }
    }
}
