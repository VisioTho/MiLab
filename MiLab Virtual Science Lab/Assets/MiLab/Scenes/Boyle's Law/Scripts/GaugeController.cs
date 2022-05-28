using UnityEngine;
using UnityEngine.UI;

public class GaugeController : MonoBehaviour
{
    public GameObject oil;
    public float initialAngle;
    //public TMP_Text pressureDisplayText;
    private const float MAX_ANGLE = -45f;
    private const float MIN_ANGLE = 71.0f;
    public Button button;
    private int counter;

    private float oilScale, maxOilScale;

    private void Start()
    {
        counter = 0;
        maxOilScale = 9f;
        transform.eulerAngles = new Vector3(0, 0, initialAngle);
    }

    float airColumn, hyperbolaFunction;
    float gaugeAngle;

    
    public void RotateGauge()
    {
        
        Debug.Log("Should be clicked");


        if (transform.eulerAngles.z == 32.0f)
        {
            transform.eulerAngles = new Vector3(0, 0, 24.0f);
            //oil.transform.localScale = new Vector2(0, 2.9f);
        }

        else if (transform.eulerAngles.z == 24.0f)
        {
            transform.eulerAngles = new Vector3(0, 0, 16.0f);
            //oil.transform.localScale = new Vector2(0.3192797f, 4.0f);
            oil.transform.LeanScaleY(4.0f, 0.5f);
        }

        else if (transform.eulerAngles.z <= 17.0f && transform.eulerAngles.z >= 14.0f)
        {

            transform.eulerAngles = new Vector3(0, 0, 8.0f);

        }
        else if (transform.eulerAngles.z <= 8.0f && transform.eulerAngles.z >= 7.0f)
        {

            transform.eulerAngles = new Vector3(0, 0, -1.0f);
            oil.transform.LeanScaleY(4.75f, 0.5f);
        }
        else if (transform.eulerAngles.z <= 359.0f && transform.eulerAngles.z >= 357.0f)
        {
            transform.eulerAngles = new Vector3(0, 0, -10.0f);

        }
        else if (transform.eulerAngles.z <= 350.0f && transform.eulerAngles.z >= 349.0f)
        {
            transform.eulerAngles = new Vector3(0, 0, -19f);
            oil.transform.LeanScaleY(5.35f, 0.5f);
        }
        else if (transform.eulerAngles.z == 341f)
        {
            transform.eulerAngles = new Vector3(0, 0, -28.0f);
        }

        else if (transform.eulerAngles.z == 332.0f)
        {
            transform.eulerAngles = new Vector3(0, 0, -37.0f);
            oil.transform.LeanScaleY(5.75f, 0.5f);
        }
        else if (transform.eulerAngles.z == 323.0f)
        {
            transform.eulerAngles = new Vector3(0, 0, -43.0f); //317

        }
        else if (transform.eulerAngles.z == 317.0f)
        {
            transform.eulerAngles = new Vector3(0, 0, -52.0f);
            oil.transform.LeanScaleY(6.07f, 0.5f);
        }
        else if (transform.eulerAngles.z == 308.0f)
        {
            transform.eulerAngles = new Vector3(0, 0, -61.0f);

        }
        else if (transform.eulerAngles.z == 299.0f)
        {
            transform.eulerAngles = new Vector3(0, 0, -70.0f);
        }
        else if (transform.eulerAngles.z == 290.0f)
        {
            transform.eulerAngles = new Vector3(0, 0, -79.0f);
        }
        else if (transform.eulerAngles.z == 281.0f)
        {
            transform.eulerAngles = new Vector3(0, 0, -86);
        }


    }
    private void RotateSpeedometer()
    {
        gaugeAngle = transform.eulerAngles.z;
        //float oilScale;
        if(PumpController.isPumped)
        {
            float v;
            v = transform.eulerAngles.z - 0.5f;
            transform.eulerAngles = new Vector3(0, 0, v);
            //PumpController.isPumped = false;
        }

        //airColumn = 9.21f - oil.transform.localScale.y;

        //Debug.Log("Pressure is " + airColumn);
        //hyperbolaFunction = (1.2f / airColumn) * 1.0f;
        //oilScale = 9.21f - hyperbolaFunction;
  
        
        //oilScale = ((0.8136707f / transform.rotation.z) * 2.9f);
        //oil.transform.localScale = new Vector2(0.3192797f, oilScale);

        //Debug.Log("Pressure reading is" +(88.84557f / transform.eulerAngles.z) * 200f);
    }
    private float GaugeScaleConverter()
    {
        float totalAngleSize = MAX_ANGLE - MIN_ANGLE;
        float oilScaleNormalized = oilScale / maxOilScale;
       

        return (MIN_ANGLE + totalAngleSize / oilScaleNormalized) * -1;
    }

    float pressure;
    
    private void Update()
    {

        Debug.Log("Rotation is now at: " + transform.eulerAngles.z);
        
        if(PumpController.isPumped && counter == 0)
        {
            button.onClick.Invoke();
            counter++;
        }

        if(PumpController.isPumped == false && counter == 1)
        {
            counter = 0;
        }
        
        
        //pressure = (44.754f / transform.rotation.z) * 6.05f;
        //pressureDisplayText.text = pressure.ToString("f0");
        oilScale = oil.transform.localScale.y;
        //transform.eulerAngles = new Vector3(0, 0, GaugeScaleConverter());     
        //RotateSpeedometer();
        
    }

}
