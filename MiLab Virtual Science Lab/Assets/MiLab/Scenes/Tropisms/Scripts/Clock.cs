using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Clock : MonoBehaviour
{
    private Coroutine countdownCoroutine;
    private bool hasCountdownEnded = false;
    private int previousDirection = 0;
    [SerializeField] bonesScriptableObject movementManager;
    [SerializeField] private TMP_Text countdownText;
    [SerializeField] private Image uiFill;

    private void Update()
    {
        if (movementManager.direction != previousDirection)
        {
            if (countdownCoroutine != null)
            {
                StopCoroutine(countdownCoroutine);
                countdownCoroutine = null;
            }

            uiFill.fillAmount = 0f;
            countdownText.text = "00";
            hasCountdownEnded = false;
        }
        else if (!hasCountdownEnded)
        {
            if (countdownCoroutine == null)
            {
                float totalTime = (movementManager.direction == 2 && (previousDirection == 1 || previousDirection == 3)) ? 30f : 60f;
                countdownCoroutine = StartCoroutine(CountdownCoroutine(totalTime));
            }
        }

        previousDirection = movementManager.direction;
    }

    private IEnumerator CountdownCoroutine(float totalTime)
    {
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
