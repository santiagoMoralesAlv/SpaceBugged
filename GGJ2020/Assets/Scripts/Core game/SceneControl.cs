using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    #region singleton
    private static SceneControl instance;

    public static SceneControl Instance
    {
        get
        {
            return instance;
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
    }

    public void StartTutorial(int i)
    {
        switch (i)
        {
            case 0: //movimiento de nave y mecanicas de juego generales 
                SceneManager.LoadScene("tut_BasicRules");
                break;
            case 1: // Herramientas y Gravedad invertida
                SceneManager.LoadScene("tut_Tools");
                break;
            case 2: //skills basicas
                SceneManager.LoadScene("tut_Skills");
                break;
            case 3: // Martillo
                SceneManager.LoadScene("tut_Martillo");
                break;
            case 4: // Termofanton
                SceneManager.LoadScene("tut_Termofanton");
                break;
            case 5: // Cautin
                SceneManager.LoadScene("tut_Cautin");
                break;
            case 6: // Limpiavidrios
                SceneManager.LoadScene("tut_Limpiavidrios");
                break;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void StartMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
