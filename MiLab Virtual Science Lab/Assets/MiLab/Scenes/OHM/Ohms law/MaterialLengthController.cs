using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MaterialLengthController : MonoBehaviour
{
    public Slider wireAdjustLength;
    public GameObject wire1, wire2, wire3;
    // Start is called before the first frame update
    void Start()
    {
        wireAdjustLength.minValue = 0;
        wireAdjustLength.maxValue = 2;
        wireAdjustLength.wholeNumbers = true;
    }



    public TMP_Text wireLength;
    public void AdjustWireLength()
    {
        if (wireAdjustLength.value == 0)
        {
            ChangeMass("40");
            wire1.SetActive(true);
            wire2.SetActive(false);
            wire3.SetActive(false);
        }
        if (wireAdjustLength.value == 1)
        {
            ChangeMass("50");
            wire1.SetActive(false);
            wire2.SetActive(true);
            wire3.SetActive(false);
        }
        if (wireAdjustLength.value == 2)
        {
            ChangeMass("60");
            wire1.SetActive(false);
            wire2.SetActive(false);
            wire3.SetActive(true);
        }
        void ChangeMass(string weight)
        {
            wireLength.text = weight + " cm";
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
