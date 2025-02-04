using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class CPRCheckBoxTutorial : MonoBehaviour
{
    [SerializeField] private GameObject CheckBox;
    [SerializeField] private GameObject AEDSocket;
    [SerializeField] private GameObject ElectrodeRightSocket;
    [SerializeField] private GameObject ElectrodeLeftSocket;

    private OnSocketStatus electrodeRightonSocket = null;
    private OnSocketStatus electrodeLeftonSocket = null;
    private OnSocketStatus aedOnSocket = null;
    private CPRControllerTutorial cPRController = null;
    private MissionControllerTutorial Mission = null;
    



    private void Awake()
    {
        electrodeRightonSocket = ElectrodeRightSocket.GetComponent<OnSocketStatus>();
        electrodeLeftonSocket = ElectrodeLeftSocket.GetComponent<OnSocketStatus>();
        aedOnSocket = AEDSocket.GetComponent<OnSocketStatus>();

        cPRController = this.GetComponent<CPRControllerTutorial>();
        Mission = this.GetComponent<MissionControllerTutorial>();
    }
    private void Start()
    {
        ActiveCheckBox();
    }

    private void Update()
    {
        if(Mission.GetFinish() == false)
        {
            ActiveCheckBox();
        }
        else if (Mission.GetFinish() == true)
        {
            CheckBox.SetActive(false);
        }
    }

    private void ActiveCheckBox()
    {
        
        if(aedOnSocket.GetStatus() == true)
        {
            if((electrodeRightonSocket.GetStatus() == true) && 
            (electrodeLeftonSocket.GetStatus() == true))
            {
                Mission.SetAED();
                if(cPRController.GetCPRCheckboxStatus())
                {
                    CheckBox.SetActive(true);
                }
                else
                {
                    CheckBox.SetActive(false);
                }
                
            }
            else
            {
                CheckBox.SetActive(false);
            }
        }
        
    }
}
