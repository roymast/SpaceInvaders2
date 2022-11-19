using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{    
    public static GameManager Instance;
    public PointsCounter PointsCounter;
    public DisplayStartGame DisplayStartGame;
    public PlayerDamage playerDamage;

    public bool isGameRunning;
    public event Action OnGameOver;
    public event Action OnGameLoad;
    public event Action OnGameStart;

    public int enemysLeft;

    private void Awake()
    {
        if(Instance != null)
            Destroy(Instance);
        Instance = this;
        isGameRunning = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        DisplayStartGame.StartCountingBack();
        DisplayStartGame.OnCountDownOver += () =>
        {
            isGameRunning = true;
            OnGameStart?.Invoke();
        };
        EnemyDamageable.EnemyDestroyed += EnemyDestroyed;
        EnemyGridMovement.OnHitFloor    += () => GameOver();
        playerDamage.OnPlayerDestroyed  += () => GameOver();
    }    
    
    private void EnemyDestroyed(Enemy enemy)
    {
        PointsCounter.AddPoints(enemy.PointsFromDestroing);
        isGameRunning = --enemysLeft > 0;
        if (!isGameRunning)
            GameOver();
    }
    private void GameOver()
    {
        isGameRunning = false;
        OnGameOver?.Invoke();
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
