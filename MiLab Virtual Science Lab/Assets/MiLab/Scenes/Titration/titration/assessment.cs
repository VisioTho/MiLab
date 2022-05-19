using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class assessment : MonoBehaviour
{
    public float userAnswer, concentrationAnswer;
    private int correctRessponseCount = 0;

    // public float correctAnswer = 15;
    [SerializeField] private TMP_InputField userFeedback, userConcentrationFeedback;
    [SerializeField] private TMP_Text feedbackText, secondFeedback;

    public GameObject congratsPanel, tryAgainPanel;

    public void VolumeCheck()
    {

        userAnswer = float.Parse(userFeedback.text);
        if (userAnswer != 15)
        {
            feedbackText.text = "Oops! Incorrect volume of titrant. Please check that your burette reading was correct and try again";
        }
        else if (userAnswer == null)
        {
            feedbackText.text = "Please enter your answer";
        }
        else
        {
            feedbackText.text = "Great job! your calculated volume of 15 ml was equal to the actual value of 15 ml";
            correctRessponseCount++;
        }
    }

    public void concentrationCheck()
    {
        concentrationAnswer = float.Parse(userConcentrationFeedback.text);
        if (concentrationAnswer != 0.05f)
        {
            secondFeedback.text = "Oops! Incorrect concentration of titrant. Please check that you entered correct values and try again";
        }
        else if (concentrationAnswer == null)
        {
            secondFeedback.text = "Please enter your answer";
        }
        else
        {
            secondFeedback.text = "Great job! your calculated concentration of 0.05M was equal to the actual value of 0.05M ml";
            correctRessponseCount++;
        }
    }

    public void checkResponse()
    {
        if (correctRessponseCount < 2)
        {
            tryAgainPanel.SetActive(true);
        }
        else
        {
            // Debug.Log("mwapha");
            congratsPanel.SetActive(true);
        }
    }

}
