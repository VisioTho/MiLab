using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class on_drag_extend : MonoBehaviour

{
    public GameObject anode, cathode, anode_extender, cathode_extender, an_stretchPointA, an_stretchPointB, cath_stretchPointA, cath_stretchPointB;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //anode
        float anodeExtspritesize = anode_extender.GetComponent<SpriteRenderer>().sprite.rect.width / anode_extender.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
        Vector2 scale1 = anode_extender.transform.localScale;
        scale1.x = (an_stretchPointA.transform.position.x - an_stretchPointB.transform.position.x) / anodeExtspritesize;
        anode_extender.transform.localScale = scale1;
        anode_extender.transform.position = new Vector2((an_stretchPointA.transform.position.x + an_stretchPointB.transform.position.x) / 2, anode_extender.transform.position.y );



        ///cathode
        float cathodeExtspritesize = cathode_extender.GetComponent<SpriteRenderer>().sprite.rect.width / cathode_extender.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
        Vector2 scale2 = cathode_extender.transform.localScale;
        scale2.x = (cath_stretchPointA.transform.position.x - cath_stretchPointB.transform.position.x) / cathodeExtspritesize;
        cathode_extender.transform.localScale = scale2;
        cathode_extender.transform.position = new Vector2((cath_stretchPointA.transform.position.x + cath_stretchPointB.transform.position.x) / 2, cathode_extender.transform.position.y);
    }
}
