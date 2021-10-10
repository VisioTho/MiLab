using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class PhysicsModuleManager : MonoBehaviour
{
    RectTransform rectTransform;

    #region Getter
    static PhysicsModuleManager instance;
    public static PhysicsModuleManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<PhysicsModuleManager>();
            if (instance == null)
                Debug.LogError("HomeUIManager not found");
            return instance;
        }
    }
    #endregion Getter

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.DOAnchorPosX(rectTransform.rect.width, 0f);
    }
    public void Show(float delay = 0f)
    {
        rectTransform.DOAnchorPosX(0, 0.3f).SetDelay(delay);
    }

    public void Hide(float delay = 0f)
    {
        rectTransform.DOAnchorPosX(rectTransform.rect.width, 0.3f).SetDelay(delay);
    }

    public void ShowHomeScreen()
    {
        Hide();
        HomeUIManager.Instance.Show();
    }
    public void ShowLinearMotionMenu()
    {
        Hide();
        PhysicsUIManager.Instance.Show();
    }
}
