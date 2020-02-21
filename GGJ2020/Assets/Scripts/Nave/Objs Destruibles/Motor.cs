using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : PartDestruible
{
    private Animator m_animator;
    private AudioSource audioSource;

    new private void Awake()
    {
        base.Awake();
        audioSource = GetComponent<AudioSource>();
        m_animator = this.GetComponent<Animator>();
    }
    
    override public void UpdatePart()
    {
        m_animator.Play("animacion", 0, 1-Ship.Instance.MotorHealth);
    }

    override public void Heal(float value)
    {
        Ship.Instance.ApplyMotorHeal(value);
    }

    override protected IEnumerator UpdateDamage()
    {

        yield return new WaitForSeconds(7);
    }
}
