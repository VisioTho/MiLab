using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustomMassManager : MonoBehaviour
{
    public TMP_Text lMassText, rMassText;
    
    void Start()
    {
        DisplayMass(gameObject.GetComponent<Rigidbody2D>().mass);
        AdjustScale(gameObject.GetComponent<Rigidbody2D>().mass);
    }

    public void AdjustMass(float val)
    {
        gameObject.GetComponent<Rigidbody2D>().mass = val;

        AdjustScale(val);

        DisplayMass(val);
    }

    private void AdjustScale(float val)
    {
        float massIngrams = ((val / 2.0f) * 25);
        if (massIngrams >= 25f && massIngrams < 30f)
        {
            transform.localScale = new Vector3(0.04f, 0.04f, transform.localScale.z);
        }
        else if (massIngrams >= 30 && massIngrams < 35)
        {
            transform.localScale = new Vector3(0.042f, 0.042f, transform.localScale.z);
        }
        else if (massIngrams >= 35 && massIngrams < 45)
        {
            transform.localScale = new Vector3(0.043f, 0.043f, transform.localScale.z);
        }
        else if (massIngrams >= 45 && massIngrams < 50)
        {
            transform.localScale = new Vector3(0.044f, 0.044f, transform.localScale.z);
        }
        else if (massIngrams >= 50 && massIngrams < 55)
        {
            transform.localScale = new Vector3(0.045f, 0.045f, transform.localScale.z);
        }
        else if (massIngrams >= 55 && massIngrams < 60)
        {
            transform.localScale = new Vector3(0.046f, 0.046f, transform.localScale.z);
        }
        else if (massIngrams >= 60 && massIngrams < 65)
        {
            transform.localScale = new Vector3(0.047f, 0.047f, transform.localScale.z);
        }
        else if (massIngrams >= 65 && massIngrams < 70)
        {
            transform.localScale = new Vector3(0.048f, 0.048f, transform.localScale.z);
        }
        else if (massIngrams >= 70 && massIngrams < 75)
        {
            transform.localScale = new Vector3(0.049f, 0.049f, transform.localScale.z);
        }
        else if (massIngrams >= 75 && massIngrams < 80)
        {
            transform.localScale = new Vector3(0.049f, 0.049f, transform.localScale.z);
        }
        else if (massIngrams >= 80 && massIngrams < 100)
        {
            transform.localScale = new Vector3(0.0492f, 0.0492f, transform.localScale.z);
        }
        else if (massIngrams >= 100 && massIngrams < 105)
        {
            transform.localScale = new Vector3(0.05f, 0.05f, transform.localScale.z);
        }
        else if (massIngrams >= 105 && massIngrams < 120)
        {
            transform.localScale = new Vector3(0.051f, 0.051f, transform.localScale.z);
        }
        else if (massIngrams >= 120 && massIngrams < 150)
        {
            transform.localScale = new Vector3(0.052f, 0.052f, transform.localScale.z);
        }
        else if (massIngrams >= 150 && massIngrams < 200)
        {
            transform.localScale = new Vector3(0.053f, 0.053f, transform.localScale.z);
        }
        else if (massIngrams >= 200 && massIngrams < 250)
        {
            transform.localScale = new Vector3(0.054f, 0.054f, transform.localScale.z);
        }
        else if(massIngrams >250 && massIngrams < 260)
            transform.localScale = new Vector3(0.056f, 0.056f, transform.localScale.z);
        else
            transform.localScale = new Vector3(0.058f, 0.058f, transform.localScale.z);

    }

    private void DisplayMass(float val)
    {
        if (gameObject.name == "MassCustom")
        {
            lMassText.text = ((val / 2.0f) * 25).ToString("f0") + " g";
        }
        else
            rMassText.text = ((val / 2.0f) * 25).ToString("f0") + " g";
    }

}
