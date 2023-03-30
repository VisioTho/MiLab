using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SwitchExperimentController : MonoBehaviour
{
    

   private GameObject photoPlant;
   private GameObject Tropism_stand;
   private GameObject SpotLightsContainer;
   private GameObject Geotropism_container;
   private GameObject ButtonContainer;
   private GameObject GeoResetButton;

    void Start()
    {
        // populate the dictionary with GameObjects by key and name
        photoPlant = GameObject.Find("photoPlant");
        Tropism_stand = GameObject.Find("Tropism_stand");
        SpotLightsContainer = GameObject.Find("SpotLightsContainer");
        Geotropism_container = GameObject.Find("Geotropism_container");
        ButtonContainer = GameObject.Find("ButtonContainer");
        GeoResetButton = GameObject.Find("Reset");

        Geotropism_container.SetActive(false);
        GeoResetButton.SetActive(false);


    }

    public void HandleInputData(int val)
    {
        if (val == 0) {

            photoPlant.SetActive(true);
            Tropism_stand.SetActive(true);
            SpotLightsContainer.SetActive(true);
            ButtonContainer.SetActive(true);
            Geotropism_container.SetActive(false);
            GeoResetButton.SetActive(false);
            
   
        }
        if (val == 1)
        {
            photoPlant.SetActive(false);
            Tropism_stand.SetActive(false);
            SpotLightsContainer.SetActive(false);
            ButtonContainer.SetActive(false);
            Geotropism_container.SetActive(true);
            GeoResetButton.SetActive(true);
            
        }
    }  

   
}
