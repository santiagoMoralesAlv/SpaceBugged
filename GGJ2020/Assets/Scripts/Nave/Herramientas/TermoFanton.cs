using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TermoFanton : MonoBehaviour
{
    [SerializeField]
    private float distanceRay;
    private Ray ray;

    private float energy;

    private bool inFuente, inDowntime;
    [SerializeField]
    private float downtimeToIntWithFuente;

    [SerializeField]
    private ParticleSystem particulasExternas, particulasInternas;
    [SerializeField]
    private GameObject aim;

    [SerializeField]
    private OVRGrabbable m_grabbable;
    private OVRInput.Controller m_controller = OVRInput.Controller.None;

    // Update is called once per frame
    void ThrowRayCast()
    {
        //se tiene q reemplazar por la direccion del control del oculus
        ray = new Ray(this.transform.position, aim.transform.position-this.transform.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distanceRay, LayerMask.GetMask("Esferas"), QueryTriggerInteraction.Collide))
        {
            energy += 0.01f;

            var emi = particulasInternas.emission.rateOverTime;
            emi.constant = energy * 20;
        }

        Debug.DrawRay(this.transform.position, aim.transform.position - this.transform.position, Color.cyan, 2);
        particulasExternas.Play();
    }

    private void Update()
    {
        if (m_grabbable.isGrabbed && inFuente && !inDowntime) {
            DisconnectToFuente();
        }

        if (m_grabbable.isGrabbed) {
            ThrowRayCast();
        }
    }

    public bool ConnectToFuente()
    {
        if (!inDowntime)
        {
            inFuente = true;
            //m_grabbable.allowOffhandGrab = false;

            Ship.Instance.ApplyGasHeal(energy);
            energy = 0;
            StartCoroutine("ResetDownTime");
            return true;
        }
        return false;
    }
    public bool DisconnectToFuente()
    {
        if (!inDowntime)
        {
            inFuente = false;
            StartCoroutine("ResetDownTime");
            return true;
        }
        return false;
    }

    IEnumerator ResetDownTime()
    {
        inDowntime = true;
        yield return new WaitForSeconds(downtimeToIntWithFuente);
        //m_grabbable.allowOffhandGrab = true;
        inFuente = !inFuente;
        inDowntime = false;
    }
}
