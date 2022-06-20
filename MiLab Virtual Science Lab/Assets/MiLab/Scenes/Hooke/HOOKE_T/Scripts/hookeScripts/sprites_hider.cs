using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sprites_hider : MonoBehaviour
{
    public List<GameObject> sprites_to_be_hidden;
    public GameObject APPARATUS_SETUP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (APPARATUS_SETUP.activeSelf)
        {
        foreach(GameObject sprite in sprites_to_be_hidden)
                {
                sprite.GetComponent<SpriteRenderer>().enabled = false;
              }
        }


        if (!APPARATUS_SETUP.activeSelf)
        {
            foreach (GameObject sprite in sprites_to_be_hidden)
            {
                sprite.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }
}
