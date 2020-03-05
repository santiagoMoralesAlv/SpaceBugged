using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using UnityEngine.UI;

public class tut_Skills : Tutorial
{
    [SerializeField]
    private VRTK_DashTeleport teleportSkill;

    private bool gravityExecuted, toolsInPockets, HUBshowed;

    [SerializeField]
    private Image imgGravityExecuted, imgTools, imgHUB;

    private void Awake()
    {
        //teleportSkill.Teleported += Teleported;
        Ship.Instance.SkillControl.GravitySkill.e_Execute += GravityExecute;
    }

    private void Update()
    {
        CheckStatus();
        UpdateGUI();
    }

    override protected bool CheckIsComplete()
    {
        toolsInPockets = CheckPockets();
        HUBshowed = CheckHubAndRadar();
        bool result = (gravityExecuted && toolsInPockets && HUBshowed);

        return result;
    }

    public void GravityExecute()
    {
        gravityExecuted = true;
    }
    /*
    public void Teleported(object sender, DestinationMarkerEventArgs e) {
        teleported = true;
    }
    */
    public bool CheckPockets()
    {
        bool result = (Ship.Instance.SkillControl.Pocket1A.HasToolIn()&& Ship.Instance.SkillControl.Pocket2A.HasToolIn() && Ship.Instance.SkillControl.Pocket1B.HasToolIn() && Ship.Instance.SkillControl.Pocket2B.HasToolIn());

        return result;
    }

    public bool CheckHubAndRadar()
    {
        bool result = Ship.Instance.SkillControl.ShowingPlayerHub && Ship.Instance.SkillControl.ShowingRadar;

        return result;
    }
    
    override protected void UpdateGUI()
    {
        imgGravityExecuted.enabled = gravityExecuted;
        imgTools.enabled = toolsInPockets;
        imgHUB.enabled = HUBshowed;
    }
}
