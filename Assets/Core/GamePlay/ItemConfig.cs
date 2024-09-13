using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemConfig", menuName = "ItemConfig")]
public class ItemConfig : ScriptableObject
{
    public List<ItemSO> items;

    public void Initialize()
    {
    }

    public ItemSO GetRandomItem()
    {
        int itemAmount = items.Count;
        int randomIndex = Random.Range(0, itemAmount);
        return items[randomIndex];
    }

}
