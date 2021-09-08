using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MotionCharacteristicsManager : MonoBehaviour
{
    private const bool A = false;
    private const bool V = true;

    /*--------------------------------------------------------------------
Script Summary 
This script measures characteristics of motion of the 2D car including 
average speed, instantenous speed and distance. 

The script also manages end-of-simulation assesment.
------------------------------------------------------------------------*/
    private float Speed;
    [SerializeField] TMP_Text distanceText, timerText, speedometerText;
    private float startTime;
    [SerializeField] private GameObject car, flag, finishLineUI;
    private Vector3 lastPosition;
    private float totalDistance, totalTime, averageSpeed;
    Vector3 currentEulerAngles; public Rigidbody2D carbody;
    [SerializeField] private GameObject redLight, greenLight, carControls;
    [SerializeField] private float delay;
    [SerializeField] private TMP_Text lightsText;

    #region simulation assesment

    public GameObject[] assesmentPanels;
    [SerializeField] private TMP_InputField userFeedbackS, userFeedbackD;
    [SerializeField] private TMP_Text feedbackText;
    public Button[] nextButtons;

    //class AssesmentManager handles student assesment questions for this simulation
    public class AssesmentManager
    {
        public float userAnswer;
        public float correctAnswer;
        private bool result = false;

        public AssesmentManager()
        {
            userAnswer = 0f;
            correctAnswer = -1f;
        }

        public bool mark()
        {
            if (userAnswer == correctAnswer)
            {
                result = true;
            }
            return result;
        }
    }

    //create instances of the AssesmentManager class (questions)
    AssesmentManager speedQuestion = new AssesmentManager();
    AssesmentManager distanceQuestion = new AssesmentManager();

    //processResponse handles user feedback from input fields for each question instance
    public void processResponse()
    {
        //get user input for each question. parse the string to floating point numbers.
        speedQuestion.userAnswer = float.Parse(userFeedbackS.text);
        distanceQuestion.userAnswer = float.Parse(userFeedbackD.text);

        //get correct answer for the question to find distance given speed and time
        float d = 50 * averageSpeed;
        string tempd = d.ToString("f2");
        d = float.Parse(tempd);
        distanceQuestion.correctAnswer = d;

        //get correct answer for the question to find speed given time and distance
        speedQuestion.correctAnswer = averageSpeed;

        //handle results of the assesment
        if (speedQuestion.userAnswer != 0.00)
        {
            if (speedQuestion.mark())
            {
                assesmentPanels[0].SetActive(false);
                assesmentPanels[1].SetActive(V);
                feedbackText.text = "";
            }
            else
            {
                feedbackText.text = "Incorrect! Enter a different number.";
            }
        }

        if (distanceQuestion.userAnswer != 0.00)
        {
            if (distanceQuestion.mark())
            {
                assesmentPanels[0].SetActive(false);
                assesmentPanels[1].SetActive(false);
                assesmentPanels[2].SetActive(true);
                Time.timeScale = 1f;
            }
            else
            {
                feedbackText.text = "Incorrect. Enter a different number.";
            }
        }
    }
    #endregion

    private void Awake()
    {
        Speed = 0f;
    }

    void Start()
    {
        lastPosition = car.transform.position;
        StartCoroutine(WaitForGreenLight());
        lightsText.text = "Ready..";
        carControls.SetActive(false);
        finishLineUI.SetActive(false);

        foreach (Button i in nextButtons)
        {
            i.interactable = A;
        }
    }

    //wait for traffic lights before start driving the car
    IEnumerator WaitForGreenLight()
    {
        yield return new WaitForSeconds(delay);
        Destroy(redLight);
        greenLight.SetActive(true);
        carControls.SetActive(true);
        lightsText.text = "Drive car to finish line";
        startTime = Time.time;
    }

    // Update is called once per frame
    float t = 0f;
    void Update()
    {
        if (greenLight.activeSelf) //if green lights go on
        {
            //find time collapsed in seconds
            t = Time.time - startTime;
            float seconds = t;
            string sec = seconds.ToString("f0");
            timerText.text = sec;
            totalTime = t;
            string tempT = totalTime.ToString("f0");
            totalTime = float.Parse(tempT);

            //calculate distance travelled by finding the the sum of differences of currentposition
            //and lastposition of the car for each frame.
            float distance = Vector3.Distance(lastPosition, car.transform.position);
            totalDistance += distance;
            string tempD = totalDistance.ToString("f0");
            lastPosition = car.transform.position;
            distanceText.text = totalDistance.ToString("f0");
            float distanceToFinish = Vector2.Distance(car.transform.position, flag.transform.position);

            if (distanceToFinish > 0f && distanceToFinish < 1.0f)
            {
                FinishLine();
            }

            //find average speed and instantaneous speed
            float speed = float.Parse(tempD) / totalTime;
            string tempSpeed = speed.ToString("f2");
            averageSpeed = float.Parse(tempSpeed);
            float instantaneousSpeed = carbody.velocity.x;

            if (instantaneousSpeed < 0)
            {
                instantaneousSpeed *= -1; //Ensure instantaneous speed is always a positive value (it becomes negative in reverse)
            }

            if (instantaneousSpeed == 0)
            {
                carbody.Sleep();
            }
            speedometerText.text = instantaneousSpeed.ToString("f0");
        }

        //disable 'next' buttons in assesment panels until user inputs values 
        if (userFeedbackS.text.Length > 0)
            nextButtons[0].interactable = true;
        if (userFeedbackD.text.Length > 0)
            nextButtons[1].interactable = true;
    }

    [SerializeField] private TMP_Text totalDistanceText, totalTimeText, averageSpeedText;
    [SerializeField] private GameObject FinishLinePanel;
    //this function displays summary of motion of the 2D car after the car passes the finish line
    private void FinishLine()
    {
        FinishLinePanel.SetActive(true);
        Time.timeScale = 0f;
        totalDistanceText.text = totalDistance.ToString("f0");
        totalTimeText.text = totalTime.ToString("f0");
        averageSpeedText.text = averageSpeed.ToString();
    }
}
