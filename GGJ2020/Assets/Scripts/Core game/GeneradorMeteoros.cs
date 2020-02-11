using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorMeteoros : MonoBehaviour
{
    public GameObject[] meteoros;
    public GameObject esferaEnergia;
    [SerializeField]
    private float intervalo;
    private float lastTime;

    void Start()
    {
        intervalo = Random.Range((ControlGame.Instance.Difficulty) *-3, (ControlGame.Instance.Difficulty) *3);
        lastTime = Time.time;
    }

    void Update()
    {
        if (ControlGame.Instance.InGame)
        {
            if (Time.time - lastTime > intervalo)
            {
                int i = Random.Range(0, 10);

                if(i < 9)
                {
                    GenerarMeteoro();
                }
                else
                {
                    GenerarEsfera();
                }
                lastTime = Time.time;
                intervalo = Random.Range((ControlGame.Instance.Difficulty) * -3, (ControlGame.Instance.Difficulty) * 3);

            }
        }
    }

    void GenerarMeteoro()
    {
        int i = (int)Mathf.Floor(Random.Range(0,1.9f));

        Vector3 pos = new Vector3(30, Random.Range(1f, 8f), Ship.Instance.gameObject.transform.localPosition.z + Random.Range(-20, 20));

        Instantiate(meteoros[i], pos, Quaternion.identity, gameObject.transform);
    }

    void GenerarEsfera()
    {

        Vector3 pos = new Vector3(30, Random.Range(1f, 8f), Ship.Instance.gameObject.transform.localPosition.z + Random.Range(-20, 20));

        Instantiate(esferaEnergia, pos, Quaternion.identity, gameObject.transform);
    }
}