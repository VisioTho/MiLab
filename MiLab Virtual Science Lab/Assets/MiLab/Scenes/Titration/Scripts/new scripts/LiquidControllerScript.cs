using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LiquidControllerScript : MonoBehaviour
{
    public Image content;
    [SerializeField]
    private Stat fill;

    public GameObject liquidFlowParticle, stream; //flowStream;

    public ParticleSystem DropParticle;

    public DestroyDrops destroyDrops;
    IEnumerator enumerator;
    IEnumerator flowController;
    IEnumerator fillBurette;

    // public GameObject toggleBackground, toggleHandle;
    public Slider sliderInstance;
    public Button stopButton;
    public Button fillButton;
    public static bool pipetteDrop;
    private float valueHolder;

    public TMP_Text analyteNotation;
    public TMP_Dropdown titrantVariation, analyteVariation;

    private bool isTransformed;

    private void Awake()
    {
        fill.Initialize();
        enumerator = LiquidDrop();
        fillBurette = LiquidFill();
        flowController = LiquidFlow();

    }

    void Start()
    {
        isTransformed = false;
        sliderInstance.minValue = 0;
        sliderInstance.maxValue = 2;
        sliderInstance.wholeNumbers = true;

        fill.CurrentVal = 0;
        content.fillAmount = 0;
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
        Debug.Log("fillDifference" + fillDifference);
        Debug.Log("current Value" + fill.CurrentVal);
        Debug.Log("valueHolder" + valueHolder);
        if (titrantVariation.value == 0 && analyteVariation.value == 0 && !isTransformed)
        {
            if (fillDifference == 3)
            {
                if (LiquidControllerScript.pipetteDrop)
                {
                    Debug.Log("start reaction");
                    analyteNotation.text = "sulphuric acid + Sodium Hydroxide";
                }
                else
                {
                    Debug.Log("oops");
                }
            }
            if (fillDifference == 8)
            {
                if (LiquidControllerScript.pipetteDrop)
                {
                    Debug.Log("checked");
                    destroyDrops.titrant1.GetComponent<Image>().color = new Color32(255, 155, 202, 255);
                    Debug.Log("color change1");
                }
                else
                {
                    Debug.Log("oops");
                }
            }

            if (fillDifference == 10)
            {
                if (LiquidControllerScript.pipetteDrop)
                {
                    Debug.Log("checked");
                    destroyDrops.titrant1.GetComponent<Image>().color = new Color32(255, 152, 203, 255);
                    Debug.Log("color change2");
                }
                else
                {
                    Debug.Log("oops");
                }
            }
            if (fillDifference == 12)
            {
                if (LiquidControllerScript.pipetteDrop)
                {
                    Debug.Log("checked");
                    destroyDrops.titrant1.GetComponent<Image>().color = new Color32(255, 207, 248, 255);
                    Debug.Log("color change3");
                    // isTransformed = true;
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
                    destroyDrops.titrant1.GetComponent<Image>().color = new Color32(234, 234, 234, 109);
                    Debug.Log("color change4");
                    isTransformed = true;
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
        else if (titrantVariation.value == 1 && analyteVariation.value == 0 && !isTransformed)
        {
            if (fillDifference == 3)
            {
                if (LiquidControllerScript.pipetteDrop)
                {
                    Debug.Log("start reaction");
                    analyteNotation.text = "Hydrochloric acid + Sodium Hydroxide";
                }
                else
                {
                    Debug.Log("oops");
                }
            }
            if (fillDifference == 6)
            {
                if (LiquidControllerScript.pipetteDrop)
                {
                    Debug.Log("checked");
                    destroyDrops.titrant1.GetComponent<Image>().color = new Color32(255, 155, 202, 255);
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
                    destroyDrops.titrant1.GetComponent<Image>().color = new Color32(255, 152, 203, 255);
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
                    destroyDrops.titrant1.GetComponent<Image>().color = new Color32(234, 234, 234, 109);
                    Debug.Log("color change4");
                    isTransformed = true;
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
        else if (titrantVariation.value == 0 && analyteVariation.value == 1 && !isTransformed)
        {
            if (fillDifference == 3)
            {
                if (LiquidControllerScript.pipetteDrop)
                {
                    Debug.Log("start reaction");
                    analyteNotation.text = "Sulphuric acid + Calcium Hydroxide";
                }
                else
                {
                    Debug.Log("oops");
                }
            }
            if (fillDifference == 10)
            {
                if (LiquidControllerScript.pipetteDrop)
                {
                    Debug.Log("checked");
                    destroyDrops.titrant1.GetComponent<Image>().color = new Color32(255, 155, 202, 255);
                    Debug.Log("color change1");
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
                    destroyDrops.titrant1.GetComponent<Image>().color = new Color32(255, 152, 203, 255);
                    Debug.Log("color change2");
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
                    destroyDrops.titrant1.GetComponent<Image>().color = new Color32(255, 207, 248, 255);
                    Debug.Log("color change3");
                }
                else
                {
                    Debug.Log("pepani");
                }
            }
            if (fillDifference == 20)
            {
                if (LiquidControllerScript.pipetteDrop)
                {
                    Debug.Log("checked");
                    destroyDrops.titrant1.GetComponent<Image>().color = new Color32(234, 234, 234, 109);
                    Debug.Log("color change4");
                    isTransformed = true;
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
        else if (titrantVariation.value == 1 && analyteVariation.value == 1 && !isTransformed)
        {
            if (fillDifference == 3)
            {
                if (LiquidControllerScript.pipetteDrop)
                {
                    Debug.Log("start reaction");
                    analyteNotation.text = "Hydrochloric acid + Calcium Hydroxide";
                }
                else
                {
                    Debug.Log("oops");
                }
            }
            if (fillDifference == 5)
            {
                if (LiquidControllerScript.pipetteDrop)
                {
                    Debug.Log("checked");
                    destroyDrops.titrant1.GetComponent<Image>().color = new Color32(255, 155, 202, 255);
                    Debug.Log("color change1");
                }
                else
                {
                    Debug.Log("pepani");
                }
            }

            if (fillDifference == 8)
            {
                if (LiquidControllerScript.pipetteDrop)
                {
                    Debug.Log("checked");
                    destroyDrops.titrant1.GetComponent<Image>().color = new Color32(255, 152, 203, 255);
                    Debug.Log("color change2");
                }
                else
                {
                    Debug.Log("pepani");
                }
            }

            if (fillDifference == 11)
            {
                if (LiquidControllerScript.pipetteDrop)
                {
                    Debug.Log("checked");
                    destroyDrops.titrant1.GetComponent<Image>().color = new Color32(234, 234, 234, 109);
                    Debug.Log("color change4");
                    isTransformed = true;
                }
                else
                {
                    Debug.Log("oops");
                }
            }
            if (fill.CurrentVal == 0)
            {
                var localReftoParticle = DropParticle.main;
                localReftoParticle.playOnAwake = false;
            }
        }
        else
        {
            Debug.Log("oops! something went wrong");
        }


    }

    // slider that controls the titration liquid flow 
    public void OnValueChanged(float value)
    {
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
                Vibration.Vibrate(60);
                DropParticle.gameObject.SetActive(true);
                var localReftoParticle = DropParticle.main;
                localReftoParticle.playOnAwake = true;
                liquidFlowParticle.SetActive(false);
                StopCoroutine(flowController);
                StartCoroutine(enumerator);
                analyteVariation.enabled = false;
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
                Vibration.Vibrate(60);
                analyteVariation.enabled = false;
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
            analyteVariation.enabled = true;
        }
    }

    // Titrant Variation DropDown
    public void handleTitrantVariation()
    {
        if (titrantVariation.value == 0)
        {
            Debug.Log("option selected");
            content.GetComponent<Image>().color = new Color32(212, 203, 100, 85);
            fill.CurrentVal = 0;
            sliderInstance.value = 0;
        }
        if (titrantVariation.value == 1)
        {
            Debug.Log("option 2 selected");
            content.GetComponent<Image>().color = new Color32(234, 234, 234, 60);
            fill.CurrentVal = 0;
            sliderInstance.value = 0;

        }
    }

    // analyte Variation DropDown
    public void handleAnalyteVariation()
    {
        if (analyteVariation.value == 0)
        {
            Debug.Log("option selected");
            analyteNotation.text = "15ml NaOH";
            destroyDrops.titrant1.GetComponent<Image>().color = new Color32(234, 234, 234, 150);


        }
        if (analyteVariation.value == 1)
        {
            Debug.Log("option 2 selected");
            analyteNotation.text = "15ml CaOH";
            destroyDrops.titrant1.GetComponent<Image>().color = new Color32(234, 234, 234, 205);

        }
    }

    public void fillUp()
    {
        StartCoroutine(fillBurette);
    }
    IEnumerator LiquidFill()
    {

        do
        {
            // titrantVariation.enabled = false;
            if (fill.currentVal == fill.MaxVal)
            {
                stopButton.gameObject.SetActive(false);
                stream.SetActive(false);
                sliderInstance.enabled = true;
                titrantVariation.enabled = true;
                Debug.Log("maximum reached");
                stopFlow();

            }
            else
            {
                sliderInstance.value = 0;
                sliderInstance.enabled = false;
                titrantVariation.enabled = false;
                if (titrantVariation.value == 0)
                {
                    stream.SetActive(true);
                    stream.GetComponent<Image>().color = new Color32(212, 203, 100, 85);
                }
                else
                {
                    stream.SetActive(true);
                    stream.GetComponent<Image>().color = new Color32(234, 234, 234, 60);
                }

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
            if (fill.currentVal == 0)
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
            DropParticle.Stop();
            if (fill.currentVal == 0)
            {
                liquidFlowParticle.SetActive(false);
                var localReftoParticle = DropParticle.main;
                localReftoParticle.playOnAwake = false;
                DropParticle.Stop();
            }
            yield return new WaitForSeconds(2f);
        }
    }

    public void stopFlow()
    {
        sliderInstance.enabled = true;
        //titrantVariation.enabled = true;
        analyteVariation.enabled = false;
        StopCoroutine(flowController);
        StopCoroutine(enumerator);
        StopCoroutine(fillBurette);
        stream.SetActive(false);
        //  flowStream.SetActive(false);

        valueHolder = fill.CurrentVal;
    }

}
