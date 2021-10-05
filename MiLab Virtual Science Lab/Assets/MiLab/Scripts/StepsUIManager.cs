using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepsUIManager : MonoBehaviour
{
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
    private void Start()
    { 
        StepOne = new Steps(objectsAtStepOne);
        StepTwo = new Steps(objectsAtStepTwo);
        Steps StepThree = new Steps(objectsAtStepThree);
        Steps StepFour = new Steps(objectsAtStepFour);
    }

    public void GoToNextStep()
    {
        if(stepsCounter == 0)
        {
            StepOne.HideObjects();
            StepTwo.ShowObjects();
            stepsCounter++;
        }
    }

   
    

}
