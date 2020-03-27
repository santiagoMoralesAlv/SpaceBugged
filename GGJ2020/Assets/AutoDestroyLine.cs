using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyLine : MonoBehaviour
{
    private LineRenderer line;
    [SerializeField]
    private float velocity;

    [SerializeField]
    private bool inDestroy;

    // Start is called before the first frame update
    void Start()
    {
        line = this.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inDestroy)
        {
            line.SetPosition(0, Vector3.Lerp(line.GetPosition(0), line.GetPosition(1), velocity));
        } 
    }
}
