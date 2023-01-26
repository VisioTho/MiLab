using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class controller : MonoBehaviour
{
 
    [SerializeField] public Slider _massSlider;
    [SerializeField] public TextMeshProUGUI currentMass, mass_overlay_value;
    [SerializeField] public Toggle _massToggler, el_toggler, ml_toggler, nl_toggler, ruler_toggler, custom_mass_toggler;
    [SerializeField] public GameObject _massBg, el, ml,nl, ruler, load, step_1_sprites;
    [SerializeField] public Rigidbody2D el_rb;
    public SpriteRenderer ml_render, el_render, nl_render;
    public float gravitymultiplier = 0.01f;
    public static Vector2 initial_load_pos;
    public static bool isDragged;
    public static Hashtable loads = new Hashtable();
    public static float current_slider_mass_value;
    public static string current_hanged_mass=null;

   
    // Start is called before the first frame update
    void Start()
    {
        loads.Add(1, "load_100");
        loads.Add(2, "load_200");
        loads.Add(3, "load_300");
        loads.Add(4, "load_400");
        loads.Add(5, "load_custom");
        ml_render.enabled = false;
        el_render.enabled = false;
        nl_render.enabled = false;

    }

    private void HandleCustomMass()
    {
        _massSlider.onValueChanged.AddListener((v) =>
        {

            if ((v > 0f) && (v < 75f))
            {
                _massSlider.value = 50;
                // currentMass.text = mass_overlay_value.text = v.ToString("0") + " (g)";
                currentMass.text = mass_overlay_value.text = "50 (g)";
            }
            else if ((v > 75f) && (v < 125f))
            {
                _massSlider.value = 100;
                // currentMass.text = mass_overlay_value.text = v.ToString("0") + " (g)";
                currentMass.text = mass_overlay_value.text = "100 (g)";
            }
            else if ((v > 125f) && (v < 175f))
            {
                _massSlider.value = 150;
                // currentMass.text = mass_overlay_value.text = v.ToString("0") + " (g)";
                currentMass.text = mass_overlay_value.text = "150 (g)";
            }
            else if ((v > 175f) && (v < 225f))
            {
                _massSlider.value = 200;
                // currentMass.text = mass_overlay_value.text = v.ToString("0") + " (g)";
                currentMass.text = mass_overlay_value.text = "200 (g)";
            }
            else if ((v > 225f) && (v < 275f))
            {
                _massSlider.value = 250;
                // currentMass.text = mass_overlay_value.text = v.ToString("0") + " (g)";
                currentMass.text = mass_overlay_value.text = "250 (g)";
            }
            else if ((v > 275f) && (v < 325f))
            {
                _massSlider.value = 300;
                // currentMass.text = mass_overlay_value.text = v.ToString("0") + " (g)";
                currentMass.text = mass_overlay_value.text = "300 (g)";
            }
            else if ((v > 325f) && (v < 375f))
            {
                _massSlider.value = 350;
                // currentMass.text = mass_overlay_value.text = v.ToString("0") + " (g)";
                currentMass.text = mass_overlay_value.text = "350 (g)";
            }
            else if ((v > 375f) && (v < 425f))
            {
                _massSlider.value = 400;
                // currentMass.text = mass_overlay_value.text = v.ToString("0") + " (g)";
                currentMass.text = mass_overlay_value.text = "400 (g)";
            }
           /* else if ((v > 425f) && (v < 475f))
            {
                _massSlider.value = 450;
                // currentMass.text = mass_overlay_value.text = v.ToString("0") + " (g)";
                currentMass.text = mass_overlay_value.text = "450 (g)";
            }
            else if ((v > 475f) && (v < 525f))
            {
                _massSlider.value = 500;
                // currentMass.text = mass_overlay_value.text = v.ToString("0") + " (g)";
                currentMass.text = mass_overlay_value.text = "500 (g)";
            }
            else if ((v > 525f) && (v < 575f))
            {
                _massSlider.value = 550;
                // currentMass.text = mass_overlay_value.text = v.ToString("0") + " (g)";
                currentMass.text = mass_overlay_value.text = "550 (g)";
            }
            else if (v > 575f)
            {
                _massSlider.value = 600;
                // currentMass.text = mass_overlay_value.text = v.ToString("0") + " (g)";
                currentMass.text = mass_overlay_value.text = "600 (g)";
            }*/


        });
    }

    // Update is called once per frame
    void Update()
    {

        HandleCustomMass();
        current_slider_mass_value = _massSlider.value;
   
        //toggle mass slider
        if (custom_mass_toggler.isOn)
        {
            _massBg.SetActive(true);
        }
        else
        {
            _massBg.SetActive(false);
        }
        //toggle ruler
        if (ruler_toggler.isOn)
        {
            ruler.SetActive(true);
        }
        else
        {
            ruler.SetActive(false);
        }
      
        //toggle el
          if (el_toggler.isOn)
          {
            el_render.enabled = true;
          }
          else
          {
            el_render.enabled = false;
        }
        //toggle ml
        if (ml_toggler.isOn)
        {
            ml_render.enabled= true;
        }
        else
        {
            ml_render.enabled =false;
        }
        //toggle nl
        if (nl_toggler.isOn)
        {
            nl_render.enabled = true;
        }
        else
        {
            nl_render.enabled = false;
        }   
    }
}
