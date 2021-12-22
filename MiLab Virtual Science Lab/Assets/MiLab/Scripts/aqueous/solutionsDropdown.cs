using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class solutionsDropdown : MonoBehaviour
{
    public TMP_Dropdown solutions_dd;
    public GameObject solid_water, bulb, bulb_light_emu;
    public TextMeshProUGUI solution_name;
    public Light bulb_light;
    public Button removeSolution;
    //to enable real time switching of the bulb if circumstances allow
    public static bool sugar_solution;
    public static bool sodium_chloride;
    public static bool concentrated_sulphuric_acid;
    public static bool copper_sulphate;
    public static bool pure_water;
    public static bool acidified_water;
    public static bool lemon_juice;
    public static bool salt_solution;
    //from switch controller
    public static bool switch_is_on;
    //from _node_collider
    public static bool isCollided=false;
    public static float ammeter_final_readingA;

    //to be used by the observation_dealer
    public static float should_restart_observation;

    // Start is called before the first frame update
    void Start()
    {
        should_restart_observation = 0;

         solutions_dd.onValueChanged.AddListener(delegate {
        valueHasChanged(solutions_dd);
        });

      
    }

    // Update is called once per frame
    void Update()
    {
        isCollided = __node_collider_controller.isCollided;
        //accessing from conductivityStatuses
        sugar_solution = conductivityStatuses.sugar_solution;
        sodium_chloride = conductivityStatuses.sodium_chloride;
        concentrated_sulphuric_acid = conductivityStatuses.concentrated_sulphuric_acid;
        copper_sulphate = conductivityStatuses.copper_sulphate;
        pure_water = conductivityStatuses.pure_water;
        acidified_water = conductivityStatuses.acidified_water;
        lemon_juice = conductivityStatuses.lemon_juice;
        salt_solution = conductivityStatuses.salt_solution;

        //
         switch_is_on = switch_controller.switch_is_on;
        //


        ////enabling and disabling remove solution button, somehow redanducy
        if(solutions_dd.value == 0)
        {
            removeSolution.interactable=false;
        }
        else
        {
            removeSolution.interactable=true;
        }
        ///ending

        if (solutions_dd.value==1 && (sugar_solution || isCollided) && switch_is_on) {
            bulb.GetComponent<SpriteRenderer>().color = new Color(225, 225, 225);
            bulb_light_emu.SetActive(true);
            ammeter_final_readingA = 4.56f;
            bulb_light.range = 4f;
        }
        else if (solutions_dd.value == 2 && (sodium_chloride || isCollided) && switch_is_on)
        {
            bulb.GetComponent<SpriteRenderer>().color = new Color(225, 225, 225);
            bulb_light_emu.SetActive(true);
            ammeter_final_readingA = 4.79f;
            bulb_light.range = 4f;
        }
        else if (solutions_dd.value == 3 && (concentrated_sulphuric_acid || isCollided) && switch_is_on)
        {
            bulb.GetComponent<SpriteRenderer>().color = new Color(225, 225, 225);
            bulb_light_emu.SetActive(true);
            ammeter_final_readingA = 6.34f;
            bulb_light.range = 6f;
        }
        else if (solutions_dd.value == 4 && (copper_sulphate || isCollided) && switch_is_on)
        {
            bulb.GetComponent<SpriteRenderer>().color = new Color(225, 225, 225);
            bulb_light_emu.SetActive(true);
            ammeter_final_readingA = 3.59f;
            bulb_light.range = 4f;
        }
        else if (solutions_dd.value == 5 && (pure_water || isCollided) && switch_is_on)
        {
            bulb.GetComponent<SpriteRenderer>().color = new Color(225, 225, 225);
            bulb_light_emu.SetActive(true);
            ammeter_final_readingA = 3.00f;
            bulb_light.range = 4f;
        }
        else if (solutions_dd.value == 6 && (acidified_water || isCollided) && switch_is_on)
        {
            bulb.GetComponent<SpriteRenderer>().color = new Color(225, 225, 225);
            bulb_light_emu.SetActive(true);
            ammeter_final_readingA = 7.64f;
            bulb_light.range = 8f;
        }
        else if (solutions_dd.value == 7 && (lemon_juice || isCollided) && switch_is_on)
        {
            bulb.GetComponent<SpriteRenderer>().color = new Color(225, 225, 225);
            bulb_light_emu.SetActive(true);
            ammeter_final_readingA = 6.24f;
            bulb_light.range = 6f;
        }
        else if (solutions_dd.value == 8 && (salt_solution || isCollided) && switch_is_on)
        {
            bulb.GetComponent<SpriteRenderer>().color = new Color(225, 225, 225);
            bulb_light_emu.SetActive(true);
            ammeter_final_readingA = 5.64f;
            bulb_light.range = 5f;
        }
        else
        {
            bulb.GetComponent<SpriteRenderer>().color = new Color32(128, 127, 127, 255);
            bulb_light.range = 0f;
            ammeter_final_readingA = 0.00f;
            bulb_light_emu.SetActive(false);
        }
     //if the _nodes (anode and cathode) collide
        if (isCollided && switch_is_on)
        {
            bulb.GetComponent<SpriteRenderer>().color = new Color(225, 225, 225);
            bulb_light_emu.SetActive(true);
            ammeter_final_readingA = 8.50f;
            bulb_light.range = 8f;
        }
    }


    ///----------------------------------------------------///
    public void valueHasChanged(TMP_Dropdown sender){
        Debug.Log(sender.value);
            if(sender.value ==0)
                {
                    solid_water.SetActive(false);
                    solution_name.text = "";

            should_restart_observation = 0;
        }

        if (sender.value == 1)
        {
            solid_water.SetActive(true);
            solid_water.GetComponent<SpriteRenderer>().color = new Color32(204, 98, 22, 188);
            solution_name.text = "Sugar solution";

            should_restart_observation = 0;
        }
        if (sender.value == 2)
        {
            solid_water.SetActive(true);
            solid_water.GetComponent<SpriteRenderer>().color = new Color32(191, 158, 134, 188);
            solution_name.text = "Sodium Chloride solution";

            should_restart_observation = 1f;
        }
        if (sender.value == 3)
        {
            solid_water.SetActive(true);
            solid_water.GetComponent<SpriteRenderer>().color = new Color32(217, 216, 216, 188);
            solution_name.text = "Concentrated Sulphuric acid solution";

            should_restart_observation = 2f;
        }
        if (sender.value == 4)
        {
            solid_water.SetActive(true);
            solid_water.GetComponent<SpriteRenderer>().color = new Color32(0, 0, 255, 188);
            solution_name.text = "Copper Sulphate solution";

            should_restart_observation = 3f;
        }
        if (sender.value == 5)
        {
            solid_water.SetActive(true);
            solid_water.GetComponent<SpriteRenderer>().color = new Color32(225, 225, 225, 188);
            solution_name.text = "Pure water";

            should_restart_observation = 0f;
        }
        if (sender.value == 6)
        {
            solid_water.SetActive(true);
            solid_water.GetComponent<SpriteRenderer>().color = new Color32(90, 114, 123, 188);
            solution_name.text = "Acidified water";

            should_restart_observation = 4f;
        }
        if (sender.value == 7)
        {
            solid_water.SetActive(true);
            solid_water.GetComponent<SpriteRenderer>().color = new Color32(227, 225, 0, 170);
            solution_name.text = "Lemon juice";

            should_restart_observation = 5f;
        }
        if (sender.value == 8)
        {
            solid_water.SetActive(true);
            solid_water.GetComponent<SpriteRenderer>().color = new Color32(189, 193, 158, 168);
            solution_name.text = "Salt solution";

            should_restart_observation = 6f;
        }
    }
}
