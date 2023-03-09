using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TwoStepReset : MonoBehaviour
{
    public TMP_Dropdown dropDown;
    public Button resetButton;
    public int valueToSelect;

    public Sprite newImage; // The new image we want to show on the button

    private Image buttonImage; // The image component of the button
    private Sprite originalImage; // The original image of the button

    private float duration = 2.0f;

    
    // Start is called before the first frame update

    void Start()
    {
        dropDown.gameObject.SetActive(false);
        resetButton.gameObject.SetActive(false);

        buttonImage = resetButton.GetComponent<Image>(); // Get the image component of the button
        originalImage = buttonImage.sprite; // Save the original image of the button
        
    }
    
    private void OnMouseDown()
    {
        if(dropDown.gameObject.activeSelf == false && resetButton.gameObject.activeSelf == false) 
        {
            dropDown.value = valueToSelect;
            dropDown.gameObject.SetActive(true);
            StartCoroutine(HideDropDown());
            ShowButton();
        }
        
    }

    public void ShowButton()
    {
        buttonImage.sprite = newImage; // Change the image of the button to the new image
        resetButton.gameObject.SetActive(true); // Show the button
        StartCoroutine(ResetImage());
    }

    private IEnumerator ResetImage()
    {
        yield return new WaitForSeconds(duration); // Wait for the specified duration

        resetButton.image.sprite = originalImage; // Change the image of the button back to the original image
    }

    private IEnumerator HideDropDown()
    {
        while (true) // Loop forever until the button is hidden
        {
            yield return null;

            if (Input.GetMouseButtonDown(0) && !RectTransformUtility.RectangleContainsScreenPoint(dropDown.GetComponent<RectTransform>(), Input.mousePosition) && !RectTransformUtility.RectangleContainsScreenPoint(resetButton.GetComponent<RectTransform>(), Input.mousePosition))
            {
                dropDown.gameObject.SetActive(false); // Hide the button
                resetButton.gameObject.SetActive(false);
                buttonImage.sprite = originalImage; // Change the image of the button back to the original image
                break; // Exit the loop
            }
        }
    }


}
