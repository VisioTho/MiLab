using UnityEngine;
using UnityEngine.UI;

public partial class StepsUIManager : MonoBehaviour
{

    //group the objects contained in each step respectively.
    public GameObject[] simulationUI, conclusionUI, graphUI;
    private int stepsCounter = 0;

    Steps StepOne; //from Steps partial Class
    Steps StepTwo;
    Steps StepThree;

    private void Start()
    {
        StepOne = new Steps(simulationUI);
        StepTwo = new Steps(conclusionUI);
        StepThree = new Steps(graphUI);
        StepTwo.HideObjects();
        StepThree.HideObjects();
    
    }

    public void GoToNextStep()
    {
       
    }

    public void GoToSimulationScreen()
    {
        foreach(GameObject a in simulationUI)
        {
            a.SetActive(true);
        }

        foreach(GameObject a in conclusionUI)
        {
            a.SetActive(false);
        }
        
        foreach(GameObject a in graphUI)
        {
            a.SetActive(false);
        }
    }
    public void GoToGraphUI()
    {
        foreach(GameObject a in simulationUI)
        {
            a.SetActive(false);
        }

        foreach(GameObject a in conclusionUI)
        {
            a.SetActive(false);
        }
        
        foreach(GameObject a in graphUI)
        {
            a.SetActive(true);
        }
    }

    public void ConclusionUI()
    {
        foreach(GameObject a in simulationUI)
        {
            a.SetActive(false);
        }

        foreach(GameObject a in conclusionUI)
        {
            a.SetActive(true);
        }
        
        foreach(GameObject a in graphUI)
        {
            a.SetActive(false);
        }
    }

    
}
