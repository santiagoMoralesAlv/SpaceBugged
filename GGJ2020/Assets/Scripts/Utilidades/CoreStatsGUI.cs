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

    private void Awake()
    {
        //Ship.Instance.e_UpdateParts += UpdatePartStats;
    }

    private void Update()
    {
        UpdateBasicStats();
    }

    private void UpdateBasicStats() {
        enemyVelocity.text = Enemy.Instance.Velocity + "";
        playerVelocity.text = Ship.Instance.Velocity + "";
        distance.text = ((int)(ControlGame.Instance.Distance * 100)) * 0.01f + " Km";

        playerLevel.text = Ship.Instance.SkillControl.LevelPlayer+"";
        Level.text = (int)(ControlGame.Instance.Level) + "";
        gameTime.text = (int)(ControlGame.Instance.GameTime) + "";
    }

    
}
