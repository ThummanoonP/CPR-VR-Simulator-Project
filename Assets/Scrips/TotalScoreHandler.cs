using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TotalScoreHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI MissionScore1;
    [SerializeField] private TextMeshProUGUI MissionScore2;
    [SerializeField] private TextMeshProUGUI MissionScore3;
    [SerializeField] private TextMeshProUGUI MissionScore4;
    [SerializeField] private TextMeshProUGUI MissionScore5;
    [SerializeField] private TextMeshProUGUI MissionScore6;
    [SerializeField] private TextMeshProUGUI MissionScore7;
    [SerializeField] private TextMeshProUGUI MissionScore8;
    [SerializeField] private TextMeshProUGUI PumpCriHit;
    [SerializeField] private TextMeshProUGUI PumpHit;
    private MissionController Mission = null;
    private int criHit = 0 ;
    private int hit = 0 ;
    void Awake()
    {
        Mission = this.GetComponent<MissionController>();
    }

    // Update is called once per frame
    void Update()
    {
        criHit = Mission.GetCriticalHit();
        hit = Mission.GetHit();
        MissionScore7.text = string.Format("{0:#,##0}", ((criHit*5)+hit));
        PumpCriHit.text = string.Format("{0:#,##0}", criHit);
        PumpHit.text = string.Format("{0:#,##0}", hit);

        if(Mission.GetStatusClearArea() == true)
            MissionScore1.text = string.Format("{0:#,##0}", 500);
        else
            MissionScore1.text = string.Format("{0:#,##0}", 0); 
  
        if(Mission.GetStatusWakeUp() == true)
            MissionScore2.text = string.Format("{0:#,##0}", 500);
        else 
            MissionScore2.text = string.Format("{0:#,##0}", 0);
        
        if(Mission.GetStatusHapticPulse() == true)
            MissionScore3.text = string.Format("{0:#,##0}", 500); 
        else 
        MissionScore3.text = string.Format("{0:#,##0}", 0); 
        
        if(Mission.GetStatusCallEmergency() == true)
            MissionScore4.text = string.Format("{0:#,##0}", 500);
        else
            MissionScore4.text = string.Format("{0:#,##0}", 0);
        
        if(Mission.GetStatusSetAED() == true)
            MissionScore5.text = string.Format("{0:#,##0}", 2000);
        else
            MissionScore5.text = string.Format("{0:#,##0}", 0);
        
        if(Mission.GetStatusCPRCheck() == true)
            MissionScore6.text = string.Format("{0:#,##0}", 1000);
        else
            MissionScore6.text = string.Format("{0:#,##0}", 0);
        
        if(Mission.GetRise() == true)
            MissionScore8.text = string.Format("{0:#,##0}", 1000);
        else    
            MissionScore8.text = string.Format("{0:#,##0}", 0);
    }
}
