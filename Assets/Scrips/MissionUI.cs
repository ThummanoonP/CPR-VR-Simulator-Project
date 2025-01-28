using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionUI : MonoBehaviour
{
    [SerializeField] private GameObject CheckList;
    [SerializeField] private GameObject UerManual;
    [SerializeField] private GameObject Step1;
    [SerializeField] private GameObject Step2;
    [SerializeField] private GameObject Step3;
    [SerializeField] private GameObject Step4;
    [SerializeField] private GameObject Step5;
    [SerializeField] private GameObject Step5WhitAED;
    [SerializeField] private GameObject Step6WhitAED;
    [SerializeField] private GameObject Step7WhitAED;

    private MissionController Mission = null;
    // Start is called before the first frame update
    void Awake()
    {
        Mission = this.GetComponent<MissionController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Mission.GetStatusClearArea()== true){Step1.SetActive(true);}
        if(Mission.GetStatusWakeUp() == true){Step2.SetActive(true);}
        if(Mission.GetStatusHapticPulse() == true){Step3.SetActive(true);}
        if(Mission.GetStatusCallEmergency() == true){Step4.SetActive(true);}
        if((Mission.GetStatusSetAED() == false) && (Mission.GetStatusCPRCheck() == true)){Step5.SetActive(true);}
        if(Mission.GetStatusSetAED() == true){Step5WhitAED.SetActive(true);}
        if((Mission.GetStatusSetAED() == true) && (Mission.GetStatusCPRCheck() == true)){Step6WhitAED.SetActive(true);}
        if(Mission.GetStatusAEDCharge() == true){Step7WhitAED.SetActive(true);}
    }

    public void PickUpFirst()
    {
        CheckList.SetActive(true);
        UerManual.SetActive(false);
    }
}
