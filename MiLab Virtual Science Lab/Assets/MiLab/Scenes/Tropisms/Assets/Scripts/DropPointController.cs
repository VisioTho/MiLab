using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


///<summary>
/// Control Drop Points by Ray casting. 
/// If It so happens That this is the Drop Point that got Hit
/// It shoud disappear a little later than its siblings
///</summary>
public class DropPointController : MonoBehaviour
{
    
    [SerializeField]
    public TreeRotateScriptableObject treeRotate;
    [SerializeField]
    public RaycastHitScriptableObject rayObject;

    SpriteRenderer DropPoint;

    private string gameObjectName;
    // Start is called before the first frame update
    void Start()
    {
        gameObjectName = this.gameObject.name;
        
        DropPoint = this.GetComponent<SpriteRenderer>();
        DropPoint.enabled = false;
    }

     private void OnEnable()
    {
        treeRotate.treeClickedEvent.AddListener(showUp);
    }

    public void showUp(int mouseOn)
    {
        if(mouseOn == 1 || mouseOn == 0)
        {
           DropPoint.enabled = true; 
        }else
        {
            DropPoint.enabled = false;
        }
    }

    public void onHit()
    {
        if(rayObject.rayName == gameObjectName )
        {
            DropPoint.color = new Color(1f, 0.5f, 0f, 1f);;
        }else
        {
            DropPoint.color = Color.green;
        }
    }



    // Update is called once per frame
    void Update()
    {
        showUp(treeRotate.mouseOn);
        onHit();
    }
}
