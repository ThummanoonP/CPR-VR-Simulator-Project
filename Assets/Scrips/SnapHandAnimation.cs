using UnityEngine.InputSystem;
using UnityEngine;
using System;

public class SnapHandAnimation : MonoBehaviour
{
    [SerializeField] private Animator handAnimator;
    [SerializeField] private InputActionReference triggerActionRef;
    [SerializeField] private InputActionReference gripActionRef;
    [SerializeField] private GameObject Phone;
    [SerializeField] private GameObject HandMenu;
    [SerializeField] private GameObject StartUI;
    [SerializeField] private GameObject Manager;

    private static readonly int TriggerAnimation = Animator.StringToHash("Trigger");
    private static readonly int GripAnimation = Animator.StringToHash("Grip");
    private MissionUI missionUI = null;

    void Awake()
    {
        missionUI = Manager.GetComponent<MissionUI>();
    }

    private void OnEnable()
    {
        triggerActionRef.action.performed += TriggerAction_performed;
        triggerActionRef.action.canceled += TriggerAction_canceled;

        gripActionRef.action.performed += GripAction_performed;
        gripActionRef.action.canceled += GripAction_canceled;

    }

    private void TriggerAction_performed(InputAction.CallbackContext obj)
    { 
        handAnimator.SetFloat(TriggerAnimation, 1);
        if (this.name == "Left Hand Model")
        {
            Phone.SetActive(true);
        }
        else if (this.name == "Right Hand Model")
        {
            HandMenu.SetActive(true);
            StartUI.SetActive(false);
        }
    } 


    private void TriggerAction_canceled(InputAction.CallbackContext obj)
    {
        handAnimator.SetFloat(TriggerAnimation, 0);
        if (this.name == "Left Hand Model")
        {
            Phone.SetActive(false);
        }
        else if (this.name == "Right Hand Model")
        {
            HandMenu.SetActive(false);
            missionUI.PickUpFirst();
        }
    }


    private void GripAction_performed(InputAction.CallbackContext obj) => handAnimator.SetFloat(GripAnimation, 1);

    private void GripAction_canceled(InputAction.CallbackContext obj) => handAnimator.SetFloat(GripAnimation, 0);


    private void OnDisable()
    {
        triggerActionRef.action.performed -= TriggerAction_performed;
        triggerActionRef.action.canceled -= TriggerAction_canceled;

        gripActionRef.action.performed -= GripAction_performed;
        gripActionRef.action.canceled -= GripAction_canceled;
    }

}