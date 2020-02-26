using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoreStatsGUI : MonoBehaviour
{
    [SerializeField]
    private Text enemyVelocity, playerVelocity, distance;
    [SerializeField]
    private Text playerLevel, Level, gameTime;
    [SerializeField]
    private Image motor, fuenteEnergia, vidrio, cable1, cable2, cable3;

    private void Awake()
    {
        //Ship.Instance.e_UpdateParts += UpdatePartStats;
    }

    private void Update()
    {
        UpdateBasicStats();
        UpdatePartStats();
    }

    private void UpdateBasicStats() {
        enemyVelocity.text = "Velocidad enemiga: " + Enemy.Instance.Velocity + "";
        playerVelocity.text = "Tu velocidad: " + Ship.Instance.Velocity + "";
        distance.text = ((int)(ControlGame.Instance.Distance * 100)) * 0.01f + " Km";

        playerLevel.text = "0";
        Level.text = (int)(ControlGame.Instance.Level) + "";
        gameTime.text = (int)(ControlGame.Instance.GameTime) + "";
    }

    private void UpdatePartStats(){
        motor.rectTransform.localScale = new Vector3((Ship.Instance.MotorHealth), 1f, 1f);
        fuenteEnergia.rectTransform.localScale = new Vector3((Ship.Instance.Gas), 1f, 1f);
        vidrio.rectTransform.localScale = new Vector3((Ship.Instance.GlassClarity), 1f, 1f);
        cable1.rectTransform.localScale = new Vector3((Ship.Instance.CablesHealth[0]), 1f, 1f);
        cable2.rectTransform.localScale = new Vector3((Ship.Instance.CablesHealth[1]), 1f, 1f);
        cable3.rectTransform.localScale = new Vector3((Ship.Instance.CablesHealth[2]), 1f, 1f);
    }
}
