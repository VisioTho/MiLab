using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OneStepReset : MonoBehaviour
{
    public Button button; // The button we want to show/hide7
 
    public Sprite newImage; // The new image we want to show on the button

    private Image buttonImage; // The image component of the button
    private Sprite originalImage; // The original image of the button

    private float duration = 2.0f;

    private void Start()
    {
        buttonImage = button.GetComponent<Image>(); // Get the image component of the button
        originalImage = buttonImage.sprite; // Save the original image of the button
        button.gameObject.SetActive(false); // Hide the button at start
    }

    public void ShowButton()
    {
        buttonImage.sprite = newImage; // Change the image of the button to the new image
        button.gameObject.SetActive(true); // Show the button
        StartCoroutine(HideButton()); // Start the coroutine to hide the button when the user taps outside of it
        StartCoroutine(ResetImage());
    }
    void OnMouseDown()
    {
        if(button.gameObject.activeSelf == false)
            ShowButton();
    }

    private IEnumerator ResetImage()
    {
        yield return new WaitForSeconds(duration); // Wait for the specified duration

        button.image.sprite = originalImage; // Change the image of the button back to the original image
    }

    private IEnumerator HideButton()
    {
        while (true) // Loop forever until the button is hidden
        {
            yield return null;

            if (Input.GetMouseButtonDown(0) && !RectTransformUtility.RectangleContainsScreenPoint(button.GetComponent<RectTransform>(), Input.mousePosition))
            {
                button.gameObject.SetActive(false); // Hide the button
                buttonImage.sprite = originalImage; // Change the image of the button back to the original image
                break; // Exit the loop
            }
        }
    }
}

