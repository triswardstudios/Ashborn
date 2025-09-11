using UnityEngine;

public class GameAssets : MonoSingleton<GameAssets>
{
    public Material darkDummy;
    public Material lightDummy;

    [Header("Basic Workbench")]
    public UIItemContainer uIItemContainerPrefb;
    public UIRequiredItemContainer uIRequiredItemContainerPrefab;
}
