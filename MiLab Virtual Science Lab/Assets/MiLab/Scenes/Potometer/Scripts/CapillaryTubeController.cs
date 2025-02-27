using UnityEngine;

public class CapillaryTubeController : MonoBehaviour
{
    private Vector3 initialPosition;  // Store original position
    private Quaternion initialRotation;  // Store original rotation
    private bool isDragging = false;
    private bool hasReleased = false;
    public float returnSpeed = 5f;  // Speed of returning to original position

    public BubbleController bubble;  // Reference to bubble script

    private void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    private void OnMouseDown()
    {
        isDragging = true;
        hasReleased = false;
    }


    private void OnMouseUp()
    {
        isDragging = false;
        hasReleased = true;
    }

    private void Update()
    {
        if (hasReleased)
        {
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, returnSpeed * Time.deltaTime);

            // Stop when it reaches the exact position
            if (transform.position == initialPosition)
            {
                hasReleased = false;

                if (bubble != null)
                {
                    bubble.ActivateBubble();
                }
            }
        }
    }
}
