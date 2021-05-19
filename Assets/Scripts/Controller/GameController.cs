using System.Collections;
using System.Collections.Generic;
using Controller;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private ScriptableObject _configure;
    private Controllers _controllers;

    private float _deltaTime;

    // Start is called before the first frame update
    void Start()
    {
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
