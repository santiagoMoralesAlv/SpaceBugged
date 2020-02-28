using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autodamage : MonoBehaviour
{
    [SerializeField]
    private float timeToApplyDamage;
    private float time;

    private void Update()
    {
        if (ControlGame.Instance.InGame)
        {
            time += Time.deltaTime;
            if (time >= (timeToApplyDamage*(1 - ControlGame.Instance.Difficulty)))
            {
                UpdateTimeToAutodamage();
                time = 0;
            }
        }
    }

    public void UpdateTimeToAutodamage()
    {
        Ship.Instance.ApplyRandomDamage();
    }
}
