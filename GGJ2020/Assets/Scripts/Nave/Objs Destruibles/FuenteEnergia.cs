using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuenteEnergia : PartDestruible
{
    [SerializeField]
    private ParticleSystem m_particles;

    [SerializeField]
    private GameObject eje;

    new private void Awake()
    {
        base.Awake();
    }

    // Update is called once per frame
    override public void UpdatePart()
    {
        var emi = m_particles.emission.rateOverTime;
        emi.constant = Ship.Instance.Gas*20;
    }

    override public void Heal(float value)
    {
        Ship.Instance.ApplyGasHeal(value);
    }

    override public float GetHeal()
    {
        return Ship.Instance.Gas;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TermoFanton")) {
            if (other.gameObject.GetComponent<TermoFanton>().ConnectToFuente())
            {
                other.transform.SetParent(eje.transform);
                other.transform.position = Vector3.zero;
                other.transform.rotation = Quaternion.identity;
            }
        }
    }

    override protected IEnumerator UpdateDamage()
    {

        yield return new WaitForSeconds(7);
    }
}
