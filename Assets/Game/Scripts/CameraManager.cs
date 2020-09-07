using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [Header("Transform")]
    [SerializeField] private Transform _rootTransform = null;
    [SerializeField] private Transform _pivotTransform = null;
    [SerializeField] private Transform _cameraTransform = null;

    [Header("Speed")]
    [Range(0, 10)]
    [SerializeField] private float _movementSpeed = 5.0f;
    [Range(0, 10)]
    [SerializeField] private float _rotationSpeed = 5.0f;
    [Range(0, 10)]
    [SerializeField] private float _zoomSpeed = 5.0f;
    
    [Header("Smooth Speed")]
    [Range(0, 1)]
    [SerializeField] private float _smoothMovementSpeed = 0.125f;
    [Range(0, 1)]
    [SerializeField] private float _smoothRotationSpeed = 0.125f;
    [Range(0, 1)]
    [SerializeField] private float _smoothZoomSpeed = 0.125f;

    private Vector2 _currentMovementInput;
    private Vector2 _currentRotationInput;
    private float _currentZoomInput;

    private Vector3 _targetPosition;
    private Vector3 _currentPosition;
    private Vector3 _currentPositionVelocity;

    private float _targetHRotation;
    private float _currentHRotation;
    private float _currentHRotationVelocity;

    private float _targetVRotation;
    private float _currentVRotation;
    private float _currentVRotationVelocity;

    private float _targetZoomPosition;
    private float _currentZoomPosition;
    private float _currentZoomPositionVelocity;

    private void Awake()
    {
        _targetPosition = _rootTransform.position;
        _currentPosition = _rootTransform.position;

        _targetHRotation = _rootTransform.eulerAngles.y;
        _currentHRotation = _rootTransform.eulerAngles.y;

        _targetVRotation = _pivotTransform.eulerAngles.x;
        _currentVRotation = _pivotTransform.eulerAngles.x;

        _targetZoomPosition = _cameraTransform.localPosition.z;
        _currentZoomPosition = _cameraTransform.localPosition.z;
    }

    private void Update()
    {
        Move();
        RotateHorizontal();
        RotateVertical();
        Zoom();
    }

    private void Move()
    {
        // Movement.
        if (MovementCondition)
        {
            Vector3 movementValue = CurrentMovementInput.y * _rootTransform.forward + CurrentMovementInput.x * _rootTransform.right;
            _targetPosition += movementValue * _movementSpeed * Time.deltaTime;
        }

        _currentPosition = Vector3.SmoothDamp(_currentPosition, _targetPosition, ref _currentPositionVelocity, _smoothMovementSpeed);
        _rootTransform.position = _currentPosition;
    }

    private void RotateHorizontal()
    {
        if (RotationHorizontalCondition)
        {
            _targetHRotation += _currentRotationInput.x * _rotationSpeed * Time.deltaTime;
        }

        _currentHRotation = Mathf.SmoothDamp(_currentHRotation, _targetHRotation, ref _currentHRotationVelocity, _smoothRotationSpeed);
        _rootTransform.rotation = Quaternion.Euler(0.0f, _currentHRotation, 0.0f);
    }

    private void RotateVertical()
    {
        if (RotationVerticalCondition)
        {
            _targetVRotation += _currentRotationInput.y * _rotationSpeed * Time.deltaTime;
            _targetVRotation = Mathf.Clamp(_targetVRotation, 20.0f, 80.0f);
        }

        _currentVRotation = Mathf.SmoothDamp(_currentVRotation, _targetVRotation, ref _currentVRotationVelocity, _smoothRotationSpeed);
        _pivotTransform.localRotation = Quaternion.Euler(_currentVRotation, 0.0f, 0.0f);
    }

    private void Zoom()
    {
        if (ZoomCondition)
        {
            _targetZoomPosition += CurrentZoomInput * _zoomSpeed * Time.deltaTime;
            _targetZoomPosition = Mathf.Clamp(_targetZoomPosition, -15, -2);
        }

        _currentZoomPosition = Mathf.SmoothDamp(_currentZoomPosition, _targetZoomPosition, ref _currentZoomPositionVelocity, _smoothZoomSpeed);
        _cameraTransform.localPosition = new Vector3(0.0f, 0.0f, _currentZoomPosition);
    }

    public Vector2 CurrentMovementInput
    {
        private get
        {
            return _currentMovementInput;
        }

        set
        {
            _currentMovementInput = value;
        }
    }

    public Vector2 CurrentRotationInput
    { 
        private get
        {
            return _currentRotationInput;
        }
        set
        {
            _currentRotationInput = value;
        }
    }

    public float CurrentZoomInput
    {
        private get
        {
            return _currentZoomInput;
        }
        set
        {
            _currentZoomInput = value;
        }
    }

    public bool MovementCondition
    {
        get
        {
            return CurrentMovementInput.sqrMagnitude > Mathf.Epsilon;
        }
    }

    public bool RotationHorizontalCondition
    {
        get
        {
            return Mathf.Abs(_currentRotationInput.x) > float.Epsilon;
        }
    }

    public bool RotationVerticalCondition
    {
        get
        {
            return Mathf.Abs(_currentRotationInput.y) > float.Epsilon;
        }
    }

    public bool ZoomCondition
    {
        get
        {
            return Mathf.Abs(CurrentZoomInput) > float.Epsilon;
        }
    }
}
