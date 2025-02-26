﻿using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class HomeUIManager : MonoBehaviour
{
    RectTransform rectTransform;

    #region Getter
    static HomeUIManager instance;
    public static HomeUIManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<HomeUIManager>();
            if (instance == null)
                Debug.LogError("HomeUIManager not found");
            return instance;
        }
    }
    #endregion Getter

    void Start()
    {
        Time.timeScale = 1f;
        rectTransform = GetComponent<RectTransform>();
        rectTransform.DOAnchorPosX(0, 0f);
    }

    public void Show(float delay = 0f)
    {
        rectTransform.DOAnchorPosX(0, 0.3f).SetDelay(delay);
    }

    public void Hide(float delay = 0f)
    {
        rectTransform.DOAnchorPosX(rectTransform.rect.width * -1, 0.3f).SetDelay(delay);
    }

    public void ShowSettingsMenu()
    {
        Hide();
        SettingsUIManager.Instance.Show();
    }
    public void ShowApparatusMenu()
    {
        Hide();
        ApparatusUIManager.Instance.Show();
    }
    public void ShowPhysicsMenu()
    {
        Hide();
        PhysicsModuleManager.Instance.Show();
    }
    public void ShowLinearMotionMenu()
    {
        Hide();
        PhysicsUIManager.Instance.Show();
    }
}