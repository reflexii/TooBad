using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public abstract class State
{
    public SceneID sceneId;
    protected SceneType sceneType;
    protected int sceneIndex;

    public State(SceneID stateType, int sceneIndex)
    {
        this.sceneIndex = sceneIndex;
        this.sceneId = stateType;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public virtual void LoadScene()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(sceneIndex);
    }

    //This method is called each time a scene is loaded.
    void OnSceneLoaded(Scene scene, LoadSceneMode m)
    {
        if (scene.buildIndex == sceneIndex)
        {
            if (sceneType == SceneType.Level)
            {
                GameManager.Instance.StartGame();
            }
        }    
    }

    public enum SceneID
    {
        LevelOne,
        LevelTwo,
        MainMenu
    }

    public enum SceneType
    {
        Level,
        Menu
    }
}
