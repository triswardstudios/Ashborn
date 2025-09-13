using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Jy_Util
{
    public class Jy_Utility : MonoSingleton<Jy_Utility>
    {

    }
    [System.Serializable]
    public class InventoryItem
    {
        public E_Inventory_Item_Type item_type;
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

    public enum E_Craft_State
    {
        Empty,
        CraftSelcted,
        Craftinginprogress,
        ReadytoCollect,
    }
    public enum E_GroundType
    {
        Rock = 0,
        Grass = 1,
        WoodFloor = 2,
        Mud = 3,
        Water = 4,
        Soil = 5,
    }


    #endregion

    #region  Struct
    [System.Serializable]
    public struct RecipePair
    {
        public InventorySCO inventorySCO;
        public int requiredAmount;
    }
    #endregion

    #region CLASS
    [System.Serializable]
    public class C_FootStepAudioPair
    {
        public E_GroundType e_GroundType;
        public List<AudioClip> audioClips = new List<AudioClip>();
    }

    #endregion


}