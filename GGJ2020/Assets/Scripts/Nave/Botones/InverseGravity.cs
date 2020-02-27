using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverseGravity : ActiveButton
{
    [SerializeField]
    private Rigidbody[] tools;
    [SerializeField]
    private float gravityForce;

    override public void Use()
    {
        base.Use();
        if (ControlGame.Instance.InGame)
        {
            SetForce();
        }else
        {
            StartGame();
            SetForce();

        }
    }

    public void SetForce()
    {
        foreach (Rigidbody tool in tools)
        {
            if (tool.gameObject.activeInHierarchy)
            {
                tool.AddForce(Vector3.up * gravityForce, ForceMode.Impulse);
            }

        }
    }

    public void StartGame()
    {
        ControlGame.Instance.StartGame();
    }
}
