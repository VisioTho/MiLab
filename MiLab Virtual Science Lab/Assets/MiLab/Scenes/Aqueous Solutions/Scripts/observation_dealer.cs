using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class observation_dealer : MonoBehaviour
{

    public GameObject positivesToBeSpawned, switch_ob, negativesToBeSpawned, tryposTopMost, tryposBottomMost, tryposLeftMost, tryposRightMost, anode, cathode, attracted_positive_ions, attracted_negative_ions, empty_y_Particle_system, positive_ions_Particle_system, negative_ions_Particle_system;
    public float speed = 2f;
    public static bool switch_is_on;
    public bool restart_ob = false;
    public int doOnce = 0;
    public GameObject[] positive_ions, negative_ions;

    public bool already_spawned = false;
    public static float should_restart_observation;
    void Start()
    {
        attracted_negative_ions.SetActive(false);  
        attracted_positive_ions.SetActive(false);
        negative_ions_Particle_system.SetActive(false);
        positive_ions_Particle_system.SetActive(false);        
    }
    void Update()
    {
        switch_is_on = switch_controller.switch_is_on;
        should_restart_observation= solutionsDropdown.should_restart_observation;

     if(should_restart_observation!=0 && switch_is_on){
            empty_y_Particle_system.SetActive(true);
            negative_ions_Particle_system.SetActive(true);
            positive_ions_Particle_system.SetActive(true);
            attracted_negative_ions.SetActive(true);
            attracted_positive_ions.SetActive(true);           

        }
        else
        {
            empty_y_Particle_system.SetActive(false);
            negative_ions_Particle_system.SetActive(false);
            positive_ions_Particle_system.SetActive(false);
            attracted_negative_ions.SetActive(false);
            attracted_positive_ions.SetActive(false);

        }

    }
}
