using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadBullet : MonoBehaviour
{
    public float speed = 2;
    [SerializeField] public int damage = 1;
    
    private Vector2 velocity;
    public Vector2 direction = new Vector2(1, 0);
    void Start()
    {
        Destroy(gameObject,4);
    }

    // Update is called once per frame
    void Update()
    {
        velocity = direction * speed;
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        pos += velocity;
        transform.position = pos;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            DamageTaker damageTaker = collision.GetComponent<DamageTaker>();
            damageTaker.TakeDamage(damage);
            Destroy(gameObject);
        }

        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        
    }
}
