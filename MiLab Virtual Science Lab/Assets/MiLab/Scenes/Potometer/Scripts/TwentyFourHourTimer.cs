using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TwentyFourHourTimer : MonoBehaviour
{
    [SerializeField]private TMP_Text timeDisplay;
    private int count = 0;
    private float timer = 0f;

    public void ResetTimer()
    {
        timer = 0f;
        count = 0;
    }
    void Update()
    {
        if(BubbleController.patometerIsConnected)
        {
            timer += Time.deltaTime; // Increase timer
            if (timer >= 1f)
            { // Check if 1 second has passed
                count++; // Increment count by 1
                timer = 0f; // Reset timer
            }
            if (count >= 24)
            {
                timer = 0f;
            }
        }
        

        timeDisplay.text = "Hours elapsed: " + count;
    }
}
