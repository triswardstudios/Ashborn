using CustomInspector;
using UnityEngine;


[CreateAssetMenu(menuName = "GAME/InventorySCO")]
public class InventorySCO : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public bool isStackable = true;

    [ShowIf(nameof(isStackable))]
    public int stackUpto = 64;
    public E_Inventory_Item_Type itemType;
}
