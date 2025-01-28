using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartRateColor : MonoBehaviour
{
    [SerializeField] public GameObject WoundedPeople;

    private CharacterHeartRate CharHR;
    private float HeartRate;
    private Text HRText;

    void Awake()
    {
        CharHR = WoundedPeople.GetComponent<CharacterHeartRate>();
        HRText = this.GetComponent<Text>();
    }

    void Update()
    {
        HeartRate = CharHR.GetShowHeartRate();
        if (HeartRate <= 40) HRText.color = Color.red;
        else if (HeartRate > 40 && HeartRate <= 80) HRText.color = Color.yellow;
        else HRText.color = Color.green;
    }
}
