using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum platform {
    PC,
    HTC,
    OculusQuest
}

public class HeadsetReference : MonoBehaviour
{
    [SerializeField]
    private Transform[] headsetTf;

    [SerializeField]
    private platform typePlatform;

    public Transform HeadsetTf { get => headsetTf[(int)typePlatform];}

    #region singleton
    private static HeadsetReference instance;

    public static HeadsetReference Instance
    {
        get
        {
            return instance;
        }
    }
    #endregion

    void Awake()
    {
        if (instance != null && instance != this) //posible bug
        {
            Destroy(instance.gameObject);
        }
        instance = this;
    }

}
