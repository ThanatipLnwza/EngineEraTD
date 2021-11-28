using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : Singleton<PlayerStat>
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            EventManager.TriggerEvent("Captured", collision.gameObject, null);
        }
        
    }

    public void Isdead()
    {
        gameObject.SetActive(false);
    }
}
