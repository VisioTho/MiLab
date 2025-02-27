using UnityEngine;
using TMPro;
public class FanSpeedDisplay : MonoBehaviour
{
    public WindController windController;
    private TextMeshProUGUI textComponent; // Reference to the text component

    void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>(); // Get the TextMeshPro component
    }

    void Update()
    {
        if (windController != null && textComponent != null)
        {
            textComponent.text = "Level " +windController.FanSpeedLevel;
        }
    }
}
