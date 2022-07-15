using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MolesController : MonoBehaviour
{
    public LiquidControllerScript liquidControllerScript;
    // Burette dropdowns
    public int burette_moles = 0;
    private int maxMoles = 2;
    private int minMoles = 0;
    public TMP_Text molesValueNotation;

    // Conical flask dropdown 
    public TMP_Text ConicalFlaskmolesValueNotation;
    public int conicalFlaskMoles = 0;

    //Moles Control buttons
    public Button BMoles1, BMoles2, CMoles1, CMoles2;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (burette_moles > 0)
        {
            CMoles1.interactable = false;
            CMoles2.interactable = false;
        }
        if (conicalFlaskMoles > 0)
        {
            BMoles1.interactable = false;
            BMoles2.interactable = false;
        }
        if (burette_moles == 0 && conicalFlaskMoles == 0)
        {
            BMoles1.interactable = true;
            BMoles2.interactable = true;
            CMoles1.interactable = true;
            CMoles2.interactable = true;
        }
        buretteMolesCheck();
        conicalFlaskMolesCheck();
    }
    void buretteMolesCheck()
    {
        if (burette_moles == 0)
        {
            molesValueNotation.text = "";
        }
        if (burette_moles == 1)
        {
            molesValueNotation.text = "0.1M";
        }
        if (burette_moles == 2)
        {
            molesValueNotation.text = "0.2M";
        }
        if (burette_moles == 3)
        {
            molesValueNotation.text = "0.3M";
        }
    }
    void conicalFlaskMolesCheck()
    {
        if (conicalFlaskMoles == 0)
        {
            ConicalFlaskmolesValueNotation.text = "";
        }
        if (conicalFlaskMoles == 1)
        {
            ConicalFlaskmolesValueNotation.text = "0.1M";
        }
        if (conicalFlaskMoles == 2)
        {
            ConicalFlaskmolesValueNotation.text = "0.2M";
        }
        if (conicalFlaskMoles == 3)
        {
            ConicalFlaskmolesValueNotation.text = "0.3M";
        }
    }
    public void MolesIncrement()
    {
        if (burette_moles < maxMoles)
        {
            burette_moles++;
        }

    }
    public void MolesDecrement()
    {
        if (burette_moles > minMoles)
        {
            burette_moles--;
        }

    }

    public void ConicalFlaskMolesIncrement()
    {
        if (conicalFlaskMoles < maxMoles)
        {
            conicalFlaskMoles++;
        }

    }
    public void ConicalFlaskMolesDecrement()
    {
        if (conicalFlaskMoles > minMoles)
        {
            conicalFlaskMoles--;
        }

    }

    public void resetMoles()
    {
        burette_moles = 0;
        CMoles1.interactable = true;
        CMoles2.interactable = true;
    }
    public void resetConicaFlaskMoles()
    {
        conicalFlaskMoles = 0;
        BMoles1.interactable = true;
        BMoles2.interactable = true;
    }
}
