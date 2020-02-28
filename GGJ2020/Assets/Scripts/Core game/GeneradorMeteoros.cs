using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorMeteoros : MonoBehaviour
{
    [SerializeField]
    public bool ignoreControlGame;
    public GameObject[] meteoros;
    public GameObject esferaEnergia;

    [Header("Time control")] [SerializeField]
    private float intervalo;
    [SerializeField]
    private float generationRateMin, generationRateMax;
    private float time;

    [Header("PositionControl")]
    [SerializeField]
    private float instantiateFrontDistance;
    [SerializeField]
    private float instantiateSideDistance, instantiateTopDistance;

    void Start()
    {
        intervalo = 1;
    }

    void Update()
    {
        if (ControlGame.Instance.InGame || ignoreControlGame)
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
        int i = (Random.Range(0,meteoros.Length));

        Vector3 pos = new Vector3(instantiateFrontDistance, Random.Range(0, instantiateTopDistance), Ship.Instance.gameObject.transform.localPosition.z + Random.Range(-instantiateSideDistance, instantiateSideDistance));

        Instantiate(meteoros[i], pos, Quaternion.identity, gameObject.transform);
    }

    void GenerarEsfera()
    {

        Vector3 pos = new Vector3(instantiateFrontDistance, Random.Range(0, instantiateTopDistance), Ship.Instance.gameObject.transform.localPosition.z + Random.Range(-instantiateSideDistance, instantiateSideDistance));

        Instantiate(esferaEnergia, pos, Quaternion.identity, gameObject.transform);
    }
}