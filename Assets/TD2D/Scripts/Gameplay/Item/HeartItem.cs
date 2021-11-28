using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartItem : Singleton<HeartItem>
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EventManager.TriggerEvent("Heal", collision.gameObject, null);
            DataManager.instance.playerScore += 2;
            Destroy(gameObject);
        }
    }
    public void IsEnd()
    {
        Destroy(gameObject);
    }
}
