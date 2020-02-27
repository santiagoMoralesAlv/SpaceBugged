using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using VRTK;

public class Table : MonoBehaviour
{
    #region singleton
    private static Table instance;

    public static Table Instance
    {
        get
        {
            return instance;
        }
    }
    #endregion
    

    public UnityAction e_blueButton, e_redButton;

    private bool scenePlay;

    [SerializeField]
    private bool inSurvivor;
    
    [SerializeField]
    private VRTK_InteractUse vrtkTouchIzq, vrtkTouchDer;

    private void Awake()
    {
        if (instance != null) //posible bug
        {
            Destroy(instance.gameObject);
        }
        instance = this;

        vrtkTouchIzq.ControllerStartUseInteractableObject += Interaction;
        vrtkTouchDer.ControllerStartUseInteractableObject += Interaction;
    }

    private void Interaction(object sender, ObjectInteractEventArgs t_Use)
    {
        if (t_Use.target.CompareTag("blueButton"))
        {
            if (e_blueButton != null)
            {
                e_blueButton();
            }           
        }else if (t_Use.target.CompareTag("redButton"))
        {
            if (e_redButton != null)
            {
                e_redButton();
            }
        }
    }

    
}
