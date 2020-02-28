using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DestroyablePart
{
    Motor,
    FuenteEnergia,
    Cable1, Cable2, Cable3,
    Vidrio

}

public abstract class PartDestruible : MonoBehaviour
{
    [SerializeField]
    private DestroyablePart type;

    public DestroyablePart Type { get => type; set => type = value; }

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
