using UnityEngine;
using UnityEngine.UI;

public class LightingController : MonoBehaviour
{
    public Material daySkybox; // Assign your day skybox material in the Inspector
    public Material nightSkybox; // Assign your night skybox material in the Inspector
    public GameObject mainCamera; // Reference to the Main Camera (where the Skybox Material is set)
  
    public Toggle dayNightToggle; // UI Toggle to switch between day and night
    public BubbleController bubble;

    private void Start()
    {
        // Ensure the toggle is set correctly
        if (dayNightToggle != null)
        {
            dayNightToggle.onValueChanged.AddListener(SetLightingMode);
        }

        // Initialize lighting based on toggle state
        SetLightingMode(dayNightToggle != null && dayNightToggle.isOn);
    }

    public void SetLightingMode(bool isDay)
    {
        if (mainCamera != null)
        {
            Skybox cameraSkybox = mainCamera.GetComponent<Skybox>();
            if (cameraSkybox != null)
            {
                cameraSkybox.material = isDay ? daySkybox : nightSkybox;
            }
        }

        
        bubble.SetNightMode(isDay);
    }
}
