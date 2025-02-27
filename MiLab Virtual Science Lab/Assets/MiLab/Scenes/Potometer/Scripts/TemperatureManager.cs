using UnityEngine;

public class TemperatureManager : MonoBehaviour
{
    public float temperature = 20f; // Initial temperature
    public float tempChangeAmount = 0.2f;
    public float maxTemperature = 50f; // Maximum temperature
    public float minTemperature = 0f; // Minimum temperature

    public BubbleController bubble; // Reference to the BubbleController

    public float CurrentTemperature => temperature; // Expose the temperature for UI or other scripts

    public void OnTemperatureChanged(float newTemperature)
    {
        temperature = newTemperature;
        Debug.Log(temperature);
        UpdateBubbleSpeed();
    }

    private void UpdateBubbleSpeed()
    {
        if (bubble != null)
        {
            bubble.AdjustSpeed(temperature, BubbleController.SpeedType.Temperature);
        }
    }
}
