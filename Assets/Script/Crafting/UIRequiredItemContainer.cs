using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIRequiredItemContainer : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] TMP_Text itemName;
    [SerializeField] TMP_Text amountNeededText;
    [SerializeField] TMP_Text amountInventoryText;
    [SerializeField] Image bgImage;


    public void Configure(Sprite iconSprint, string itemName, int amountNeeded, int amountInventory)
    {
        icon.sprite = iconSprint;
        this.itemName.text = itemName;
        this.amountNeededText.text = "/" + amountNeeded.ToString();
        this.amountInventoryText.text = amountInventory.ToString();

        bgImage.color = (amountNeeded > amountInventory) ? Color.red : Color.white;
    }
}
