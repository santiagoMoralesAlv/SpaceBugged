﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vidrio : PartDestruible
{
    [SerializeField]
    private Material m_material;

    new private void Awake()
    {
        base.Awake();
        m_material = this.GetComponent<Renderer>().material;

        ControlGame.Instance.e_startGame += UpdatePart;
    }

    // Update is called once per frame
    override public void UpdatePart()
    {
        //m_material.color = new Color(1,1,1, 1-Ship.Instance.GlassClarity);
        StartCoroutine("UpdateDamage");
    }

    override public void Heal(float value)
    {
        Ship.Instance.ApplyGlassHeal(value);
    }

    override protected IEnumerator UpdateDamage()
    {
        while ((Mathf.Round(  m_material.GetFloat("_alpha")*100) != Mathf.Round( (1 - Ship.Instance.GlassClarity) * 100)))
        {
            m_material.SetFloat("_alpha", Mathf.Lerp(m_material.GetFloat("_alpha"), 1 - Ship.Instance.GlassClarity, 0.1f));
            yield return null;
        }
    }
}
