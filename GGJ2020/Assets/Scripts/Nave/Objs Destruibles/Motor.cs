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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Martillo"))
        {
            audioSource.Play();
            Ship.Instance.ApplyMotorHeal(0.1f);
        }
    }

    override protected IEnumerator UpdateDamage()
    {

        yield return new WaitForSeconds(7);
    }
}
