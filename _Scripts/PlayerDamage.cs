using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour, IDamageable
{
    Player player;
    AudioManager audioManager;
    public event Action OnPlayerDestroyed;
    void Start()
    {
        player = GetComponent<Player>();
        audioManager = AudioManager.Instance;
    }
    
    public void Damage(float damage)
    {
        player.Hp -= damage;
        if (player.Hp <= 0)
            Destroyed();        
    }

    public void Destroyed()
    {        
        OnPlayerDestroyed?.Invoke();
    }    
}
