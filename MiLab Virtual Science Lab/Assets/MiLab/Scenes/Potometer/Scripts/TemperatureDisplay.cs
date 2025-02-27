using UnityEngine;
using TMPro;

public class TemperatureDisplay : MonoBehaviour
{
    public TemperatureManager temperatureManager;
     private TextMeshProUGUI textComponent; // Reference to the text component

    void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>(); // Get the TextMeshPro component
    }

    void Update()
    {
        if (temperatureManager != null && textComponent != null)
        {
            textComponent.text = temperatureManager.temperature + "°C";
        }
    }
}
