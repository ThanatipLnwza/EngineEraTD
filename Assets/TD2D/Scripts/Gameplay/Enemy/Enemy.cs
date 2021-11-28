using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : Singleton<Enemy>
{
    [Serializable]
    public class DropItem
    {
        public GameObject item;
        public int dropRarity;
    }
    public List<DropItem> LootTable = new List<DropItem>();
    [SerializeField]
    public int dropChance;
    
    public void calculateLoot()
    {
        int calc_dropChance = Random.Range(0, 101);
        if (calc_dropChance <= dropChance)
        {
            int itemWeight = 0;
            
            for (int i = 0; i < LootTable.Count; i++)
            {
                itemWeight += LootTable[i].dropRarity;
            }

            int randomValue = Random.Range(0, itemWeight);

            for (int j = 0; j < LootTable.Count; j++)
            {
                if (randomValue <= LootTable [j].dropRarity)
                {
                    Instantiate(LootTable[j].item, transform.position, Quaternion.identity);
                    return;
                }
                randomValue -= LootTable[j].dropRarity;
            }
        }
    }
}
