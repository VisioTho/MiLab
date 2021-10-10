using UnityEngine;
using UnityEngine.UI;


public class BunsenBurnerTutorialManager : MonoBehaviour
{
 
    public Slider gasValveSlider;
    
    public Slider airHolesSlider;
   
    public GameObject[] tutorialboxes;
   
    public ParticleSystem flame;
   
    private float initialgasSliderValue, initialairHolesSliderValue;

    void Start()
    {
        airHolesSlider.enabled = false;
        gasValveSlider.enabled = false;

        initialairHolesSliderValue = airHolesSlider.value;

        initialgasSliderValue = gasValveSlider.value;
    }


    public void TurnGasOn()
    {
        if (!flame.isEmitting && gasValveSlider.enabled == false)
        {
            tutorialboxes[0].SetActive(false);
            tutorialboxes[1].SetActive(true);
        }
    }

  
    void Update()
    {
        RunTutorial();
    }

    private void RunTutorial()
    {
        if (!StartGame.isTutorialEnabled)
        {
            gasValveSlider.enabled = true;
            airHolesSlider.enabled = true;

            foreach (GameObject i in tutorialboxes)
            {
                Destroy(i);
            }
        }

        if (FlintDropHandler.isFlint && gasValveSlider.enabled == false && flame.isEmitting == true)
        {
            tutorialboxes[1].SetActive(false);
            tutorialboxes[2].SetActive(true);
           
            gasValveSlider.enabled = true;
        }
        
        else if (gasValveSlider.value != initialgasSliderValue && airHolesSlider.enabled == false && flame.isEmitting == true)
        {
            tutorialboxes[2].SetActive(false);
            tutorialboxes[3].SetActive(true);
            airHolesSlider.enabled = true;
        }

        else if (airHolesSlider.value != initialairHolesSliderValue)
        {
            for (int i = 0; i < tutorialboxes.Length; i++)
                Destroy(tutorialboxes[i]);
        }
    }
}
