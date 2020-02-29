using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Tutorial : MonoBehaviour
{
    [SerializeField]
    private int numTutorial;
    [SerializeField]
    private bool isComplete;
    public delegate void UpdateState(bool state);
    public UpdateState e_completeTutorial;
    public UnityAction e_completeStep;

    public int NumTutorial { get => numTutorial; set => numTutorial = value; }
    public bool IsComplete { get => isComplete; set => isComplete = value; }
    
    protected void CheckStatus()
    {
        if (CheckIsComplete())
        {
            if (!isComplete) { 
                isComplete = true;
                if(e_completeTutorial!= null) {
                e_completeTutorial(true);
                }
            }
        }
    }

    abstract protected bool CheckIsComplete();
}
