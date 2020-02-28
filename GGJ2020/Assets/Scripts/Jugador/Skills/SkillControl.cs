using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillControl : MonoBehaviour
{
    #region player

    [SerializeField]
    private int levelPlayer;
    private float timeToUpgradeLevel;


    public int LevelPlayer
    {
        get
        {
            return levelPlayer;
        }
    }
    #endregion


    [SerializeField]
    private InverseGravity gravitySkill;
    public InverseGravity GravitySkill { get => gravitySkill; }


    [SerializeField]
    private bool showingPlayerHub, showingRadar, canLaunchGravity;
    public bool ShowingPlayerHub { get => showingPlayerHub;}
    public bool ShowingRadar { get => showingRadar;  }
    public bool CanLaunchGravity { get => canLaunchGravity; }



    [SerializeField]
    private VRTK.VRTK_Pointer pointerB;

    [SerializeField]
    private GameObject playerHub, radar; //A = izq, B = Der

    [SerializeField]
    private Pocket pocket1A, pocket1B, pocket2A, pocket2B; //A = izq, B = Der

    public Pocket Pocket1A { get => pocket1A; }
    public Pocket Pocket1B { get => pocket1B; }
    public Pocket Pocket2A { get => pocket2A; }
    public Pocket Pocket2B { get => pocket2B; }


    private void Awake()
    {
        timeToUpgradeLevel = 20;
        levelPlayer = 0;
    }

    private void Update()
    {
        if (ControlGame.Instance.InGame)
        {
            timeToUpgradeLevel += Time.deltaTime;
            if (timeToUpgradeLevel >= 20)
            {
                UpgradeLevel();
                timeToUpgradeLevel = 0;
            }
        }
    }

    public void UpgradeLevel()
    {
        if (levelPlayer < 5)
        {
            levelPlayer++;
        }

        if (levelPlayer == 3)
        {
            canLaunchGravity = true;
            pointerB.enabled = true;
        }
    }

    public void ShowPlayerHub(bool value) {
        if (levelPlayer > 1)
        {
            showingPlayerHub = value;
            playerHub.SetActive(value);
        }
    }
    public void ShowRadar(bool value)
    {
        if (levelPlayer > 1)
        {
            showingRadar = value;
            radar.SetActive(value);
        }
    }

    public void ShowPocket1A(bool state)
    {
        if (levelPlayer >= 4)
        {
            pocket1A.gameObject.SetActive(state);
        }
        pocket2A.gameObject.SetActive(false);
    }
    public void ShowPocket2A(bool state)
    {
        if (levelPlayer >= 4)
        {
            pocket2A.gameObject.SetActive(state);
        }
        pocket1A.gameObject.SetActive(false);
    }
    public void ShowPocket1B(bool state)
    {
        if (levelPlayer == 5)
        {
            pocket1B.gameObject.SetActive(state);
        }
        pocket2B.gameObject.SetActive(false);
    }
    public void ShowPocket2B(bool state)
    {
        if (levelPlayer >= 5)
        {
            pocket2B.gameObject.SetActive(state);
        }
        pocket1B.gameObject.SetActive(false);
    }

    
}
