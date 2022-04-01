using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hand_positionalizer : MonoBehaviour
{
    public GameObject anode_hand, cathode_hand, anode, cathode, pos_particle_system, neg_particle_system;
    // Start is called before the first frame update
    void Start()
    {
        anode_hand.SetActive(false);
        cathode_hand.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        anode_hand.transform.position = new Vector2(anode.transform.position.x, anode_hand.transform.position.y);
        cathode_hand.transform.position = new Vector2(cathode.transform.position.x, cathode_hand.transform.position.y);


        pos_particle_system.transform.position = new Vector2(cathode.transform.position.x, pos_particle_system.transform.position.y);
        neg_particle_system.transform.position = new Vector2(anode.transform.position.x, neg_particle_system.transform.position.y);
    }
}
