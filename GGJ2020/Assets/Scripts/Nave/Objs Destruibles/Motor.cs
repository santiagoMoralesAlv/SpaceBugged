using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : PartDestruible
{
    [SerializeField]
    private Animator m_animator;

    new private void Awake()
    {
        base.Awake();
        m_animator = this.GetComponent<Animator>();
    }

    override public void UpdatePart()
    {
        //if(coroutin)
        if (!isCoroutineRunning)
        {
            isCoroutineRunning = true;
            StartCoroutine("UpdateDamage");
        }
    }

    override public void Heal(float value)
    {
        Ship.Instance.ApplyMotorHeal(value);
    }

    override public float GetHeal()
    {
        return Ship.Instance.MotorHealth;
    }

    private bool isCoroutineRunning;
    override protected IEnumerator UpdateDamage()
    {

        //La animacion de la corutina parpadea porque se esta reparando todo el tiempo, entonces la corutina funciona en ambas direcciones todo el tiempo

        if (m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1 - Ship.Instance.MotorHealth)
        {
            m_animator.SetFloat("speedMult", 1);
            while (m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1 - Ship.Instance.MotorHealth)
            {
                yield return null;
            }
        }
        else
        {
            m_animator.SetFloat("speedMult", -1);

            while (m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 - Ship.Instance.MotorHealth)
            {
                yield return null;
            }
        }

        m_animator.Play("animacion", 0, 1 - Ship.Instance.MotorHealth);
        m_animator.SetFloat("speedMult", 0);
        isCoroutineRunning = false;


    }
}
