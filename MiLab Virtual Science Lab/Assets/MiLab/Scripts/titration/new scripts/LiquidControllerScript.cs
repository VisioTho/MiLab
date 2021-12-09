using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiquidControllerScript : MonoBehaviour
{
    public Image content;
    [SerializeField]
    private Stat fill;

    public GameObject liquidFlowParticle, conicalflaskliquid, stream, flowStream;

    public ParticleSystem DropParticle;
    IEnumerator enumerator;
    IEnumerator flowController;
    IEnumerator fillBurette;

    // public GameObject toggleBackground, toggleHandle;
    public Slider sliderInstance;
    public Button stopButton;
    public Button fillButton;
    public static bool pipetteDrop;
    private float valueHolder;




    // public bool isFilled = false;
    private void Awake()
    {
        fill.Initialize();
        enumerator = LiquidDrop();
        fillBurette = LiquidFill();
        flowController = LiquidFlow();
        // toggle = GetComponent<Toggle>();

        // handlePosition = uiHandleRectTransform.anchoredPosition;
        // toggle.onValueChanged.AddListener(OnSwitch);

        // if (toggle.isOn)
        //     OnSwitch(true);

    }

    // bool toggleisOn;

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
            var localReftoParticle = DropParticle.main;
            localReftoParticle.playOnAwake = false;
            DropParticle.Stop();

        }
        else if (content.fillAmount > 0f)
        {
            var localReftoParticle = DropParticle.main;
            localReftoParticle.playOnAwake = true;
        }

        var fillDifference = valueHolder - fill.CurrentVal;
        if (fillDifference == 8)
        {
            if (LiquidControllerScript.pipetteDrop)
            {
                Debug.Log("checked");
                conicalflaskliquid.GetComponent<Image>().color = new Color32(255, 155, 202, 255);
                Debug.Log("color change1");
            }
            else
            {
                Debug.Log("pepani");
            }
        }
        if (fillDifference == 10)
        {
            if (LiquidControllerScript.pipetteDrop)
            {
                Debug.Log("checked");
                conicalflaskliquid.GetComponent<Image>().color = new Color32(255, 152, 203, 255);
                Debug.Log("color change2");
            }
            else
            {
                Debug.Log("pepani");
            }
        }
        if (fillDifference == 12)
        {
            if (LiquidControllerScript.pipetteDrop)
            {
                Debug.Log("checked");
                conicalflaskliquid.GetComponent<Image>().color = new Color32(255, 207, 248, 255);
                Debug.Log("color change3");
            }
            else
            {
                Debug.Log("pepani");
            }
        }
        if (fillDifference == 15)
        {
            if (LiquidControllerScript.pipetteDrop)
            {
                Debug.Log("checked");
                conicalflaskliquid.GetComponent<Image>().color = new Color32(234, 234, 234, 109);
                Debug.Log("color change4");
            }
            else
            {
                Debug.Log("pepani");
            }
        }
        if (fill.CurrentVal == 0)
        {
            var localReftoParticle = DropParticle.main;
            localReftoParticle.playOnAwake = false;
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
                //DropParticle.Stop();
            }
            else
            {
                DropParticle.gameObject.SetActive(true);
                var localReftoParticle = DropParticle.main;
                localReftoParticle.playOnAwake = true;
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
                

                liquidFlowParticle.SetActive(true);

                StartCoroutine(flowController);
                StopCoroutine(enumerator);
            }

        }
        else
        {
            var localReftoParticle = DropParticle.main;
            localReftoParticle.playOnAwake = false;
            DropParticle.gameObject.SetActive(false);
            //DropParticle.Stop();

            liquidFlowParticle.SetActive(false);
            StopCoroutine(enumerator);
        }
    }
   
    //destroying object on collision
    public void OnCollisionEnter(Collision hit)
    {
        LiquidControllerScript.pipetteDrop = true;
        Destroy(hit.gameObject);
        conicalflaskliquid.GetComponent<Image>().color = new Color32(255, 105, 180, 255);
        Debug.Log("collision detected");
    }

    public void fillUp()
    {
        StartCoroutine(fillBurette);
    }
    IEnumerator LiquidFill()
    {

        do
        {
            if(fill.currentVal == fill.MaxVal)
            {
                stopButton.gameObject.SetActive(false);
                stream.SetActive(false);
                sliderInstance.enabled = true;
                Debug.Log("maximum reached");
                stopFlow();

            }
            else
            {
                sliderInstance.value = 0;
                sliderInstance.enabled = false;
                stream.SetActive(true);
            }
            //stream.SetActive(true);
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
            if(fill.currentVal == 0)
            {
                var localReftoParticle = DropParticle.main;
                localReftoParticle.playOnAwake = false;
                DropParticle.Stop();
            }
            else
            {
                DropParticle.Play();
            }
            yield return new WaitForSeconds(3f);
        }
    }

    IEnumerator LiquidFlow()
    {

        while (fill.CurrentVal > 0)
        {
            fill.CurrentVal--;
            if (fill.currentVal == 0)
            {
                liquidFlowParticle.SetActive(false);
            }
            yield return new WaitForSeconds(2f);
        }
    }

    public void stopFlow()
    {
        sliderInstance.enabled = true;
        StopCoroutine(flowController);
        StopCoroutine(enumerator);
        StopCoroutine(fillBurette);
        stream.SetActive(false);
        flowStream.SetActive(false);

        valueHolder = fill.CurrentVal;
    }

}
