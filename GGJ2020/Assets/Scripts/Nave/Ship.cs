using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ship : MonoBehaviour
{
    public UnityAction e_UpdateParts, e_StartGame;

    #region singleton
    private static Ship instance;

    public static Ship Instance
    {
        get
        {
            return instance;
        }
    }
    #endregion

    [SerializeField]
    private float motorHealth, gas, glassClarity;
    [SerializeField]
    private float[] cablesHealth;
    private bool handleIsGood;

    [SerializeField]
    private float velocity, currentVelocity, slowdown;
    
    [SerializeField]
    private Transform goHerramientas;

    public float MotorHealth
    {
        get
        {
            return motorHealth;
        }
    }

    public float Gas
    {
        get
        {
            return gas;
        }
    }

    public float[] CablesHealth
    {
        get
        {
            return cablesHealth;
        }
    }

    public float GlassClarity
    {
        get
        {
            return glassClarity;
        }
    }

    public bool HandleIsGood
    {
        get
        {
            return handleIsGood;
        }

    }

    public float Velocity
    {
        get
        {
            return currentVelocity;
        }
    }

    public Transform GoHerramientas { get => goHerramientas;  }

    void Awake()
    {
        if (instance != null && instance != this) //posible bug
        {
            Destroy(instance.gameObject);
        }
        instance = this;
        UpdateVelocity();
    }

    private void Start()
    {

        //e_UpdateParts();
    }

    public void ApplyRandomDamage() {
        ApplySlowdown();

        int i = (int)Random.Range(0, 3);
        switch (i) {
            case 0:
                ApplyMotorDamage( (ControlGame.Instance.Difficulty-1) );
                break;
            case 1:

                ApplyCableDamage((ControlGame.Instance.Difficulty - 1));
                break;
            case 2:
                ApplyGlassDamage((ControlGame.Instance.Difficulty - 1));
                break;
            case 3:
                ApplyHandleDamage();
                break;
        }

        e_UpdateParts();
    }

    private void ApplySlowdown (){
        slowdown += 1;
    }

    private void ApplyMotorDamage(float t_Damage) {

        motorHealth -= t_Damage;
        if (motorHealth < 0)
        {
            motorHealth = 0;
        }
    }
    private void ApplyCableDamage(float t_Damage)
    {
        int i = (int)Random.Range(0, 2.9f);
        cablesHealth[i] -= t_Damage;
        if (cablesHealth[i] < 0) {
            cablesHealth[i] = 0;
        }
    }
    private void ApplyGlassDamage(float t_Damage)
    {
        glassClarity -= t_Damage;
        if (glassClarity < 0) {
            glassClarity = 0;
        }
    }
    private void ApplyHandleDamage()
    {
        handleIsGood = false;
    }

    public void ApplyMotorHeal(float t_value)
    {

        motorHealth += t_value;
        if (motorHealth > 1)
        {
            motorHealth = 1;
        }
        e_UpdateParts();
    }
    public void ApplyCableHeal(int t_pos, float t_value)
    {
        cablesHealth[t_pos] += t_value;
        if (cablesHealth[t_pos] > 1)
        {
            cablesHealth[t_pos] = 1;
        }
        e_UpdateParts();
    }
    public void ApplyGasHeal(float t_value)
    {
        gas += t_value;
        if (gas > 1)
        {
            gas = 1;
        }
        e_UpdateParts();
    }
    public void ApplyGlassHeal(float t_value)
    {
        glassClarity += t_value;
        if (glassClarity > 1)
        {
            glassClarity = 1;
        }
        e_UpdateParts();
    }
    public void ApplyHandleHeal()
    {
        handleIsGood = true;
        e_UpdateParts();
    }

    void Update()
    {
        if (ControlGame.Instance.InGame)
        {
            UpdateVelocity();

            gas -= Time.deltaTime*0.01f;
        }
    }

    public void UpdateVelocity()
    {
        currentVelocity = velocity - (slowdown*0.05f) - ((1-gas)*0.1f)- ((1 - cablesHealth[0]) * 0.5f) - ((1 - cablesHealth[1]) * 0.5f) - ((1 - cablesHealth[2]) * 0.5f) - ((1-motorHealth)*0.1f);

        if (slowdown > 0)
        {
            slowdown -= Time.deltaTime;
        }
        else {
            slowdown = 0;
        }
    }

    

}
