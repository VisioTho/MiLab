using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConicalFlaskVolume : MonoBehaviour
{
    public LiquidControllerScript liquidControllerScript;
    public Image volume;
    public float volumeMax = 100f;
    public float volumeMin = 5f;
    public Slider volumeSlider;
    public TMP_Text volumeNotation;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        volumeMin = Mathf.RoundToInt(volumeSlider.value);
        volume.fillAmount = volumeMin / volumeMax;
        volumeNotation.text = volumeMin.ToString() + " ml";

        if (liquidControllerScript.sliderInstance.value == 2 && liquidControllerScript.fill.CurrentVal > 0)
        {
            volumeSlider.value += 0.0086f;
            volumeSlider.interactable = false;
        }
        else if (liquidControllerScript.sliderInstance.value == 1 && liquidControllerScript.fill.CurrentVal > 0)
        {
            volumeSlider.value += 0.0022f;
            volumeSlider.interactable = false;
        }


    }
}
