using System.Collections.Generic;
using UnityEngine;
using Jy_Util;

public class GameAssets : MonoSingleton<GameAssets>
{
    public Material darkDummy;
    public Material lightDummy;

    [Header("Basic Workbench")]
    public UIItemContainer uIItemContainerPrefb;
    public UIRequiredItemContainer uIRequiredItemContainerPrefab;

    [Space]
    [Header("Footsteps")]
    public List<C_FootStepAudioPair> footStepsAudio = new List<C_FootStepAudioPair>();

    public AudioClip GetRandomFootStep(E_GroundType e_GroundType)
    {
        foreach (C_FootStepAudioPair item in footStepsAudio)
        {
            if (item.e_GroundType == e_GroundType)
            {
                return item.audioClips[Random.Range(0, item.audioClips.Count)];
            }
        }

        return footStepsAudio[0].audioClips[0];
    }
}
