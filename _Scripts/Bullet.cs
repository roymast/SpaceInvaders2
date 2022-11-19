using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{    
    public float Damage;
    public string ShooterName;
    [SerializeField] private Rigidbody2D rb;
    
    // Start is called before the first frame update
    public void Init(Vector2 dir, Vector2 startPos, float damage, float speed, string shooterName)
    {       
        transform.position = startPos;
        rb.AddForce(dir*speed, ForceMode2D.Impulse);
        Destroy(gameObject, 6);
        Damage = damage;
        ShooterName = shooterName;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (ShooterName == collision.gameObject.name)
            return;

        Destroy(gameObject);
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if(damageable != null)
            damageable.Damage(Damage);        
    }    
}
