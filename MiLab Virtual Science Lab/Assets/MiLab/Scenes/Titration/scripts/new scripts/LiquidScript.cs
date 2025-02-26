using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LiquidScript : MonoBehaviour
{
    private float fillAmount;

    //  [SerializeField]
    public float lerpSpeed;

    [SerializeField]
    private Image content;

    [SerializeField]
    private TMP_Text valueText;

    public float MaxValue { get; set; }
    public float Value
    {
        set
        {
            valueText.text = value + " " + "ml";
            fillAmount = Map(value, 0, MaxValue, 0, 1);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HandleBar();
    }

    private void HandleBar()
    {
        if (fillAmount != content.fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
        }

    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
