using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    private float sicknessLevel;
    private float timeToJump, time;
    private bool withTool;
    private GameObject tool;
    private float cooldownToTakeTools;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TakeTool() {

    }

    private void OnCollisionEnter(Collision collision)
    {
        string tag = collision.gameObject.tag;
        switch (tag) {
            case "":
                break;
            default:

                break;
        }
    }

}
