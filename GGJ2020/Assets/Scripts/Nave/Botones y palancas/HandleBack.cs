using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleBack : Handle
{
    [SerializeField]
    private Tutorial tutorial;

    override protected void Awake()
    {
        base.Awake();
        if (isTutorial)
        {
            tutorial = GameObject.FindGameObjectWithTag("Tutorial").GetComponent<Tutorial>();
        }
        if (tutorial == null)
        {
            Destroy(this);
        }
    }

    override protected void Activation()
    {
        if (isTutorial)
        {
            SceneControl.Instance.StartTutorial(tutorial.NumTutorial - 1);
        }
        else
        {
            SceneControl.Instance.StartMenu();
        }
    }
}
