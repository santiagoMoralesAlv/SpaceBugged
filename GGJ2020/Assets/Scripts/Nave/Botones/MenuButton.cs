using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : ActiveButton
{
    override protected void Activation()
    {
        SceneControl.Instance.StartMenu();
    }


}
