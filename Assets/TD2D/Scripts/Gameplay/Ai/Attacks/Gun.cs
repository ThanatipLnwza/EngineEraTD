using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public SpreadBullet bullet;

    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = (transform.localPosition * Vector2.one).normalized;
    }
    
    // Update is called once per frame
    void Update()
    {
    }

    public void Shoot()
    {
        GameObject go = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
        SpreadBullet goBullet = go.GetComponent<SpreadBullet>();
        goBullet.direction = direction;
    }
}
