using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private CameraManager _cameraManager;
    [SerializeField] private SelectionManager _selectionManager;
    [SerializeField] private Core _core;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if(_core == null || _core.IsAlive == false)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("GAME OVER");
    }

    public CameraManager CameraManager
    {
        get
        {
            return _cameraManager;
        }
    }

    public SelectionManager SelectionManager
    {
        get
        {
            return _selectionManager;
        }
    }

    public Core Core 
    {
        get
        {
            return _core;
        }
    }
}
