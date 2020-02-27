using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : ActiveButton
{
    override public void Use()
    {
        base.Use();
        SceneControl.Instance.StartMenu();
    }


}
