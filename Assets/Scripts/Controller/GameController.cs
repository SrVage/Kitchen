using Controller;
using DefaultNamespace;
using UnityEngine;

public sealed class GameController : MonoBehaviour
{
    [SerializeField] private Configure _configure;
    private Controllers _controllers = null;

    private float _deltaTime;

    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Landscape;
        Application.targetFrameRate = 60;
        _controllers = new Controllers();
        new GameInitialization(_controllers, _configure);
        _controllers.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        _deltaTime = Time.deltaTime;
        _controllers.Execute(_deltaTime);
    }
}
