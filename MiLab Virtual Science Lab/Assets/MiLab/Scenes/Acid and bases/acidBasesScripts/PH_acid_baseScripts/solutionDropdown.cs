using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class solutionDropdownPH : MonoBehaviour
{
    public TMP_Dropdown solutions_dd;
    public GameObject liquid, custom_solution_toggler, litmus_paper_b, litmus_paper_type_toggler;
    // Start is called before the first frame update
   void Start()
    {
        solutions_dd.onValueChanged.AddListener(delegate {
            valueHasChanged(solutions_dd);
            ToggleValueChanged();
        });

       /* litmus_paper_type_toggler.GetComponent<Toggle>().onValueChanged.AddListener(delegate
        {
            ToggleValueChanged();
        });*/
    }

    public void ToggleValueChanged()
    {
        Debug.Log("Litmus toggled");

        if (litmus_paper_type_toggler.GetComponent<Toggle>().isOn)//red
        {
            //litmus_paper_a.GetComponent<SpriteRenderer>().color = new Color32(239, 73, 26, 255);
            litmus_paper_b.GetComponent<SpriteRenderer>().color = new Color32(239, 73, 26, 255);
        }
        else //blue
        {
           //litmus_paper_a.GetComponent<SpriteRenderer>().color = new Color32(8, 135, 199, 255);
            litmus_paper_b.GetComponent<SpriteRenderer>().color = new Color32(8, 135, 199, 255);
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
            liquid.GetComponent<SpriteRenderer>().color = new Color32(243, 241, 235, 255);
            liquid.tag = "milk";
        }
        else if (sender.value == 2)//blood
        {
            liquid.SetActive(true);
            liquid.GetComponent<SpriteRenderer>().color = new Color32(231, 28, 34, 255);
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
            liquid.GetComponent<SpriteRenderer>().color = new Color32(255, 16, 16, 255);
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
            liquid.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            liquid.tag = "bleach";
        }
       
    }


}
