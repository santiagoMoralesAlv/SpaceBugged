using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsContainer : MonoBehaviour
{
    [SerializeField]
    private float forceGravitation, velocityToBeInert, startVelocityInY;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Herramienta"))
        {
            if(other.transform.position.y > this.transform.position.y)
            {
                other.attachedRigidbody.AddForce(-forceGravitation * Vector3.up, ForceMode.Force);
            }else {
                other.attachedRigidbody.AddForce(forceGravitation * Vector3.up, ForceMode.Force);
            }

            other.attachedRigidbody.velocity = Vector3.Lerp(other.attachedRigidbody.velocity,new Vector3(0, other.attachedRigidbody.velocity.y, 0), velocityToBeInert);
            other.attachedRigidbody.angularVelocity = Vector3.Lerp(other.attachedRigidbody.angularVelocity, Vector3.zero, velocityToBeInert);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Herramienta"))
        {
            other.attachedRigidbody.velocity = (new Vector3(other.attachedRigidbody.velocity.x, startVelocityInY, other.attachedRigidbody.velocity.z));
        }
    }
}
