
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PaperFill : MonoBehaviour
{
    // Start is called before the first frame update
    public FillableImage[] images;

    private void Start()
    {
        foreach (FillableImage image in images)
        {
            image.ResetFill();
        }

        StartCoroutine(FillImagesWithDelay());
    }

    private IEnumerator FillImagesWithDelay()
    {
        foreach (FillableImage image in images)
        {
            image.StartFill();
            yield return new WaitForSeconds(image.fillDelay);
        }
    }
}

public class FillableImage : MonoBehaviour
{
    public Image image;
    public float fillDuration = 2.0f;
    public float fillDelay = 1.0f;

    private float targetFillAmount = 0.0f;
    private float startFillAmount = 0.0f;
    private float fillTime = 0.0f;
    private bool isFilling = false;

    public void ResetFill()
    {
        image.fillAmount = 0.0f;
    }

    public void StartFill()
    {
        startFillAmount = image.fillAmount;
        targetFillAmount = 1.0f;
        fillTime = 0.0f;
        isFilling = true;
    }

    public void UpdateFill()
    {
        if (isFilling && fillTime < fillDuration)
        {
            fillTime += Time.deltaTime;
            float t = Mathf.Clamp01(fillTime / fillDuration);
            image.fillAmount = Mathf.Lerp(startFillAmount, targetFillAmount, t);
        }
        else
        {
            isFilling = false;
        }
    }
}