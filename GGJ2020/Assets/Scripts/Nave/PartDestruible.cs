using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PartDestruible : MonoBehaviour
{
    public void Awake()
    {
        Ship.Instance.e_UpdateParts += UpdatePart;

    }

    // Update is called once per frame
    abstract public void  UpdatePart();

    protected abstract IEnumerator UpdateDamage();

    public abstract void Heal(float value);
    
    public abstract float GetHeal();
}
