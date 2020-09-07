using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public void OnMove(InputValue inputValue)
    {
        Vector2 input = inputValue.Get<Vector2>();
        GameManager.Instance.CameraManager.CurrentMovementInput = input;
    }

    public void OnLook(InputValue inputValue)
    {
        Vector2 input = inputValue.Get<Vector2>();
        GameManager.Instance.CameraManager.CurrentRotationInput = input;
    }

    public void OnZoom(InputValue inputValue)
    {
        float input = inputValue.Get<float>();
        GameManager.Instance.CameraManager.CurrentZoomInput = input;
    }
}
