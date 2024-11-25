using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHeartRate : MonoBehaviour
{
    [SerializeField] private GameObject CPR;
    private float HeartRateMax;
    private float HeartRate;
    private int PumpRate = 0;

    private float timer = 0.0f;
    private float UpRate = 0.0f;
    private Brian brian = null;

    // Start is called before the first frame update
    void Start()
    {
        HeartRateMax = 120.0f;
        HeartRate = Random.Range(1, 30);
        brian = this.GetComponent<Brian>();
    }

    public float GetHeartRate()
    {
        return HeartRate;
    }

    public float GetHeartRateMax()
    {
        return HeartRateMax;
    }

    public void HeartRatePumping()
    {
        if (CPR.activeSelf) 
        {
            //PumpRate++;
            HeartRateUp();
        }
    }

    private void HeartRateDown()
    {
        HeartRate -= 0.1f;
        Debug.Log("Rate Down : " + HeartRate);
    }

    private void HeartRateUp()
    {
        UpRate = Random.Range(0.5f, 1.0f);
        HeartRate += UpRate;
        Debug.Log("Rate Up : " + HeartRate);
    }

    private void RateCheck()
    {
       if ((HeartRate > 0) && (HeartRate <= HeartRateMax))
        {
            if (PumpRate > 5) HeartRateUp();
            PumpRate = 0;
        }
        else if (HeartRate >= HeartRateMax)
        {
            HeartRate = HeartRateMax;
            PumpRate = 0;
            brian.Rise();
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 3.0f)
        {
            RateCheck();
            timer = 0.0f;
        }
    }

}
