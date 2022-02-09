using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ToggleOneOn : MonoBehaviour
{
    [SerializeField] private Toggle toggle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (toggle.isOn)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    }
}
