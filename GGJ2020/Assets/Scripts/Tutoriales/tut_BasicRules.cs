using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tut_BasicRules : Tutorial
{
    private float time;
    [SerializeField]
    private float timeToWin;
    private bool survived;


    [SerializeField]
    private Text txtTime, txtTimeToWin;
    [SerializeField]
    private Image imgTimeToWin;

    #region properties
    public float CurrentTime { get => time; set => time = value; }
    public float TimeToWin { get => timeToWin; set => timeToWin = value; }
    public bool Survived { get => survived; set => survived = value; }
    #endregion

    private void Awake()
    {
        Ship.Instance.e_GotDamage += LoseTutorial;

        txtTimeToWin.text = "Tiempo mínimo: " + timeToWin;
    }

    private void Update()
    {
        if (!survived)
        {
            CheckTime();
            UpdateGUI();
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
            time = timeToWin;
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

    override protected void UpdateGUI()
    {
        txtTime.text = "Tiempo actual: " + (int)time;

        imgTimeToWin.rectTransform.localScale = new Vector3(time/timeToWin, 1f, 1f);
    }
}
