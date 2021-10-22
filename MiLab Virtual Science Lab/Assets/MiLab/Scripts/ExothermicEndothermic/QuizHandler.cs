using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizHandler : MonoBehaviour
{
    public ToggleGroup potassiumNitrateQuest, iceQuest, sodiumHydroxideQuest;
    private Toggle toggleA, toggleB, toggleC;
    public GameObject congratsPanel, tryAgainPanel;

    public void HandleResponse()
    {
        int correctResponseCount = 0;
        GetResponses();

        if (toggleA.name == "EndothermicOn")
        {
            correctResponseCount++;
        }
        if (toggleB.name == "EndothermicOn")
        {
            correctResponseCount++;
        }
        if (toggleC.name == "ExothermicOn")
        {
            correctResponseCount++;
        }

        if(correctResponseCount<3)
        {
            tryAgainPanel.SetActive(true);
        }
        else
        {
            congratsPanel.SetActive(true);
        }

        void GetResponses()
        {
            toggleA = potassiumNitrateQuest.GetFirstActiveToggle();
            toggleB = iceQuest.GetFirstActiveToggle();
            toggleC = sodiumHydroxideQuest.GetFirstActiveToggle();
        }

        Debug.Log(correctResponseCount);
    }

    private void Update()
    {
       
    }

}
