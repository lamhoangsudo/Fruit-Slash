using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndUI : MonoBehaviour
{
    [SerializeField] private Button mainMenuBtn;
    private void Start()
    {
        GameLevelManager.instance.OnFinalLevelClear += GameLevelManager_OnFinalLevelClear;
        Hide();
        mainMenuBtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("MainMenu");
        });
    }

    private void GameLevelManager_OnFinalLevelClear(object sender, System.EventArgs e)
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
