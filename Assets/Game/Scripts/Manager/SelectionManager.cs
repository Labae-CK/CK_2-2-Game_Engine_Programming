using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private Transform _currentSelection;
    private RaycastHit _hit;

    public LayerMask _hitLayerMask;
    public LayerMask _groundLayerMask;
    public LayerMask _moveFocusLayerMask;

    public void SetSelectionAtScreenPosition(Vector2 value)
    {
        Camera mainCamera = GameManager.Instance.CameraManager.MainCamera;
        Ray ray = mainCamera.ScreenPointToRay(value);
        if(Physics.Raycast(ray ,out _hit, 300, _hitLayerMask))
        {
            int mask = 1 << _hit.transform.gameObject.layer;
            if((mask & _moveFocusLayerMask.value) != 0)
            {
                GameManager.Instance.CameraManager.SetTargetPosition(_hit.point);
            }
        }
    }
}
