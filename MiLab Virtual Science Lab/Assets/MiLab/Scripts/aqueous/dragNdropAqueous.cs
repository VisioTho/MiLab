using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragNdropAqueous : MonoBehaviour
{
    public static bool isDragged = false;
    private Vector3 mouseDragStartPosition, spriteDragStartPosition;
    public float difference_between_nodes;
    public GameObject anode_hand, cathode_hand;
    public static bool isHandAnodeDragged = false;
    public static bool isHandCathodeDragged = false;
    Vector3 initAnodePos, initCathodePos;
    // Start is called before the first frame update
    void Start()
    {
        initAnodePos = GameObject.FindWithTag("anode").transform.position;
        initCathodePos = GameObject.FindWithTag("cathode").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        difference_between_nodes = GameObject.FindWithTag("anode").transform.position.x - GameObject.FindWithTag("cathode").transform.position.x;//to be used later

        //showing a hand on top of anode as it is being dragged
        if (isHandAnodeDragged)
        {
            anode_hand.SetActive(true);
        }
        else
        {
            anode_hand.SetActive(false);
        }
        //showing a hand on top of cathode as it is being dragged
        if (isHandCathodeDragged)
        {
            cathode_hand.SetActive(true);
        }
        else
        {
            cathode_hand.SetActive(false);
        }
    }
     private void OnMouseDown()
    {
        Vibration.Vibrate(30); //vibration
        isDragged = true;
        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragStartPosition = transform.localPosition;

       

        }
    private void OnMouseDrag()
    {
        
        if (isDragged)
        {
           

           transform.localPosition = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition);


            if (gameObject.tag=="anode"){
                isHandAnodeDragged = true;
                GameObject.FindWithTag("cathode").transform.position = initCathodePos;//taking cathode to its original position

                gameObject.transform.position = new Vector2(gameObject.transform.position.x,  initAnodePos.y);
                //restricting the anode from going to the far left
               if (gameObject.transform.position.x < -0.3903209f)
                {
                    gameObject.transform.position = new Vector2(-0.3903209f, gameObject.transform.position.y);
                }
                //restricting the anode from going to the far right
                if (gameObject.transform.position.x >  0.8829727f)
                {
                    gameObject.transform.position = new Vector2(0.8829727f, gameObject.transform.position.y);
                }

            }
           
          if(gameObject.tag=="cathode"){
                isHandCathodeDragged = true;

                GameObject.FindWithTag("anode").transform.position = initAnodePos;//taking anode to its original position

                gameObject.transform.position = new Vector2(gameObject.transform.position.x, initCathodePos.y);
                //restricting the cathode from going to the far left
                if (gameObject.transform.position.x < -0.1736131f)
                {
                    gameObject.transform.position = new Vector2(-0.1736131f, transform.position.y);
                }
                //restricting the cathode from going to the far right
                if (gameObject.transform.position.x > 1.099679f)
                {
                    gameObject.transform.position = new Vector2(1.099679f, transform.position.y);
                }
              
            } 
        }
    }

    private void OnMouseUp()
    {
      isDragged = false;
      isHandAnodeDragged = isHandCathodeDragged = false;
    }
}
