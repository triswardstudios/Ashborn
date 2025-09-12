using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    [Header("Basic Workbench")]  //bwb -> basic Work bench
    public GameObject bwb_Parent;
    public GameObject bwb_Details;
    public Transform bwb_recipeHolder;
    public Image bwb_mainItemIcon;
    public TMP_Text bwb_mainItemNameText;
    public Transform bwb_ItemRequiredHolder;
    public Button bwb_CraftButton;

    public void bwb_CloseButtonPressed()
    {
        ActionManager.onBasicWorkbenchClosed?.Invoke();
    }
    public void bwb_CraftButtonPressed()
    {
        ActionManager.onCraftButtonPressed?.Invoke();
    }
}
