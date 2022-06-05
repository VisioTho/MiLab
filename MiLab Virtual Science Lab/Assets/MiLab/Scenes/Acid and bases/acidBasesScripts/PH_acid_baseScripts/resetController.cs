using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class resetController : MonoBehaviour
{
    public static string current_selected_beaker;
    public Color transparent_color;
    public GameObject customs_solution_toggler, custom_solution_dropdown;
    // Start is called before the first frame update
    void Start()
    {
        transparent_color = GameObject.FindWithTag("hydrochloric_acid").GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void reset_liquid_color()
    {
        //drop_controller.stopCoroutines();
        current_selected_beaker = selectorNdropper_position_controller.current_selected_beaker;
        if (!customs_solution_toggler.GetComponent<Toggle>().isOn)//
        {
            if (current_selected_beaker == "sodium_hydroxide_beaker")
            {
                GameObject.FindWithTag("sodium_hydroxide").GetComponent<SpriteRenderer>().color = transparent_color;
                drop_controller.sodium_hydroxide_drops = 0;
            }

            if (current_selected_beaker == "ammonium_solution_beaker")
            {
                GameObject.FindWithTag("ammonium_solution").GetComponent<SpriteRenderer>().color = transparent_color;
                drop_controller.ammonium_solution_drops = 0;
            }
            if (current_selected_beaker == "ethanoic_acid_beaker" && customs_solution_toggler.GetComponent<Toggle>().isOn == false)
            {
                GameObject.FindWithTag("ethanoic_acid").GetComponent<SpriteRenderer>().color = transparent_color;
                drop_controller.ethanoic_acid_drops = 0;
            }
            if (current_selected_beaker == "hydrochloric_acid_beaker")
            {
                GameObject.FindWithTag("hydrochloric_acid").GetComponent<SpriteRenderer>().color = transparent_color;
                drop_controller.hydrochrolic_acid_drops = 0;
            }
        }
         //Handling custom substances
        if (customs_solution_toggler.GetComponent<Toggle>().isOn)//
        {
            TMP_Dropdown solution_dropdown = custom_solution_dropdown.GetComponent<TMP_Dropdown>();
            if (solution_dropdown.value == 1) { drop_controller.milk_drops = 0; GameObject.FindWithTag("milk").GetComponent<SpriteRenderer>().color = new Color32(243, 241, 235, 255); }
            if (solution_dropdown.value == 2) { drop_controller.blood_drops = 0; GameObject.FindWithTag("blood").GetComponent<SpriteRenderer>().color = new Color32(231, 28, 34, 255); }
            if (solution_dropdown.value == 3) { drop_controller.pure_water_drops = 0; GameObject.FindWithTag("pure_water").GetComponent<SpriteRenderer>().color = new Color32(8, 7, 7, 47); }
            if (solution_dropdown.value == 4) { drop_controller.tomato_drops = 0; GameObject.FindWithTag("tomato").GetComponent<SpriteRenderer>().color = new Color32(255, 16, 16, 255); }
            if (solution_dropdown.value == 5) { drop_controller.vinegar_drops = 0; GameObject.FindWithTag("vinegar").GetComponent<SpriteRenderer>().color = new Color32(8, 7, 7, 47); }
            if (solution_dropdown.value == 6) { drop_controller.bleach_drops = 0; GameObject.FindWithTag("bleach").GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255); }
         }
    }
}
