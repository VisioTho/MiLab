using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClockGeo : MonoBehaviour
{
    [SerializeField] public RaycastHitScriptableObject rayHit;
    [SerializeField] private TMP_Text countdownText;
    [SerializeField] private Image uiFill;

    private Coroutine countdownCoroutine;
    private bool hasCountdownEnded = false;

    private void Update()
    {
        if (rayHit.rayName == null)
        {
            if (countdownCoroutine != null)
            {
                StopCoroutine(countdownCoroutine);
                countdownCoroutine = null;
            }

            uiFill.fillAmount = 0f;
            countdownText.text = "00";
        }
        else if (!hasCountdownEnded)
        {
            if (countdownCoroutine == null)
            {
                countdownCoroutine = StartCoroutine(CountdownCoroutine());
            }
        }
    }

    private IEnumerator CountdownCoroutine()
    {
        float totalTime = 30f;
        float currentValue = 1f;
        float timer = 0f;

        while (timer < totalTime)
        {
            float progress = timer / totalTime;
            currentValue = Mathf.Lerp(1f, 9f, progress);
            uiFill.fillAmount = (currentValue - 1f) / 8f;
            countdownText.text = Mathf.FloorToInt(currentValue).ToString("00");
            timer += Time.deltaTime;
            yield return null;
        }

        currentValue = 9f;
        uiFill.fillAmount = 1f;
        countdownText.text = "09";
        hasCountdownEnded = true;
        countdownCoroutine = null;
        yield break;
    }
}
