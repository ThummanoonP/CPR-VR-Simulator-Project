using UnityEngine;
using UnityEngine.InputSystem;
using System;
using System.Collections;

public class PushAEDButtonTutorial : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject Manager;
    // Start is called before the first frame update
    private CPRControllerTutorial cPRController = null;
    private void Awake()
    {
        cPRController = Manager.GetComponent<CPRControllerTutorial>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.name == "Right Controller"))
        {
            Debug.Log("Right Hit");
            cPRController.OpenAED();
        }
        else if ((other.gameObject.name == "Left Controller"))
        {
            Debug.Log("Left Hit");
            cPRController.OpenAED();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Right Controller")
        {

        }
        else if (other.gameObject.name == "Left Controller")
        {

        }
    }
}
