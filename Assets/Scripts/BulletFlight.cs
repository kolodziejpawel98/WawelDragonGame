using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFlight : MonoBehaviour
{
    float bulletSpeed = 2f;
    Rigidbody2D rigidbody;
    Move playerTarget;
    Vector2 moveDirection;    
    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerTarget = GameObject.FindObjectOfType<Move>();
        moveDirection = (playerTarget.transform.position - transform.position).normalized * bulletSpeed;
        if(moveDirection.x <= 0)
        {
            rigidbody.velocity = new Vector2(moveDirection.x, moveDirection.y);
        }
        else if(moveDirection.x > 0)
        {
            Destroy(gameObject, 0.01f);
        }
        Destroy(gameObject, 4f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            Debug.Log("TRAFIONY");
        }
    }
}
