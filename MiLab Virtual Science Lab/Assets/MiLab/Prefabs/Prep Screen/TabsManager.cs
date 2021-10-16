using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class TabsManager : MonoBehaviour, ISelectHandler
{
    private Button butn;
    private void Start()
    {
        butn = gameObject.GetComponent<Button>();
    }
    // Update is called once per frame
    void Update()
    {
        OnActive();
        OnInActive();
    }

    private void OnActive()
    {
        
    }

    public void OnSelect(BaseEventData eventData)
    {
        gameObject.LeanScaleX(2f, 1.2f);
        gameObject.LeanScaleY(2f, 1.2f);
    }

    private void OnInActive()
    {
        
    }
}
