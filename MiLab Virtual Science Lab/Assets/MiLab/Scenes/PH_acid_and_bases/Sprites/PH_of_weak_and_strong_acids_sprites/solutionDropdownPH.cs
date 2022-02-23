using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class solutionDropdown : MonoBehaviour
{
    public TMP_Dropdown solutions_dd;
    public GameObject liquid;
    // Start is called before the first frame update
    void Start()
    {
        solutions_dd.onValueChanged.AddListener(delegate {
            valueHasChanged(solutions_dd);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void valueHasChanged(TMP_Dropdown sender)
    {
        //  Debug.Log(sender.value);
        if (sender.value == 0) {
            liquid.SetActive(false);
            
        }
        else if(sender.value==1)//milk
        {
            liquid.SetActive(true);
            liquid.GetComponent<SpriteRenderer>().color = new Color32(243, 241, 235, 255);
        }
        else if (sender.value == 2)//blood
        {
            liquid.SetActive(true);
            liquid.GetComponent<SpriteRenderer>().color = new Color32(231, 28, 34, 255);

        }
        else if (sender.value == 3)//puer water
        {
            liquid.SetActive(true);
            liquid.GetComponent<SpriteRenderer>().color = new Color32(8, 7, 7, 47);
        }
        else if (sender.value == 4)//tomato
        {
            liquid.SetActive(true);
            liquid.GetComponent<SpriteRenderer>().color = new Color32(255, 16, 16, 255);

        }
        else if (sender.value == 5)//vinegar
        {
            liquid.SetActive(true);
            liquid.GetComponent<SpriteRenderer>().color = new Color32(8, 7, 7, 47);
        }
        else if (sender.value == 6)//bleach
        {
            liquid.SetActive(true);
            liquid.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        }
       
    }


}
