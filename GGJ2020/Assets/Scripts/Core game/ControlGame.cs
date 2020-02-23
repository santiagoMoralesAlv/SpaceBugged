using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using VRTK;

public class ControlGame : MonoBehaviour
{
    public UnityAction e_startGame, e_loseGame;
    public UnityAction e_enterDangerZone, e_exitDangerZone;

    #region singleton
    private static ControlGame instance;

    public static ControlGame Instance
    {
        get
        {
            return instance;
        }
    }
    #endregion


    #region variables
    [SerializeField]
    private bool inGame, inDangerZone;

    [SerializeField]
    private VRTK_InteractUse vrtkUseIzq, vrtkUseDer;

    [SerializeField]
    private float difficulty;
    [SerializeField]
    private float gameTime;


    [SerializeField]
    private float distance, distanceMin, dangerDistance;

    [SerializeField]
    private Ship m_ship;
    [SerializeField]
    private Enemy m_enemy;

    public bool InGame
    {
        get
        {
            return inGame;
        }
    }

    public float Distance
    {
        get
        {
            return distance;
        }
    }

    public float Difficulty
    {
        get
        {
            return difficulty;
        }
    }
    #endregion


    void Awake()
    {
        if (instance != null) //posible bug
        {
            Destroy(instance.gameObject);
        }

        instance = this;

        e_loseGame += LoseGame;
        UpdateDifficulty();


        vrtkUseIzq.ControllerUseInteractableObject += StartGame;
        vrtkUseDer.ControllerUseInteractableObject += StartGame;
    }

    private void Start()
    {
        UpdateDistance();
    }

    public void StartGame(object sender, ObjectInteractEventArgs t_Use)
    {
        if (inGame == false)
        {
            if (t_Use.target.gameObject.CompareTag("StartButton"))
            {
                inGame = true;
            gameTime = 0;
            if (e_startGame != null)
            {
                e_startGame();
                }
                }
        }
    }

    IEnumerator ResetLevel()
    {
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoseGame()
    {
        inGame = false;
        StartCoroutine("ResetLevel");
    }

    void Update()
    {
        if (inGame == true)
        {
            gameTime += Time.deltaTime;
            UpdateDistance();
            UpdateDifficulty();
        }
    }

    private void UpdateDifficulty()
    {
        difficulty = (gameTime / 30) + 1;
    }

    private void UpdateDistance()
    {
        CalculateDistance();

        if (CheckDistanceToLose())
        {
            //El alien llego a la nave
            e_loseGame();

        }
        else if (inDangerZone) //si esta en peligro, ya salio ? 
        {
            if (!CheckDistanceInDanger())
            {
                //Se salio de zona de peligro
                e_exitDangerZone();
            }
        }
        else
        {
            if (CheckDistanceInDanger())
            {
                //Se entro en zona de peligro
                e_enterDangerZone();
            }
        }
    }

    // Update is called once per frame
    private void CalculateDistance()
    {
        distance = ((m_ship.Velocity - m_enemy.Velocity));
    }

    private bool CheckDistanceInDanger()//comprueba si el alien esta cerca de la nave
    {
        if (distance <= dangerDistance)
        {
            return true;
        }

        return false;
    }

    private bool CheckDistanceToLose() //Comprueba si el alien llego a la nave
    {
        if (distance <= distanceMin)
        {
            return true;
        }

        return false;
    }
}
