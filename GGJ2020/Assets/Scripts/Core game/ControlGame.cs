using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

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
    private float difficulty;
    [SerializeField]
    private float gameTime, level;


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

    public float Level
    {
        get
        {
            return level;
        }
    }
    public float GameTime
    {
        get
        {
            return gameTime;
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
        UpdateLevel();

    }

    private void Start()
    {
        UpdateDistance();
    }

    public void StartGame()
    {
        if (inGame == false)
        {
            inGame = true;
            gameTime = 0;
            if (e_startGame != null)
            {
                e_startGame();
            }
        }
    }

    public void LoseGame()
    {
        inGame = false;
        StartCoroutine("ReturnToMenu");
    }

    IEnumerator ReturnToMenu()
    {
        yield return new WaitForSeconds(15f);
        SceneControl.Instance.StartMenu();
    }

    void Update()
    {
        if (inGame == true)
        {
            gameTime += Time.deltaTime;
            UpdateDistance();
            UpdateLevel();
            UpdateDifficulty();
        }
    }

    private void UpdateDifficulty()
    {
        difficulty = (level-1f)/((level-1f)+2.5f);
    }

    private void UpdateLevel()
    {
        level = (gameTime / 30f) + 1f;
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
                if (e_enterDangerZone != null)
                {
                    e_enterDangerZone();
                    Debug.Log("zona peligro");
                }

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
