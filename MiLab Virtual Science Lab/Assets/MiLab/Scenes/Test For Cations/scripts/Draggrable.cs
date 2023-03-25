using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Draggrable : MonoBehaviour
{
    public delegate void DragEndedDelegate(Draggrable draggableObjects);
    public DragEndedDelegate dragEndedCallback;

    private bool isDragged = false;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;
    private Vector3 defaultPosition;
    private bool hasCollided = false;

    public float xRange = 10f;
    public float yRange = 10f;
    public GameObject snapRange;
    // public Camera mainCamera;

    private void Start()
    {
        defaultPosition = transform.position;
    }

    private void Update()
    {
        if (transform.position.y > yRange)
        {
            Debug.Log("yey");
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        }
        else if (transform.position.y < -1.206)
        {
            transform.position = new Vector3(transform.position.x, -1.206f, transform.position.z);
        }
    }
    private void OnMouseDown()
    {
        snapRange.SetActive(true);
        isDragged = true;
        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragStartPosition = transform.localPosition;
    }

    private void OnMouseDrag()
    {
        if (isDragged)
        {
            Debug.Log("dragged");
            transform.localPosition = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition);
        }
    }

    private void OnMouseUp()
    {
        snapRange.SetActive(false);
        isDragged = false;
        dragEndedCallback(this);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

    }

    public void MoveToDefaultPosition(float duration)
    {
        StartCoroutine(MoveToPosition(defaultPosition, duration));
    }

    private IEnumerator MoveToPosition(Vector3 position, float duration)
    {
        float elapsed = 0f;
        Vector3 startingPosition = transform.localPosition;

        // Move towards the default position on the x-axis
        Vector3 xPosition = new Vector3(position.x, startingPosition.y, startingPosition.z);
        while (Vector3.Distance(transform.localPosition, xPosition) > 0.01f)
        {
            transform.localPosition = Vector3.Lerp(startingPosition, xPosition, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Set starting position to current position
        startingPosition = transform.localPosition;

        // Drop to the default position on the y-axis
        elapsed = 0f;
        while (elapsed < duration)
        {
            transform.localPosition = Vector3.Lerp(startingPosition, position, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = position;
    }





}