using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSelector : MonoBehaviour
{
    [SerializeField] private GameObject flatRoad, hillyRoad, finishLineFlag;
    public void SelectRoad(int val)
    {
        if(val == 0)
        {
            flatRoad.SetActive(true);
            hillyRoad.SetActive(false);
<<<<<<< HEAD
=======
            finishLineFlag.transform.position = new Vector2(35f, -5.6f);
>>>>>>> parent of dc69827 (Resized the canvas scaler to 1640 x 720 Pixels for each scene)
        }
        if(val == 1)
        {
            flatRoad.SetActive(false);
            hillyRoad.SetActive(true);
        }
    }
    void Start()
    {}

    void FixedUpdate()
    {
        if(hillyRoad.activeSelf==true)
            finishLineFlag.transform.position = new Vector2(33.6f,0.4f);
            else
            finishLineFlag.transform.position = new Vector2(35f,-5.6f);
    }
}
