using UnityEngine;
using UnityEngine.UI;

public partial class BottomNavController : MonoBehaviour
{

    //group the objects contained in each step respectively.
    public GameObject[] simulationUI, conclusionUI, graphUI, apparatusUI;
    private int stepsCounter = 0;


    Tabs TabOne; //Represents the tabs in the navigation
    Tabs TabTwo;
    Tabs TabThree;
    Tabs TabFour;

    private void Start()
    {
        TabOne = new Tabs(simulationUI);
        TabTwo = new Tabs(conclusionUI);
        TabThree = new Tabs(graphUI);
        TabFour = new Tabs(apparatusUI);
        TabTwo.HideObjects();
        TabThree.HideObjects();
        TabFour.HideObjects();
    
    }

    // functions for navigating to the different screens
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
        foreach (GameObject a in apparatusUI)
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
        foreach (GameObject a in apparatusUI)
        {
            a.SetActive(false);
        }
    }
    public void GoToApparatusScreen()
    {
        foreach (GameObject a in simulationUI)
        {
            a.SetActive(false);
        }

        foreach (GameObject a in conclusionUI)
        {
            a.SetActive(false);
        }

        foreach (GameObject a in graphUI)
        {
            a.SetActive(false);
        }
        
        foreach (GameObject a in apparatusUI)
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
        foreach (GameObject a in apparatusUI)
        {
            a.SetActive(false);
        }
    }

    
}
