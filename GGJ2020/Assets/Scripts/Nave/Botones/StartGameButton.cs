using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameButton : ActiveButton
{
    override public void Use()
    {
        base.Use();
        if (!ControlGame.Instance.InGame) { 
            SceneControl.Instance.StartGame();
        }
    }
}
