using System.Collections.Generic;
using UnityEngine;
using Jy_Util;

[CreateAssetMenu(menuName = "GAME/Recipe")]
public class Recipe : ScriptableObject
{
    public string itemName;
    public InventoryItem outputCraftedItem;
    public Sprite outputItemIcon;
    public List<RecipePair> requiredItemToCraft = new List<RecipePair>();
    [Range(1f,100f)]
    public float workload = 10f;
}
