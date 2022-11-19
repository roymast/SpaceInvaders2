using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public float Damage;
    public float BulletSpeed;
    private int dir;
    [SerializeField] private Bullet bulletPrefab;

    AudioManager audioManager;
    enum ShootingDir 
    { 
        UP, 
        DOWN 
    };
    [SerializeField] private ShootingDir shootingDir;
    
    // Start is called before the first frame update
    void Start()
    {
        dir = shootingDir == ShootingDir.UP ? 1 : -1;
        audioManager = AudioManager.Instance;
    }    

    public void Shoot()
    {
        Bullet bullet = Instantiate(bulletPrefab);
        bullet.Init(transform.up*dir, new Vector2(transform.position.x, transform.position.y + transform.localScale.y * dir), Damage, BulletSpeed, gameObject.name);
        audioManager.PlayShot();
    }
}
