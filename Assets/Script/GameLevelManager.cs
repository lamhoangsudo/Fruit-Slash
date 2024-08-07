using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameLevelManager : MonoBehaviour
{
    private int pointToClearLevel;
    [SerializeField] private List<LevelSO> levelSOs;
    private int currentPoint;
    public bool playerHasEnoughPoints {  get; private set; }
    public static GameLevelManager instance;
    public event EventHandler OnLevelClear;
    public event EventHandler OnGameOver;
    public event EventHandler OnFinalLevelClear;
    private Transform currentLevel;
    private int currentLevelIndex;
    public string currentLevelName {  get; private set; }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        currentLevelIndex = 0;
        playerHasEnoughPoints = false;
        currentLevel = null;
    }
    private void Start()
    {
        Enemy.OnAnyEnemyKill += Enemy_OnAnyEnemyKill;
        Gate.OnAnyLevelClear += Gate_OnAnyLevelClear;
        NextLevelUI.instance.OnLevelChange += Instance_OnLevelChange;
        GameOverUI.instance.OnPlayAgain += Instance_OnPlayAgain;
        Sword.OnAnySwordBreak += Sword_OnAnySwordBreak;
        LoadLevel(levelSOs[currentLevelIndex]);
    }

    private void Instance_OnPlayAgain(object sender, EventArgs e)
    {
        LoadLevel(levelSOs[currentLevelIndex]);
    }

    private void Sword_OnAnySwordBreak(object sender, EventArgs e)
    {
        OnGameOver?.Invoke(this, EventArgs.Empty);
    }

    private void Instance_OnLevelChange(object sender, EventArgs e)
    {
        currentLevelIndex++;
        if (currentLevelIndex <= levelSOs.Count - 1)
        {
            LoadLevel(levelSOs[currentLevelIndex]);
        }
    }

    private void Gate_OnAnyLevelClear(object sender, System.EventArgs e)
    {
        if (currentLevelIndex < levelSOs.Count - 1)
        {
            OnLevelClear?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            OnFinalLevelClear?.Invoke(this, EventArgs.Empty);
        }
    }

    private void Enemy_OnAnyEnemyKill(object sender, System.EventArgs e)
    {
        IncreaseCurrentPoint();
    }
    private void IncreaseCurrentPoint()
    {
        currentPoint += 1;
        if(currentPoint == pointToClearLevel)
        {
            playerHasEnoughPoints = true;
        }
    }
    private void LoadLevel(LevelSO levelSO)
    {
        if(currentLevel != null) Destroy(currentLevel.gameObject);
        currentPoint = 0;
        playerHasEnoughPoints = false;
        pointToClearLevel = levelSO.levelPoint;
        currentLevel = Instantiate(levelSO.levelMap, transform);
        currentLevelName = levelSO.name;
    }
}
