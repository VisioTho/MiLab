using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Accessibility;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject[] tutorialBoxes;
    public Slider lengthSLider;
    public Button oscillateButton;
    int tutorialStep = 0; //keeps track of which step in the tutorial we are at
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 1; i<tutorialBoxes.Length; i++)
        {
            tutorialBoxes[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        RunTutorial();
    }

    private void RunTutorial()
    {
        if (!StartGameScreen.isTutorialEnabled)
        {
            foreach (GameObject i in tutorialBoxes)
            {
                Destroy(i);
            }
        }

        //step 3 tutorial - instruct the user to record findings
        if(!tutorialBoxes[0].activeSelf && tutorialStep ==0)
        {
            tutorialBoxes[1].SetActive(true);
            tutorialStep = 1;
        }
        if(!tutorialBoxes[1].activeSelf && tutorialStep == 1)
        {
            tutorialBoxes[2].SetActive(true);
            tutorialStep = 2;
        }
        if (!tutorialBoxes[2].activeSelf && tutorialStep == 2)
        {
            tutorialBoxes[3].SetActive(true);
            Destroy(tutorialBoxes[2]);
            tutorialStep = 3;
        }
        if (!tutorialBoxes[3].activeSelf && tutorialStep == 3)
        {
            Destroy(tutorialBoxes[3]);
            tutorialBoxes[4].SetActive(true);
            tutorialStep = 4;
        }
    }

   
}
