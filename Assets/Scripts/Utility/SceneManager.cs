using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class StateManager
{
    public List<State> scenes = new List<State>();
    private State activeState;

    public StateManager()
    {
        scenes.Add(new MenuState(State.SceneID.MainMenu, 0));
        scenes.Add(new GameState(State.SceneID.LevelOne, 1));
        scenes.Add(new GameState(State.SceneID.LevelTwo, 2));
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
}
