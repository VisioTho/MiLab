using UnityEngine;
using TMPro;
public class StopWatchManager : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    private float stopWatchTime;
    private float timer;
    private bool watchReset = true;
    private bool watchStopped = true;

    public void ResetWatch()
    {
        watchReset = true;
    }

    private void Start()
    {
        watchStopped = true;
    }

    public void StartWatch()
    {
        watchReset = false;
        watchStopped = false;
    }
    public void StopWatch()
    {
        watchStopped = true;
    }
    private void ControlStopWatch()
    {
        if (!watchReset)
        {
            if (!watchStopped)
                stopWatchTime += 1 * Time.deltaTime;
            string sec = stopWatchTime.ToString("f2");
            timer = stopWatchTime;
            timerText.text = sec;
        }
        else
        {
            stopWatchTime = 0f;
            timerText.text = "0.00";
        }
    }

    private void FixedUpdate()
    {
        ControlStopWatch();
    }
}