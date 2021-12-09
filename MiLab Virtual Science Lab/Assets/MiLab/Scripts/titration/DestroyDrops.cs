using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyDrops : MonoBehaviour
{
    public GameObject conicalflaskliquid;
    public void OnCollisionEnter(Collision hit)
    {
        Destroy(hit.gameObject);
        conicalflaskliquid.GetComponent<Image>().color = new Color32(255, 105, 180, 255);

    }
}
