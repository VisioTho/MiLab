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
    int tutorialStep = 0;
    // Start is called before the first frame update
    void Start()
    {
        lengthSLider.onValueChanged.AddListener(delegate { AdjustSlider(); });
        oscillateButton.onClick.AddListener(TaskOnClick);
        for(int i = 1; i<tutorialBoxes.Length; i++)
        {
            tutorialBoxes[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!StartGameScreen.isTutorialEnabled)
        {
            foreach(GameObject i in tutorialBoxes)
            {
                Destroy(i);
            }
        }

       
        
        if(!tutorialBoxes[2].activeSelf && tutorialStep>0)
        {
            tutorialBoxes[3].SetActive(true);
            tutorialStep = 0;
        }
    }

    public void AdjustSlider()
    {
        Destroy(tutorialBoxes[0]);
        tutorialBoxes[1].SetActive(true);
    }
    void TaskOnClick()
    {
        Destroy(tutorialBoxes[1]);
        tutorialBoxes[2].SetActive(true);
        tutorialStep++;
    }
}
