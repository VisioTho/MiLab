using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorsController : MonoBehaviour
{
    [SerializeField] private GameObject oil;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(oil.transform.localScale.y==3.45f)
        {
            transform.position = new Vector2(transform.position.x, -0.05f);
        }
        
        else if(oil.transform.localScale.y==4f)
        {
            transform.position = new Vector2(transform.position.x, 0.225f);
        }

        else if(oil.transform.localScale.y== 4.37f)
        {
            transform.position = new Vector2(transform.position.x, 0.407f);
        }

        else if(oil.transform.localScale.y== 4.75f)
        {
            transform.position = new Vector2(transform.position.x, 0.6f);
        }

        else if(oil.transform.localScale.y== 5.05f)
        {
            transform.position = new Vector2(transform.position.x, 0.751f);
        }

        else if(oil.transform.localScale.y== 5.35f)
        {
            transform.position = new Vector2(transform.position.x, 0.901f);
        }
       
        else if(oil.transform.localScale.y== 5.5f)
        {
            transform.position = new Vector2(transform.position.x, 0.976f);
        }

        else if(oil.transform.localScale.y== 5.69f)
        {
            transform.position = new Vector2(transform.position.x, 1.076f);
        }

        else if(oil.transform.localScale.y== 5.88f)
        {
            transform.position = new Vector2(transform.position.x, 1.17f);
        }

        else if(oil.transform.localScale.y== 6.07f)
        {
            transform.position = new Vector2(transform.position.x, 1.265f);
        }

        else if(oil.transform.localScale.y== 6.27f)
        {
            transform.position = new Vector2(transform.position.x, 1.365f);
        }

        else if(oil.transform.localScale.y== 6.44f)
        {
            transform.position = new Vector2(transform.position.x, 1.365f);
        }

        else if(oil.transform.localScale.y== 6.64f)
        {
            transform.position = new Vector2(transform.position.x, 1.55f);
        }

        else if(oil.transform.localScale.y== 6.72f)
        {
            transform.position = new Vector2(transform.position.x, 1.591f);
        }

    }
}
