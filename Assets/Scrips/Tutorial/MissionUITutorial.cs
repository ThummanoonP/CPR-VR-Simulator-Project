using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MissionUITutorial : MonoBehaviour
{
    [SerializeField] private GameObject CheckList;
    [SerializeField] private GameObject UerManual;
    [SerializeField] private GameObject Step1;
    [SerializeField] private GameObject Step2;
    [SerializeField] private GameObject Step3;
    [SerializeField] private GameObject Step4;
    [SerializeField] private GameObject Step5WhitAED;
    [SerializeField] private GameObject Step6WhitAED;
    [SerializeField] private GameObject Step7WhitAED;

    private MissionControllerTutorial Mission = null;
    private TextMeshProUGUI Text;


    // Start is called before the first frame update
    void Awake()
    {
        Mission = this.GetComponent<MissionControllerTutorial>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Mission.GetStatusClearArea()== true)
        {
            Text = Step1.GetComponent<TextMeshProUGUI>();
            Text.color = Color.green;
        }
        if(Mission.GetStatusWakeUp() == true)
        {
            Text = Step2.GetComponent<TextMeshProUGUI>();
            Text.color = Color.green;
        }
        if(Mission.GetStatusHapticPulse() == true)
        {
            Text = Step3.GetComponent<TextMeshProUGUI>();
            Text.color = Color.green;
        }
        if(Mission.GetStatusCallEmergency() == true)
        {
            Text = Step4.GetComponent<TextMeshProUGUI>();
            Text.color = Color.green;
        }
        if(Mission.GetStatusSetAED() == true)
        {
            Text = Step5WhitAED.GetComponent<TextMeshProUGUI>();
            Text.color = Color.green;
        }
        if((Mission.GetStatusSetAED() == true) && (Mission.GetStatusCPRCheck() == true))
        {
            Text = Step6WhitAED.GetComponent<TextMeshProUGUI>();
            Text.color = Color.green;
        }
        if(Mission.GetStatusAEDCharge() == true)
        {
            Text = Step7WhitAED.GetComponent<TextMeshProUGUI>();
            Text.color = Color.green;
        }
    }

    public void PickUpFirst()
    {
        CheckList.SetActive(true);
        UerManual.SetActive(false);
    }
}
