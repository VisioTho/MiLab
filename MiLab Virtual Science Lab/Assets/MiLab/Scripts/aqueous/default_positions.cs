using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class default_positions : MonoBehaviour
{
    public GameObject anode, cathode;
    public static Vector2 anode_pos, cathode_pos;
    void Start()
    {
        anode_pos = anode.transform.position;
        cathode_pos = cathode.transform.position;
    }
}
