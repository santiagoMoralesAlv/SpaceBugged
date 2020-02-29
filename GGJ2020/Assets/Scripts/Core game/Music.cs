using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    #region singleton
    private static Music instance;

    public static Music Instance
    {
        get
        {
            return instance;
        }
    }
    #endregion
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip[] songs;
    
    private void Awake()
    {
        if (instance != null && instance != this) //posible bug
        {
            Destroy(this.gameObject);
            instance.UpdateScene();
        }
        else {
            instance = this;
        }

        DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();
    }

    public void StartMenu()
    {
        if (audioSource.clip != songs[0])
        {
            audioSource.clip = songs[0];
            audioSource.Play();
        }
    }

    public void StartGame()
    {
        if (audioSource.clip != songs[1])
        {
            audioSource.clip = songs[1];
            audioSource.Play();
        }
    }

    public void EnterDanger()
    {
        audioSource.volume = 0.2f;
    }

    public void ExitDanger()
    {
        audioSource.volume = 0.5f;
    }

    public void LoseGame()
    {
        if (audioSource.clip != songs[2])
        {
            audioSource.clip = songs[2];
            audioSource.Play();
        }
    }

    // Update is called once per frame
    public void UpdateScene()
    {
        if (ControlGame.Instance != null)
        {
            ControlGame.Instance.e_startGame += StartGame;
            ControlGame.Instance.e_enterDangerZone += EnterDanger;
            ControlGame.Instance.e_exitDangerZone += ExitDanger;
            ControlGame.Instance.e_loseGame += LoseGame;
        }
        else {
            StartMenu();
        }
    }
}
