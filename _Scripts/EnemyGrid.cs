using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGrid : MonoBehaviour
{
    public List<Enemy> Enemys = new List<Enemy>();
    private void Start()
    {
        EnemyDamageable.EnemyDestroyed += RemoveEnemy;
    }
    public void AddEnemy(Enemy newEnemy)
    {
        Enemys.Add(newEnemy);
    }
    public void RemoveEnemy(Enemy removeEnemy)
    {
        Enemys.Remove(removeEnemy);
        Destroy(removeEnemy.gameObject);
    }
    public Enemy GetRandomEnemy()
    {
        return Enemys[Random.Range(0, Enemys.Count)];
    }
}
