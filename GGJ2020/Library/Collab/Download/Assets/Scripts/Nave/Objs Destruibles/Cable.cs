using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable : PartDestruible
{
    [SerializeField]
    private int numCable;
    AudioSource audioSource;
    public ParticleSystem cautin;

    private Animator m_animator;

    new private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        base.Awake();
        m_animator = this.GetComponent<Animator>();
    }
    
    override public void UpdatePart()
    {
        m_animator.SetFloat("Health", Ship.Instance.CablesHealth[numCable]);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("puntaCautin"))
        {
            audioSource.Play();
            cautin.Play();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("puntaCautin"))
        {
            Ship.Instance.ApplyCableHeal(numCable, 0.01f * Time.deltaTime);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("puntaCautin"))
        {
            audioSource.Stop();
            cautin.Stop();
        }
    }
}
