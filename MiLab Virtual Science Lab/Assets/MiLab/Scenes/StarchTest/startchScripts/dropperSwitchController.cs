using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DropperSwitchController : MonoBehaviour
{
    public GameObject dropper;
    public Vector3 dropperDefaultPosition;
    // Start is called before the first frame update
    void Start()
    {
        dropperDefaultPosition = dropper.transform.position;

        gameObject.GetComponent<Toggle>().onValueChanged.AddListener(delegate
        {
            ShowHideIodineDropper();
        });
    }

    // Update is called once per frame

    public void ShowHideIodineDropper()
    {
        if (gameObject.GetComponent<Toggle>().isOn)
        {
            dropper.transform.DOMove(dropperDefaultPosition, 1);
        }
        else
        {
            dropper.transform.DOMove(new Vector3(dropperDefaultPosition.x - 10.5f, dropperDefaultPosition.y, 0f), 1);
        }
    }
}
