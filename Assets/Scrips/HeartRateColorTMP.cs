using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HeartRateColorTMP : MonoBehaviour
{
    [SerializeField] public GameObject WoundedPeople;

    private CharacterHeartRate CharHR;
    private float HeartRate;
    private TextMeshProUGUI HRText;

    void Awake()
    {
        CharHR = WoundedPeople.GetComponent<CharacterHeartRate>();
        HRText = this.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        HeartRate = CharHR.GetShowHeartRate();
        if (HeartRate <= 40) HRText.color = Color.red;
        else if (HeartRate > 40 && HeartRate <= 80) HRText.color = Color.yellow;
        else HRText.color = Color.green;
    }
}
