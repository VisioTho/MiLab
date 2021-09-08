using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedFormulaManager : MonoBehaviour
{
    [SerializeField] private TMP_Text formulaText;
    [SerializeField] private GameObject[] formulaButtons;
    // Start is called before the first frame update

    public void changeSubjectOfTheFormula(string subject)
    {
        if (subject == "Speed")
        {
            formulaText.text = "Speed = Distance/Time";
            formulaButtons[0].transform.localScale = new Vector3(1.15f, 1.15f, 1);
            formulaButtons[1].transform.localScale = new Vector3(1, 1, 1);
            formulaButtons[2].transform.localScale = new Vector3(1, 1, 1);
        }

        if (subject == "Distance")
        {
            formulaText.text = "Distance = Speed x Time";
            formulaButtons[1].transform.localScale = new Vector3(1.15f, 1.15f, 1);
            formulaButtons[0].transform.localScale = new Vector3(1, 1, 1);
            formulaButtons[2].transform.localScale = new Vector3(1, 1, 1);

        }

        if (subject == "Time")
        {
            formulaText.text = "Time = Distance/Speed";
            formulaButtons[2].transform.localScale = new Vector3(1.15f, 1.15f, 1);
            formulaButtons[1].transform.localScale = new Vector3(1, 1, 1);
            formulaButtons[0].transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
