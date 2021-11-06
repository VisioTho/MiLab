using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiquidControllerScript : MonoBehaviour
{
    [SerializeField]
    private Stat fill;

    // Start is called before the first frame update
    public GameObject liquidDropParticle;
    public GameObject conicalflaskliquid;
    [SerializeField] private float myDelay = 10f;
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

    public void OnSwitch(bool on)
    {
        // uiHandleRectTransform.anchoredPosition = on ? handlePosition * -1 : handlePosition;
        if (on)
        {
            uiHandleRectTransform.anchoredPosition = handlePosition * -1;
            toggleBackground.GetComponent<Image>().color = new Color32(14, 126, 10, 255);
            toggleHandle.GetComponent<Image>().color = new Color32(132, 234, 21, 255);
            liquidDropParticle.SetActive(true);
            StartCoroutine(enumerator);
        }
        else
        {
            uiHandleRectTransform.anchoredPosition = handlePosition;
            toggleBackground.GetComponent<Image>().color = new Color32(83, 10, 55, 255);
            toggleHandle.GetComponent<Image>().color = new Color32(173, 0, 193, 255);
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
        for (int x = 0; x <= 50; x += 2)
        {
            yield return new WaitForSeconds(0.5f);
            fill.CurrentVal = x;
        }

    }

    public void Flow()
    {
        StartCoroutine(flowController);
    }
    IEnumerator LiquidDrop()
    {
        for (float x = 50; x >= 0; x--)
        {
            liquidDropParticle.SetActive(true);
            changeColors();
            yield return new WaitForSeconds(1f);
            fill.CurrentVal = x;
        }
    }

    IEnumerator LiquidFlow()
    {
        flowStream.SetActive(true);
        for (int x = 50; x >= 0; x -= 2)
        {
            yield return new WaitForSeconds(1f);
            fill.CurrentVal = x;
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
        if (fill.currentVal == 40)
        {
            conicalflaskliquid.GetComponent<Image>().color = new Color32(255, 152, 203, 255);
        }
        if (fill.currentVal == 38)
        {
            conicalflaskliquid.GetComponent<Image>().color = new Color32(255, 207, 248, 255);
        }
        if (fill.currentVal == 35)
        {
            conicalflaskliquid.GetComponent<Image>().color = new Color32(255, 105, 180, 0);
        }
        if (fill.currentVal == 0)
        {
            liquidDropParticle.SetActive(false);
        }

    }

}
