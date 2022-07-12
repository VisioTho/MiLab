using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    public GameObject[] tutorialElements;
    public GameObject[] initialParents;
    public GameObject simulationScreen; //tutorial starts only when this screen is active
    public GameObject TutorialScreen;
    private int stepCounter = 0;

    private void Start()
    {
        TutorialScreen.SetActive(false);
    }
    public void AdvanceToNextStep()
    {
        stepCounter++;
        Debug.Log("steps " + stepCounter);
    }

    public void FinishTutorial()
    {
        if(tutorialElements[4] != null)
            tutorialElements[4].transform.SetParent(initialParents[0].transform);
        else
            tutorialElements[3].transform.SetParent(initialParents[0].transform);
        StartGame.isTutorialEnabled = false;
        //fader.transform.DetachChildren();
        Destroy(TutorialScreen);
        Time.timeScale = 1f;
       
    }
    private void Update()
    {
        RunTutorial();

    }

    private void RunTutorial()
    {
        if (StartGame.isTutorialEnabled && simulationScreen.activeSelf)
        {
            Time.timeScale = 0f;
            TutorialScreen.SetActive(true);
            switch (stepCounter)
            {
                case 0:
                    tutorialElements[0].transform.SetParent(TutorialScreen.transform);
                    break;
                case 1:
                    tutorialElements[0].transform.SetParent(initialParents[0].transform);
                    tutorialElements[1].transform.SetParent(TutorialScreen.transform);
                    break;
                case 2:
                    tutorialElements[1].transform.SetParent(initialParents[0].transform);
                    tutorialElements[2].transform.SetParent(TutorialScreen.transform);
                    break;
                case 3:
                    tutorialElements[2].transform.SetParent(initialParents[0].transform);
                    tutorialElements[3].transform.SetParent(TutorialScreen.transform);
                    break;
                case 4:
                    tutorialElements[3].transform.SetParent(initialParents[0].transform);
                    tutorialElements[4].transform.SetParent(TutorialScreen.transform);
                    break;
                case 5:
                    tutorialElements[4].transform.SetParent(initialParents[0].transform);
                    tutorialElements[5].transform.SetParent(TutorialScreen.transform);
                    break;
            }
        }
        else
        {

        }
    }
}
