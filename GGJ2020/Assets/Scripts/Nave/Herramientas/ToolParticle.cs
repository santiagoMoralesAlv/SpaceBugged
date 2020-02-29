using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolParticle : ToolSFX
{
    [SerializeField]
    private ParticleSystem psystem;

    new private void Awake()
    {
        base.Awake();
        if (psystem == null)
        {
            psystem = this.GetComponent<ParticleSystem>();
        }
    }

    override protected void UpdateSFX(bool value)
    {
        if (value)
        {
            psystem.Play();
        }
        else
        {
            psystem.Stop();
        }
    }
}
