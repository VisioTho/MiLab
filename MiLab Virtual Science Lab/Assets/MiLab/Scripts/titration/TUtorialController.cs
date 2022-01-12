using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TUtorialController : MonoBehaviour
{
    public GameObject[] tutorialElements;
    public GameObject[] initialParents;
    public GameObject fader;
    private int stepCounter = 0;

    private void Start()
    {
        fader.SetActive(false);

    }
    public void AdvanceToNextStep()
    {
        stepCounter++;
        Debug.Log("steps " + stepCounter);
    }

    public void FinishTutorial()
    {
        tutorialElements[5].transform.SetParent(initialParents[0].transform);
        StartGame.isTutorialEnabled = false;
        //fader.transform.DetachChildren();
        Destroy(fader);
        Time.timeScale = 1f;

    }
    private void Update()
    {

        if (StartGame.isTutorialEnabled)
        {
            Time.timeScale = 0f;
            fader.SetActive(true);
            switch (stepCounter)
            {
                case 0:
                    tutorialElements[0].transform.SetParent(fader.transform);
                    break;
                case 1:
                    tutorialElements[0].transform.SetParent(initialParents[0].transform);
                    tutorialElements[1].transform.SetParent(fader.transform);
                    break;
                case 2:
                    tutorialElements[1].transform.SetParent(initialParents[0].transform);
                    tutorialElements[2].transform.SetParent(fader.transform);
                    break;
                case 3:
                    tutorialElements[2].transform.SetParent(initialParents[0].transform);
                    tutorialElements[3].transform.SetParent(fader.transform);
                    break;
                case 4:
                    tutorialElements[3].transform.SetParent(initialParents[0].transform);
                    tutorialElements[4].transform.SetParent(fader.transform);
                    break;
                case 5:
                    tutorialElements[4].transform.SetParent(initialParents[0].transform);
                    tutorialElements[5].transform.SetParent(fader.transform);
                    break;
            }
        }
        else
        {

        }

    }
}

