using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StepsUIManager : MonoBehaviour
{
    public int numberOfSteps;
    public Slider progressBar;
    public class Steps
    {
        public GameObject[] stepObjects;
        public void HideObjects()
        {
            foreach(GameObject i in stepObjects)
            {
                i.SetActive(false);
            }
        }
        public void ShowObjects()
        {
            foreach (GameObject i in stepObjects)
            {
                i.SetActive(true);
            }
        }
        public Steps(GameObject[] stepObjects)
        {
            this.stepObjects = stepObjects;
        }
    }

    public GameObject[] objectsAtStepOne, objectsAtStepTwo, objectsAtStepThree, objectsAtStepFour, objectsAtStepFive;
    private int stepsCounter = 0;
    Steps StepOne;
    Steps StepTwo;
    Steps StepThree;
   
    private void Start()
    { 
        StepOne = new Steps(objectsAtStepOne);
        StepTwo = new Steps(objectsAtStepTwo);
        StepThree = new Steps(objectsAtStepThree);
        Steps StepFour = new Steps(objectsAtStepFour);

        StepTwo.HideObjects();
        StepThree.HideObjects();
        progressBar.maxValue = numberOfSteps;
    }

    public void GoToNextStep()
    {
        if(stepsCounter == 0)
        {
            StepOne.HideObjects();
            StepTwo.ShowObjects();
            stepsCounter++;
        }
        else if(stepsCounter == 1)
        {
            StepTwo.HideObjects();
            StepThree.ShowObjects();
            stepsCounter++;
        }
    }

    public void PreviousStep()
    {
        if(stepsCounter == 1)
        {
            StepOne.ShowObjects();
            StepTwo.HideObjects();
            stepsCounter--;
        }
        if(stepsCounter==2)
        {
            StepThree.HideObjects();
            StepTwo.ShowObjects();
            stepsCounter--;
        }
    }

    private void FixedUpdate()
    {
        ProgressBar();
    }

    private void ProgressBar()
    {
        progressBar.value = stepsCounter;
    }
}
