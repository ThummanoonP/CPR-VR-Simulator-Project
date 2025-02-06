using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHeartRateTutorial : MonoBehaviour
{
    [SerializeField] private GameObject CPR;
    [SerializeField] public GameObject Manager;
    private float HeartRateMax = 120.0f;
    private float HeartRateMin = 100.0f;
    private float showHeartRate = 0.0f;
    private float currentRate = 0.0f;
    private float startTime = 0f; 
    private bool hasStarted = false;
    private float elapsedTime = 0.0f;
    private int totalCompressions = 0;
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

    public void HeartRatePumping()
    {
        if (CPR.activeSelf) 
        {
            isPump = true;
            cPRController.PumpStart();
        }
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
            }
            else
            {
                showHeartRate = Random.Range(30, 60);
            }
            isPump = false;
        }
     
    }

}
