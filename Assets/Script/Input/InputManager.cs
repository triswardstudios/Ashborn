using Game_Input;
using UnityEngine;

public class InputManager : MonoSingleton<InputManager>
{
    public InputReader gameInpupt;


    public void TogglePlayerInput(bool isActive)
    {
        gameInpupt.SetPlayerInputActivationStatus(isActive);
    }
    public void ToggleUIInput(bool isActive)
    {
        gameInpupt.SetUIInputActivationStatus(isActive);
    }

    public void SetCursorState(bool locked)
    {
        Cursor.lockState = locked ? CursorLockMode.Locked : CursorLockMode.None;
    }
}
