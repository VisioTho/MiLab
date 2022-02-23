using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewHorizontalController : MonoBehaviour
{
    public GameObject Fader;
    private Scrollbar scroll;
    // Start is called before the first frame update

    void Start()
    {
        scroll = gameObject.GetComponent<CustomScrollRect>().horizontalScrollbar;
        scroll.value = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(gameObject.GetComponent<CustomScrollRect>().horizontalScrollbar.value);
        if (scroll.value <= 0.1f)
        {
            Fader.SetActive(true);
        }
        else
            Fader.SetActive(false);
    }
}
