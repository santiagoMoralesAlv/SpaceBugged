using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Test : MonoBehaviour
{
    public UnityAction e_Complete;

    private ManagerClassicTest manager;

    public ManagerClassicTest Manager { get => manager; }

    public void OnCompleteTest()
    {
        if (e_Complete != null)
        {
            e_Complete();
        }
    }

}
