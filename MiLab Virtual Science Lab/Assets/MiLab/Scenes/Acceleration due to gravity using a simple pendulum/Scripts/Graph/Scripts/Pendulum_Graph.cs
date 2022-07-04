using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using TMPro;

public class Pendulum_Graph : MonoBehaviour
{
    [SerializeField] private Sprite circleSprite;
    private RectTransform graphContainer;
    private RectTransform labelTemplateX;
    private RectTransform labelTemplateY;
    private RectTransform dashTemplateX;
    private RectTransform dashTemplateY;
    private List<GameObject> gameObjectList;

    private string xValue1 = "0", xValue2 = "0", xValue3 = "0", xValue4 = "0", xValue5 = "0";
    private string[] xValues;
    private string yValue1 = "0", yValue2 = "0", yValue3 = "0", yValue4 = "0", yValue5 = "0";

    private string x1_num, x2_num;
    private string y1_num, y2_num;
    private float Gradient_value;
    public TMP_Text gradientValue;

    public Button plotGraphButton, resetGraphButton;
    //public TMP_InputField InputField, InputField2, InputField3, InputField4, InputField5;
    // public InputField inputField1, inputField2, inputField3, inputField4, inputField5;

    private float maxEntry = 100;
    private float minEntry = 0;

    private void Awake()
    {
    }

    private void Update()
    {

    }

    public void GradientXvalue1(string x_num1)
    {
        x1_num = x_num1;
    }
    public void GradientXvalue2(string x_num2) => x2_num = x_num2;
    public void GradientYvalue1(string y_num1) => y1_num = y_num1;
    public void GradientYvalue2(string y_num2) => y2_num = y_num2;

    public void CalculateGradient()
    {
        Gradient_value = (float.Parse(y2_num) - float.Parse(y1_num)) / (float.Parse(x2_num) - float.Parse(x1_num));

        gradientValue.text = "Gradient :   " + Gradient_value.ToString();
    }


    // X-axis controlling values

   
    public void xAxis1(string x1)
    {
        if (float.Parse(x1) > maxEntry)
        {
            xValue1 = maxEntry.ToString();
        }
        else if (float.Parse(x1) < minEntry)
        {
            xValue1 = minEntry.ToString();
        }
        else
        {
            xValue1 = x1;
        }
    }


    public void xAxis2(string x2)
    {
        if (float.Parse(x2) > maxEntry)
        {
            xValue2 = maxEntry.ToString();
        }
        else if (float.Parse(x2) < minEntry)
        {
            xValue2 = minEntry.ToString();
        }
        else
        {
            xValue2 = x2;
        }
    }
    public void xAxis3(string x3)
    {
        if (float.Parse(x3) > maxEntry)
        {
            xValue3 = maxEntry.ToString();
        }
        else if (float.Parse(x3) < minEntry)
        {
            xValue3 = minEntry.ToString();
        }
        else
        {
            xValue3 = x3;
        }
    }
    public void xAxis4(string x4)
    {
        if (float.Parse(x4) > maxEntry)
        {
            xValue4 = maxEntry.ToString();
        }
        else if (float.Parse(x4) < minEntry)
        {
            xValue4 = minEntry.ToString();
        }
        else
        {
            xValue4 = x4;
        }
    }
    public void xAxis5(string x5)
    {
        if (float.Parse(x5) > maxEntry)
        {
            xValue5 = maxEntry.ToString();
        }
        else if (float.Parse(x5) < minEntry)
        {
            xValue5 = minEntry.ToString();
        }
        else
        {
            xValue5 = x5;
        }
    }



    //Y-axis controlling values
    public void yAxis1(string y1) => yValue1 = y1;
    public void yAxis2(string y2) => yValue2 = y2;
    public void yAxis3(string y3) => yValue3 = y3;
    public void yAxis4(string y4) => yValue4 = y4;
    public void yAxis5(string y5) => yValue5 = y5;


    public void PlotGraph()
    {

        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();
        labelTemplateX = graphContainer.Find("labelTemplateX").GetComponent<RectTransform>();
        labelTemplateY = graphContainer.Find("labelTemplateY").GetComponent<RectTransform>();
        dashTemplateX = graphContainer.Find("dashTemplateX").GetComponent<RectTransform>();
        dashTemplateY = graphContainer.Find("dashTemplateY").GetComponent<RectTransform>();

        gameObjectList = new List<GameObject>();

        List<float> valueList = new List<float>() { float.Parse(yValue1), float.Parse(yValue2), float.Parse(yValue3), float.Parse(yValue4), float.Parse(yValue5) };
        ShowGraph(valueList, (float _i) => "" + (_i), (float _f) => "" + Mathf.RoundToInt(_f));

        resetGraphButton.interactable = true;
        plotGraphButton.interactable = false;
    }
    private GameObject CreateCircle(Vector2 anchoredPosition)
    {
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = circleSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(8, 8);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        return gameObject;
    }

    public void GraphReset()
    {
        foreach (GameObject gameObject in gameObjectList)
        {
            Destroy(gameObject);
        }
        gameObjectList.Clear();
        plotGraphButton.interactable = true;
        resetGraphButton.interactable = false;

        //  inputField1.text = inputField2.text = inputField3.text = inputField4.text = inputField5.text = "";
        // InputField.text = InputField2.text = InputField3.text = InputField4.text = InputField5.text = "";
    }


    public void ShowGraph(List<float> valueList, Func<float, string> getAxisLabelX = null, Func<float, string> getAxisLabelY = null)
    {
        if (getAxisLabelX == null)
        {
            getAxisLabelX = delegate (float _i) { return _i.ToString(); };
        }
        if (getAxisLabelY == null)
        {
            getAxisLabelY = delegate (float _f) { return Mathf.RoundToInt(_f).ToString(); };
        }

        GraphReset();

        float graphHeight = graphContainer.sizeDelta.y;
        float graphWidth = graphContainer.sizeDelta.x;
        float xMaximum = 100f;

        float yMaximum = 10;
        float yMinimum = 0;

        foreach (float value in valueList)
        {
            if (value > yMaximum)
            {
                yMaximum = value;
                yMaximum = yMaximum + (yMaximum - yMinimum) * 0.2f;
            }
            if (value < yMinimum)
            {
                yMinimum = value;
                //yMinimum = yMinimum - (yMaximum - yMinimum) * 0.2f;
            }
        }

        //List<float> xValueList = new List<float>() { 0.3f, 0.5f, 0.7f, 0.9f, 1.1f };
        List<float> xValueList = new List<float>() { float.Parse(xValue1), float.Parse(xValue2), float.Parse(xValue3), float.Parse(xValue4), float.Parse(xValue5) };
        // float xSize = 48f;

        GameObject lastCircleGameObject = null;
        for (int i = 0; i < valueList.Count; i++)
        {
            //float xPosition = xSize + i * xSize;
            float xPosition = (xValueList[i] / xMaximum) * graphWidth;
            float yPosition = ((valueList[i] - yMinimum) / (yMaximum - yMinimum)) * graphHeight;
            GameObject circleGameObject = CreateCircle(new Vector2(xPosition, yPosition));
            gameObjectList.Add(circleGameObject);
            if (lastCircleGameObject != null)
            {
                GameObject dotConnectionGameObject = CreateDotConnection(lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent<RectTransform>().anchoredPosition);
                gameObjectList.Add(dotConnectionGameObject);
            }
            lastCircleGameObject = circleGameObject;
        }

        // X-axis labels
        int xSeparatorCount = 5;
        for (int i = 0; i <= xSeparatorCount; i++)
        {
            RectTransform labelx = Instantiate(labelTemplateX);
            labelx.SetParent(graphContainer, false);
            labelx.gameObject.SetActive(true);
            float normalizedValue = i * 1f / xSeparatorCount;
            labelx.anchoredPosition = new Vector2(normalizedValue * graphWidth, -9f);
            labelx.GetComponent<TextMeshProUGUI>().text = getAxisLabelX(normalizedValue * xMaximum);
            gameObjectList.Add(labelx.gameObject);

            RectTransform dashX = Instantiate(dashTemplateX);
            dashX.SetParent(graphContainer, false);
            dashX.gameObject.SetActive(true);
            dashX.anchoredPosition = new Vector2(-7f, normalizedValue * graphHeight);
            gameObjectList.Add(dashX.gameObject);
        }

        // Y-axis labels
        int separatorCount = 10;
        for (int i = 0; i <= separatorCount; i++)
        {
            RectTransform labelY = Instantiate(labelTemplateY);
            labelY.SetParent(graphContainer, false);
            labelY.gameObject.SetActive(true);
            float normalizedValue = i * 1f / separatorCount;
            labelY.anchoredPosition = new Vector2(-7f, normalizedValue * graphHeight);
            labelY.GetComponent<TextMeshProUGUI>().text = getAxisLabelY(yMinimum + (normalizedValue * (yMaximum - yMinimum))); ;
            gameObjectList.Add(labelY.gameObject);

            RectTransform dashY = Instantiate(dashTemplateY);
            dashY.SetParent(graphContainer, false);
            dashY.gameObject.SetActive(true);
            dashY.anchoredPosition = new Vector2(normalizedValue * graphWidth, -4f);
            gameObjectList.Add(dashY.gameObject);
        }
    }

    private GameObject CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB)
    {
        GameObject gameObject = new GameObject("dotConnection", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 150);
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        Vector2 dir = (dotPositionB - dotPositionA).normalized;
        float distance = Vector2.Distance(dotPositionA, dotPositionB);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(distance, 3f);
        rectTransform.anchoredPosition = dotPositionA + dir * distance * .5f;
        rectTransform.localEulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVectorFloat(dir));
        return gameObject;
    }
}
