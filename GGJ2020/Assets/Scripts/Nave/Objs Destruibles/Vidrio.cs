using System.Collections;
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
    }

    // Update is called once per frame
    override public void UpdatePart()
    {
        m_material.color = new Color(1,1,1, 1-Ship.Instance.GlassClarity);

    }
}
