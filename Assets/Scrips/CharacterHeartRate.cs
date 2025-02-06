using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHeartRate : MonoBehaviour
{
    [SerializeField] private GameObject CPR;
    [SerializeField] public GameObject Manager;
    private float HeartRateMax = 120.0f;
    private float HeartRateMin = 100.0f;
    private float realHeartRate = 0.0f;
    private float totalHeartRate = 0.0f;
    private float showHeartRate = 0.0f;
    private float currentRate = 0.0f;
    private int totalCompressions = 0;
    private float startTime = 0f; 
    private bool hasStarted = false;
    private float elapsedTime = 0.0f;
    private float UpRate = 0.0f;
    private bool isPump = false;
    private Brian brian = null;
    private CPRCheckBox cPRCheckbox = null;
    private CPRController cPRController = null;
    private MissionController Mission = null;
    
    void Awake()
    {
        showHeartRate = Random.Range(0, 29);
        brian = this.GetComponent<Brian>();
        cPRCheckbox = Manager.GetComponent<CPRCheckBox>();
        cPRController = Manager.GetComponent<CPRController>();
        Mission = Manager.GetComponent<MissionController>();
    }

    public float GetShowHeartRate()
    {
        return showHeartRate;
    }

    public bool HeartRateIsBack()
    {
        realHeartRate = (totalHeartRate/(cPRController.GetFinishTime()/60));
        Debug.Log("HeartRate : " +realHeartRate.ToString());
        if(realHeartRate >= 100)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void HeartRatePumping()
    {
        if (CPR.activeSelf) 
        {
            isPump = true;
            if(cPRCheckbox.GetAEDStatus() == true)
            {
                cPRController.PumpStart();
            }
            else if(cPRCheckbox.GetAEDStatus() == false)
            {
                cPRController.PumpWithOutAED();
            }
        }
    }

    private void HeartRateUp(int min, int max)
    {
        UpRate = ((Random.Range(min, max)) * 0.1f);
        Debug.Log("Up : " +UpRate);
        totalHeartRate += UpRate;
        Debug.Log("Rate : " +totalHeartRate);
    }

    void Update()
    {
        showHeartRate = Random.Range(0, 29);
        if (isPump == true)
        {
            if(cPRController.GetIsFirstPump() == true)
            {
                hasStarted = false;
                totalCompressions = 0;
            }

            if(!hasStarted)
            {
                hasStarted = true;
                startTime = Time.time; 
            }

            totalCompressions++;
            elapsedTime = Time.time - startTime;
            currentRate = totalCompressions / (elapsedTime / 60f);

            if (currentRate >= HeartRateMin && currentRate <= HeartRateMax)
            {
                showHeartRate = Random.Range(70, 110);
                HeartRateUp(30,50);
                Mission.Hit(true);
            }
            else
            {
                showHeartRate = Random.Range(30, 60);
                HeartRateUp(1,10);
                Mission.Hit(false);
            }
            isPump = false;
        }
     
    }

}
