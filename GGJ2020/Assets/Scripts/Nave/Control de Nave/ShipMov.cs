using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables;
using VRTK.Controllables.ArtificialBased;

public class ShipMov : MonoBehaviour
{
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


        vrtkRotator.ValueChanged += UpdateVelocity;

        ControlGame.Instance.e_loseGame += DestroyThis;
    }

    void Start()
    {
        tr = GetComponent<Transform>();
    }

    public void DestroyThis()
    {
        Destroy(this);
    }

    private void UpdateVelocity(object sender, ControllableEventArgs e)
    {
        vrtkRotator.GetValue();
        currentSpeed = vrtkRotator.GetValue()*speed;

        currentSpeed += currentSpeed*(0.7f+Ship.Instance.SkillControl.LevelPlayer);
        tr.localPosition = new Vector3(tr.localPosition.x, tr.localPosition.y, tr.localPosition.z + (-currentSpeed*Time.deltaTime));
    }
}