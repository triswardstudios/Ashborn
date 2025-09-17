using System.Collections.Generic;
using UnityEngine;
using Jy_Util;
using System.Collections;
using UnityEngine.UI;
using System;

public class CraftbenchBase : InteractableBase
{
    public E_Craft_State craftState;
    public List<Recipe> canbeCraftedIn = new List<Recipe>();
    protected Recipe selectedRecipe;

    [Header("ProgressWidget")]
    protected Action OneCraftDone;



    public override void Interact(GameObject interctingObject)
    {
        if (!canInteract) return;

        canInteract = false;
        InputManager.Instance.TogglePlayerInput(false);
        InputManager.Instance.ToggleUIInput(true);
        InputManager.Instance.SetCursorState(false);
    }

    protected void CloseBench()
    {
        canInteract = true;
        InputManager.Instance.TogglePlayerInput(true);
        InputManager.Instance.ToggleUIInput(false);
        InputManager.Instance.SetCursorState(true);
    }

    public virtual void CraftButtonPressed()
    {
        if (craftState != E_Craft_State.Empty) return;
        //new craft recipe selected
        craftState = E_Craft_State.CraftSelcted;
        canInteract = false;
        UnHover(); //close pointer widget

            Debug.Log("Selected recipe :" + selectedRecipe.itemName + "Require count" + selectedRecipe.requiredItemToCraft.Count);
        //Inventory remove
        for (int i = 0; i < selectedRecipe.requiredItemToCraft.Count; i++)
        {
            Debug.Log("inventory remove status " + InventoryManager.Instance.RemoveItemFromInventory(selectedRecipe.requiredItemToCraft[i].inventorySCO.itemType, selectedRecipe.requiredItemToCraft[i].requiredAmount));
        }

        UIManager.Instance.bwb_iconProgressImg.sprite = selectedRecipe.outputItemIcon;
        UIManager.Instance.progressPanel.SetActive(true);
        StartCoroutine(AddProgress(selectedRecipe));
    }

    IEnumerator AddProgress(Recipe recipe)
    {
        float currentTime = 0f;
        while (currentTime <= recipe.carftTime)
        {
            // progress goes from 0 → 1 as time passes
            UIManager.Instance.bwb_progressImg.fillAmount = Mathf.Clamp01(currentTime / recipe.carftTime);
            yield return new WaitForSeconds(0.01f);
            currentTime += 0.01f;
        }
        UIManager.Instance.bwb_progressImg.fillAmount = 1f;
        OneCraftDone?.Invoke();
        UIManager.Instance.progressPanel.SetActive(false);
    }


    protected void OnCraftDone()
    {
        OneCraftDone -= OnCraftDone;
        PlayerAnimationManager.Instance.PlayerCraftonBasicWorkbench(false);
        canInteract = true;
        InputManager.Instance.TogglePlayerInput(true);
        InputManager.Instance.ToggleUIInput(false);
        InputManager.Instance.SetCursorState(false);
        craftState = E_Craft_State.Empty;
    }
}
