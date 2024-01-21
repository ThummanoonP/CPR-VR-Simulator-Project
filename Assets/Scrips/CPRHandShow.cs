using UnityEngine;
using UnityEngine.InputSystem;
using System;
using System.Collections;

public class CPRHandShow : MonoBehaviour
{
    [SerializeField] private GameObject CPR;
    bool L_Clash = true;
    bool R_Clash = true;



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

        if ((R_Clash == false) && (L_Clash == false))
        {
            CPR.SetActive(true);
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
}
