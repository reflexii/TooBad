using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public bool dontDestroy;
    public ObjectPool objectPool;
    public Inventory inventory;
    public AssetManager assetManager;
    public SoundManager soundManager;
    public DialogManager dialogManager;
    public EventManager eventManager;
    public IngameMenu ingameMenu;

    public GameObject player;
    public bool bossState = false;

    public delegate void GameActivityState();

    public event GameActivityState OnStartGame;
    public event GameActivityState OnLevelLoad;
    public event GameActivityState OnRestart;

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
        if (!dontDestroy)
            return;
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

    public void ReloadObjects()
    {
        OnRestart();
    }

    public void RestartCurrentLevel()
    {
        ReloadObjects();
        StateManager.Instance.SwitchScene(StateManager.Instance.activeState.sceneId);
    }

    public void ActivateIngameObjects()
    {
        OnStartGame();
        if(OnLevelLoad != null)
            OnLevelLoad();
    }
}
