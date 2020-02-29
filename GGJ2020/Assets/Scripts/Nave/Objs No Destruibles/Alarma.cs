using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarma : MonoBehaviour
{
    private Animator m_animator;
    private AudioSource audioSource;

    private void Awake()
    {
        ControlGame.Instance.e_enterDangerZone += EnterDanger;
        ControlGame.Instance.e_exitDangerZone += ExitDanger;

        audioSource = GetComponent<AudioSource>();
        m_animator = this.GetComponent<Animator>();
    }

    private void EnterDanger()
    {
        m_animator.SetBool("inDanger", true);
        audioSource.Play();
    }

    private void ExitDanger()
    {
        m_animator.SetBool("inDanger", false);
        audioSource.Stop();
    }
}
