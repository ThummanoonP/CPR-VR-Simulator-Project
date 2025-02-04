using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHeartRateTutorial : MonoBehaviour
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
    private CPRControllerTutorial cPRController = null;
    
    void Awake()
    {
        showHeartRate = Random.Range(0, 29);
        brian = this.GetComponent<Brian>();
        cPRController = Manager.GetComponent<CPRControllerTutorial>();
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
            cPRController.PumpStart();
        }
    }

    private void HeartRateUp(float min, float max)
    {
        UpRate = Random.Range(min, max);
        totalHeartRate += UpRate;
        //Debug.Log("Rate Up : " +totalHeartRate.ToString());
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
                HeartRateUp(5.0f,10.0f);
            }
            else
            {
                showHeartRate = Random.Range(30, 60);
                HeartRateUp(1.0f,3.0f);
            }
            isPump = false;
        }
     
    }

}
