using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextTutorialButton : ActiveButton
{
    [SerializeField]
    private Tutorial tutorial;
    [SerializeField]
    private bool toBack;

    override protected void Awake()
    {
        base.Awake();
        tutorial = GameObject.FindGameObjectWithTag("Tutorial").GetComponent<Tutorial>();
        if (tutorial == null)
        {
            Destroy(this);
        }
    }

    private void Update()
    {
    }

    override protected void Activation()
    {
        if (toBack) { 
            SceneControl.Instance.StartTutorial(tutorial.NumTutorial-1);
        }else
        {
            SceneControl.Instance.StartTutorial(tutorial.NumTutorial + 1);
        }
    }
}
