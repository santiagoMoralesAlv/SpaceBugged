using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameButton : ActiveButton
{
    override protected void Activation()
    {
        if (!ControlGame.Instance.InGame) { 
            SceneControl.Instance.StartGame();
        }
    }
}
