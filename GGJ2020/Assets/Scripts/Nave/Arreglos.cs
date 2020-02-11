using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arreglos : MonoBehaviour
{
    public GameObject motor1, motor2, motor3;
    public int saludMotor;
    public int saludGasolina;
    public int saludCables1, saludCables2, saludCables3;
    public int saludVidrio;
    public int saludManubrio;

    void Start()
    {
        saludMotor = saludGasolina = saludCables1 = saludCables2 = saludCables3 = saludVidrio = saludManubrio = 0;
    }
    
    void Update()
    {

    }

    public void RepararMotor()
    {
        if (saludMotor < 10)
        {
            saludMotor++;
            if(saludMotor==5)
            {
                motor1.SetActive(false);
                motor2.SetActive(true);
            }
            else if(saludMotor==10)
            {
                motor2.SetActive(false);
                motor3.SetActive(true);
            }
        }
    }

    public void RepararGasolina()
    {
        if (saludGasolina <= 10) saludGasolina++;
    }

    public void RepararCables1()
    {
        if (saludCables1 <= 10) saludCables1++;
    }

    public void RepararCables2()
    {
        if (saludCables2 <= 10) saludCables2++;
    }

    public void RepararCables3()
    {
        if (saludCables3 <= 10) saludCables3++;
    }

    public void RepararVidrio()
    {
        if (saludVidrio <= 10) saludVidrio++;
    }

    public void RepararManubrio()
    {
        if (saludManubrio <= 10) saludManubrio++;
    }
}