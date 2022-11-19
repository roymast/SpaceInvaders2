using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public BoxCollider2D enemyCollider;
    Camera mainCam;

    float width;
    float height;
    public static event Action EnemyWallHit;
    public static event Action OnEnemyHitFloor;
    private void Start()
    {
        mainCam = Camera.main;
        width = enemyCollider.size.x;
        height = enemyCollider.size.y;        
    }
    private void Update()
    {        
        Vector2 posLeft = mainCam.WorldToViewportPoint(new Vector2(transform.position.x - width, transform.position.y));
        Vector2 posRight= mainCam.WorldToViewportPoint(new Vector2(transform.position.x + width, transform.position.y));
        
        if (posRight.x >= 1.0f)
        {            
            CheckForHitGround();
            EnemyWallHit?.Invoke();
        }
        if (posLeft.x <= 0)
        {            
            CheckForHitGround();
            EnemyWallHit?.Invoke();
        }
    }    
    private void CheckForHitGround()
    {        
        if (mainCam.WorldToViewportPoint(transform.position).y < 0.3f)
            OnEnemyHitFloor?.Invoke();
    }
}
