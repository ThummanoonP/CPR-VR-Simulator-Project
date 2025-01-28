using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveElectrode : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public GameObject ElectrodeRight;
    [SerializeField] public GameObject ElectrodeLeft;
    [SerializeField] public GameObject WakeUpCheckBox;
    [SerializeField] public GameObject PulseRateCheckBox;
    [SerializeField] private GameObject Manager;
    
    private WakeUp wakeUpCheck = null;
    private HapticPulse pulseRateCheck = null;
    private OnSocketStatus onSocket = null;
    private bool electrodesSet = false;
    private MissionController Mission = null;
    private void Awake()
    {
        onSocket = this.GetComponent<OnSocketStatus>();
        pulseRateCheck = PulseRateCheckBox.GetComponent<HapticPulse>();
        wakeUpCheck = WakeUpCheckBox.GetComponent<WakeUp>();
        Mission = Manager.GetComponent<MissionController>();
    }
    void Start()
    {
        ActiveAllElectrode();
    }

    // Update is called once per frame
    void Update()
    {
        ActiveAllElectrode();
    }

    private void ActiveAllElectrode()
    {   
        
        if ((onSocket.GetStatus()) && 
        (Mission.GetStatusHapticPulse()) && 
        (Mission.GetStatusWakeUp()))
        {
            ElectrodeRight.SetActive(true);
            ElectrodeLeft.SetActive(true);
            electrodesSet = true;
        }
        else
        {   
            ElectrodeRight.SetActive(false);
            ElectrodeLeft.SetActive(false);
            electrodesSet = false;
        }

    }
    public bool GetElectrodesSet()
    {   
        return electrodesSet;
    }
}
