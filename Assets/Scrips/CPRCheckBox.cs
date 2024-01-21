using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class CPRCheckBox : MonoBehaviour
{
    [SerializeField] private GameObject HeartBeatChart;
    [SerializeField] private GameObject CheckBox;
    [SerializeField] private GameObject PulseCheckBox;

    private HapticPulse Pulse = null;
    private CharacterHeartRate Dummy = null;

    private void Start()
    {
        ActiveCheckBox();
    }

    private void Update()
    {
        ActiveCheckBox();
    }

    private void ActiveCheckBox()
    {
        Pulse = PulseCheckBox.GetComponent<HapticPulse>();
        Dummy = this.GetComponent<CharacterHeartRate>();


        if ((HeartBeatChart.activeSelf) && (Pulse.HandOutOfPosition()) && (Dummy.GetHeartRate() < Dummy.GetHeartRateMax()))
        {
            CheckBox.SetActive(true);
        }
        else
        {
            CheckBox.SetActive(false);
        }
    }
}
