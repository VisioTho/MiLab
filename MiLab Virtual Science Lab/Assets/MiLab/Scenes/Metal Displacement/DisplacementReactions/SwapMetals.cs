using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SwapMetals : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] metalA;
    // public GameObject[] metalB;
    public ToggleGroup toggleGroup;
    private Toggle activeToggle;
    //  [SerializeField] private TMP_Text metalNotation;


    // Update is called once per frame
    void Update()
    {
        SwapMetalA();
    }

    private void SwapMetalA()
    {
        activeToggle = toggleGroup.GetFirstActiveToggle();

        if (activeToggle.name == "copper")
        {
            ShowMetal(0);
            //  metalNotation.text = "Copper";

        }

        if (activeToggle.name == "zinc")
        {
            ShowMetal(1);
            //   metalNotation.text = "Zinc";
        }

        if (activeToggle.name == "iron")
        {
            ShowMetal(2);
            //   metalNotation.text = "Iron";
        }
        if (activeToggle.name == "magnesium")
        {
            ShowMetal(3);
            //   metalNotation.text = "Magnesium";
        }
    }

    //show metal selected from radio group and hide the rest of the items
    private void ShowMetal(int n)
    {
        metalA[n].SetActive(true);
        for (int i = 0; i < metalA.Length; i++)
        {
            if (i != n) metalA[i].SetActive(false);
        }
    }


}
