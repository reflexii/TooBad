using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class StateManager : Singleton<StateManager>
{
    public List<State> scenes = new List<State>();
    public State activeState;
    public State previousState;

    public void Init()
    {
        scenes.Clear();
        scenes.Add(new MenuState(State.SceneID.MainMenu, 0));
        scenes.Add(new GameState(State.SceneID.LevelOne, 1));
        scenes.Add(new GameState(State.SceneID.LevelTwo, 2));
        scenes.Add(new ObejctLoadState(State.SceneID.ObjectLoad, 3));
    }

    public void SwitchScene(State.SceneID sceneId)
    {
        foreach (State state in scenes)
        {
            if (state.sceneId == sceneId)
            {
                state.LoadScene();
            }
        }
    }

    public State.SceneID CurrentState(int sceneIndex)
    {
        foreach (State s in scenes)
        {
            if (s.sceneIndex == sceneIndex)
            {
                activeState = s;
                return s.sceneId;
            }
        }

        return State.SceneID.MainMenu;
    }

    public void SwitchBack()
    {
        SwitchScene(previousState.sceneId);
    }
}
