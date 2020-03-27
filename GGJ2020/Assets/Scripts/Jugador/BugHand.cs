using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class BugHand : MonoBehaviour
{
    [SerializeField]
    private bool isRightController;

    private Tool tool;
    private bool inGrab, tryingGrab;
    private Transform tf;

    [SerializeField]
    private VRTK_ControllerEvents controller;

    [SerializeField]
    private VRTK_InteractGrab vrtkGrab;
    [SerializeField]
    private VRTK_InteractUse vrtkUse;
    [SerializeField]
    private VRTK_Pointer vrtkPointer;
    [SerializeField]
    private VRTK_InteractNearTouch vrtkNearTouch;

    
    [SerializeField]
    private Animator m_animator;
    

    private void Awake()
    {
        tf = this.transform;

        vrtkGrab.ControllerGrabInteractableObject += GrabTool;
        vrtkGrab.ControllerUngrabInteractableObject += ReleaseTool;

        vrtkUse.ControllerUseInteractableObject += UseTool;
        vrtkUse.ControllerUnuseInteractableObject += UnUseTool;

        vrtkUse.ControllerUseInteractableObject += UseTool;
        vrtkUse.ControllerUnuseInteractableObject += UnUseTool;

        vrtkNearTouch.ControllerNearTouchInteractableObject += NearTouch;
        vrtkNearTouch.ControllerNearUntouchInteractableObject += NearUnTouch;

        //Se prepara para actualizar el animator cuando se termina de cargar el SDK
        VRTK_SDKManager.instance.FinishedLoadSDK += UpdateAnimatorReference;
        
        /*
         Pendiente el uso del pointer para el hub 
        vrtkPointer. += UseTool;
        vrtkPointer. += UnUseTool;*/

    }

    private void BuildController()
    {
        m_animator.SetBool("built", true);
    }

    private void UpdateAnimatorReference()
    {
        if (!isRightController)
        {
            m_animator = VRReferences.Instance.LeftController.GetComponent<Animator>();
        }
        else
        {
            m_animator = VRReferences.Instance.RightController.GetComponent<Animator>();
        }
        BuildController();
    }

    private void GrabTool(object sender, ObjectInteractEventArgs t_grab)
    {
        if (t_grab.target.gameObject.CompareTag("Herramienta"))
        {
            tool = t_grab.target.GetComponent<Tool>();
            tool.TakeTool(this.transform);
            inGrab = true;

        }

        if(m_animator!=null)
        m_animator.SetBool("inGrab", true);
    }
    private void ReleaseTool(object sender, ObjectInteractEventArgs t_grab)
    {
        if (t_grab.target.gameObject.CompareTag("Herramienta"))
        {
            tool.DropTool();
            inGrab = false;

        }

        if (m_animator != null)
            m_animator.SetBool("inGrab", false);
    }

    private void UseTool(object sender, ObjectInteractEventArgs t_Use)
    {
        if(t_Use.target.GetComponent<Tool>() != null && t_Use.target.GetComponent<Tool>() == tool)
        {
            if (tool != null)
            {
                if (tool is ActiveTool)
                {
                    (tool as ActiveTool).Use();
                }
            }
        }


        if (m_animator != null)
        {
            if (!isCoroutineRunning)
            {
                isCoroutineRunning = true;
                StartCoroutine("UpdateUseAnimation");
            }
        }
    }
    private void UnUseTool(object sender, ObjectInteractEventArgs t_Use)
    {
        if (tool != null)
        {
            if (tool is ActiveTool)
            {
                (tool as ActiveTool).UnUse();
            }
        }


        if (m_animator != null){
            if (!isCoroutineRunning)
            {
                isCoroutineRunning = true;
                StartCoroutine("UpdateUseAnimation");
            }
        }
    }
    
    protected bool isCoroutineRunning;
    private IEnumerator UpdateUseAnimation()
    {
        //La animacion de la corutina parpadea porque se esta reparando todo el tiempo, entonces la corutina funciona en ambas direcciones todo el tiempo
        if (m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= controller.GetTriggerSenseAxis())
        {
            m_animator.SetFloat("speedMult", 1);
            while (m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= controller.GetTriggerSenseAxis())
            {
                yield return null;
            }
        }
        else
        {
            m_animator.SetFloat("speedMult", -1);
            while (m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime > controller.GetTriggerSenseAxis())
            {
                yield return null;
            }
        }

        m_animator.Play("Use", 2, controller.GetTriggerSenseAxis());
        m_animator.SetFloat("speedMult", 0);
        isCoroutineRunning = false;
    }

    private void NearTouch(object sender, ObjectInteractEventArgs t_Use)
    {
        if (t_Use.target.CompareTag("Test"))
        {
            t_Use.target.GetComponent<Test>().Show(true);
        }
    }
    private void NearUnTouch(object sender, ObjectInteractEventArgs t_Use)
    {
        if (t_Use.target.CompareTag("Test"))
        {
            t_Use.target.GetComponent<Test>().Show(false);
        }
    }

    public void UpdateDiscState(bool status)
    {
        m_animator.SetBool("inShowingDisc", status);
    }
}
