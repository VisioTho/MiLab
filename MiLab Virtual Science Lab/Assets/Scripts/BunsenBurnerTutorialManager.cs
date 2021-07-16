using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BunsenBurnerTutorialManager : MonoBehaviour
{
    [SerializeField] private Slider gasValveSlider;
    [SerializeField] private Slider airHolesSlider;
    [SerializeField] private GameObject[] tutorialboxes;
    [SerializeField] private ParticleSystem flame;
    private float initialgasSliderValue, initialairHolesSliderValue;

    // Start is called before the first frame update
    void Start()
    {
        airHolesSlider.enabled = false;
        gasValveSlider.enabled = false;
        initialairHolesSliderValue = airHolesSlider.value;
        initialgasSliderValue = gasValveSlider.value;

        for(int i=1; i<tutorialboxes.Length; i++)
            tutorialboxes[i].SetActive(false);
    }

    public void gasOn()
    {
        if(!flame.isEmitting && gasValveSlider.enabled == false)
        {
            tutorialboxes[0].SetActive(false);
            tutorialboxes[1].SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(FlintDropHandler.isFlint && gasValveSlider.enabled == false && flame.isEmitting==true)
        {
            tutorialboxes[1].SetActive(false);
            tutorialboxes[2].SetActive(true);
            gasValveSlider.enabled = true;
        } 

        if(gasValveSlider.value!=initialgasSliderValue && airHolesSlider.enabled == false && flame.isEmitting==true)
        {
            tutorialboxes[2].SetActive(false);
            tutorialboxes[3].SetActive(true);
            airHolesSlider.enabled = true;
        }

        if(airHolesSlider.value!=initialairHolesSliderValue)
        {
            for(int i=0; i<tutorialboxes.Length; i++)
                Destroy(tutorialboxes[i]);
        }

    }

}
