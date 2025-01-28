using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionController : MonoBehaviour
{
    [SerializeField] public GameObject FinishMenu;
    [SerializeField] public GameObject Bot;
    private Brian BrianStatus = null;
    private CharacterHeartRate heartRate = null;
    private bool EmergencyCallCheck = false;
    private bool ClearAreaCheck  = false;
    private bool HapticPulseCheck = false;
    private bool WakeUpCheck = false;
    private bool AEDSettingCheck = false;
    private bool CPRPumpCheck = false;
    private bool AEDChargeCheck = false;
    private bool isFinish = false;
    private bool rise = false;
    private int PlayerScore = 0;
    private int hit = 0;
    private int criticalHit = 0;
    private int normalHit = 0;


    void Awake()
    {
        BrianStatus = Bot.GetComponent<Brian>();
        heartRate = Bot.GetComponent<CharacterHeartRate>();
    }

    void Update()
    {
        
    }
    private void CalculateScore()
    {
        if(EmergencyCallCheck == true){PlayerScore += 500;}
        if(ClearAreaCheck == true){PlayerScore += 500;}
        if(HapticPulseCheck == true){PlayerScore += 500;}
        if(WakeUpCheck == true){PlayerScore += 500;}
        if(AEDSettingCheck == true){PlayerScore += 2000;}
        if(CPRPumpCheck == true){PlayerScore += 1000;}
        if(heartRate.HeartRateIsBack() == true){IsRise();}
    }
    public void CallEmergency()
    {
        EmergencyCallCheck = true; 
    }
    public void ClearArea()
    {
        ClearAreaCheck = true;
    }
    public void CheckHapticPulse()
    {
        HapticPulseCheck = true;
    }
    public void CheakWakeUp()
    {
        WakeUpCheck = true;
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
        CalculateScore();
        isFinish = true;
        FinishMenu.SetActive(true);
    }
    public void Hit(bool Cri)
    {
        hit +=1;
        if(Cri == true)
        {
            criticalHit += 1;
            PlayerScore += 5;
        }
        else if (Cri == false)
        {
            normalHit +=1;
            PlayerScore += 1;
        }
    }
    public void IsRise()
    {
        rise = true;
        PlayerScore += 1000;
        BrianStatus.Rise();
    }

    public bool GetStatusCallEmergency()
    {
        return EmergencyCallCheck ; 
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
    public bool GetFinish()
    {
       return isFinish;
    }
    public bool GetRise()
    {
       return rise;
    }
    public int GetScore()
    {
        return PlayerScore;
    }
    public int GetHit()
    {
        return hit;
    }
    public int GetCriticalHit()
    {
        return criticalHit;
    }
}
