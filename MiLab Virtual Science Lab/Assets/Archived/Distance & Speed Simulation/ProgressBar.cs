using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    private Vector3 bar;
    // Start is called before the first frame update
    void Start()
    {
        bar = transform.localScale;
    }
    int progressLevel;
    public void progressBar(int n)
    {
        progressLevel = n;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x <= 2.5f && progressLevel == 1)
        {
            const float V = 0.02f;
            bar.x += V;
            transform.localScale = bar;
            Debug.Log(transform.localScale.x);
        }
        if (transform.localScale.x <= 3.5f && progressLevel == 2)
        {
            const float V = 0.02f;
            bar.x += V;
            transform.localScale = bar;
            Debug.Log(transform.localScale.x);
        }
        if (transform.localScale.x <= 4.5f && progressLevel == 3)
        {
            const float V = 0.002f;
            bar.x += V;
            transform.localScale = bar;
            Debug.Log(transform.localScale.x);
        }

    }
}
