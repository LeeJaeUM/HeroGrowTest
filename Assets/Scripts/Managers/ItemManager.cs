using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum ItemType
{
    None,
    Coin,
    Exp,
    Heart,
    LootBox
}

public class ItemManager : MonoBehaviour
{
    [System.Serializable]
    public struct ItemPrefab
    {
        public ItemType itemType;
        public GameObject prefab;
    }

    public ItemPrefab[] itemPrefabs;

    private Dictionary<ItemType, GameObject> itemPrefabDict;

    private void Awake()
    {
        itemPrefabDict = new Dictionary<ItemType, GameObject>();
        foreach (var itemPrefab in itemPrefabs)
        {
            itemPrefabDict[itemPrefab.itemType] = itemPrefab.prefab;
        }
    }

    public GameObject CreateItem(ItemType itemType)
    {
        if (itemPrefabDict.TryGetValue(itemType, out GameObject prefab))
        {
            return Instantiate(prefab);
        }
        else
        {
            Debug.LogError("Invalid item type!");
            return null;
        }
    }

    public void SpawnItem(Vector3 spawnPosition, ItemType itemType)
    {
        GameObject item = CreateItem(itemType);
        if (item != null)
        {
            item.transform.position = spawnPosition;
        }
    }
}
