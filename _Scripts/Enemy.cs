using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Hp;
    public float Damage;
    public int PointsFromDestroing;

    public EnemyDamageable EnemyDamageable;
    public Shooter Shooter;
}
