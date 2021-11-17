using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiquidControllerScript : MonoBehaviour
{
    public Image content;
    [SerializeField]
    private Stat fill;

    public GameObject liquidDropParticle;
    public GameObject liquidFlowParticle;

    public ParticleSystem DropParticle;
    public GameObject conicalflaskliquid;
    // [SerializeField] private float myDelay;
    public GameObject stream;
    public GameObject flowStream;
    [SerializeField] RectTransform uiHandleRectTransform;
    Toggle toggle;
    Vector2 handlePosition;
    IEnumerator enumerator;
    IEnumerator flowController;
    IEnumerator fillBurette;

    public GameObject toggleBackground;
    public GameObject toggleHandle;

    public Slider sliderInstance;



    // public bool isFilled = false;
    private void Awake()
    {
        fill.Initialize();
        enumerator = LiquidDrop();
        fillBurette = LiquidFill();
        flowController = LiquidFlow();
        toggle = GetComponent<Toggle>();

        handlePosition = uiHandleRectTransform.anchoredPosition;
        toggle.onValueChanged.AddListener(OnSwitch);

        if (toggle.isOn)
            OnSwitch(true);

    }

    bool toggleisOn;

    void Start()
    {
        sliderInstance.minValue = 0;
        sliderInstance.maxValue = 2;
        sliderInstance.wholeNumbers = true;
        //sliderInstance.value = 1;
    }
    void Update()
    {
        // Debug.Log("Scale is " + content.fillAmount);
        // Debug.Log("Particle System " + DropParticle.isEmitting);
        if (content.fillAmount == 0f)
        {
            liquidDropParticle.SetActive(false);
            var localReftoParticle = DropParticle.main;
            localReftoParticle.playOnAwake = false;

        }
        else if (content.fillAmount > 0f && toggleisOn)
        {
            liquidDropParticle.SetActive(true);
            var localReftoParticle = DropParticle.main;
            localReftoParticle.playOnAwake = true;
        }
    }

    // slider that controls the titration liquid flow 
    public void OnValueChanged(float value)
    {
        //Debug.Log("New value " + value);
        if (sliderInstance.value == 1)
        {
            if (fill.CurrentVal == 0)
            {
                var localReftoParticle = DropParticle.main;
                localReftoParticle.playOnAwake = false;
                liquidDropParticle.SetActive(false);

            }
            else
            {
                var localReftoParticle = DropParticle.main;
                localReftoParticle.playOnAwake = true;
                liquidDropParticle.SetActive(true);
                liquidFlowParticle.SetActive(false);
                StopCoroutine(flowController);
                StartCoroutine(enumerator);
            }

        }
        else if (sliderInstance.value == 2)
        {
            if (fill.CurrentVal == 0)
            {
                liquidFlowParticle.SetActive(false);
            }
            else
            {
                var localReftoParticle = DropParticle.main;
                localReftoParticle.playOnAwake = false;
                liquidDropParticle.SetActive(false);

                liquidFlowParticle.SetActive(true);

                StartCoroutine(flowController);
                StopCoroutine(enumerator);
            }

        }
        else
        {
            var localReftoParticle = DropParticle.main;
            localReftoParticle.playOnAwake = false;
            liquidDropParticle.SetActive(false);

            liquidFlowParticle.SetActive(false);
            StopCoroutine(enumerator);
        }
    }
    public void OnSwitch(bool on)
    {
        // uiHandleRectTransform.anchoredPosition = on ? handlePosition * -1 : handlePosition;
        if (on)
        {
            toggleisOn = true;
            uiHandleRectTransform.anchoredPosition = handlePosition * -1;
            toggleBackground.GetComponent<Image>().color = new Color32(14, 126, 10, 255);
            toggleHandle.GetComponent<Image>().color = new Color32(132, 234, 21, 255);

            var localReftoParticle = DropParticle.main;
            localReftoParticle.playOnAwake = true;
            liquidDropParticle.SetActive(true);

            StartCoroutine(enumerator);
        }
        else
        {
            toggleisOn = false;
            uiHandleRectTransform.anchoredPosition = handlePosition;
            toggleBackground.GetComponent<Image>().color = new Color32(83, 10, 55, 255);
            toggleHandle.GetComponent<Image>().color = new Color32(173, 0, 193, 255);
            var localReftoParticle = DropParticle.main;
            localReftoParticle.playOnAwake = false;
            liquidDropParticle.SetActive(false);
            StopCoroutine(enumerator);
        }
    }

    void OnDestroy()
    {
        toggle.onValueChanged.AddListener(OnSwitch);
    }

    public void fillUp()
    {
        StartCoroutine(fillBurette);
    }
    IEnumerator LiquidFill()
    {
        stream.SetActive(true);

        do
        {
            fill.CurrentVal++;
            yield return new WaitForSeconds(0.3f);
        } while (fill.CurrentVal >= 0);
    }

    public void Flow()
    {
        StartCoroutine(flowController);
    }
    IEnumerator LiquidDrop()
    {

        while (fill.CurrentVal > 0)
        {
            fill.CurrentVal--;
            //DropParticle.Play();
            changeColors();
            yield return new WaitForSeconds(3f);
        }
    }

    IEnumerator LiquidFlow()
    {


        while (fill.CurrentVal > 0)
        {
            fill.CurrentVal--;
            //DropParticle.Play();
            changeColors();
            if (fill.currentVal == 0)
            {
                liquidFlowParticle.SetActive(false);
            }
            yield return new WaitForSeconds(2f);
        }
    }

    public void stopFlow()
    {
        StopCoroutine(flowController);
        StopCoroutine(enumerator);
        StopCoroutine(fillBurette);
        stream.SetActive(false);
        flowStream.SetActive(false);
        liquidDropParticle.SetActive(false);
    }


    void changeColors()
    {
        if (fill.CurrentVal == 43)
        {
            conicalflaskliquid.GetComponent<Image>().color = new Color32(255, 155, 202, 255);
        }
        if (fill.CurrentVal == 40)
        {
            conicalflaskliquid.GetComponent<Image>().color = new Color32(255, 152, 203, 255);
        }
        if (fill.CurrentVal == 38)
        {
            conicalflaskliquid.GetComponent<Image>().color = new Color32(255, 207, 248, 255);
        }
        if (fill.CurrentVal == 35)
        {
            conicalflaskliquid.GetComponent<Image>().color = new Color32(234, 234, 234, 255);
        }
        if (fill.CurrentVal == 0)
        {
            var localReftoParticle = DropParticle.main;
            localReftoParticle.playOnAwake = false;
            liquidDropParticle.SetActive(false);
        }

    }

}
