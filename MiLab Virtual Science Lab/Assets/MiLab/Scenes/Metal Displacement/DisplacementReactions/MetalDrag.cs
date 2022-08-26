using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MetalDrag : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 initialPos;
    float distanceFromCamera;
    public Camera mainCamera;
    public SpriteRenderer metalPiece;

    private bool hasCollided = false;

    public static bool copperCollided, zincCollided, ironCollided, magnesiumCollided = false;
    private float colorTransitionDuration = 120;


    private void Start()
    {
        initialPos = transform.position;
        hasCollided = false;
        copperCollided = false;
        distanceFromCamera = Vector3.Distance(gameObject.transform.position, mainCamera.transform.position);
    }

    void OnMouseDown()
    {
        TemperatureReaction.stirTime = 0f;
        Debug.Log("tapped");
        transform.GetChild(0).gameObject.SetActive(true);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
    }

    void OnMouseDrag()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = distanceFromCamera;
        pos = mainCamera.ScreenToWorldPoint(pos);
        gameObject.GetComponent<Rigidbody2D>().velocity = (pos - transform.position) * 15;
    }

    private void OnMouseUp()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.gameObject.GetComponent<Rigidbody2D>().simulated = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Collidable")
            transform.position = initialPos;
        if (collision.gameObject.name == "BaseCollider")
        {
            this.hasCollided = true;
        }
        if (collision.gameObject.name == "BaseColliderCopper")
        {
            this.hasCollided = true;
            copperCollided = true;
            if (this.metalPiece.name == "magnesium metal")
            {
                metalPiece.DOColor(new Color32(41, 41, 41, 255), 110);
            }
            else if (this.metalPiece.name == "zinc metal")
            {
                metalPiece.DOColor(new Color32(41, 41, 41, 255), 120);
            }
            else if (this.metalPiece.name == "iron metal")
            {
                metalPiece.DOColor(new Color32(192, 119, 34, 255), 120);
            }
            else
            {
                metalPiece.DOColor(new Color32(255, 255, 255, 255), 0);
            }
        }
        if (collision.gameObject.name == "BaseColliderZinc")
        {
            this.hasCollided = true;
            zincCollided = true;
            if (this.metalPiece.name == "magnesium metal")
            {
                metalPiece.DOColor(new Color32(50, 50, 50, 255), 100);
            }
            else
            {
                metalPiece.DOColor(new Color32(255, 255, 255, 255), 0);
            }

        }
        if (collision.gameObject.name == "BaseColliderIron")
        {
            this.hasCollided = true;
            ironCollided = true;
            if (this.metalPiece.name == "magnesium metal")
            {
                metalPiece.DOColor(new Color32(128, 128, 128, 255), 105);
            }
            else if (this.metalPiece.name == "zinc metal")
            {
                metalPiece.DOColor(new Color32(128, 128, 128, 255), 120);
            }
            else
            {
                metalPiece.DOColor(new Color32(255, 255, 255, 255), 0);
            }


        }
        if (collision.gameObject.name == "BaseColliderMagnesium")
        {
            this.hasCollided = true;
            magnesiumCollided = true;
        }

        if (collision.gameObject.name == "PetriDish" || collision.gameObject.name == "Capsule")
            this.hasCollided = false;

    }



    void Update()
    {
        if (MetalReaction.resetMetals)
        {
            metalPiece.DOColor(new Color32(255, 255, 255, 255), 0);
            DOTween.CompleteAll();
        }

        if (transform.localScale.y <= 0.001f)
        {
            this.hasCollided = false;
        }


    }
    public void resetMetalColor()
    {
        metalPiece.color = new Color32(255, 255, 255, 255);
    }

}
