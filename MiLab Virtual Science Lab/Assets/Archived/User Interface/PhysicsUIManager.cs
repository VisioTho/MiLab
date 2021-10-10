using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class PhysicsUIManager : MonoBehaviour
{
    RectTransform rectTransform;

    #region Getter
    static PhysicsUIManager instance;
    public static PhysicsUIManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<PhysicsUIManager>();
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
    public void ShowPhysicsMenu()
    {
        Hide();
        PhysicsModuleManager.Instance.Show();
    }
}

