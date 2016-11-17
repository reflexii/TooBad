﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public ObjectPool objectPool;
    public Inventory inventory;
    public AssetManager assetManager;
    public StateManager stateManager;
    public SoundManager soundManager;

    public delegate void GameActivityState();
    public event GameActivityState OnStartGame;

    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        stateManager = new StateManager();
        if (_instance == null)
        {
            DontDestroyOnLoad(gameObject);
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(this);
        }
    }

    public void StartGame()
    {
        OnStartGame();
    }
}
