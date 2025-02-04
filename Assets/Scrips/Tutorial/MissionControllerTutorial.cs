using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionControllerTutorial : MonoBehaviour
{
    [SerializeField] public GameObject FinishMenu; 
    [SerializeField] public GameObject WakeUpCheckBox;
    [SerializeField] public GameObject PulseCheckBox;
    [SerializeField] public GameObject InteracItem;


    private bool EmergencyCallCheck = false;
    private bool ClearAreaCheck  = false;
    private bool HapticPulseCheck = false;
    private bool WakeUpCheck = false;
    private bool AEDSettingCheck = false;
    private bool CPRPumpCheck = false;
    private bool AEDChargeCheck = false;
    private bool finish = false;
    private InvincibleHandTutorial invinHand= null;
    private WakeUpTutorial wakeUp = null;

    private void Awake()
    {
        invinHand = this.GetComponent<InvincibleHandTutorial>();
        wakeUp = WakeUpCheckBox.GetComponent<WakeUpTutorial>();
    }

    public void PulseOn()
    {
        PulseCheckBox.SetActive(true);
    }
    public void PulseOff()
    {
        PulseCheckBox.SetActive(false);
        invinHand.ShowHand();
    }
    public void WakeUpOn()
    {
        WakeUpCheckBox.SetActive(true);
    }
    public void WakeUpOff()
    {   
        wakeUp.Reset();
        WakeUpCheckBox.SetActive(false);
        invinHand.ShowHand();
    }
    public void ItemOn()
    {
        InteracItem.SetActive(true);
    }


    public void ClearArea()
    {
        ClearAreaCheck = true;
    }
    public void CallEmergency()
    {
        EmergencyCallCheck = true; 
        WakeUpOn();
    }
    public void CheckHapticPulse()
    {
        HapticPulseCheck = true;
        Invoke("ItemOn", 8.0f);
        Invoke("PulseOff", 8.0f);
    }
    public void CheakWakeUp()
    {
        WakeUpCheck = true;
        Invoke("PulseOn", 8.0f);
        Invoke("WakeUpOff", 8.0f);
    }
    public void SetAED()
    {
        AEDSettingCheck = true;
    }
    public void CPRCheck()
    {
        CPRPumpCheck = true;
    }
    public void AEDCharge()
    {
        AEDChargeCheck = true; 
    }

    public void IsFinish()
    {
        finish = true;
        FinishMenu.SetActive(true);
    }


    public bool GetFinish()
    {
        return finish; 
    }
    public bool GetStatusCallEmergency()
    {
        return EmergencyCallCheck; 
    }
    public bool GetStatusClearArea()
    {
        return ClearAreaCheck;
    }
    public bool GetStatusHapticPulse()
    {
        return HapticPulseCheck;
    }
    public bool GetStatusWakeUp()
    {
        return WakeUpCheck;
    }
    public bool GetStatusSetAED()
    {
        return AEDSettingCheck; 
    }
    public bool GetStatusCPRCheck()
    {
        return CPRPumpCheck;
    }
    public bool GetStatusAEDCharge()
    {
        return AEDChargeCheck;
    }
}
