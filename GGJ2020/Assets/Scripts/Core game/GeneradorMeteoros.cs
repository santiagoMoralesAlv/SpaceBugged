using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorMeteoros : MonoBehaviour
{
    public GameObject[] meteoros;
    public GameObject esferaEnergia;
    [SerializeField]
    private float intervalo, generationRate;
    [SerializeField]
    private float time;

    void Start()
    {
        intervalo = 1;
    }

    void Update()
    {
        time += Time.deltaTime*1;
        if (ControlGame.Instance.InGame)
        {
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
                intervalo = Random.Range( (1-(ControlGame.Instance.Difficulty/(1+ ControlGame.Instance.Difficulty))) * -generationRate, (1-(ControlGame.Instance.Difficulty / (1 + ControlGame.Instance.Difficulty))) *-generationRate);
                time = 0;
            }
        }
    }

    void GenerarMeteoro()
    {
        int i = (int)Mathf.Floor(Random.Range(0,1.9f));

        Vector3 pos = new Vector3(30, Random.Range(1f, 3f), Ship.Instance.gameObject.transform.localPosition.z + Random.Range(-20, 20));

        Instantiate(meteoros[i], pos, Quaternion.identity, gameObject.transform);
    }

    void GenerarEsfera()
    {

        Vector3 pos = new Vector3(30, Random.Range(1f, 8f), Ship.Instance.gameObject.transform.localPosition.z + Random.Range(-20, 20));

        Instantiate(esferaEnergia, pos, Quaternion.identity, gameObject.transform);
    }
}