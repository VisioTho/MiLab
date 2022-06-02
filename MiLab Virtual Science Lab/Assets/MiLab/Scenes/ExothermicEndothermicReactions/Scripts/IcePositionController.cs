using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IcePositionController : MonoBehaviour
{
    [SerializeField] private Slider waterSlider;
    private float initialPos;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
        float newPos;
        if(waterSlider.value > 0.8f)
        {
            newPos = (1.0f / waterSlider.value) * initialPos;
        }
        else
        {
            newPos = -1.0f;
        }
        transform.position = new Vector2(transform.position.x, newPos);
    }
}
