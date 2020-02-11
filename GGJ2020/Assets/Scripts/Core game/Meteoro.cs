using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteoro : MonoBehaviour
{
    private Transform tr;
    private float speed;
    public GameObject sonido;

    void Start()
    {
        speed = 0.05f;
        tr = GetComponent<Transform>();
    }
    
    void Update()
    {
        tr.localPosition = new Vector3(tr.localPosition.x - speed, tr.localPosition.y, tr.localPosition.z);
        if(tr.localPosition.x<-20)
        {
            Destruir();
        }

        if (tr.localPosition.x < -10) {
            Destroy(gameObject);
        }
    }

    public void Destruir()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            Ship.Instance.ApplyRandomDamage();
            Instantiate(sonido);
            Destroy(this.gameObject);
        }
    }
}