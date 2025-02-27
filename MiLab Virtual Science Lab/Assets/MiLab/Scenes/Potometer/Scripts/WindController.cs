using UnityEngine;
using TMPro;

public class WindController : MonoBehaviour
{
    public float windSpeed = 0f; // Initial wind speed
    public float windChangeAmount = 0.25f; // Amount to increase or decrease wind speed
    public float maxWindSpeed = 1.0f; // Maximum wind speed
    public float minWindSpeed = 0.1f; // Minimum wind speed

    public BubbleController bubble; // Reference to the BubbleController
    public WindZone windZone; // Reference to the WindZone component in the scene
    public GameObject fanBlade; // Reference to the fan blade object in the scene
    private float currentFanSpeed = 0f; // Current rotation speed of the fan
    public float fanRotationSpeedMultiplier = 50f; // Multiplier to adjust fan speed based on wind

    private int fanSpeedLevel = 0; // Fan speed level (1, 2, 3)

    public int FanSpeedLevel => fanSpeedLevel; // Expose fan speed level to other scripts

    private void Start()
    {
        if (windZone == null)
        {
            windZone = FindFirstObjectByType<WindZone>(); // Find WindZone if not assigned
        }

        windSpeed = Mathf.Clamp(windSpeed, minWindSpeed, maxWindSpeed); // Ensure initial wind speed is within range
        UpdateBubbleWind();
    }

    private void Update()
    {
        UpdateFanRotation(); // Continuously update fan rotation
    }

    //slider onvaluechanged
    public void OnWindSpeedChanged(float newWindSpeed)
    {
        Debug.Log($"Wind Speed Changed: {newWindSpeed}"); // Debugging to check changes
        windSpeed = newWindSpeed;
        UpdateBubbleWind();
    }

    private void UpdateBubbleWind()
    {
        if (bubble != null)
        {
            bubble.AdjustSpeed(windSpeed, BubbleController.SpeedType.Wind);
        }

        if (windZone != null)
        {
            windZone.windMain = windSpeed;
            windZone.windTurbulence = windSpeed;
        }

        UpdateFanSpeedLevel(); // Update fan speed level
        UpdateFanRotation();
    }

    private void UpdateFanSpeedLevel()
    {
        if (windSpeed < 0.25f) fanSpeedLevel = 0;
        else if (windSpeed <= 0.5f) fanSpeedLevel = 1;
        else if (windSpeed <= 0.75) fanSpeedLevel = 2;
        else fanSpeedLevel = 3;
    }

    private void UpdateFanRotation()
    {
        if (fanBlade != null)
        {
            if (windSpeed > minWindSpeed)
            {
                float targetRotationSpeed = windSpeed * fanRotationSpeedMultiplier;
                currentFanSpeed = Mathf.Lerp(currentFanSpeed, targetRotationSpeed, Time.deltaTime * 25f);
                fanBlade.transform.Rotate(Vector3.forward, currentFanSpeed * Time.deltaTime);
            }
            else
            {
                currentFanSpeed = Mathf.Lerp(currentFanSpeed, 0f, Time.deltaTime * 5f);
                fanBlade.transform.Rotate(Vector3.forward, currentFanSpeed * Time.deltaTime);
            }
        }
    }
}
