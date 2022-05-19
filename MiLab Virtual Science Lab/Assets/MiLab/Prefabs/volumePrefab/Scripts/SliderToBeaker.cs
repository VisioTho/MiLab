using System.Collections;
using System.Collections.Generic;
using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class SliderToBeaker : MonoBehaviour
{
    public Slider sliderUI;
    //public SpriteRenderer imageUI;
    public GameObject imageUI;
    public GameObject bottomLiq;
    public TMP_Text textSliderValue;
    public TMP_InputField inputVolume;
    private Vector3 initialWaterVolume;

    

    [Header("Configurables")]
    public float min;
    public float max;

    public enum UnitType
    {
        cm3 = 1,
        ml = 2
    };

    public UnitType Unit;

    private string symbol;


    // Start is called before the first frame update
    void Start()
    {
        inputVolume.onValueChanged.AddListener(delegate { ValueChangeCheck(); });

        Sprite imageUI = GetComponent<SpriteRenderer>().sprite;
        Sprite buttomLiq = GetComponent<SpriteRenderer>().sprite;
        //textSliderValue = GameObject.Find("Text").GetComponent<Text>();
        //initialWaterVolume = imageUI.transform.localScale;
        changeWaterLevel();
    }

    public void setMin(float min)
    {
        sliderUI.minValue = min;
    }

    public void setMax(float max)
    {
        sliderUI.maxValue = Mathf.Round(max * 100.0f) * 0.01f;
    }

    public void showSliderValue()
    {
        textSliderValue.text = ((imageUI.transform.localScale.y / 0.9872859) * 50.0f).ToString("f0") + symbol;
    }

    public void changeWaterLevel()
    {
        float minimum;

        minimum = min;

        if(sliderUI.value <= 0)
        {
            imageUI.transform.localScale = new Vector2(imageUI.transform.localScale.x, 0.0f);
            bottomLiq.transform.localScale = new Vector2(bottomLiq.transform.localScale.x, 0.0f);
        }
        else
        {
           
            bottomLiq.transform.localScale = new Vector2(bottomLiq.transform.localScale.x, 0.5688471f);
            imageUI.transform.localScale = new Vector2(imageUI.transform.localScale.x, sliderUI.value);
        }
        
        
    }

    // Invoked when the value of the text field changes.
    /*public void ValueChangeCheck()
    {
        if (inputVolume.text == null)
        {
            sliderUI.value = 0;
        }
        else
        {
            inputVolume.text = inputVolume.text;
            var volinput = float.Parse(inputVolume.text) / 50.0f * 0.9872859;
            sliderUI.value = (float)volinput;
            Debug.Log(volinput);
        }
    }
    */
    public void ValueChangeCheck() 
    {
     
        float Value = 0;
        Debug.Log(inputVolume.text);
        Debug.Log(inputVolume.text.Length);
        if (float.TryParse(inputVolume.text.Replace(".", ","), out float _value))
        {
            Debug.Log("parse Done");
            Value = _value;
        }
        else
        {
            Debug.Log("parse Terminated");
            Value = 0;
        }

        var volinput = Value / 50.0f * 0.9872859;

        sliderUI.value = (float)volinput;

        /*Debug.Log(volinput);*/

    }
    // Update is called once per frame
    void Update()
    {
       
        showSliderValue();
        OnInspectorGUI();

        Debug.Log(symbol);         
        
        changeWaterLevel();

    }

    void onGUI()
    {
        #if UNITY_EDITOR
                Unit = (UnitType)EditorGUILayout.EnumPopup("Display", Unit);
        #endif

    }

        public void OnInspectorGUI()
    {
      

            //Change Unit symbol 
            switch (Unit)
            {
                case UnitType.cm3:
                    symbol = "cm3";
                    break;

                case UnitType.ml:
                    symbol = "ml";
                    break;


            }
        


    }





    void Awake()
    {
        

        setMin(min);
        setMax(max);
        //
        showSliderValue();
        // OnInspectorGUI();
        changeWaterLevel();
    }
}
