using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorMeteoros : MonoBehaviour
{
    public GameObject[] meteoros;
    public GameObject esferaEnergia;
    [SerializeField]
    private float intervalo, generationRateMin, generationRateMax;
    [SerializeField]
    private float time;

    void Start()
    {
        intervalo = 1;
    }

    void Update()
    {
        if (ControlGame.Instance.InGame)
        {
            time += Time.deltaTime * 1;
            if (time > intervalo)
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
                intervalo = Random.Range( (1-ControlGame.Instance.Difficulty) * generationRateMin, (1 - ControlGame.Instance.Difficulty) * generationRateMax);
                time = 0;
            }
        }
    }

    void GenerarMeteoro()
    {
        int i = (Random.Range(0,3));

        Vector3 pos = new Vector3(60, Random.Range(-7f, 7f), Ship.Instance.gameObject.transform.localPosition.z + Random.Range(-40, 40));

        Instantiate(meteoros[i], pos, Quaternion.identity, gameObject.transform);
    }

    void GenerarEsfera()
    {

        Vector3 pos = new Vector3(30, Random.Range(1f, 8f), Ship.Instance.gameObject.transform.localPosition.z + Random.Range(-20, 20));

        Instantiate(esferaEnergia, pos, Quaternion.identity, gameObject.transform);
    }
}