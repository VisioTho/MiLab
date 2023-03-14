using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class DropBehaviour : MonoBehaviour
{
    public bool isDropped = false;
    public SpriteRenderer dropPoint;

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
        Debug.Log("triggered");
        dropPoint.DOColor(new Color32(26, 96, 14, 255), 5);
        isDropped = true;
        Destroy(collision.gameObject);

    }
}
