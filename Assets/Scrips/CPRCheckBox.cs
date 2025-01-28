using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class CPRCheckBox : MonoBehaviour
{
    [SerializeField] private GameObject HeartBeatChart;
    [SerializeField] private GameObject CheckBox;
    [SerializeField] private GameObject PulseCheckBox;
    [SerializeField] private GameObject WakeUpCheckBox;
    [SerializeField] private GameObject AEDSocket;
    [SerializeField] private GameObject ElectrodeRightSocket;
    [SerializeField] private GameObject ElectrodeLeftSocket;
    [SerializeField] private GameObject Bot;
    [SerializeField] private GameObject aEDLocatedUI;

    private HapticPulse Pulse = null;
    private WakeUp Wake = null;
    private Alert alert = null;
    private OnSocketStatus electrodeRightonSocket = null;
    private OnSocketStatus electrodeLeftonSocket = null;
    private OnSocketStatus aedOnSocket = null;
    private CPRController cPRController = null;
    private bool isAED = false;
    private MissionController Mission = null;
    



    private void Awake()
    {
        electrodeRightonSocket = ElectrodeRightSocket.GetComponent<OnSocketStatus>();
        electrodeLeftonSocket = ElectrodeLeftSocket.GetComponent<OnSocketStatus>();
        aedOnSocket = AEDSocket.GetComponent<OnSocketStatus>();
        Pulse = PulseCheckBox.GetComponent<HapticPulse>();
        Wake = WakeUpCheckBox.GetComponent<WakeUp>();
        alert = Bot.GetComponent<Alert>();
        cPRController = this.GetComponent<CPRController>();
        Mission = this.GetComponent<MissionController>();
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

    public bool GetAEDStatus()
    {
        return isAED;
    }

    private void ActiveCheckBox()
    {
        
        if(aedOnSocket.GetStatus() == true)
        {
            isAED = true;
            if((electrodeRightonSocket.GetStatus() == true) && 
            (electrodeLeftonSocket.GetStatus() == true))
            {
                Mission.SetAED();
                if(cPRController.GetCPRCheckboxStatus())
                {
                    alert.SetCPRActive();
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
        else 
        {
            isAED = false;
            if((HeartBeatChart.activeSelf) && 
            (Pulse.HandOutOfPosition()) && 
            (Mission.GetStatusHapticPulse()) && 
            (Mission.GetStatusWakeUp()) && 
            (Wake.HandOutOfPosition()))
            {
                alert.SetCPRActive();
                CheckBox.SetActive(true);
                AEDSocket.SetActive(false);
                aEDLocatedUI.SetActive(false);
            }
            else
            {
                CheckBox.SetActive(false);
            }
        }
    }
}
