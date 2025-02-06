using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CPRControllerTutorial : MonoBehaviour
{
    [SerializeField] private GameObject CPRText;
    [SerializeField] private GameObject timeCountDownUI;
    [SerializeField] private GameObject AEDChargeText;
    [SerializeField] private GameObject timeCountDown;
    [SerializeField] private GameObject pushUI;
    [SerializeField] private TextMeshProUGUI timeCounter;
    [SerializeField] private GameObject aED;
    [SerializeField] private GameObject aEDNoti;
    [SerializeField] private GameObject aEDNotiDoNot;
    [SerializeField] private GameObject aEDNotiPush;
    private bool aEDCharge = false;
    private bool isPump = false;
    private bool isFirstPump = true;
    private bool isFirstChage = true;
    private float aEDChargerTime = 30.0F;
    private float aEDChargerCounter = 0;
    private float pumpTime = 120.0F;
    private float TotalPumpTime = 240.0F;
    private float pumpCounter = 0;
    private float finishTime = 0;
    private bool aEDButtonStatus = false;
    private bool cPRCheckboxStatus = true;
    private bool finish = false;
    private bool wait = false;
    private int minutes = 0;
    private int seconds = 0;
    private MissionControllerTutorial Mission = null;
    private AudioSource aEDSound = null;
    

    
    // Start is called before the first frame update
    void Awake()
    {
        Mission = this.GetComponent<MissionControllerTutorial>();
        aEDSound = aED.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(wait == true)
        {
            isPump = false;
            cPRCheckboxStatus = false;
            CPRText.SetActive(false);
            timeCountDown.SetActive(false);
            timeCountDownUI.SetActive(false);
            isFirstPump = true;
        }
        if(GetIsPump() == true)
        {
            if(pumpCounter > 0)
            {
                pumpCounter -= Time.deltaTime;
                minutes = Mathf.FloorToInt(pumpCounter / 60);
                seconds = Mathf.FloorToInt(pumpCounter % 60);
                finishTime +=Time.deltaTime;
            }
            else if(pumpCounter <= 0)
            {
                wait = true;
                isPump = false;
                isFirstPump = true;
                cPRCheckboxStatus = false;
                aEDButtonStatus = true;
                CPRText.SetActive(false);
                pushUI.SetActive(true);
                timeCountDown.SetActive(false);
                timeCountDownUI.SetActive(false);
                minutes = 0;
                seconds = 0;
                finishTime /= 1;
                if(isFirstChage == true)
                {
                    aEDNoti.SetActive(true);
                    isFirstChage = false;
                }
            }
        }
        else if(GetAEDCharge() == true)
        {
            if(aEDChargerCounter > 0)
            {
                aEDChargerCounter -= Time.deltaTime;
                minutes = Mathf.FloorToInt(aEDChargerCounter / 60);
                seconds = Mathf.FloorToInt(aEDChargerCounter % 60);
            }
            else if(aEDChargerCounter <= 0)
            {
                aEDSound.Stop();
                aEDCharge = false;
                cPRCheckboxStatus = true;
                AEDChargeText.SetActive(false);
                timeCountDown.SetActive(false);
                timeCountDownUI.SetActive(false);
                aEDNoti.SetActive(false);
                minutes = 0;
                seconds = 0;
            }
        }

        timeCounter.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        
        if ((finishTime >= TotalPumpTime) && (finish == false))
        {
            wait = true;
            isPump = false;
            aEDCharge = false;
            pushUI.SetActive(false);
            finish = true;
            aEDButtonStatus = false;
            Mission.IsFinish();
            cPRCheckboxStatus = false;
            timeCountDownUI.SetActive(false);
        }
 
    }
    public void OpenAED()
    {   
        wait = false;
        aEDNoti.SetActive(true);
        aEDNotiDoNot.SetActive(true);
        aEDNotiPush.SetActive(false);
        timeCountDownUI.SetActive(true);
        Mission.AEDCharge();
        pushUI.SetActive(false);
        aEDButtonStatus = false;
        aEDChargerCounter = aEDChargerTime;
        aEDCharge = true;
        AEDChargeText.SetActive(true);
        timeCountDown.SetActive(true);
        aEDSound.Play();
    }

    public void PumpStart()
    {   
        Mission.CPRCheck();
        if (isFirstPump == true)
        {
            timeCountDownUI.SetActive(true);
            CPRText.SetActive(true);
            timeCountDown.SetActive(true);
            pumpCounter = pumpTime;
            isFirstPump = false;
            isPump = true;
        } 
    }

    public bool GetAEDButtonStatus()
    {
        return aEDButtonStatus;
    }
    public bool GetCPRCheckboxStatus()
    {
        return cPRCheckboxStatus;
    }
    public bool GetAEDCharge()
    {
        return aEDCharge;
    }
    public bool GetIsPump()
    {
        return isPump;
    }
    public bool GetIsFirstPump()
    {
        return isFirstPump;
    }
    public float GetFinishTime()
    {
        return finishTime;
    } 
}
