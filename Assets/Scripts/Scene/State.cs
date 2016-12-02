using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public abstract class State
{
    public SceneID sceneId;
    public SceneType sceneType;
    public int sceneIndex;

    public State(SceneID stateType, int sceneIndex)
    {
        this.sceneIndex = sceneIndex;
        this.sceneId = stateType;
    }

    public virtual void LoadScene()
    {
        Time.timeScale = 1;
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(sceneIndex);
    }

    //This method is called each time a scene is loaded.
    void OnSceneLoaded(Scene scene, LoadSceneMode m)
    {
        if (scene.buildIndex == sceneIndex)
        {
            if (sceneType != SceneType.ObjectLoad)
            {
                if (!CheckAndLoadObjects())
                {
                    return;
                }
                
            }
            if (sceneType == SceneType.Level)
            {
                GameManager.Instance.ActivateIngameObjects();
            }

            if (sceneType == SceneType.ObjectLoad)
            {
                StateManager.Instance.SwitchBack();
            }

            StateManager.Instance.activeState = this;
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    bool CheckAndLoadObjects()
    {
        if (!GameObject.FindWithTag("Managers"))
        {
            StateManager.Instance.previousState = this;
            StateManager.Instance.SwitchScene(SceneID.ObjectLoad);
            SceneManager.sceneLoaded -= OnSceneLoaded;
            return false;
        }

        return true;
    }

    public enum SceneID
    {
        LevelOne,
        LevelTwo,
        MainMenu,
        ObjectLoad
    }

    public enum SceneType
    {
        Level,
        Menu,
        ObjectLoad
    }
}
