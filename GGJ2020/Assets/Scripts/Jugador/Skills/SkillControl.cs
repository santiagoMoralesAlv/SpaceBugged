using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private bool showingPlayerHud, showingRadar, canLaunchGravity;
    public bool ShowingPlayerHud { get => showingPlayerHud;}
    public bool ShowingRadar { get => showingRadar;  }
    public bool CanLaunchGravity { get => canLaunchGravity; }



    [SerializeField]
    private VRTK.VRTK_Pointer pointer;

    [SerializeField]
    private GameObject playerHub, radar; //A = izq, B = Der

    [SerializeField]
    private Pocket pocket1A, pocket1B, pocket2A, pocket2B; //A = izq, B = Der

    public Pocket Pocket1A { get => pocket1A; }
    public Pocket Pocket1B { get => pocket1B; }
    public Pocket Pocket2A { get => pocket2A; }
    public Pocket Pocket2B { get => pocket2B; }


    [SerializeField]
    private Image imgGravity, imgPointer, imgRadar, imgPlayerHud, imgPocketAizq, imgPocketBizq, imgPocketAder, imgPocketBder;

    [SerializeField]
    private Sprite sprSkillInAction, sprGravity, sprPointer, sprRadar, sprPlayerHud, sprPocket;

    private void Awake()
    {
        timeToUpgradeLevel = 20;
    }

    private void Update()
    {
        if (ControlGame.Instance.InGame)
        {
            timeToUpgradeLevel += Time.deltaTime;
            if (timeToUpgradeLevel >= 30)
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

            switch (levelPlayer)
            {
                case 1:
                    break;
                case 2:
                    imgPlayerHud.sprite = sprPlayerHud;
                    imgRadar.sprite = sprRadar;
                    break;
                case 3: //Gravity
                    canLaunchGravity = true;

                    imgGravity.sprite = sprGravity;
                    break;
                case 4: // Pocket A
                    imgPocketAizq.sprite = sprPocket;
                    imgPocketAder.sprite = sprPocket;
                    break;
                case 5: // Pocket B
                    imgPocketBizq.sprite = sprPocket;
                    imgPocketBder.sprite = sprPocket;
                    break;
            }
        }
    }

    public void ShowPlayerHub(bool value) {
        if (levelPlayer > 1)
        {
            showingPlayerHud = value;
            VRReferences.Instance.RightBugHand.UpdateDiscState(value);
            
            imgPlayerHud.sprite = value ? sprSkillInAction : sprPlayerHud;
        }
    }
    public void ShowRadar(bool value)
    {
        if (levelPlayer > 1)
        {
            showingRadar = value;
            VRReferences.Instance.RightBugHand.UpdateDiscState(value);

            imgRadar.sprite = value ? sprSkillInAction : sprRadar;
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
