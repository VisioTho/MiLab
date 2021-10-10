using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    /*--------------------------------------------------------------------
                            Script Summary 
       This script measures characteristics of motion of the 2D car including 
       average speed, instantenous speed and distance.
    ------------------------------------------------------------------------*/

    private const float MAX_SPEED_ANGLE = -110f, MIN_SPEED_ANGLE = 115f;
    public Transform needleTransform;
    private float maxSpeed;
    private float Speed;
    [SerializeField] TMP_Text distanceText, timerText, speedText, speedometerText;
    private float startTime;
    [SerializeField] private GameObject car, flag;
    private Vector3 lastPosition;
    private float totalDistance, totalTime, averageSpeed;
    Vector3 currentEulerAngles; public Rigidbody2D carbody;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        lastPosition = car.transform.position;
    }

    private void Awake()
    {
        Speed = 0f;
        maxSpeed = 200f;
    }

    // Update is called once per frame
    void Update()
    {
        #region //find time collapsed in seconds
        float t = Time.time - startTime;
        string min = ((int)t / 60).ToString();
        string sec = t.ToString("f0");
        timerText.text = sec;
        totalTime = t;
        #endregion

        #region //find average speed and instantaneous speed
        float speed = totalDistance / t;
        averageSpeed = speed;
        speedText.text = speed.ToString("f0");
        float instantaneousSpeed = carbody.velocity.x;

        if (instantaneousSpeed < 0)
        {
            instantaneousSpeed *= -1;
        }

        speedometerText.text = instantaneousSpeed.ToString("f0");
        #endregion

        #region //manage speedometer - under development
        Speed = instantaneousSpeed * Time.deltaTime;
        if (Speed > maxSpeed) Speed = maxSpeed;

        needleTransform.Rotate(new Vector3(0f, 0f, GetSpeedRotation()));
        needleTransform.eulerAngles = new Vector3(0, 0, GetSpeedRotation());


        #endregion

        #region //Find distance travelled
        float distance = Vector3.Distance(lastPosition, car.transform.position);
        totalDistance += distance;
        lastPosition = car.transform.position;
        distanceText.text = totalDistance.ToString("f0");
        float distanceToFinish = Vector2.Distance(car.transform.position, flag.transform.position);

        if (distanceToFinish > 0f && distanceToFinish < 1.0f)
        {
            FinishLine();
        }
        #endregion 
    }

    //get rotation metrics for speedometer
    private float GetSpeedRotation()
    {
        float totalAngleSize = MIN_SPEED_ANGLE - MAX_SPEED_ANGLE;
        float speedNormalized = Speed / maxSpeed;

        // Debug.Log((MIN_SPEED_ANGLE-speedNormalized)*totalAngleSize);
        return MIN_SPEED_ANGLE - speedNormalized * totalAngleSize;
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
        averageSpeedText.text = averageSpeed.ToString("f0");
    }
}
