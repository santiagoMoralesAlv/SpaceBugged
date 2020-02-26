using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ShipMov : MonoBehaviour
{
    private Transform tr;
    [SerializeField]
    private bool izquierda, derecha;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float currentSpeed;

    [SerializeField]
    private VRTK_InteractUse vrtkLeftButton, vrtkRightButton;

    #region singleton
    private static ShipMov instance;

    public static ShipMov Instance
    {
        get
        {
            return instance;
        }
    }
    #endregion

    private void Awake()
    {
        if (instance != null && instance != this) //posible bug
        {
            Destroy(instance.gameObject);
        }
        instance = this;

        vrtkLeftButton.ControllerUseInteractableObject += UseButton;
        vrtkLeftButton.ControllerUnuseInteractableObject += UnUseButton;
        vrtkRightButton.ControllerUseInteractableObject += UseButton;
        vrtkRightButton.ControllerUnuseInteractableObject += UnUseButton;
    }

    void Start()
    {
        izquierda = false;
        derecha = false;
        tr = GetComponent<Transform>();
    }

    private void UseButton(object sender, ObjectInteractEventArgs t_Use){
        if (t_Use.target.gameObject.CompareTag("MovLeftButton"))
        {
            izquierda = true;
        }
        if (t_Use.target.gameObject.CompareTag("MovRightButton"))
        {
            derecha = true;
        }
    }
    private void UnUseButton(object sender, ObjectInteractEventArgs t_Use)
    {
        if (t_Use.target.gameObject.CompareTag("MovLeftButton"))
        {
            izquierda = false;
        }
        if (t_Use.target.gameObject.CompareTag("MovRightButton"))
        {
            derecha = false;
        }
    }

    void Update()
    {
        currentSpeed = 0;
        if (izquierda)
            currentSpeed = -speed;
        if (derecha)
            currentSpeed += speed;

        currentSpeed += currentSpeed*(0.7f+Ship.Instance.SkillControl.LevelPlayer);
        tr.localPosition = new Vector3(tr.localPosition.x, tr.localPosition.y, tr.localPosition.z + (currentSpeed*Time.deltaTime));
    }
}