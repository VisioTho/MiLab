using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SimulationTimer : MonoBehaviour
{
    float totalSimulationTime;
    float StartTime;
    public TMP_Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        StartTime = Time.time;
    }

    public void ResetTimer() => StartTime = Time.time;

    // Update is called once per frame
    void Update()
    {
        totalSimulationTime = Time.time - StartTime;
        float minutes = (int)totalSimulationTime / 60;
        float seconds = totalSimulationTime % 60;
        timerText.text = minutes.ToString("F0") + ":" +seconds.ToString("F0");
    }
}
