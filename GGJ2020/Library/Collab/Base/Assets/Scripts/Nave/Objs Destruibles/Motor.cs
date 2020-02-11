using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : PartDestruible
{
    
    private Animator m_animator;

    new private void Awake()
    {
        base.Awake();
        m_animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    override public void UpdatePart()
    {
        m_animator.SetFloat("Health", Ship.Instance.MotorHealth);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("puntaMartillo"))
        {
            Ship.Instance.ApplyMotorHeal(0.1f);
        }
    }
}
