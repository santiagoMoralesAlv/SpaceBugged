using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Test : MonoBehaviour
{
    public UnityAction e_Complete;

    public void OnCompleteTest()
    {
        if (e_Complete != null)
        {
            e_Complete();
        }
    }

    public abstract void SuscribeTest();

}
