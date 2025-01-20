using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class DropBehaviour : MonoBehaviour
{
    public bool isDropped = false;
    public SpriteRenderer dropPoint;
    public ChromatographySimulation chromatographySimulation;
    public Button resetButton;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        resetButton.interactable = true;
        chromatographySimulation.dropdown.interactable = false;
        if (chromatographySimulation.dropdown.value == 0 || chromatographySimulation.dropdown.value == 2)
        {
            Debug.Log("value one selected");
            dropPoint.DOColor(new Color32(26, 96, 14, 255), 5);
            isDropped = true;
        }
        else if (chromatographySimulation.dropdown.value == 1)
        {
            dropPoint.DOColor(new Color32(80, 31, 14, 255), 5);
            isDropped = true;
        }
        Debug.Log("triggered");
        Destroy(collision.gameObject);

    }

    public void ResetDrops()
    {
        DOTween.Clear(dropPoint);
        isDropped = false;
        dropPoint.color = Color.white;
        // dropPoint.DOColor(new Color32(255, 255, 255, 255), 1);
    }
}
