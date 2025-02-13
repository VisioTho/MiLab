using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChromatographySimulation : MonoBehaviour
{
    public Image filledImage;
    public PaperTransformHandler paperTransformHandler;
    public DraggableChromatographyPaperController draggableChromatographyPaperController;

    public Draggrable draggrableScript;
    public DropBehaviour dropBehaviour;
    public Image secondFilledImage;
    public float fillDuration = 2.0f;
    public float secondFillDuration = 3.0f;

    public Sprite[] secondFilledImages; // array of different sprites for the second filled image
    public TMP_Dropdown dropdown; // reference to the dropdown UI element

    public TMP_Text selectionText; // reference to the text UI element
    public Image selectionImage; // reference to the image UI element
    public Sprite[] selectionImages; // array of sprites for the dropdown selection

    private float fillTime;
    private bool isFilling;

    private float secondFillTime;
    private bool isSecondFilling;

    public GameObject draggableChromPaper;
    Vector3 initialPosition;
    Vector3 initialScale;

    private void Start()
    {
        filledImage.fillAmount = 0.0f;
        secondFilledImage.fillAmount = 0.0f;
        ChangeSecondFilledImage();

        // Add listener to the dropdown's OnValueChanged event
        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);

        // Manually call the method to initialize the text and image for the default selection
        OnDropdownValueChanged(dropdown.value);
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

    public void ChangeSecondFilledImage()
    {
        // get the index of the selected option in the dropdown list
        int selectedIndex = dropdown.value;
        Debug.Log("Selected index: " + selectedIndex);
        draggrableScript.MoveToDefaultPosition(1);

        // set the sprite of the secondFilledImage to the corresponding sprite in the secondFilledImages array
        secondFilledImage.sprite = secondFilledImages[selectedIndex];
    }

    private void FillImage(Image imageToFill, ref float fillTime, float fillDuration)
    {
        fillTime += Time.deltaTime;
        float t = Mathf.Clamp01(fillTime / fillDuration);
        imageToFill.fillAmount = Mathf.Lerp(0, 1, t);
    }

    // reset the simulation
    public void ResetSimulation()
    {
        // Reset the fill amounts of both images
        filledImage.fillAmount = 0.0f;
        secondFilledImage.fillAmount = 0.0f;

        // Reset the fill times and filling states
        fillTime = 0.0f;
        isFilling = false;
        secondFillTime = 0.0f;
        isSecondFilling = false;

        // Reset the dropdown list to its default value
        dropdown.value = 0;

        // Reset the secondFilledImage to its initial sprite
        ChangeSecondFilledImage();
        paperTransformHandler.Reset();
        dropBehaviour.ResetDrops();
        draggableChromatographyPaperController.ResetObject();
        dropBehaviour.resetButton.interactable = false;
        dropdown.interactable = true;
    }

    // Method to handle dropdown value changes
    private void OnDropdownValueChanged(int index)
    {
        // Define behaviors based on the selected index
        switch (index)
        {
            case 0:
                selectionText.text = "Mango Extract";
                selectionImage.sprite = selectionImages[0];
                break;
            case 1:
                selectionText.text = "Hibiscus Extract";
                selectionImage.sprite = selectionImages[1];
                break;
            case 2:
                selectionText.text = "Cassava Extract";
                selectionImage.sprite = selectionImages[2];
                break;
            // Add more cases as needed
            default:
                selectionText.text = "Default Selection";
                selectionImage.sprite = selectionImages[0];
                break;
        }

        // Optionally, you can call other methods or perform additional actions here
    }
}