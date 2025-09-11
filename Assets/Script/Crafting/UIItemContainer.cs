
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItemContainer : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] TMP_Text amountText;
    private Recipe recipe;


    public void Configure(Sprite iconSprint, int amount, Recipe recipe)
    {
        icon.sprite = iconSprint;
        amountText.text = (amount > 0) ? amount.ToString() : "";
        this.recipe = recipe;
    }
    public void Pressed()
    {
        ActionManager.OnRecipieSelected?.Invoke(recipe);
    }
}
