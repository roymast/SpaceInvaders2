using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageable : MonoBehaviour, IDamageable
{
    public static event Action<Enemy> EnemyDestroyed;
    public GameObject destroyedPatriclesPrefab;
    Enemy enemy;    
    private void Start()
    {
        enemy = GetComponent<Enemy>();        
    }
    public void Damage(float damage)
    {
        enemy.Hp -= damage;
        if(enemy.Hp <= 0)
            Destroyed();        
    }

    public void Destroyed()
    {
        EnemyDestroyed?.Invoke(enemy);        
        GameObject destroyedParticles = Instantiate(destroyedPatriclesPrefab, transform.parent);
        destroyedParticles.transform.position = gameObject.transform.position;        
    }            
}
