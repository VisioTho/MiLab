using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class drag_n_drop : MonoBehaviour
{
    //drag 'n' drop vars
    public static bool isDragged = false;
    private Vector3 mouseDragStartPosition, spriteDragStartPosition;
    public static bool drag_detached;
   // public bool isHanged = false;//to be used when disabling drag on other masses
    public static Hashtable loads = new Hashtable();
    public static string current_hanged_mass;//accessed from a load_collider class
    public static Vector3 load_dp, load_100_dp, load_200_dp, load_300_dp, load_400_dp, load_custom_dp;//to be fetched from positions_controller class
    public float lerpDuration;
    public static string Lerping_mass;
    public GameObject udr;
    public Vector2 udrPos;
    public static Vector3 loadTargertPos;
    private GameObject tagertMassObject;

    // Start is called before the first frame update
    void Start()
    {
        //track of all the masses
         loads = controller.loads;
         tagertMassObject = null;
             
        load_dp = positions_controller.load_dp;   //fetching from positions_controller class

        //fetching default load positions
        load_100_dp = positions_controller.load_100_dp;
        load_200_dp = positions_controller.load_200_dp;
        load_300_dp = positions_controller.load_300_dp;
        load_400_dp = positions_controller.load_400_dp;
        load_custom_dp = positions_controller.load_custom_dp;


        lerpDuration = 1f;
        Lerping_mass = null;
        udrPos = udr.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
if(tagertMassObject!=null){ loadTargertPos = tagertMassObject.transform.GetChild(0).gameObject.transform.position;}

        //drag_detached = load_collider.drag_detached;  //accessing variable from load_collider class
        current_hanged_mass = load_collider.current_hanged_mass;
        // Debug.Log(Lerping_mass);
        if (current_hanged_mass != null) {
             for (int i = 1; i <= loads.Count; i++)
               {
                if (current_hanged_mass ==(string) loads[i]) { continue; } //skip if the current mass being checked is the one already hanged

                BoxCollider2D[] boxcolliders = GameObject.FindWithTag((string)loads[i]).GetComponents<BoxCollider2D>();
                foreach (BoxCollider2D bcollider in boxcolliders)
                {
                    bcollider.enabled = false;
                }
            }
        }
        else if(Lerping_mass==null) {
            for (int i = 1; i <= loads.Count; i++)
            {
                if (Lerping_mass!=null && Lerping_mass == (string)loads[i]) { continue; } //skip if the current mass being checked is the one on its journey to its original position
         
               BoxCollider2D[] boxcolliders = GameObject.FindWithTag((string)loads[i]).GetComponents<BoxCollider2D>();
               foreach(BoxCollider2D bcollider in boxcolliders)
               {
                   bcollider.enabled = true;
               }
            }
        }
        
       /* if((Lerping_mass=="load_custom" || current_hanged_mass == "load_custom") && current_hanged_mass!=null)
        {
            Debug.Log("Load custom hanged");
            disableColliders();
        }
        else
        {
            Debug.Log("Not custom mass hanged");
            enableColliders();
        }*/

       /*
        if(Lerping_mass!=null && current_hanged_mass==null){
            disableColliders();
         }else{  
            enableColliders();
         }
       */

       // Debug.Log("Lerping mass " + current_hanged_mass);
    }
    //drag 'n' drop
    private void OnMouseDown()
    {   
        Vibration.Vibrate(30); //Vibration
        isDragged = true;
        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragStartPosition = transform.localPosition;
    }
    private void OnMouseDrag()
    {
        if (isDragged)
        {
         

           transform.localPosition = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition); 
            //Debug.Log(" positions -  ob:"+ gameObject.transform.position.y);
          
           if ((gameObject.tag == "load") || (gameObject.tag == "load_100") || (gameObject.tag == "load_200") || (gameObject.tag == "load_300") || (gameObject.tag == "load_400") || (gameObject.tag == "load_500") || (gameObject.tag == "load_600") || (gameObject.tag == "load_700") || (gameObject.tag == "load_800") || (gameObject.tag == "load_custom"))
            {
              

             //showing the tagert when the object is being dragged
             transform.GetChild(0).gameObject.SetActive(true);
             tagertMassObject = gameObject; //assigning the current gameobject to the target
             Debug.Log("drag_pos "+loadTargertPos);

                
                if ((gameObject.transform.position.y > -0.1627356f) && (gameObject.transform.position.x > -1.59f) && (gameObject.transform.position.x < 0.417f))
                {
                    gameObject.transform.position = new Vector2(-0.56f, gameObject.transform.position.y);  //v.x is hardcoded deliberately to force the object only make movement on y axis
                }
            }

        }
    }

    private void OnMouseUp()
    {
      //  spring_target.SetActive(false);

        isDragged = false;
        if ((gameObject.GetComponent<SpringJoint2D>()==null) && (gameObject.tag!="ruler"))
        {
             //showing the tagert when the object is being dragged
             transform.GetChild(0).gameObject.SetActive(false);

            // StartCoroutine(LerpPositionY(new Vector3(gameObject.transform.position.x, dropper.transform.position.y, 0f), lerpDuration));
          if(current_hanged_mass == null){
              
                if (gameObject.tag == "load_100") {  Lerping_mass = gameObject.tag; transform.DOMove(new Vector3(transform.position.x, load_100_dp.y, 0f), lerpDuration).SetEase(Ease.OutCubic).OnComplete(() => { transform.DOMove(load_100_dp, lerpDuration); Lerping_mass = null; }); }//StartCoroutine(LerpPositionY(load_100_dp, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0f), lerpDuration)); }//gameObject.transform.position = load_100_dp;
                if (gameObject.tag == "load_200") { Lerping_mass = gameObject.tag; transform.DOMove(new Vector3(transform.position.x, load_200_dp.y, 0f), lerpDuration).SetEase(Ease.OutCubic).OnComplete(() => { transform.DOMove(load_200_dp, lerpDuration); Lerping_mass = null; }); }//StartCoroutine(LerpPositionY(load_200_dp, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0f), lerpDuration)); }//gameObject.transform.position = load_200_dp;
                if (gameObject.tag == "load_300") { Lerping_mass = gameObject.tag; transform.DOMove(new Vector3(transform.position.x, load_300_dp.y, 0f), lerpDuration).SetEase(Ease.OutCirc).OnComplete(() => { transform.DOMove(load_300_dp, lerpDuration); Lerping_mass = null; }); }//StartCoroutine(LerpPositionY(load_300_dp, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0f), lerpDuration)); }// gameObject.transform.position = load_300_dp;
                if (gameObject.tag == "load_400") { Lerping_mass = gameObject.tag; transform.DOMove(new Vector3(transform.position.x, load_400_dp.y, 0f), lerpDuration).SetEase(Ease.OutCubic).OnComplete(() => { transform.DOMove(load_400_dp, lerpDuration); Lerping_mass = null; }); }//StartCoroutine(LerpPositionY(load_400_dp, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0f), lerpDuration)); }//gameObject.transform.position = load_400_dp;
                //if (gameObject.tag == "load_custom") { Lerping_mass = gameObject.tag; transform.DOMove(load_custom_dp, lerpDuration); Lerping_mass = null; } //StartCoroutine(LerpPositionY(load_custom_dp, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0f), lerpDuration)); }//gameObject.transform.position = load_custom_dp;
            }

  IEnumerator LerpPositionY(Vector2 targetPos, Vector3 nowPosi, float duration)
          {
              Lerping_mass = gameObject.tag;
              float time = 0;
               while (time < duration)//vertical Lerping
                {
                    gameObject.transform.position = Vector3.Lerp(nowPosi, new Vector2(nowPosi.x, targetPos.y), time / duration);
                    time += Time.deltaTime;
                    yield return null;
                }
                gameObject.transform.position = new Vector3(nowPosi.x, targetPos.y, 0f);
                time = 0; //reseting

                while (time < duration) //horizontal Lerping
                {
                    gameObject.transform.position = Vector3.Lerp(new Vector3(nowPosi.x, targetPos.y, 0f), targetPos, time / duration);
                    time += Time.deltaTime;
                    yield return null;
                }
                gameObject.transform.position = targetPos;
                time = 0; //reseting
                Lerping_mass =null;
            }
        }

        if(gameObject.tag=="ruler"){
            //restricting the ruler from going to the extreme left and right
            float ruler_current_pos = gameObject.transform.position.x;
            if( ruler_current_pos < positions_controller.ruler_dp.x ||  ruler_current_pos > positions_controller.load_400_dp.x){
                //gameObject.transform.position = positions_controller.ruler_dp;
                transform.DOMove(positions_controller.ruler_dp, 1);
            }
            Debug.Log("ruler "+  gameObject.transform.position);
            //precise measurement
           if(gameObject.transform.position.x > -2.0f && gameObject.transform.position.x < 0.9f){
                gameObject.transform.position = new Vector2(-1.1f, -1.08f);
           }
        }
    }
    //end drag 'n' drop


public void disableColliders(){
  for (int i = 1; i <= loads.Count; i++){
           if (Lerping_mass == (string) loads[i]) { continue; }
             //GameObject.FindWithTag((string)loads[i]).GetComponent<PolygonCollider2D>().enabled=false;
            //--GameObject.FindWithTag((string)loads[i]).GetComponent<BoxCollider2D>().enabled=false;

            BoxCollider2D[] boxcolliders = GameObject.FindWithTag((string)loads[i]).GetComponents<BoxCollider2D>();
            foreach (BoxCollider2D bcollider in boxcolliders)
            {
               bcollider.enabled = false;
            }
        }
    }

    public void enableColliders(){
     for (int i = 1; i <= loads.Count; i++)
               {
             //GameObject.FindWithTag((string)loads[i]).GetComponent<PolygonCollider2D>().enabled = true;
            //--GameObject.FindWithTag((string)loads[i]).GetComponent<BoxCollider2D>().enabled = true;

            BoxCollider2D[] boxcolliders = GameObject.FindWithTag((string)loads[i]).GetComponents<BoxCollider2D>();
            foreach (BoxCollider2D bcollider in boxcolliders)
            {
                bcollider.enabled = true;
            }
        }
    }
}
