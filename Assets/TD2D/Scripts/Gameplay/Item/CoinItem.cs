using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CoinItem : Singleton<CoinItem>
{
    [SerializeField] public int gold;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UiManager.Instance.AddGold(gold);
            Destroy(gameObject);
        }
    }
    public void IsEnd()
    {
        Destroy(gameObject);
    }
}
