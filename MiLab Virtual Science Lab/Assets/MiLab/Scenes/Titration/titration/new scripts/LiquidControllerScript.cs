using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LiquidControllerScript : MonoBehaviour
{
    public Titration_Drop_Controller dropController;
    public ConicalFlaskVolume ConicalFlaskVolume;
    public Image content;
    [SerializeField]
    public Stat fill;
    public GameObject liquidFlowParticle, stream; //flowStream;
    public ParticleSystem DropParticle;

    IEnumerator enumerator, flowController, fillBurette;
    public Slider sliderInstance;
    public bool pipetteDrop;
    private float valueHolder;

    public TMP_Text analyteNotation;
    public TMP_Dropdown titrantVariation, analyteVariation, indicatorVariation;
    public Button resetButton;
    public Toggle beakerToggle;

    private bool isTransformed;
    public float time = 0;
    public float duration = 8;

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
    }
    void Update()
    {
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
        if (indicatorVariation.value == 0 && (sliderInstance.value == 1 || sliderInstance.value == 2)) // using phenophthlaine as indicator
        {
            if (titrantVariation.value == 0 && analyteVariation.value == 0 && !isTransformed)
            {
                if (fillDifference == 16.5f || fillDifference == 16f)
                {
                    if (pipetteDrop)
                    {
                        StartCoroutine(titrationPhenothlaineTransition(1000));
                    }
                }
                if (fill.currentVal == 0)
                {
                    var localReftoParticle = DropParticle.main;
                    localReftoParticle.playOnAwake = false;
                }
            }
            else if (titrantVariation.value == 1 && analyteVariation.value == 0 && !isTransformed)
            {
                if (fillDifference == 10.5f || fillDifference == 10f)
                {
                    if (pipetteDrop)
                    {
                        StartCoroutine(titrationPhenothlaineTransition(1000));
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
                if (fillDifference == 12.5 || fillDifference == 12)
                {
                    if (pipetteDrop)
                    {

                        StartCoroutine(titrationPhenothlaineTransition(1050));
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
                if (fillDifference == 9 || fillDifference == 9.5)
                {
                    if (pipetteDrop)
                    {
                        StartCoroutine(titrationPhenothlaineTransition(1200));
                    }
                }
                if (fill.CurrentVal == 0)
                {
                    var localReftoParticle = DropParticle.main;
                    localReftoParticle.playOnAwake = false;
                }
            }

        }
        else if (indicatorVariation.value == 1 && (sliderInstance.value == 1 || sliderInstance.value == 2)) // using Methyl Orange indicator
        {
            if (titrantVariation.value == 0 && analyteVariation.value == 0 && !isTransformed)
            {
                if (fillDifference == 11 || fillDifference == 11.5)
                {
                    if (pipetteDrop)
                    {
                        StartCoroutine(titrationMethylOrangeTransition(1200));
                    }
                }
                if (fill.currentVal == 0)
                {
                    var localReftoParticle = DropParticle.main;
                    localReftoParticle.playOnAwake = false;
                }
            }
            else if (titrantVariation.value == 1 && analyteVariation.value == 0 && !isTransformed)
            {
                if (fillDifference == 13 || fillDifference == 13.5)
                {
                    if (pipetteDrop)
                    {
                        StartCoroutine(titrationMethylOrangeTransition(1100));
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
                if (fillDifference == 10 || fillDifference == 10.5)
                {
                    if (pipetteDrop)
                    {

                        StartCoroutine(titrationMethylOrangeTransition(1400));
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
                if (fillDifference == 17 || fillDifference == 17.5)
                {
                    if (pipetteDrop)
                    {
                        StartCoroutine(titrationMethylOrangeTransition(1000));
                    }
                }
                if (fill.CurrentVal == 0)
                {
                    var localReftoParticle = DropParticle.main;
                    localReftoParticle.playOnAwake = false;
                }
            }
        }


    }

    public void resetEverything()
    {
        resetButton.interactable = false;
        resetTime();
        isTransformed = false;
        fill.CurrentVal = 0;
        DropParticle.Stop();
        DropParticle.gameObject.SetActive(false);
        liquidFlowParticle.SetActive(false);
        stream.SetActive(false);
        dropController.resetDrops();
        titrantVariation.value = 0;
        analyteVariation.value = 0;
        indicatorVariation.value = 0;
        sliderInstance.value = 0;
        analyteVariation.interactable = true;
        titrantVariation.interactable = true;
        indicatorVariation.interactable = true;
        beakerToggle.interactable = true;
        ConicalFlaskVolume.volumeSlider.value = 5;
        ConicalFlaskVolume.volumeSlider.interactable = true;
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
                //  analyteVariation.enabled = false;
                var localReftoParticle = DropParticle.main;
                localReftoParticle.playOnAwake = false;


                liquidFlowParticle.SetActive(true);

                StartCoroutine(flowController);
                StopCoroutine(enumerator);
                // StartCoroutine(colorTransition);
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
            StopCoroutine(flowController);
        }
    }

    // Titrant Variation DropDown
    public void handleTitrantVariation()
    {
        if (titrantVariation.value == 0)
        {
            content.GetComponent<Image>().color = new Color32(212, 203, 100, 85);
            fill.CurrentVal = 0;
            sliderInstance.value = 0;
        }
        if (titrantVariation.value == 1)
        {
            content.GetComponent<Image>().color = new Color32(234, 234, 234, 190);
            fill.CurrentVal = 0;
            sliderInstance.value = 0;

        }
    }

    // analyte Variation DropDown
    public void handleAnalyteVariation()
    {
        if (analyteVariation.value == 0)
        {
            // analyteNotation.text = "15ml NaOH";
            dropController.sodium_hydroxide.GetComponent<Image>().color = new Color32(234, 234, 234, 190);


        }
        if (analyteVariation.value == 1)
        {
            // analyteNotation.text = "15ml CaOH";
            dropController.sodium_hydroxide.GetComponent<Image>().color = new Color32(234, 234, 234, 205);

        }
    }

    public void fillUp()
    {
        StartCoroutine(fillBurette);
    }

    public void startFillDelay()
    {
        stream.SetActive(true);
    }
    IEnumerator LiquidFill()
    {

        do
        {
            if (fill.currentVal == fill.MaxVal)
            {
                stream.SetActive(false);
                sliderInstance.enabled = true;
                titrantVariation.enabled = true;
                stopFlow();

            }
            else
            {
                resetButton.interactable = true;
                sliderInstance.value = 0;
                sliderInstance.enabled = false;
                if (titrantVariation.value == 0)
                {
                    stream.GetComponent<Image>().color = new Color32(195, 202, 106, 130);
                }
                else
                {
                    stream.GetComponent<Image>().color = new Color32(234, 234, 234, 50);
                }

            }
            fill.CurrentVal++;
            yield return new WaitForSeconds(0.5f);
        } while (fill.CurrentVal >= 0);
    }

    public void Flow()
    {
        StartCoroutine(flowController);

    }
    IEnumerator LiquidDrop()
    {

        while (fill.CurrentVal >= 0)
        {
            analyteVariation.interactable = false;
            titrantVariation.interactable = false;
            indicatorVariation.interactable = false;
            fill.CurrentVal -= 0.5f;
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
            yield return new WaitForSeconds(4f);
        }
    }

    IEnumerator LiquidFlow()
    {

        while (fill.CurrentVal >= 0)
        {
            fill.CurrentVal -= 1f;
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
        StopCoroutine(flowController);
        StopCoroutine(enumerator);
        StopCoroutine(fillBurette);
        stream.SetActive(false);
        valueHolder = fill.CurrentVal;
    }


    IEnumerator titrationPhenothlaineTransition(float duration)
    {
        Color startColor = dropController.sodium_hydroxide.GetComponent<Image>().color;
        Color endColor = new Color32(234, 234, 234, 109);

        while (time < duration)
        {
            dropController.sodium_hydroxide.GetComponent<Image>().color = Color.Lerp(startColor, endColor, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        dropController.sodium_hydroxide.GetComponent<Image>().color = endColor;
    }

    IEnumerator titrationMethylOrangeTransition(float duration)
    {
        Color startColor = dropController.sodium_hydroxide.GetComponent<Image>().color;
        Color endColor = new Color32(226, 16, 109, 255);

        while (time < duration)
        {
            dropController.sodium_hydroxide.GetComponent<Image>().color = Color.Lerp(startColor, endColor, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        dropController.sodium_hydroxide.GetComponent<Image>().color = endColor;
    }

    public void resetTime()
    {
        time = 0;
        StopAllCoroutines();
    }




}
