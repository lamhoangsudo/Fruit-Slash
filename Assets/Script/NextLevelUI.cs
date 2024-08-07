using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NextLevelUI : MonoBehaviour
{
    [SerializeField] private Button nextLevelBtn;
    [SerializeField] private TextMeshProUGUI level;
    public static NextLevelUI instance;
    public event EventHandler OnLevelChange;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    private void Start()
    {
        level.text = "Level 1";
        GameLevelManager.instance.OnLevelClear += GameLevelManager_OnLevelClear;
        Hide();
        nextLevelBtn.onClick.AddListener(() =>
        {
            Hide();
            OnLevelChange?.Invoke(this, EventArgs.Empty);
            level.text = GameLevelManager.instance.currentLevelName;
        });
    }

    private void GameLevelManager_OnLevelClear(object sender, System.EventArgs e)
    {
        Show();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
    private void Show()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
}
