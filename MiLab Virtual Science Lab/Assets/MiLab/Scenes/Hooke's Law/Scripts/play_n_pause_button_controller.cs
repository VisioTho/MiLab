using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class play_n_pause_button_controller : MonoBehaviour
{
   /* public Button playBtn, pauseBtn;
    [SerializeField] public GameObject overlay_mass_text, load, ml, mass_slider;
    [SerializeField] public Slider _mslider;
    public SpringJoint2D spring;
    public Rigidbody2D rigidbody2;
    Vector3 initial_pos, initial_ml;
    float c_mass;
    bool massIsEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
      /*  initial_pos = new Vector3(-5.38f, -0.33f);
        initial_ml= new Vector3(-5.338901f, 0.6105f);*/
       // load.transform.localScale = new Vector2(0.5836432f, 0.5711f);

        ///default
      /*  spring.frequency = 0f;
        load.transform.position = initial_pos;
        ml.GetComponent<Rigidbody2D>().transform.position = initial_ml;
        massIsEnabled = true;*/

    }
    /*void Awake()
    {
      spring =load.GetComponent<SpringJoint2D>();
      rigidbody2 = load.GetComponent<Rigidbody2D>();
       
    }*/

    // Update is called once per frame
    /*void Update()
    {
      c_mass= mass_slider.GetComponent<Slider>().value;
        mass_slider.GetComponent<Slider>().enabled = massIsEnabled;
        // Debug.Log(c_mass);
    }*/
    /*public float gravityscale_to_be_used()
    {
        return (mass_slider.GetComponent<Slider>().value*0.01f);
    }*/
   
   /* public void diable_playBtn()//on play button click
    {
        pauseBtn.interactable = true;
        playBtn.interactable = false;
        overlay_mass_text.SetActive(false);
       // spring.frequency = 1000000f;
        rigidbody2.gravityScale = gravityscale_to_be_used();
        spring.frequency = 1f;

        //disable slider
        massIsEnabled = false;

    }*/
    /*public void diable_pauseBtn()//on pause button click
    {
        pauseBtn.interactable = false;
        playBtn.interactable = true;
        overlay_mass_text.SetActive(true);
         spring.frequency = 0f;
        //rigidbody2.gravityScale=3f;
        load.transform.position = initial_pos;
        ml.GetComponent<Rigidbody2D>().transform.position = initial_ml;
        //load.BodyType = Kinematic;

        //enable slider
        massIsEnabled = true;
    }*/
//}
