using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ship : MonoBehaviour
{
    public UnityAction e_UpdateParts, e_StartGame, e_GotDamage;

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

    

    #region var
    [SerializeField]
    private float motorHealth, gas, glassClarity;
    [SerializeField]
    private float[] cablesHealth;
    private bool handleIsGood;

    [SerializeField]
    private float velocity, currentVelocity, slowdown;
    
    [SerializeField]
    private Transform goHerramientas;

    [SerializeField]
    private SkillControl skillControl;
    #endregion

    #region properties
    public SkillControl SkillControl
    {
        get
        {
            return skillControl;
        }
    }

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
    #endregion


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

        e_UpdateParts();
    }

    public void ApplyRandomDamage() {

        int i = (int)Random.Range(0, 3);
        switch (i) {
            case 0:
                ApplyMotorDamage( (ControlGame.Instance.Difficulty*0.8f) );
                break;
            case 1:
                ApplyCableDamage((ControlGame.Instance.Difficulty * 0.8f));
                break;
            case 2:
                ApplyGlassDamage((ControlGame.Instance.Difficulty * 0.8f));
                break;
        }

        e_UpdateParts();
        if (e_GotDamage != null)
        {
            e_GotDamage();
        }
    }

    public void ApplySlowdown (float value){
        slowdown += value;
        if (e_GotDamage != null)
        {
            e_GotDamage();
        }
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
    private void ApplyGasDamage()
    {
        gas -= Time.deltaTime * (0.01f * ControlGame.Instance.Difficulty);
        Mathf.Clamp(gas,0f,1f);
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

            ApplyGasDamage();
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
