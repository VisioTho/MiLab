using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mass_toggler_controller : MonoBehaviour
{
    [SerializeField] public Toggle load_100_t, load_200_t, load_300_t, load_400_t, t_100_400_t, custom_mass_toggler;
    [SerializeField] public GameObject custom_mass;
    public static string current_hanged_mass;
    [SerializeField] public Slider _mass_slider;
    // Start is called before the first frame update
    void Start()
    {
      custom_mass.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (current_hanged_mass != null)
        {
            custom_mass_toggler.interactable = false;
            _mass_slider.interactable = false;
           
        }
        else
        {
            custom_mass_toggler.interactable = true;
            _mass_slider.interactable = true;
        }
        //toggle custom mass
        if ((custom_mass_toggler.isOn))
        {
          // t_100_400_t.isOn= false;
           custom_mass_toggler.isOn = true;
        }
        else
        {
            custom_mass_toggler.isOn = false;
        }

        current_hanged_mass = load_collider.current_hanged_mass; //fetching from another class
        //Disabiling the mass toggler
      //  if (current_hanged_mass == "load_100") { load_100_t.interactable = false; } else { load_100_t.interactable = true; }
      //  if (current_hanged_mass == "load_200") { load_200_t.interactable = false; } else { load_200_t.interactable = true; }
        //if (current_hanged_mass == "load_300") { load_300_t.interactable = false; } else { load_300_t.interactable = true; }
      //  if (current_hanged_mass == "load_400") { load_400_t.interactable = false; } else { load_400_t.interactable = true; }
       // if (current_hanged_mass == "load_500") { load_500_t.interactable = false; } else { load_500_t.interactable = true; }
       // if (current_hanged_mass == "load_600") { load_600_t.interactable = false; } else { load_600_t.interactable = true; }
       // if (current_hanged_mass == "load_700") { load_700_t.interactable = false; } else { load_700_t.interactable = true; }
       // if (current_hanged_mass == "load_800") { load_800_t.interactable = false; } else { load_800_t.interactable = true; }
        //----------------------------------------------------------------------------------------------------------------//
       
        //Hiding masses on toggle change
       // if (load_100_t.isOn) { GameObject.FindWithTag("load_100").GetComponent<SpriteRenderer>().enabled = true; } else { GameObject.FindWithTag("load_100").GetComponent<SpriteRenderer>().enabled = false; }
        //if (load_200_t.isOn) { GameObject.FindWithTag("load_200").GetComponent<SpriteRenderer>().enabled = true; } else { GameObject.FindWithTag("load_200").GetComponent<SpriteRenderer>().enabled = false; }
        //if (load_300_t.isOn) { GameObject.FindWithTag("load_300").GetComponent<SpriteRenderer>().enabled = true; } else { GameObject.FindWithTag("load_300").GetComponent<SpriteRenderer>().enabled = false; }
        //if (load_400_t.isOn) { GameObject.FindWithTag("load_400").GetComponent<SpriteRenderer>().enabled = true; } else { GameObject.FindWithTag("load_400").GetComponent<SpriteRenderer>().enabled = false; }
       // if (load_500_t.isOn) { GameObject.FindWithTag("load_500").GetComponent<SpriteRenderer>().enabled = true; } else { GameObject.FindWithTag("load_500").GetComponent<SpriteRenderer>().enabled = false; }
       // if (load_600_t.isOn) { GameObject.FindWithTag("load_600").GetComponent<SpriteRenderer>().enabled = true; } else { GameObject.FindWithTag("load_600").GetComponent<SpriteRenderer>().enabled = false; }
       // if (load_700_t.isOn) { GameObject.FindWithTag("load_700").GetComponent<SpriteRenderer>().enabled = true; } else { GameObject.FindWithTag("load_700").GetComponent<SpriteRenderer>().enabled = false; }
       // if (load_800_t.isOn) { GameObject.FindWithTag("load_800").GetComponent<SpriteRenderer>().enabled = true; } else { GameObject.FindWithTag("load_800").GetComponent<SpriteRenderer>().enabled = false; }


        //disabling 'all' togglers

      /*  if((int.Parse((current_hanged_mass).Replace("load_", ""))>99)&& (int.Parse((current_hanged_mass).Replace("load_", "")) < 401))
        {
            t_100_400_t.interactable = false;
        }
        else
        {
            t_100_400_t.interactable = true;
        }*/
     }
}