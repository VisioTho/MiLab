using DG.Tweening;
using UnityEngine;

public class MiniCarController : MonoBehaviour
{
    [SerializeField] private RectTransform miniCar;
    [SerializeField] private GameObject arrow;
    private Vector3 initialposition;
    [SerializeField] private GameObject contextualHelp;

    // Start is called before the first frame update
    void Start()
    {
        arrow.SetActive(false);
        initialposition = miniCar.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void moveCar()
    {
        miniCar.DOLocalMoveY(20f, 1f).SetLoops(-1);
        arrow.SetActive(true);
    }


    void resetCar()
    {
        if (!contextualHelp.activeSelf)
            miniCar.transform.position = initialposition;
    }
}
