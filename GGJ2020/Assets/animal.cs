using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animal : MonoBehaviour
{
    private Animator m_animator;
    private AudioSource audioSource;

    new private void Awake()
    {
        ControlGame.Instance.e_loseGame += Dead;

        //audioSource = GetComponent<AudioSource>();
        m_animator = this.GetComponent<Animator>();
    }

    private void Dead()
    {
        m_animator.SetBool("dead", true);
        //audioSource.Play();
    }
}
