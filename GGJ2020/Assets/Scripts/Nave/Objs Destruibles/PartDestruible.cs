using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DestroyablePart
{
    Motor,
    FuenteEnergia,
    Cable1, Cable2, Cable3,
    Vidrio

}

public abstract class PartDestruible : MonoBehaviour
{
    [SerializeField]
    private DestroyablePart type;

    public DestroyablePart Type { get => type; set => type = value; }

    [SerializeField]
    protected Animator m_animator;

    public void Awake()
    {
        Ship.Instance.e_UpdateParts += UpdatePart;
        if (m_animator == null) { 
            m_animator = this.GetComponent<Animator>();
        }
        ControlGame.Instance.e_startGame += UpdatePart;

    }

    public abstract void Heal(float value);
    public abstract float GetHeal();

    protected bool isCoroutineRunning;
    private void UpdatePart()
    {
        if (!isCoroutineRunning)
        {
            isCoroutineRunning = true;
            StartCoroutine("UpdateDamage");
        }
    }

    private IEnumerator UpdateDamage()
    {
        //La animacion de la corutina parpadea porque se esta reparando todo el tiempo, entonces la corutina funciona en ambas direcciones todo el tiempo
        if (m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1 - GetHeal())
        {
            m_animator.SetFloat("speedMult", 1);
            while (m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1 - GetHeal())
            {
                yield return null;
            }
        }
        else
        {
            m_animator.SetFloat("speedMult", -1);
            while (m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 - GetHeal())
            {
                yield return null;
            }
        }

        m_animator.Play("animacion", 0, 1 - GetHeal());
        m_animator.SetFloat("speedMult", 0);
        isCoroutineRunning = false;
    }

}
