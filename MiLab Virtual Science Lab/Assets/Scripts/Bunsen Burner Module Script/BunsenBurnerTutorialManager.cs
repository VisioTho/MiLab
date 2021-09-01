using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*-----------------------------Script Summary--------------------------------*/
/* This script manages the tutorial messages shown on the screen to aid novice 
players in gameplay. The messages are kept as text and image objects in an array
and played in sequence from 0 to n, using triggers i.e user manipulations on the UI.
Note The player can chose to skip the tutorial
/*----------------------------------------------------------------------------*/
public class BunsenBurnerTutorialManager : MonoBehaviour
{
    //reference to slider on gas panel
    [SerializeField] private Slider gasValveSlider;
    //reference to "air holes" slider
    [SerializeField] private Slider airHolesSlider;
    //reference to objects holding sequencial tutorial messages/images 
    [SerializeField] private GameObject[] tutorialboxes;
    //reference to flames particle system
    [SerializeField] private ParticleSystem flame;
    //reference to the default values of the sliders (before player's manipulation)
    private float initialgasSliderValue, initialairHolesSliderValue;
    [SerializeField] private Toggle tutorialOrNot;


    // Start is called before the first frame update
    void Start()
    {
        //disable sliders on wake (only if the user has chosen tutorial to be included in gameplay)
        //refer to  StartGameScreen.startGame()
        airHolesSlider.enabled = false;
        gasValveSlider.enabled = false;
        //get the default values of the sliders
        initialairHolesSliderValue = airHolesSlider.value;
        initialgasSliderValue = gasValveSlider.value;
    }

    //this function is triggered when the gas button is tapped it triggers the second 
    //tutorial message to be displayed and the first one hidden
    public void gasOn()
    {
        if (!flame.isEmitting && gasValveSlider.enabled == false)
        {
            tutorialboxes[0].SetActive(false);
            tutorialboxes[1].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //enable the sliders if the player chose tutorial to be skipped
        //refer to StartGameScreen.startGame()
        if (!tutorialOrNot.isOn)
        {
            gasValveSlider.enabled = true;
            airHolesSlider.enabled = true;
        }

        //display the next tutorial message if the player completes the process of dragging and dropping the flint.
        //if gasValve slider is disabled it means tutorial was activated
        if (FlintDropHandler.isFlint && gasValveSlider.enabled == false && flame.isEmitting == true)
        {
            tutorialboxes[1].SetActive(false);
            tutorialboxes[2].SetActive(true);
            //if tutorial was activated, the gasValve slider is enabled at this point
            gasValveSlider.enabled = true;
        }
        //display next tutorial messages
        if (gasValveSlider.value != initialgasSliderValue && airHolesSlider.enabled == false && flame.isEmitting == true)
        {
            tutorialboxes[2].SetActive(false);
            tutorialboxes[3].SetActive(true);
            airHolesSlider.enabled = true;
        }
        //end of the tutorial, destroy all tutorial objects after the air holes slider value is changed by the player.
        if (airHolesSlider.value != initialairHolesSliderValue)
        {
            for (int i = 0; i < tutorialboxes.Length; i++)
                Destroy(tutorialboxes[i]);
        }

    }

}
