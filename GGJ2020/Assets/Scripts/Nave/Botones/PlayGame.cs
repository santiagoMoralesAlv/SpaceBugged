using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGame : ActiveButton
{
    override protected void Activation()
    {
        if (!ControlGame.Instance.InGame)
        {
            ControlGame.Instance.StartGame();
        }
    }


    private void Update()
    {

    }
}
