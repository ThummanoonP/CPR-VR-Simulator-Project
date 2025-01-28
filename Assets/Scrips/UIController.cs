using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject HeartRateUI;
    [SerializeField] private GameObject TimeCountDownUI;
    private MissionController Mission = null;

    // Start is called before the first frame update
    void Awake()
    {
        Mission = this.GetComponent<MissionController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mission.GetFinish() == true)
        {
            TimeCountDownUI.SetActive(false);
            HeartRateUI.SetActive(false);
        } 
    }
}
