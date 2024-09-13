using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemSO", fileName = "New ItemSO")]
public class ItemSO : ScriptableObject
{
    public int itemID;
    public Sprite sprite;
    public Sprite pickSprite;
}
