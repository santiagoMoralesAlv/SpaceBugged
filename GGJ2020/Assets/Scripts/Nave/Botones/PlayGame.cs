using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGame : ActiveButton
{
    override public void Use()
    {
        base.Use();
        if (!ControlGame.Instance.InGame)
        {
            ControlGame.Instance.StartGame();
            this.gameObject.SetActive(false);
        }
    }
}
