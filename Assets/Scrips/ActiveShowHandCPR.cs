using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class ActiveShowHandCPR : MonoBehaviour
{
    [SerializeField] InputActionReference LeftGrip;
    [SerializeField] InputActionReference RightGrip;
    [SerializeField] private GameObject CPR;

    bool L_Clash = true;
    bool R_Clash = true;
   
    private void Awake()
    {
        LeftGrip.action.performed += GripPress;
        RightGrip.action.performed += GripPress;
        LeftGrip.action.canceled += GripCancle;
        RightGrip.action.canceled += GripCancle;

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Right Controller")
        {
            R_Clash = false;
        }
        else if (other.gameObject.name == "Left Controller")
        {
            L_Clash = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Right Controller")
        {
            R_Clash = true;
        }
        else if (other.gameObject.name == "Left Controller")
        {
            L_Clash = true;
        }
        if ((R_Clash == true) || (L_Clash == true))
        {
            CPR.SetActive(false);
        }
    }


    private void GripPress(InputAction.CallbackContext obj)
    {
        if ((R_Clash == false) && (L_Clash == false))
        {
            CPR.SetActive(true);
        }
        else
        {
            CPR.SetActive(false);
        }
    }

    private void GripCancle(InputAction.CallbackContext obj)
    {
        CPR.SetActive(false);
    }
}