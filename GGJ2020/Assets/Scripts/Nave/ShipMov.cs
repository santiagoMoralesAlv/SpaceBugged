using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMov : MonoBehaviour
{
    Transform tr;
    bool izquierda, derecha;
    float speed;
    private int state;

    #region singleton
    private static ShipMov instance;

    public static ShipMov Instance
    {
        get
        {
            return instance;
        }
    }
    #endregion

    private void Awake()
    {
        if (instance != null && instance != this) //posible bug
        {
            Destroy(instance.gameObject);
        }
        instance = this;
    }

    void Start()
    {
        state = 0;
        speed = 0.04f;
        izquierda = false;
        derecha = false;
        tr = GetComponent<Transform>();
    }

    void Update()
    {
        if(derecha)
        {
            tr.localPosition = new Vector3(tr.localPosition.x, tr.localPosition.y, tr.localPosition.z - speed);
        }
        if(izquierda)
        {
            tr.localPosition = new Vector3(tr.localPosition.x, tr.localPosition.y, tr.localPosition.z + speed);
        }


    }

    public void Derecha()
    {
        state = 1;
        izquierda = false;
        derecha = true;
    }

    public void Izquierda()
    {
        state = 2;
        izquierda = true;
        derecha = false;
    }

    public void Yano()
    {
        state = 0;
        izquierda = false;
        derecha = false;
    }
}