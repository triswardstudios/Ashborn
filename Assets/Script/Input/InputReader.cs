using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static GameInput;



namespace Game_Input
{


    [CreateAssetMenu(fileName = "New Input Reader", menuName = "GAME/Input/Input Reader")]
    public class InputReader : ScriptableObject, IPlayerActions, IUIActions
    {
        public event Action<bool> OnJumpEvent, OnRunEvent, onFirePress, onAimPress;
        public event Action OnFlashlightEvent, OnNightVisionEvent, OnInventoryEvent, OnInteractEvent, OnBackEvent;
        public event Action<Vector2> OnMoveEvent, OnLookEvent;
        public event Action<Double> OnZoomEvent;
        private GameInput inputActions;



        private void OnEnable()
        {
            if (inputActions == null)
            {
                inputActions = new GameInput();
                inputActions.Player.SetCallbacks(this);
                inputActions.UI.SetCallbacks(this);
            }
            inputActions.Player.Enable();
            inputActions.UI.Enable();
        }


        private void OnDisable()
        {
            inputActions.Player.Disable();
            inputActions.UI.Disable();
        }

        public void SetPlayerInputActivationStatus(bool IsActive)
        {
            if (IsActive)
            {
                inputActions.Player.Enable();
            }
            else
            {
                inputActions.Player.Disable();
            }
        }
        public void SetUIInputActivationStatus(bool IsActive)
        {
            if (IsActive)
            {
                inputActions.UI.Enable();
            }
            else
            {
                inputActions.UI.Disable();
            }
        }



        #region  PlayerMAP
        public void OnMove(InputAction.CallbackContext context)
        {
            OnMoveEvent?.Invoke(context.ReadValue<Vector2>());
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.performed) OnJumpEvent?.Invoke(true);
            else if (context.canceled) OnJumpEvent?.Invoke(false);
        }





        public void OnInventory(InputAction.CallbackContext context)
        {
            if (context.performed) OnInventoryEvent?.Invoke();
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.performed) OnInteractEvent?.Invoke();
        }

        public void OnFire(InputAction.CallbackContext context)
        {
            if (context.performed) onFirePress?.Invoke(true);
            else if (context.canceled) onFirePress?.Invoke(false);
        }

        public void OnBack(InputAction.CallbackContext context)
        {
            if (context.performed) OnBackEvent?.Invoke();
        }

        public void OnAim(InputAction.CallbackContext context)
        {
            if (context.performed) onAimPress?.Invoke(true);
            else if (context.canceled) onAimPress?.Invoke(false);
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            OnLookEvent?.Invoke(context.ReadValue<Vector2>());
        }

        public void OnSprint(InputAction.CallbackContext context)
        {
            if (context.performed) OnRunEvent?.Invoke(true);
            else if (context.canceled) OnRunEvent?.Invoke(false);
        }


        #endregion



        #region UIMAP

        public Action OnCancelEvent;



        public void OnNavigate(InputAction.CallbackContext context)
        {

        }

        public void OnSubmit(InputAction.CallbackContext context)
        {
           
        }

        public void OnCancel(InputAction.CallbackContext context)
        {
            if(context.performed)OnCancelEvent?.Invoke();
        }

        public void OnPoint(InputAction.CallbackContext context)
        {
           
        }

        public void OnClick(InputAction.CallbackContext context)
        {
           
        }

        public void OnRightClick(InputAction.CallbackContext context)
        {
           
        }

        public void OnMiddleClick(InputAction.CallbackContext context)
        {
           
        }

        public void OnScrollWheel(InputAction.CallbackContext context)
        {
           
        }

        public void OnTrackedDevicePosition(InputAction.CallbackContext context)
        {
           
        }

        public void OnTrackedDeviceOrientation(InputAction.CallbackContext context)
        {
           
        }



        #endregion
    }
}