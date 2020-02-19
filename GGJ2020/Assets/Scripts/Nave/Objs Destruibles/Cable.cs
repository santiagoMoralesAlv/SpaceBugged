using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable : PartDestruible
{
    [SerializeField]
    private int numCable;

    [SerializeField]
    private Animator m_animator;

    public int NumCable { get => numCable; }

    new private void Awake()
    {
        base.Awake();
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


    private bool isCoroutineRunning;
    override protected IEnumerator UpdateDamage()
    {
        
            //La animacion de la corutina parpadea porque se esta reparando todo el tiempo, entonces la corutina funciona en ambas direcciones todo el tiempo
            
            if (m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1 - Ship.Instance.CablesHealth[numCable])
            {
                m_animator.SetFloat("speedMult", 1);
                while (m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1 - Ship.Instance.CablesHealth[numCable])
                {
                    yield return null;
                }
            }
            else
            {
                m_animator.SetFloat("speedMult", -1);

                while (m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 - Ship.Instance.CablesHealth[numCable])
                {
                    yield return null;
                }
            }

            m_animator.Play("animacion", 0, 1 - Ship.Instance.CablesHealth[numCable]);
            m_animator.SetFloat("speedMult", 0);
            isCoroutineRunning = false;
        

    }
}
