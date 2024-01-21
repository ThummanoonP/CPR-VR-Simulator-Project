using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEngine.XR.Interaction.Toolkit;

public class PopUpUI : MonoBehaviour
{
    [SerializeField] private GameObject HeartBeatChart;

    private Animator BodyAnimator;
    int L_count = 0, R_count = 0;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Right Controller")
        {
            R_count = 1;
        }
        else if (other.gameObject.name == "Left Controller")
        {
            L_count = 1;
        }
        PopUp();

    }

    private void PopUp()
    {
        if ((L_count == 1) && (R_count == 0)) HeartBeatChart.SetActive(true);
        else if ((L_count == 0) && (R_count == 1)) HeartBeatChart.SetActive(true);
        else if ((L_count == 1) && (R_count == 1)) HeartBeatChart.SetActive(true);
        else HeartBeatChart.SetActive(false);
    }

}
