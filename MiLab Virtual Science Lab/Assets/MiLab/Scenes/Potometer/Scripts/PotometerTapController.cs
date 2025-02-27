using UnityEngine;

public class PotometerTapController : MonoBehaviour
{
    public BubbleController bubble;  // Reference to the bubble
    public Transform tapObject;  // The tap that moves along the x-axis
    public float openThreshold = 0.0f;  // X position where tap is considered "open"

    private bool isTapOpen = false;

    private void Update()
    {
        float tapX = tapObject.position.x; // Get current X position of the tap
        Debug.Log(tapX);
        if (tapX < openThreshold && tapX > -0.3f && !isTapOpen)
        {
            isTapOpen = true;
            bubble.RetraceMovement(); // Start the retrace movement
        }
        else if (tapX == 0f && isTapOpen)
        {
            isTapOpen = false;
        }
    }
}
