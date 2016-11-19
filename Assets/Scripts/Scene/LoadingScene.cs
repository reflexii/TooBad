using UnityEngine;
using System.Collections;

public class ObejctLoadState : State
{
    public ObejctLoadState(SceneID stateType, int sceneIndex) : base(stateType, sceneIndex)
    {
        sceneType = SceneType.ObjectLoad;
    }
}
