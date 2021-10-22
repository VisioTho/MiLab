using UnityEngine;
using UnityEngine.UI;

public partial class StepsUIManager : MonoBehaviour
{
    public int numberOfSteps;

    public Slider progressBar;

    //group the objects contained in each step respectively.
    public GameObject[] objectsAtStepOne, objectsAtStepTwo, objectsAtStepThree, objectsAtStepFour, objectsAtStepFive;

    private int stepsCounter = 0;

    Steps StepOne; //from Steps partial Class
    Steps StepTwo;
    Steps StepThree;

    private void Start()
    {
        StepOne = new Steps(objectsAtStepOne);
        StepTwo = new Steps(objectsAtStepTwo);
        StepThree = new Steps(objectsAtStepThree);
        StepTwo.HideObjects();
        StepThree.HideObjects();
        progressBar.maxValue = numberOfSteps-1;
    }

    public void GoToNextStep()
    {
        switch (stepsCounter)
        {
            case 0:
                StepOne.HideObjects();

                StepTwo.ShowObjects();
                stepsCounter++;
                break;
            case 1:
                StepTwo.HideObjects();

                StepThree.ShowObjects();

                stepsCounter++;
                break;
        }
    }

    public void PreviousStep()
    {

        switch (stepsCounter)
        {
            case 1:
                StepOne.ShowObjects();

                StepTwo.HideObjects();
                stepsCounter--;
                break;
            case 2:
                StepThree.HideObjects();
                StepTwo.ShowObjects();

                stepsCounter--;
                break;
        }
    }

    public Button finishButton, nxtButton;
    void Finish()
    {
        if(stepsCounter == numberOfSteps-1)
        {
            finishButton.gameObject.SetActive(true);
            nxtButton.gameObject.SetActive(false);
        }
        else
        {
            finishButton.gameObject.SetActive(false);
            nxtButton.gameObject.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        ProgressBar();
        Finish();
    }

    private void ProgressBar() => progressBar.value = stepsCounter;
}
