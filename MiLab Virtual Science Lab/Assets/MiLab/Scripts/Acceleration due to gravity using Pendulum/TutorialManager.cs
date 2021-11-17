using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] tutorialBoxes;

    int tutorialStep = 0; //keeps track of which step in the tutorial we are at

    void Start()
    {
        for (int i = 1; i < tutorialBoxes.Length; i++)
        {
            tutorialBoxes[i].SetActive(false);
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
            foreach (GameObject i in tutorialBoxes)
            {
                Destroy(i);
            }
        }

        if (!tutorialBoxes[0].activeSelf && tutorialStep == 0)
        {
            tutorialBoxes[1].SetActive(true);

            tutorialStep = 1;
        }
        if (!tutorialBoxes[1].activeSelf && tutorialStep == 1)
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
