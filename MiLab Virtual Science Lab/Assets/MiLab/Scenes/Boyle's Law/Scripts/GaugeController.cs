using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GaugeController : MonoBehaviour
{
    public GameObject oil;
    public GameObject oilLevelIndicator;
    public float initialAngle;
    public GameObject gasTap;
    //public TMP_Text pressureDisplayText;
    private const float MAX_ANGLE = -45f;
    private const float MIN_ANGLE = 71.0f;
    public Button pumpButton;
    public Button drainButton;
    private int counter;
    

    private float oilScale, maxOilScale;

    private void Start()
    {
        counter = 0;
        maxOilScale = 9f;
        transform.eulerAngles = new Vector3(0, 0, initialAngle);
    }

    

    IEnumerator DrainCoroutine()
    {
        yield return new WaitForSeconds(1.0f);
    }

    public void Depressurize()
    {
        oilLevelIndicator.LeanScaleY(-0.05f, 2.9f);
       
        transform.eulerAngles = new Vector3(0, 0, 32.0f);
        oil.transform.LeanScaleY(2.9f, 0.5f);
        pressureLabel.text = "110";
    }
    public void DrainGas()
    {
        StartCoroutine(DrainCoroutine());
       
        if (transform.eulerAngles.z == 32.0f)
        {
            pressureLabel.text = "110";
        }

        else if (transform.eulerAngles.z == 24.0f)
        {
            oilLevelIndicator.LeanScaleY(-0.05f, 2.9f); 
            Debug.Log("are you alive? " + oilLevelIndicator.name);
            transform.eulerAngles = new Vector3(0, 0, 32.0f);
            oil.transform.LeanScaleY(2.9f, 0.5f);
            pressureLabel.text = "110";

        }

        else if (transform.eulerAngles.z <= 17.0f && transform.eulerAngles.z >= 14.0f)
        {

            transform.eulerAngles = new Vector3(0, 0, 24.0f);
            //oil.transform.localScale = new Vector2(0, 2.9f);
            oil.transform.LeanScaleY(3.45f, 0.5f);
            pressureLabel.text = "120";
            oilLevelIndicator.LeanMoveLocalY(-0.05f, 0.5f);//transform.position = new Vector2(oilLevelIndicator.transform.position.x, -0.05f);



        }
        else if (transform.eulerAngles.z <= 8.0f && transform.eulerAngles.z >= 7.0f)
        {
            transform.eulerAngles = new Vector3(0, 0, 16.0f);
            //oil.transform.localScale = new Vector2(0.3192797f, 4.0f);
            oil.transform.LeanScaleY(4.0f, 0.5f);
            pressureLabel.text = "130";

            oilLevelIndicator.LeanMoveLocalY(0.225f, 0.5f);
        }
        else if (transform.eulerAngles.z <= 359.0f && transform.eulerAngles.z >= 357.0f)
        {
            transform.eulerAngles = new Vector3(0, 0, 8.0f);
            oil.transform.LeanScaleY(4.37f, 0.5f);
            pressureLabel.text = "140";
            oilLevelIndicator.LeanMoveLocalY(0.498f, 0.5f);
        }
        else if (transform.eulerAngles.z <= 350.0f && transform.eulerAngles.z >= 349.0f)
        {
            transform.eulerAngles = new Vector3(0, 0, -2.0f);
            oil.transform.LeanScaleY(4.75f, 0.5f);
            pressureLabel.text = "150";
            oilLevelIndicator.LeanMoveLocalY(0.704f, 0.5f);
        }
        else if (transform.eulerAngles.z == 341.0f)
        {
            transform.eulerAngles = new Vector3(0, 0, -10.0f);
            oil.transform.LeanScaleY(5.05f, 0.5f);
            pressureLabel.text = "160";
            oilLevelIndicator.LeanMoveLocalY(0.88f, 0.5f);
        }

        else if (transform.eulerAngles.z == 332.0f)
        {
            transform.eulerAngles = new Vector3(0, 0, -19f);
            oil.transform.LeanScaleY(5.35f, 0.5f);
            pressureLabel.text = "170";
            oilLevelIndicator.LeanMoveLocalY(1.055f, 0.5f);
        }
        else if (transform.eulerAngles.z == 323.0f)
        {
            transform.eulerAngles = new Vector3(0, 0, -28.0f);
            oil.transform.LeanScaleY(5.5f, 0.5f);
            pressureLabel.text = "180";
            oilLevelIndicator.LeanMoveLocalY(1.134f, 0.5f);

        }
        else if (transform.eulerAngles.z == 317.0f)
        {
            transform.eulerAngles = new Vector3(0, 0, -37.0f);
            oil.transform.LeanScaleY(5.69f, 0.5f);
            pressureLabel.text = "190";
            oilLevelIndicator.LeanMoveLocalY(1.254f, 0.5f);

        }
        else if (transform.eulerAngles.z == 308.0f)
        {
            transform.eulerAngles = new Vector3(0, 0, -43.0f); //317
            oil.transform.LeanScaleY(5.88f, 0.5f);
            pressureLabel.text = "200";
            oilLevelIndicator.LeanMoveLocalY(1.358f, 0.5f);
        }
        else if (transform.eulerAngles.z == 299.0f)
        {
            transform.eulerAngles = new Vector3(0, 0, -52.0f);
            oil.transform.LeanScaleY(6.07f, 0.5f);
            pressureLabel.text = "210";
            oilLevelIndicator.LeanMoveLocalY(1.473f, 0.5f);
        }
        else if (transform.eulerAngles.z == 290.0f)
        {
            transform.eulerAngles = new Vector3(0, 0, -61.0f);
            oil.transform.LeanScaleY(6.27f, 0.5f);
            pressureLabel.text = "220";
            oilLevelIndicator.LeanMoveLocalY(1.573f, 0.5f);
        }
        else if (transform.eulerAngles.z == 281.0f)
        {
            transform.eulerAngles = new Vector3(0, 0, -70.0f);
            oil.transform.LeanScaleY(6.64f, 0.5f);
            pressureLabel.text = "230";
            oilLevelIndicator.LeanMoveLocalY(1.68f, 0.5f);
        }
        else if (transform.eulerAngles.z == 274.0f)
        {
            transform.eulerAngles = new Vector3(0, 0, -70.0f);
            oil.transform.LeanScaleY(6.64f, 0.5f);
            pressureLabel.text = "240";
            oilLevelIndicator.LeanMoveLocalY(1.796f, 0.5f);
        }
    }

    public TMP_Text pressureLabel;
    public void RotateGauge()
    {
        if (transform.eulerAngles.z == 32.0f)
        {
            transform.eulerAngles = new Vector3(0, 0, 24.0f);
            //oil.transform.localScale = new Vector2(0, 2.9f);
            oil.transform.LeanScaleY(3.45f, 0.5f);
            pressureLabel.text = "120";
            oilLevelIndicator.LeanMoveLocalY(-0.05f, 0.5f);
        }

        else if (transform.eulerAngles.z == 24.0f)
        {
            transform.eulerAngles = new Vector3(0, 0, 16.0f);
            //oil.transform.localScale = new Vector2(0.3192797f, 4.0f);
            oil.transform.LeanScaleY(4.0f, 0.5f);
            pressureLabel.text = "130";
            oilLevelIndicator.LeanMoveLocalY(0.225f, 0.5f);
        }

        else if (transform.eulerAngles.z <= 17.0f && transform.eulerAngles.z >= 14.0f)
        {

            transform.eulerAngles = new Vector3(0, 0, 8.0f);
            oil.transform.LeanScaleY(4.37f, 0.5f);
            pressureLabel.text = "140";
            oilLevelIndicator.LeanMoveLocalY(0.498f, 0.5f);

        }
        else if (transform.eulerAngles.z <= 8.0f && transform.eulerAngles.z >= 7.0f)
        {

            transform.eulerAngles = new Vector3(0, 0, -2.0f);
            oil.transform.LeanScaleY(4.75f, 0.5f);
            pressureLabel.text = "150";
            oilLevelIndicator.LeanMoveLocalY(0.704f, 0.5f);
        }
        else if (transform.eulerAngles.z <= 359.0f && transform.eulerAngles.z >= 357.0f)
        {
            transform.eulerAngles = new Vector3(0, 0, -10.0f);
            oil.transform.LeanScaleY(5.05f, 0.5f);
            pressureLabel.text = "160";
            oilLevelIndicator.LeanMoveLocalY(0.88f, 0.5f);

        }
        else if (transform.eulerAngles.z <= 350.0f && transform.eulerAngles.z >= 349.0f)
        {
            transform.eulerAngles = new Vector3(0, 0, -19f);
            oil.transform.LeanScaleY(5.35f, 0.5f);
            pressureLabel.text = "170";
            oilLevelIndicator.LeanMoveLocalY(1.055f, 0.5f);
        }
        else if (transform.eulerAngles.z == 341f)
        {
            transform.eulerAngles = new Vector3(0, 0, -28.0f);
            oil.transform.LeanScaleY(5.5f, 0.5f);
            pressureLabel.text = "180";
            oilLevelIndicator.LeanMoveLocalY(1.134f, 0.5f);
        }

        else if (transform.eulerAngles.z == 332.0f)
        {
            transform.eulerAngles = new Vector3(0, 0, -37.0f);
            oil.transform.LeanScaleY(5.69f, 0.5f);
            pressureLabel.text = "190";
            oilLevelIndicator.LeanMoveLocalY(1.254f, 0.5f);

        }
        else if (transform.eulerAngles.z == 323.0f)
        {
            transform.eulerAngles = new Vector3(0, 0, -43.0f); //317
            oil.transform.LeanScaleY(5.88f, 0.5f);
            pressureLabel.text = "200";
            oilLevelIndicator.LeanMoveLocalY(1.358f, 0.5f);
        }
        else if (transform.eulerAngles.z == 317.0f)
        {
            transform.eulerAngles = new Vector3(0, 0, -52.0f);
            oil.transform.LeanScaleY(6.07f, 0.5f);
            pressureLabel.text = "210";
            oilLevelIndicator.LeanMoveLocalY(1.473f, 0.5f);
        }
        else if (transform.eulerAngles.z == 308.0f)
        {
            transform.eulerAngles = new Vector3(0, 0, -61.0f);
            oil.transform.LeanScaleY(6.27f, 0.5f);
            pressureLabel.text = "220";
            oilLevelIndicator.LeanMoveLocalY(1.573f, 0.5f);
        }
        else if (transform.eulerAngles.z == 299.0f)
        {
            transform.eulerAngles = new Vector3(0, 0, -70.0f);
            oil.transform.LeanScaleY(6.44f, 0.5f);
            pressureLabel.text = "230";
            oilLevelIndicator.LeanMoveLocalY(1.68f, 0.5f);
        }
        else if (transform.eulerAngles.z == 290.0f)
        {
            transform.eulerAngles = new Vector3(0, 0, -79.0f);
            oil.transform.LeanScaleY(6.64f, 0.5f);
            pressureLabel.text = "240";
            oilLevelIndicator.LeanMoveLocalY(1.68f, 0.5f);
        }
        else if (transform.eulerAngles.z == 281.0f)
        {
            transform.eulerAngles = new Vector3(0, 0, -86);
            oil.transform.LeanScaleY(6.72f, 0.5f);
            pressureLabel.text = "250";
            oilLevelIndicator.LeanMoveLocalY(1.796f, 0.5f);
        }


    }
   
   

    int otherCounter = 0;
    private void Update()
    {
        DetectPumpEvent(); 
        DetectDrainEvent();
        oilScale = oil.transform.localScale.y;


    }

    private void DetectPumpEvent()
    {
        if (PumpController.isPumped && counter == 0)
        {
            pumpButton.onClick.Invoke();
            counter++;
        }

        if (PumpController.isPumped == false && counter == 1)
        {
            counter = 0;
        }

       
    }

    private void DetectDrainEvent()
    {
        if (gasTap.transform.position.x < 1.276372f)
        {
            if (otherCounter == 0)
            {
                drainButton.onClick.Invoke();
                otherCounter++;
            }
        }
        if (gasTap.transform.position.x >= 1.276372f)
        {
            otherCounter = 0;
        }
    }
}
