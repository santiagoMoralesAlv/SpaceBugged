using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextTutorialButton : ActiveButton
{
    [SerializeField]
    private Tutorial tutorial;
    [SerializeField]
    private bool toBack;

    private void Awake()
    {
        tutorial = GameObject.FindGameObjectWithTag("Tutorial").GetComponent<Tutorial>();
        if (!toBack) { 
        this.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private void Update()
    {
        if (!toBack)
        {
            if (tutorial.IsComplete)
        {
            this.GetComponent<MeshRenderer>().enabled = true;
                this.GetComponent<BoxCollider>().enabled = true;
            }
        }
    }

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
