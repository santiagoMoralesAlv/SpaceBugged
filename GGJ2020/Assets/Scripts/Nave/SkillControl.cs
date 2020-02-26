using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillControl : MonoBehaviour
{
    #region player
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

    public void ShowPlayerHub() {
        if (levelPlayer > 1)
        {
            showingPlayerHub = !showingPlayerHub;
            playerHub.SetActive(showingPlayerHub);
        }
    }
    public void ShowRadar()
    {
        if (levelPlayer > 1)
        {
            showingRadar = !showingRadar;
            playerHub.SetActive(showingRadar);
        }
    }

    public void ShowPocket1A(bool state)
    {
        if (levelPlayer >= 3)
        {
            pocket1A.SetActive(state);
            pocket2A.SetActive(!state);
        }
    }
    public void ShowPocket2A(bool state)
    {
        if (levelPlayer >= 3)
        {
            pocket2A.SetActive(state);
            pocket1A.SetActive(!state);
        }
    }
    public void ShowPocket1B(bool state)
    {
        if (levelPlayer == 4)
        {
            pocket1B.SetActive(state);
            pocket2B.SetActive(!state);
        }
    }
    public void ShowPocket2B(bool state)
    {
        if (levelPlayer >= 4)
        {
            pocket2B.SetActive(state);
            pocket1B.SetActive(!state);
        }
    }

    public void UpgradeLevel() {
        if (levelPlayer < 4)
        {
            levelPlayer++;
        }

        if (levelPlayer == 2)
        {
            pointerA.enabled = true;
            pointerB.enabled = true;
        }
    }


}
