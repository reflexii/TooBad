using UnityEngine;
using System.Collections;

public class MenuState : State
{
    public MenuState(SceneID sceneId, int sceneIndex) : base(sceneId, sceneIndex)
    {
        sceneType = SceneType.Menu;
    }
}
