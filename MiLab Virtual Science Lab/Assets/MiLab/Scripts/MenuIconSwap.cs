using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuIconSwap : MonoBehaviour
{
    Color newColor;

    public void SwapColor(GameObject image)
    {
        image.GetComponent<Image>().color = new Color32(97, 15, 106, 255);
        image.GetComponentInChildren<TMP_Text>().color = new Color32(97, 15, 106, 255);
    }

    public void ResetColor(GameObject image)
    {
        image.GetComponent<Image>().color = new Color32(183, 183, 183, 255);
        image.GetComponentInChildren<TMP_Text>().color = new Color32(183, 183, 183, 255);
    }

}
