using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class drop_controller : MonoBehaviour
{
    public GameObject hydrochrolic_acid, ethanoic_acid, sodium_hydroxide, ammonium_solution; //ethanoic acid is also used as a custom solution
    public static int hydrochrolic_acid_drops, ethanoic_acid_drops, sodium_hydroxide_drops, ammonium_solution_drops, milk_drops, blood_drops, pure_water_drops, tomato_drops, vinegar_drops, bleach_drops;
   
    public float time = 0;
    public float duration = 8;
    public bool disableSoluDropdownAndCustomSoluToggler = false;
    public TMP_Dropdown solutions_dd;
    public Toggle custom_solution_toggler;
    // Start is called before the first frame update
    void Start()
    {
        hydrochrolic_acid_drops = 0;
        ethanoic_acid_drops = 0;
        sodium_hydroxide_drops = 0;
        ammonium_solution_drops = 0;
        //
        milk_drops=blood_drops = pure_water_drops = tomato_drops = vinegar_drops = bleach_drops = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (disableSoluDropdownAndCustomSoluToggler)
        {
            custom_solution_toggler.enabled = false;
           solutions_dd.enabled = false;
        }
        else
        {
           custom_solution_toggler.GetComponent<Toggle>().enabled = true;
           solutions_dd.GetComponent<TMP_Dropdown>().enabled = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
       // Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "drop_to_spawn")
        {
            //Debug.Log("dropped");
            Destroy(collision.gameObject, 0.02f);
          
            //incrementing number of drops in a liquid
             if(gameObject.tag== "hydrochloric_acid") {
                hydrochrolic_acid_drops++;
                if (hydrochrolic_acid_drops == 2) { StartCoroutine(hydrochloric_acid_color_changer());}
            }
             if(gameObject.tag== "ethanoic_acid") {
                ethanoic_acid_drops++;
                if (ethanoic_acid_drops == 2) { StartCoroutine(ethanoic_acid_color_changer()); }
            }
             if(gameObject.tag== "sodium_hydroxide") { 
                sodium_hydroxide_drops++;
                if (sodium_hydroxide_drops == 2) { StartCoroutine(sodium_hydroxide_color_changer()); }
            }
            if (gameObject.tag== "ammonium_solution") {     
                ammonium_solution_drops++;
                if (ammonium_solution_drops == 2) { StartCoroutine(ammonium_solution_color_changer()); }
            }

            //---custom solution drops handler---//
            if (gameObject.tag == "milk")
            {
                milk_drops++;
                if (milk_drops == 2) { StartCoroutine(milk_color_changer()); }
                blood_drops = pure_water_drops = tomato_drops = vinegar_drops = bleach_drops = 0;
            }
            if (gameObject.tag == "blood")
            {
                blood_drops++;
                if (blood_drops == 2) { StartCoroutine(blood_color_changer()); }
                milk_drops = pure_water_drops = tomato_drops = vinegar_drops = bleach_drops = 0;
            }
            if (gameObject.tag == "pure_water")
            {
                pure_water_drops++;
                if (pure_water_drops == 2) { StartCoroutine(pure_water_color_changer()); }
                milk_drops = blood_drops = tomato_drops = vinegar_drops = bleach_drops = 0;
            }
            if (gameObject.tag == "tomato")
            {
                tomato_drops++;
                if (tomato_drops == 2) { StartCoroutine(tomato_color_changer()); }
                milk_drops = blood_drops = pure_water_drops = vinegar_drops = bleach_drops = 0;
            }
            if (gameObject.tag == "vinegar")
            {
                vinegar_drops++;
                if (vinegar_drops == 2) { StartCoroutine(vinegar_color_changer()); }
                milk_drops = blood_drops = pure_water_drops = tomato_drops = bleach_drops = 0;
            }
            if (gameObject.tag == "bleach")
            {
                bleach_drops++;
                if (bleach_drops == 2) { StartCoroutine(bleach_color_changer()); }
                milk_drops = blood_drops = pure_water_drops = tomato_drops = vinegar_drops = 0;
            }
            //---ending custom solution drops handler---//

        }
    }

                 /*-------------------------------------------------------------------
                  ----------------------------------COLOR CHANGERS--------------------
                  -------------------------------------------------------------------*/

    IEnumerator hydrochloric_acid_color_changer() //hydrochrolic color-changer
    {
        turnOffCustomSolutionTogglerAndDropdown();
        Color startColor = hydrochrolic_acid.GetComponent<SpriteRenderer>().color;
        Color endColor = new Color32(231, 28, 36, 255);

        while (time < duration)
        {
            hydrochrolic_acid.GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, endColor, time / duration);
            time += Time.deltaTime;
            yield return null;
  
        }
        resetTime();
        hydrochrolic_acid.GetComponent<SpriteRenderer>().color = endColor;
        turnOnCustomSolutionTogglerAndDropdown();
    }

    IEnumerator ethanoic_acid_color_changer() //ethanoic acid color-changer
    {
        turnOffCustomSolutionTogglerAndDropdown();
        Color startColor = ethanoic_acid.GetComponent<SpriteRenderer>().color;
        Color endColor = new Color32(252, 201, 31, 255);

        while (time < duration)
        {
            ethanoic_acid.GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, endColor, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        resetTime();
        ethanoic_acid.GetComponent<SpriteRenderer>().color = endColor;
        turnOnCustomSolutionTogglerAndDropdown();
    }


    IEnumerator sodium_hydroxide_color_changer() //sodium hydroxide color-changer
    {
        turnOffCustomSolutionTogglerAndDropdown();
        Color startColor = sodium_hydroxide.GetComponent<SpriteRenderer>().color;
        Color endColor = new Color32(73, 24, 178, 255);

        while (time < duration)
        {
            sodium_hydroxide.GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, endColor, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        resetTime();
        sodium_hydroxide.GetComponent<SpriteRenderer>().color =endColor;
        turnOnCustomSolutionTogglerAndDropdown();
    }

    IEnumerator ammonium_solution_color_changer()//ammonium color-changer
    {
        turnOffCustomSolutionTogglerAndDropdown(); 
        Color startColor = ammonium_solution.GetComponent<SpriteRenderer>().color;
        Color endColor = new Color32(8, 76, 199, 255);

        while (time < duration)
        {
            ammonium_solution.GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, endColor, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        resetTime();
        ammonium_solution.GetComponent<SpriteRenderer>().color =endColor;
        turnOnCustomSolutionTogglerAndDropdown(); 
    }
    /*--------------------------------------------------------------

       Ethanoic acid [GameObject] is being used a custom liquid

    ------------------------------------------------------------*/
    IEnumerator milk_color_changer()//milk color-changer
    {
        turnOffCustomSolutionTogglerAndDropdown(); 
        Color startColor = ethanoic_acid.GetComponent<SpriteRenderer>().color;
        Color endColor = new Color32(73, 179, 16, 255);
        
        while (time < duration)
        {
            ethanoic_acid.GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, endColor, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        resetTime();
        ethanoic_acid.GetComponent<SpriteRenderer>().color = endColor;
        turnOnCustomSolutionTogglerAndDropdown();
    }

    IEnumerator blood_color_changer()//blood color-changer
    {
        turnOffCustomSolutionTogglerAndDropdown(); 
        Color startColor = ethanoic_acid.GetComponent<SpriteRenderer>().color;
        Color endColor = new Color32(0, 165, 91, 255);

        while (time < duration)
        {
            ethanoic_acid.GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, endColor, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        resetTime();
        ethanoic_acid.GetComponent<SpriteRenderer>().color = endColor;
        turnOnCustomSolutionTogglerAndDropdown();
    }

    IEnumerator pure_water_color_changer() //pure-water color-changer
    {
        turnOffCustomSolutionTogglerAndDropdown();
        Color startColor = ethanoic_acid.GetComponent<SpriteRenderer>().color;
        Color endColor = new Color32(0, 153, 24, 255);

        while (time < duration)
        {
            ethanoic_acid.GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, endColor, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        resetTime();
        ethanoic_acid.GetComponent<SpriteRenderer>().color = endColor;
        turnOnCustomSolutionTogglerAndDropdown(); 
    }

    IEnumerator tomato_color_changer()//tomato color-changer
    {
        turnOffCustomSolutionTogglerAndDropdown(); 

        Color startColor = ethanoic_acid.GetComponent<SpriteRenderer>().color;
        Color endColor = new Color32(220, 220, 47, 255);
      
        while(time < duration)
        {
            ethanoic_acid.GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, endColor, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        resetTime();
        ethanoic_acid.GetComponent<SpriteRenderer>().color = endColor;
        turnOnCustomSolutionTogglerAndDropdown();
    }

    IEnumerator vinegar_color_changer() //vinegar color-changer
    {
        turnOffCustomSolutionTogglerAndDropdown();
        Color startColor = ethanoic_acid.GetComponent<SpriteRenderer>().color;
        Color endColor = new Color32(252, 201, 31, 255);

        while (time < duration)
        {
            ethanoic_acid.GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, endColor, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        resetTime();
        ethanoic_acid.GetComponent<SpriteRenderer>().color = endColor;
        turnOnCustomSolutionTogglerAndDropdown(); 
    }

    IEnumerator bleach_color_changer() //bleach color-changer
    {
        turnOffCustomSolutionTogglerAndDropdown();
        Color startColor = ethanoic_acid.GetComponent<SpriteRenderer>().color;
        Color endColor = new Color32(52, 40, 178, 255);

        while (time < duration)
        {
            ethanoic_acid.GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, endColor, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        resetTime();
        ethanoic_acid.GetComponent<SpriteRenderer>().color = endColor;
        turnOnCustomSolutionTogglerAndDropdown(); 
    }

    public void turnOffCustomSolutionTogglerAndDropdown()
    {
     
        disableSoluDropdownAndCustomSoluToggler = true;
    }
    public void turnOnCustomSolutionTogglerAndDropdown()
    {
        disableSoluDropdownAndCustomSoluToggler = false;
    }
    public void resetTime()
    {
        time = 0;
    }
    
}
