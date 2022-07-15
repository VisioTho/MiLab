using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.Mathematics;
using UnityEngine.UI;
using TMPro;

public class ProgressBarApparatus : MonoBehaviour
{
    public static double MAXIMUM_X_STRETCH;
    public static int current_connected_points;
    public int NUMBER_OF_PAIR_CONNECTION_POINTS; //to be accessed from Engine Inspector
    public static double current_x_stretch;
    public float lerpDuration;
    public static bool shouldUpdateProgBar;
    public TextMeshProUGUI percentage_text;
    public GameObject next_button;

    void Start()
    {
        // Default values, to be modified by other classes
        current_connected_points = 0;
        MAXIMUM_X_STRETCH = 0.995f;

        current_x_stretch = 0.0f;
        lerpDuration = 3f;
        shouldUpdateProgBar = false;
    }


    void FixedUpdate()
    {
      
        current_x_stretch = Math.Round((Convert.ToDouble(current_connected_points/2) / Convert.ToDouble(NUMBER_OF_PAIR_CONNECTION_POINTS) * MAXIMUM_X_STRETCH), 3);

        if (shouldUpdateProgBar) { StartCoroutine(update_progressBar(lerpDuration)); shouldUpdateProgBar = false; };
        double progress_percent = Math.Round(current_x_stretch / MAXIMUM_X_STRETCH * 100f, 0, MidpointRounding.AwayFromZero);

        if (progress_percent != 100.0f) {
            percentage_text.text = current_connected_points/2 +"/"+NUMBER_OF_PAIR_CONNECTION_POINTS +"("+ progress_percent + "%)";
            if (next_button.activeSelf)
            {
                next_button.SetActive(false);
            }
        }
        else
        {
            percentage_text.text = progress_percent + "% - completed!";
            next_button.SetActive(true);
        }
    }

    public IEnumerator update_progressBar(float duration)
    {
        float time = 0;

        while (time < duration)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(Convert.ToSingle(current_x_stretch), transform.localScale.y, transform.localScale.z), time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.localScale = new Vector3(Convert.ToSingle(current_x_stretch), transform.localScale.y, transform.localScale.z);
        time = 0; //reseting
    }
}
