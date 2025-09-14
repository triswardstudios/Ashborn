using System.Collections.Generic;
using UnityEngine;
using Jy_Util;

public class CraftbenchBase : InteractableBase
{
    public E_Craft_State craftState;
    public List<Recipe> canbeCraftedIn = new List<Recipe>();


    public override void Interact(GameObject interctingObject)
    {
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
        //new craft recipe selected
        craftState = E_Craft_State.CraftSelcted;
        canInteract = false;
    }
    
}
