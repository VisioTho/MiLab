using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class default_positions : MonoBehaviour
{
    public GameObject anode, cathode;
    public static Vector2 anode_pos, cathode_pos;
    // Start is called before the first frame update
    void Start()
    {
        anode_pos = anode.transform.position;
        cathode_pos = cathode.transform.position;
    }

    void Update()
    {
     //   Debug.Log("anode_pos" +  anode.transform.position);
       // Debug.Log("cathode_pos" + cathode.transform.position);
    }
}
