using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextTutorialButton : ActiveButton
{
    [SerializeField]
    private Tutorial tutorial;
    [SerializeField]
    private bool toBack;

    override public void Use()
    {
        base.Use();
        if (toBack) { 
            SceneControl.Instance.StartTutorial(tutorial.NumTutorial-1);
        }else
        {
            SceneControl.Instance.StartTutorial(tutorial.NumTutorial + 1);
        }
    }
}
