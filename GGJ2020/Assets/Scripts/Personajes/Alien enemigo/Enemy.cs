using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region singleton
    private static Enemy instance;

    public static Enemy Instance
    {
        get
        {
            return instance;
        }
    }
    #endregion

    [SerializeField]
    private float multDistance=1;

    [SerializeField]
    private float velocity, currentVelocity;

    [SerializeField]
    private GameObject Abducion;

    [SerializeField]
    private bool inHunt;

    public float Velocity
    {
        get
        {
            return currentVelocity;
        }
    }
    
    void Awake()
    {
        if (instance != null && instance != this) //posible bug
        {
            Destroy(instance.gameObject);
        }
        instance = this;
        UpdateVelocity();
        ControlGame.Instance.e_loseGame += Abducir;
    }

    void Update() {
        if (ControlGame.Instance.InGame && inHunt)
        {
            UpdateVelocity();
            UpdateDistance();
        }
    }

    public void UpdateVelocity() {
        currentVelocity = velocity+(ControlGame.Instance.Difficulty/(1f+ ControlGame.Instance.Difficulty));
    }

    public void UpdateDistance() {
        this.transform.position = new Vector3(Mathf.Lerp(this.transform.position.x, - ControlGame.Instance.Distance * multDistance, 0.2f), this.transform.position.y, Mathf.Lerp( this.transform.position.z, Ship.Instance.transform.position.z, 0.2f) );
    }

    public void Abducir() {
        inHunt = false;
        this.transform.position = new Vector3(Ship.Instance.gameObject.transform.position.x, 4, Ship.Instance.gameObject.transform.position.z);
        Abducion.SetActive(true);
    }
}
