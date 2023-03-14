using UnityEngine;
using UnityEngine.UI;

public class ChromatographySimulation : MonoBehaviour
{
    public Image filledImage;
    public Image secondFilledImage;
    public float fillDuration = 2.0f;
    public float secondFillDuration = 3.0f;

    private float fillTime;
    private bool isFilling;
    
    private float secondFillTime;
    private bool isSecondFilling;

    private void Start()
    {
        filledImage.fillAmount = 0.0f;
        secondFilledImage.fillAmount = 0.0f;
    }

    private void LateUpdate()
    {
        if (isFilling && fillTime < fillDuration)
        {
            FillImage(filledImage, ref fillTime, fillDuration);

            if (filledImage.fillAmount >= 0.234f && !isSecondFilling)
            {
                FillImage(secondFilledImage, ref secondFillTime, secondFillDuration);
                isSecondFilling = true;
            }
            else if (isSecondFilling && secondFillTime < secondFillDuration)
            {
                FillImage(secondFilledImage, ref secondFillTime, secondFillDuration);
            }
        }
    }

    public void StartFill()
    {
        if (!isFilling)
        {
            fillTime = 0.0f;
            isFilling = true;
        }
    }

    private void FillImage(Image imageToFill, ref float fillTime, float fillDuration)
    {
        fillTime += Time.deltaTime;
        float t = Mathf.Clamp01(fillTime / fillDuration);
        imageToFill.fillAmount = Mathf.Lerp(0, 1, t);
    }
}
