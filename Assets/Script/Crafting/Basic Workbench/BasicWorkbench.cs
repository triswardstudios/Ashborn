using System.Collections.Generic;
using CustomInspector;
using Unity.VisualScripting;
using UnityEngine;

public class BasicWorkbench : CraftbenchBase
{


    private List<Recipe> unlockedCraftablItems = new List<Recipe>();
    public override void Interact(GameObject interctingObject)
    {
        Configure();
    }

    [NaughtyAttributes.Button]
    void Configure()
    {
        unlockedCraftablItems.Clear();


        foreach (Recipe item in canbeCraftedIn)
        {
            if (CraftManager.Instance.unlokcedRecipes.Contains(item))
            {
                //this item can be crafted rn
                unlockedCraftablItems.Add(item);
            }
        }
        ActionManager.OnRecipieSelected += OnRecipeSelected;
        UpdateDisplay();

        ActionManager.onBasicWorkbenchClosed += OnClose;
        UIManager.Instance.bwb_Parent.SetActive(true);
    }

    //Shows avilabel blueprints
    void UpdateDisplay()
    {
        UIItemContainer uIItemContainer;
        for (int i = 0; i < unlockedCraftablItems.Count; i++)
        {
            if (i < UIManager.Instance.bwb_recipeHolder.childCount)
            {
                //use preiviousely created containers
                uIItemContainer = UIManager.Instance.bwb_recipeHolder.GetChild(i).GetComponent<UIItemContainer>();
                uIItemContainer.gameObject.SetActive(true);
                //Update just the amount text
                uIItemContainer.Configure(unlockedCraftablItems[i].outputItemIcon, unlockedCraftablItems[i].outputCraftedItem.amount, unlockedCraftablItems[i]);

            }
            else
            {
                //when there is not enough container create new
                uIItemContainer = Instantiate(GameAssets.Instance.uIItemContainerPrefb, UIManager.Instance.bwb_recipeHolder);
                uIItemContainer.Configure(unlockedCraftablItems[i].outputItemIcon, unlockedCraftablItems[i].outputCraftedItem.amount, unlockedCraftablItems[i]);
            }

        }


        int remaningContainer = UIManager.Instance.bwb_recipeHolder.childCount - unlockedCraftablItems.Count;

        if (remaningContainer <= 0) return;


        //Deactivate all other active container
        for (int i = 0; i < remaningContainer; i++)
            UIManager.Instance.bwb_recipeHolder.GetChild(unlockedCraftablItems.Count + i).gameObject.SetActive(false);
    }

    //show real required items
    void ShowRecipe(Recipe recipe)
    {
        UIManager.Instance.bwb_mainItemIcon.sprite = recipe.outputItemIcon;
        UIManager.Instance.bwb_mainItemNameText.text = recipe.itemName + " X " + recipe.outputCraftedItem.amount.ToString();
        UIManager.Instance.bwb_Details.SetActive(true);

        UIRequiredItemContainer uIRequiredItemContainer;
        for (int i = 0; i < recipe.requiredItemToCraft.Count; i++)
        {
            if (i < UIManager.Instance.bwb_ItemRequiredHolder.childCount)
            {
                //use preiviousely created containers
                uIRequiredItemContainer = UIManager.Instance.bwb_ItemRequiredHolder.GetChild(i).GetComponent<UIRequiredItemContainer>();
                uIRequiredItemContainer.gameObject.SetActive(true);
                //Update just the amount text
                uIRequiredItemContainer.Configure(recipe.requiredItemToCraft[i].inventorySCO.icon, recipe.requiredItemToCraft[i].inventorySCO.itemName, recipe.requiredItemToCraft[i].requiredAmount,InventoryManager.Instance.GetInventory().GetItemAmountInInventory(recipe.requiredItemToCraft[i].inventorySCO.itemType));

            }
            else
            {
                //when there is not enough container create new
                uIRequiredItemContainer = Instantiate(GameAssets.Instance.uIRequiredItemContainerPrefab, UIManager.Instance.bwb_ItemRequiredHolder);
                uIRequiredItemContainer.Configure(recipe.requiredItemToCraft[i].inventorySCO.icon, recipe.requiredItemToCraft[i].inventorySCO.itemName, recipe.requiredItemToCraft[i].requiredAmount,InventoryManager.Instance.GetInventory().GetItemAmountInInventory(recipe.requiredItemToCraft[i].inventorySCO.itemType));
                uIRequiredItemContainer.gameObject.SetActive(true);
            }

        }


        int remaningContainer = UIManager.Instance.bwb_ItemRequiredHolder.childCount - recipe.requiredItemToCraft.Count;

        if (remaningContainer <= 0) return;


        //Deactivate all other active container
        for (int i = 0; i < remaningContainer; i++)
            UIManager.Instance.bwb_ItemRequiredHolder.GetChild(recipe.requiredItemToCraft.Count + i).gameObject.SetActive(false);


    }

    void OnRecipeSelected(Recipe recipe)
    {
        ShowRecipe(recipe);
    }
    void OnClose()
    {
        ActionManager.onBasicWorkbenchClosed -= OnClose;
        ActionManager.OnRecipieSelected -= OnRecipeSelected;

        UIManager.Instance.bwb_Details.SetActive(false);
        UIManager.Instance.bwb_Parent.SetActive(false);

        for (int i = 0; i < UIManager.Instance.bwb_ItemRequiredHolder.childCount; i++)
            UIManager.Instance.bwb_ItemRequiredHolder.GetChild(i).gameObject.SetActive(false);
        

    }
}
