using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public enum platform {
    PC,
    HTC,
    OculusQuest
}

public class VRReferences : MonoBehaviour
{
    
    [SerializeField]
    private Transform[] headsetTf;

    [SerializeField]
    private platform typePlatform;

    public Transform HeadsetTf { get  => headsetTf [(int)typePlatform]; }

    [SerializeField]
    private BugHand leftBugHand, rightBugHand;

    public GameObject LeftController { get => VRTK_SDKManager.instance.loadedSetup.modelAliasLeftController; }
    public GameObject RightController { get => VRTK_SDKManager.instance.loadedSetup.modelAliasRightController; }

    public BugHand LeftBugHand { get => leftBugHand; }
    public BugHand RightBugHand { get => rightBugHand; }

    #region singleton
    private static VRReferences instance;

    public static VRReferences Instance
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
            Destroy(this.gameObject);
        }
        instance = this;
        
        VRTK_SDKManager.instance.TryLoadSDKSetup(0, true, VRTK_SDKManager.instance.setups);
    }
}
