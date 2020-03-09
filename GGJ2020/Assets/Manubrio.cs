using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manubrio : MonoBehaviour
{
    private Animator animator;

    [SerializeField]
    private Transform tf;

    [SerializeField]
    private float distance;

    private bool showing;

    private void Awake()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (showing)
        {
            if (Vector3.Distance(HeadsetReference.Instance.HeadsetTf.position, tf.position) > distance)
            {
                showing = !showing;
                UpdateAnimator();
            }
        }
        else {
            if (Vector3.Distance(HeadsetReference.Instance.HeadsetTf.position, tf.position) < distance)
            {
                showing = !showing;
                UpdateAnimator();
            }
        }
    }

    private void UpdateAnimator() {
        animator.SetBool("Show", showing);
    }
}
