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

}

