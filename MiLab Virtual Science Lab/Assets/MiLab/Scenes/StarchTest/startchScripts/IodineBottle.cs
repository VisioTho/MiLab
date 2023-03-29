using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class IodineBottle : MonoBehaviour
{
    public GameObject iodineBottle;
    public Vector3 iodineBottleDefaultPosition;
    // Start is called before the first frame update
    void Start()
    {
        iodineBottleDefaultPosition = iodineBottle.transform.position;

        gameObject.GetComponent<Toggle>().onValueChanged.AddListener(delegate
        {
            ShowHideIodineBottle();
        });
    }

    // Update is called once per frame
 
    public void ShowHideIodineBottle()
    {
        if (gameObject.GetComponent<Toggle>().isOn)
        {
            iodineBottle.transform.DOMove(iodineBottleDefaultPosition, 1);
        }
        else
        {
           iodineBottle.transform.DOMove(new Vector3(iodineBottleDefaultPosition.x - 6.5f, iodineBottleDefaultPosition.y, 0f), 1);
        }
    }
}
