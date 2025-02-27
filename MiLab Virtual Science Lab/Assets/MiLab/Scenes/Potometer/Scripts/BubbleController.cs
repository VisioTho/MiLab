using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BubbleController : MonoBehaviour
{
    public float baseSpeed = 1f;
    private float currentSpeed;
    private Rigidbody2D rb;
    private bool isMoving = false;
    private Vector2 initialPosition;
    private bool movingUp = false;
    private bool isNight = false;

public enum SpeedType { Temperature, Wind };
 private SpeedType currentSpeedType;
    public WindController windController; // Reference to WindController

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = baseSpeed;
        rb.gravityScale = 0;
        gameObject.SetActive(false); // Hide bubble initially
        initialPosition = transform.position; // Store original position

        if (windController == null)
            windController = FindFirstObjectByType<WindController>();
    }

    public void ActivateBubble()
    {
        gameObject.SetActive(true);
        isMoving = true;
        movingUp = false;
        UpdateBubbleVelocity();
    }

     // Combined AdjustSpeed function for both temperature and wind
    public void AdjustSpeed(float value, SpeedType speedType)
    {
        currentSpeedType = speedType;

        if (isNight)
        {
            currentSpeed = 0;
        }
        else
        {
            if (currentSpeedType == SpeedType.Temperature)
            {
                // Adjust speed based on temperature
                currentSpeed = baseSpeed + (value - 10.0f) * 0.01f;
            }
            else if (currentSpeedType == SpeedType.Wind) 
            {

                Debug.Log(value + " wind speed");
                currentSpeed = Mathf.Lerp(currentSpeed, value, Time.deltaTime * 10f);
            }
        }
       
        currentSpeed = Mathf.Max(0.1f, currentSpeed); // Ensure speed doesn't go negative
        UpdateBubbleVelocity();
    }

    //set night mode
    public void SetNightMode(bool night)
    {
        isNight = !night; // the toggle for setNightMode passes 1 for day and 0 for night
        AdjustSpeed(0, SpeedType.Wind); // Force update to stop movement
    }
    private void UpdateBubbleVelocity()
    {
        if (!isMoving || isNight)  // Stop movement if it's night
        {
            rb.linearVelocity = Vector2.zero; // Stop the bubble completely
            return;
        }

        float totalSpeed = currentSpeed;  // Combine temperature + wind effect

        if (!movingUp)
        {
            rb.linearVelocity = new Vector2(totalSpeed, 0);
        }
        else
        {
            rb.linearVelocity = new Vector2(0, totalSpeed);
        }
    }


    private void FixedUpdate()
    {
        Debug.Log(transform.position+ "bubble pos");
        if (!isMoving) return;

        if (!movingUp)
        {
            if (transform.position.x >= 1.90f)
            {
                movingUp = true;
                UpdateBubbleVelocity();
            }
        }

        if (movingUp)
        {
            if (transform.position.y >= 1.90f)
            {
                ResetBubble();
            }
        }
    }

    private void ResetBubble()
    {
        isMoving = false;
        movingUp = false;
        rb.linearVelocity = Vector2.zero;
        transform.position = initialPosition;
        gameObject.SetActive(false);
    }

    public void RetraceMovement()
    {
        if (!isMoving) return; // Don't retrace if the bubble isn't moving

        StartCoroutine(RetraceCoroutine());
    }

    private IEnumerator RetraceCoroutine()
    {
        isMoving = false;
        rb.linearVelocity = Vector2.zero; // Stop any movement

        Vector2 startPos = transform.position;
        Vector2 middlePos;
        Vector2 endPos = initialPosition; // Final target

        if (movingUp)
        {
            // If bubble was moving up, use the fixed middle position you specified
            middlePos = new Vector2(1.90f, 0.02f); 
            yield return StartCoroutine(LerpPosition(startPos, middlePos, 0.5f));
        }
        else
        {
            // If the bubble wasn't moving up, move horizontally first before moving back
            middlePos = new Vector2(initialPosition.x, startPos.y);
            yield return StartCoroutine(LerpPosition(startPos, middlePos, 0.5f));
        }

        yield return StartCoroutine(LerpPosition(middlePos, endPos, 0.5f));

        ResetBubble();
    }



   private IEnumerator LerpPosition(Vector2 from, Vector2 to, float duration)
{
    float elapsedTime = 0f;

    while (elapsedTime < duration)
    {
        transform.position = Vector2.Lerp(from, to, elapsedTime / duration);
        elapsedTime += Time.deltaTime;
        yield return null;
    }

    transform.position = to; // Ensure it reaches the final position
}


}
