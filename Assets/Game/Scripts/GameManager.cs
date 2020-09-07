using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private CameraManager _cameraManager;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public CameraManager CameraManager
    {
        get
        {
            return _cameraManager;
        }
    }
}
