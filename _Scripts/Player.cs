using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Hearts;
    public float Hp;
    public float Damage;
    public float Speed;
    public float BulletSpeed;
    public int KillCounter;

    Shooter shooter;
    PlayerMovment playerMovment;
    private void Awake()
    {
        shooter = GetComponent<Shooter>();
        shooter.Damage = Damage;
        shooter.BulletSpeed = BulletSpeed;

        playerMovment = GetComponent<PlayerMovment>();
        playerMovment.Speed = Speed;
    }
}
