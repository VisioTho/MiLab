using UnityEngine;

public class DraggableChromatographyPaperController : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 initialPos;
    float distanceFromCamera;
    public Camera mainCamera;



    private bool hasCollided = false;

    public bool canDrag;

    public ChromatographySimulation filledImageController;
    public float fillTime = 2.0f;

    private void Start()
    {
        canDrag = true;
        initialPos = transform.position;
        hasCollided = false;
        distanceFromCamera = Vector3.Distance(gameObject.transform.position, mainCamera.transform.position);
    }

    void OnMouseDown()
    {

        Debug.Log("tapped");
        transform.GetChild(0).gameObject.SetActive(true);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
    }

    void OnMouseDrag()
    {
        if (canDrag)
        {
            Vector3 pos = Input.mousePosition;
            pos.z = distanceFromCamera;
            pos = mainCamera.ScreenToWorldPoint(pos);
            gameObject.GetComponent<Rigidbody2D>().velocity = (pos - transform.position) * 15;
        }



    }

    private void OnMouseUp()
    {
        transform.gameObject.GetComponent<Rigidbody2D>().simulated = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Collidable")
        {
            transform.LeanMoveLocal(initialPos, 0.5f);
        }


        if (collision.gameObject.name == "BaseCollider" && gameObject.name == "DraggableChromPaper")
        {
            this.hasCollided = true;
            filledImageController.fillDuration = fillTime;
            filledImageController.StartFill();
        }

        if (collision.gameObject.name == "PetriDish" || collision.gameObject.name == "Capsule")
            this.hasCollided = false;

    }



    void Update()
    {


    }

    public void ResetObject()
    {
        transform.position = initialPos;
        this.hasCollided = false;
        Debug.Log("no more collision");
        GetComponent<Rigidbody2D>().simulated = true;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        gameObject.GetComponent<PolygonCollider2D>().enabled = true;
    }
}
