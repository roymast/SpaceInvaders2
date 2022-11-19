using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGridMovement : MonoBehaviour
{
    public float speed;
    public int dir;
    public float lastTimeWallHit;
    public float heightToMoveDown;

    bool isGameRunning;

    public static event Action OnHitFloor;
    private void Start()
    {
        GameManager.Instance.OnGameStart += () => isGameRunning = true;
        GameManager.Instance.OnGameOver += () => isGameRunning = false;

        Enemy enemyPrefab = gameObject.GetComponent<EnemysGenerator>().EnemyPrefab;        
        BoxCollider2D enemyCollider2D = enemyPrefab.GetComponent<BoxCollider2D>();        
        heightToMoveDown = enemyCollider2D.size.y * 0.5f;
        
        EnemyMovement.EnemyWallHit += HitWall;
        EnemyMovement.OnEnemyHitFloor += HitFloor;
    }
    private void OnDestroy()
    {
        GameManager.Instance.OnGameStart -= () => isGameRunning = true;
        GameManager.Instance.OnGameOver -= () => isGameRunning = false;
        EnemyMovement.EnemyWallHit -= HitWall;
        EnemyMovement.OnEnemyHitFloor -= HitFloor;
    }
    private void FixedUpdate()
    {        
        if (!isGameRunning)
            return;
        Vector3 target = transform.position + transform.right * dir;
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
    private void HitWall()
    {
        if (Time.time - lastTimeWallHit < 1 || !isGameRunning)
            return;        
        lastTimeWallHit = Time.time;
        dir *= -1;
        transform.position = new Vector2(transform.position.x, transform.position.y - heightToMoveDown);
    }
    private void HitFloor()
    {        
        OnHitFloor?.Invoke();        
    }
}
