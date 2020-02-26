using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillControl : MonoBehaviour
{
    #region player

    [SerializeField]
    private int levelPlayer;

    public int LevelPlayer
    {
        get
        {
            return levelPlayer;
        }
    }
    #endregion

    private bool showingPlayerHub, showingRadar;

    [SerializeField]
    private VRTK.VRTK_Pointer pointerA, pointerB;

    [SerializeField]
    private GameObject playerHub, radar, pocket1A, pocket1B, pocket2A, pocket2B; //A = izq, B = Der

    private void Awake()
    {
        levelPlayer = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpgradeLevel();
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
            pointerA.enabled = true;
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
            pocket1A.SetActive(state);
        }
        pocket2A.SetActive(false);
    }
    public void ShowPocket2A(bool state)
    {
        if (levelPlayer >= 4)
        {
            pocket2A.SetActive(state);
        }
        pocket1A.SetActive(false);
    }
    public void ShowPocket1B(bool state)
    {
        if (levelPlayer == 5)
        {
            pocket1B.SetActive(state);
        }
        pocket2B.SetActive(false);
    }
    public void ShowPocket2B(bool state)
    {
        if (levelPlayer >= 5)
        {
            pocket2B.SetActive(state);
        }
        pocket1B.SetActive(false);
    }

    


}
