using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables;
using VRTK.Controllables.ArtificialBased;

public class ShipMov : MonoBehaviour
{
    private Animator animator;
    private Transform tr;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float currentSpeed;

    [SerializeField]
    private VRTK_ArtificialRotator vrtkRotator;

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

        animator = this.GetComponent<Animator>();
        tr = GetComponent<Transform>();
        
        ControlGame.Instance.e_startGame += TurnOnShip;
        ControlGame.Instance.e_loseGame += DestroyThis;
    }

    public void DestroyThis()
    {
        Destroy(this);
    }

    private void Update()
    {
        if(ControlGame.Instance.InGame)
        UpdateVelocity();
    }

    private void UpdateVelocity()
    {
        currentSpeed = vrtkRotator.GetStepValue(vrtkRotator.GetValue()) * speed;

        currentSpeed += currentSpeed*(0.7f+Ship.Instance.SkillControl.LevelPlayer);
        tr.localPosition = new Vector3(tr.localPosition.x, tr.localPosition.y, tr.localPosition.z + (-currentSpeed*Time.deltaTime));
        UpdateAnimator();
    }

    private void TurnOnShip()
    {
        animator.SetBool("inMov", true);
    }

    private void UpdateAnimator()
    {
        animator.SetFloat("velocity", (-vrtkRotator.GetStepValue(vrtkRotator.GetValue()) +1)/2);
    }
}