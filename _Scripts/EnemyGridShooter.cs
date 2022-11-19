using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGridShooter : MonoBehaviour
{    
    public float MaxTimeBetweenShots;
    float TimeBetweenShots;
    float LastTimeShot;
    [SerializeField] EnemyGrid enemyGrid;

    GameManager gameManager;
    bool isGameRunning;
    private void Start()
    {
        isGameRunning = false;
        LastTimeShot = Time.time;
        TimeBetweenShots = Random.Range(0, MaxTimeBetweenShots);
        gameManager = GameManager.Instance;
        gameManager.OnGameStart += () => isGameRunning = true;
        gameManager.OnGameOver  += () => isGameRunning = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (!isGameRunning)
            return;
        if (Time.time - LastTimeShot > TimeBetweenShots)
            Shoot();
    }
    void Shoot()
    {
        TimeBetweenShots = Random.Range(0, MaxTimeBetweenShots);
        LastTimeShot = Time.time;
        enemyGrid.GetRandomEnemy().Shooter.Shoot();
    }
}
