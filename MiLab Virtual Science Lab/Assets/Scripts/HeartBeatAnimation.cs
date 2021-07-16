using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBeatAnimation : MonoBehaviour
{
	[SerializeField]
	public LeanTweenType type;

    // Start is called before the first frame update
	void Start()
	{
		LeanTween.scale(gameObject, new Vector3(1.1f,1.1f,1.1f), 0.1f).setEase(type).setLoopPingPong(1);
	}
	public void animate()
    {
		LeanTween.scale(gameObject, new Vector3(0,0,0), 0.5f).setEase(type).setLoopPingPong(1);
    }

    // Update is called once per frame
	public void DestroyMe()
    {
		gameObject.SetActive(false);

    }
}
