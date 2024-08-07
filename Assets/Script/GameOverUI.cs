using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Button playAgainBtn;
    public static GameOverUI instance;
    public event EventHandler OnPlayAgain;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    private void Start()
    {
        GameLevelManager.instance.OnGameOver += GameLevelManager_OnGameOver;
        Hide();
        playAgainBtn.onClick.AddListener(() =>
        {
            Hide();
            OnPlayAgain?.Invoke(this, EventArgs.Empty);
        });
    }

    private void GameLevelManager_OnGameOver(object sender, System.EventArgs e)
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
