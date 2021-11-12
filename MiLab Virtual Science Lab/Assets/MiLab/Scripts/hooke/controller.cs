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
    [SerializeField] public GameObject _massBg, el, ml,nl, ruler, load;
    [SerializeField] public Rigidbody2D el_rb;
    public SpriteRenderer ml_render, el_render, nl_render;
    public float gravitymultiplier = 0.01f;
    public static Vector2 initial_load_pos;
    public static bool isDragged;
    public static Hashtable loads = new Hashtable();
    public static float current_slider_mass_value;

    // Start is called before the first frame update
    void Start()
    {
        loads.Add(1, "load_100");
        loads.Add(2, "load_200");
        loads.Add(3, "load_300");
        loads.Add(4, "load_400");
       // loads.Add(5, "load_500");
       // loads.Add(6, "load_600");
       // loads.Add(7, "load_700");
        //loads.Add(8, "load_800");
        loads.Add(5, "load_custom");

        ml_render = ml.GetComponent<SpriteRenderer>();
        el_render = el.GetComponent<SpriteRenderer>();
        nl_render = nl.GetComponent<SpriteRenderer>();
        //initial_load_pos = positions_controller.load_dp;
        _massSlider.onValueChanged.AddListener((v) => {

            //forcing a slider to fall on a number an interval of 100
          /*  if ((v > 0f) && (v < 75f))
            {
                _massSlider.value = 50;
                // currentMass.text = mass_overlay_value.text = v.ToString("0") + " (g)";
                currentMass.text = mass_overlay_value.text = "50 (g)";
                //  if (load.GetComponent<SpringJoint2D>() != null)load.GetComponent<Rigidbody2D>().gravityScale = 100f * gravitymultiplier;

            }*/
             if ((v > 0f) && (v < 125f))
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
            else if ((v > 425f) && (v < 475f))
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
            }
           


            //currentMass.text = mass_overlay_value.text= v.ToString("0")+" (g)";

            //scale load
            if ((v * 0.00075f) > 0.3836432f) {
                //load.GetComponent<Rigidbody2D>().gravityScale = 0f;
               // load.GetComponent<Rigidbody2D>().mass=0.0001f;
               // Destroy(load.GetComponent<SpringJoint2D>());

             //load.transform.localScale = new Vector3(v*0.00075f,0.3711f, 0.7422f);
             // load.AddComponent<SpringJoint2D>();
             // SpringJoint2D spj = load.GetComponent<SpringJoint2D>();
            //spj.connectedBody = nl_rb;
            // spj.anchor = new Vector2(-1.700165e-07f, 2.5f);
            // spj.connectedAnchor = new Vector2(-0.0772457f, 11.75946f);
            //load.GetComponent<Rigidbody2D>().mass = 500f;//1
            //load.transform.position = new Vector2(-0.56f, 0.2928663f); //2
            //load.GetComponent<Rigidbody2D>().mass = 600f;//4
            // load.GetComponent<Rigidbody2D>().gravityScale = v*gravitymultiplier;//4
           // load.GetComponent<SpringJoint2D>().frequency = 1f;
            }
        });
       
        //load.GetComponent<SpringJoint2D>().frequency = 1000000f;
       
    }

    // Update is called once per frame
    void Update()
    {
        current_slider_mass_value = _massSlider.value;
       // isDragged = drag_n_drop.isDragged;
      /*  if (load.GetComponent<SpringJoint2D>() != null)
        {
            load.GetComponent<Rigidbody2D>().gravityScale = _massSlider.value * 0.01f;
        }
        else
        {
            load.GetComponent<Rigidbody2D>().gravityScale = 0;
            
            if (!isDragged)
            {
                load.transform.position = initial_load_pos;
               // Debug.Log("is not dragged");
            }
        }*/
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
