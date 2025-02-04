using UnityEngine;
using UnityEngine.InputSystem;
using System;
using System.Collections;

public class HideVisaulArea : MonoBehaviour
{
    [SerializeField] private GameObject VArea;
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
            VArea.SetActive(false);
        }
    }
}
