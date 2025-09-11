using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GAME/Recipe")]
public class Recipe : ScriptableObject
{
    public string itemName;
    public InventoryItem outputCraftedItem;
    public Sprite outputItemIcon;
    public List<RecipePair> requiredItemToCraft = new List<RecipePair>();
}
