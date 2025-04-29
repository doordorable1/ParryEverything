using UnityEngine;
using UnityEngine.InputSystem;

public class Managers : MonoBehaviour
{
    public static Managers Instance => _instance;
    static Managers _instance;

    public static InputManager InputManager => Instance._inputManager;
    InputManager _inputManager = new InputManager();

   // TODO : 카메라 매니저 뭔지 금지한테 물어보기 
   // public static CameraTargetManager CameraTargetManager => Instance._cameraTargetManager;
   // CameraTargetManager _cameraTargetManager = new CameraTargetManager();

    private void Awake()
    {
        if (_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
                go.AddComponent<PlayerInput>();
            }
            _instance = go.GetComponent<Managers>();
        }
        else
            _instance = this;

        Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow);
        InputManager.Init();
        // TODO: 카메라 매니저? 금지한테 물어보기 
        //  CameraTargetManager.Init();
    }

    private void OnDisable()
    {
        InputManager.Clear();
    }
}