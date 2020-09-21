using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private bool _leftMousePressed;
    private bool _rightMousePressed;
    private bool _middleMousePressed;

    public void OnMove(InputAction.CallbackContext callbackContext)
    {
        Vector2 input = callbackContext.ReadValue<Vector2>();
        GameManager.Instance.CameraManager.CurrentMovementInput = input;
    }

    public void OnLook(InputAction.CallbackContext callbackContext)
    {
        if(callbackContext.control.device.GetType() == typeof(Mouse))
        {
            if(_rightMousePressed == true)
            {
                Vector2 input = callbackContext.ReadValue<Vector2>();
                GameManager.Instance.CameraManager.CurrentRotationInput = input;
            }
            else
            {
                GameManager.Instance.CameraManager.CurrentRotationInput = Vector2.zero;
            }
        }
    }

    public void OnZoom(InputAction.CallbackContext callbackContext)
    {
        float input = callbackContext.ReadValue<float>();
        GameManager.Instance.CameraManager.CurrentZoomInput = input;
    }

    public void OnRightMouseButton(InputAction.CallbackContext callbackContext)
    {
        if(callbackContext.performed || callbackContext.started)
        {
            _rightMousePressed = true;
        }
        else
        {
            _rightMousePressed = false;
        }
    }

    public void OnLeftMouseButton(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed || callbackContext.started)
        {
            _leftMousePressed = true;
        }
        else
        {
            _leftMousePressed = false;
        }

        if(callbackContext.started)
        {
            GameManager.Instance.SelectionManager.SetSelectionAtScreenPosition(Mouse.current.position.ReadValue());
        }
    }

    public void OnMiddleMouseButton(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed || callbackContext.started)
        {
            _middleMousePressed = true;
        }
        else
        {
            _middleMousePressed = false;
            GameManager.Instance.CameraManager.CurrentMovementInput = Vector2.zero;
        }
    }

    public void OnPanning(InputAction.CallbackContext callbackContext)
    {
        if(_middleMousePressed == false)
        {
            return;
        }

        if(callbackContext.canceled == false)
        {
            GameManager.Instance.CameraManager.CurrentMovementInput = callbackContext.ReadValue<Vector2>();
        }
        else
        {
            GameManager.Instance.CameraManager.CurrentMovementInput = Vector2.zero;
        }
    }
}
