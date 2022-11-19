using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float HorizontalMovement;
    public float Speed;

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + HorizontalMovement, transform.position.y), Speed * Time.deltaTime);
    }
    
}
