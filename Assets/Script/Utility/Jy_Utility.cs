using UnityEngine;

public class Jy_Utility : MonoSingleton<Jy_Utility>
{

}
[System.Serializable]
public class InventoryItem 
{
    public  E_Inventory_Item_Type item_type;
    public int amount;

    public InventoryItem(E_Inventory_Item_Type item_type, int amount)
    {
        this.item_type = item_type;
        this.amount = amount;
    }
}


#region  ENUM
public enum E_LightState
{
    InLight,
    InShadow
}

public enum E_Inventory_Item_Type
{
    Wood = 0,
    Stone = 1,
    Iron = 2,
    Nail = 3,
    Gun = 4,
}


#endregion

#region  Struct
[System.Serializable]
public struct RecipePair
{
    public InventorySCO inventorySCO;
    public int requiredAmount ;
}
#endregion
