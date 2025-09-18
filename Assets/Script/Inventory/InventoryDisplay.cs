using Jy_Util;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    private InventoryItem[] items;
    public void Configure(Inventory inventory)
    {
        items = inventory.GetInventoryItems();
        UIItemContainer uIItemContainer;

        for (int i = 0; i < items.Length; i++)
        {
            if (i < UIManager.Instance.inventoryConatienr.childCount)
            {
                //use preiviousely created containers
                uIItemContainer = UIManager.Instance.inventoryConatienr.GetChild(i).GetComponent<UIItemContainer>();
                uIItemContainer.gameObject.SetActive(true);
                //Update just the amount text
                uIItemContainer.Configure(GameAssets.Instance.GetIcon(items[i].item_type),items[i].amount );
            }else
            {
                //when there is not enough container create new
                uIItemContainer = Instantiate(GameAssets.Instance.uIItemContainerPrefb, UIManager.Instance.inventoryConatienr);
                uIItemContainer.Configure(GameAssets.Instance.GetIcon(items[i].item_type),items[i].amount );
            }
        }
    }

    public void UpdateDisplay(Inventory inventory)
    {
        Configure(inventory);
    }
}
