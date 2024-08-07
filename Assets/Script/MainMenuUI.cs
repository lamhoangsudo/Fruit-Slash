using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button exitBtn;
    [SerializeField] private Button playBtn;
    private void Start()
    {
        exitBtn.onClick.AddListener(() => { Application.Quit(); });
        playBtn.onClick.AddListener(() => { SceneManager.LoadScene("SampleScene"); });
    }
}
