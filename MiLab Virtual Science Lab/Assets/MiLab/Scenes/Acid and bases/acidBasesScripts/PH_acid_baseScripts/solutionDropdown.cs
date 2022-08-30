using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class solutionDropdownPH : MonoBehaviour
{
    public TMP_Dropdown solutions_dd;
    public GameObject liquid, custom_solution_toggler, litmus_paper_b, litmus_paper_type_toggler;

    Color defaultBlue = new Color32(17, 97, 137, 255);
    Color defaultRed = new Color32(161, 80, 63, 255);
    // Start is called before the first frame update
    void Start()
    {
        solutions_dd.onValueChanged.AddListener(delegate {
            valueHasChanged(solutions_dd);
            ToggleValueChanged();
        });
    }

    public void ToggleValueChanged()
    {

        if (litmus_paper_type_toggler.GetComponent<Toggle>().isOn)//red
        {
            litmus_paper_b.GetComponent<SpriteRenderer>().color = defaultRed;
        }
        else //blue
        {
            litmus_paper_b.GetComponent<SpriteRenderer>().color = defaultBlue;
        }
    }

    public void custom_solution_togglerValueChenged()
    {
        if (!custom_solution_toggler.GetComponent<Toggle>().isOn)
        {
            liquid.GetComponent<SpriteRenderer>().color = new Color32(55, 48, 48, 31);
            liquid.tag = "ethanoic_acid";
            liquid.SetActive(true);
        }
    }

    public void valueHasChanged(TMP_Dropdown sender)
    {
        //  Debug.Log(sender.value);
        if (sender.value == 0) {
            liquid.SetActive(false);
            liquid.tag = "null";
        }
        else if(sender.value==1)//milk
        {
            liquid.SetActive(true);
            liquid.GetComponent<SpriteRenderer>().color = new Color32(243, 241, 235, 145);
            liquid.tag = "milk";
        }
        else if (sender.value == 2)//blood
        {
            liquid.SetActive(true);
            liquid.GetComponent<SpriteRenderer>().color = new Color32(231, 28, 34, 155);
            liquid.tag = "blood";

        }
        else if (sender.value == 3)//puer water
        {
            liquid.SetActive(true);
            liquid.GetComponent<SpriteRenderer>().color = new Color32(55, 48, 48, 49);
            liquid.tag = "pure_water";
        }
        else if (sender.value == 4)//tomato
        {
            liquid.SetActive(true);
            liquid.GetComponent<SpriteRenderer>().color = new Color32(255, 16, 16, 145);
            liquid.tag = "tomato";
        }
        else if (sender.value == 5)//vinegar
        {
            liquid.SetActive(true);
            liquid.GetComponent<SpriteRenderer>().color = new Color32(55, 48, 47, 49);
            liquid.tag = "vinegar";
        }
        else if (sender.value == 6)//bleach
        {
            liquid.SetActive(true);
            liquid.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 145);
            liquid.tag = "bleach";
        }
       
    }


}
