using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tut_BasicRules : Tutorial
{
    [SerializeField]
    private float time;
    [SerializeField]
    private float timeToWin;
    
    [SerializeField]
    private bool survived;

    public float CurrentTime { get => time; set => time = value; }
    public float TimeToWin { get => timeToWin; set => timeToWin = value; }
    public bool Survived { get => survived; set => survived = value; }

    private void Awake()
    {
        Ship.Instance.e_GotDamage += LoseTutorial;
    }

    private void Update()
    {
        if (!survived)
        {
            CheckTime();
        }
        CheckStatus();
    }

    override protected bool CheckIsComplete()
    {
        return (survived);
    }

    public void CheckTime()
    {
        time += Time.deltaTime;

        if (time > timeToWin)
        {
            if (e_completeStep != null)
            {
                e_completeStep();
            }

            survived = true;
        }
    }

    public void LoseTutorial() {
        SceneControl.Instance.StartTutorial(NumTutorial);
    }

}
