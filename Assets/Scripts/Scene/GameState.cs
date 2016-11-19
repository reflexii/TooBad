using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameState : State
{
    public GameState(SceneID sceneId, int sceneIndex) : base(sceneId, sceneIndex)
    {
        sceneType = SceneType.Level;
    }
}
