using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InvincibleHand : MonoBehaviour
{
    [SerializeField] private GameObject LeftHand;
    [SerializeField] private GameObject RightHand;
    [SerializeField] private GameObject CPR;
    [SerializeField] private GameObject LeftHandWakeUp;
    [SerializeField] private GameObject RightHandWakeUp;
    [SerializeField] private GameObject LeftHandPulse;
    [SerializeField] private GameObject RightHandPulse;
    [SerializeField] private GameObject CPRCheckBox;
    [SerializeField] private GameObject PulseRateCheckBox;
    [SerializeField] private GameObject WakeUpCheckBox;
    [SerializeField] private GameObject AEDButton;
    [SerializeField] private GameObject AEDSocket;
    [SerializeField] private GameObject ElectrodeRightSocket;
    [SerializeField] private GameObject ElectrodeLeftSocket;


    private SkinnedMeshRenderer MeshRendererLeft = null;
    private SkinnedMeshRenderer MeshRendererRight = null;
    private OnSocketStatus electrodeRightonSocket = null;
    private OnSocketStatus electrodeLeftonSocket = null;
    private OnSocketStatus aedOnSocket = null;
    private ActiveElectrode electrodeCheck = null;
    private CPRController cPRController = null;
    private MissionController mission = null;


    private void Awake()
    {
        MeshRendererRight = RightHand.GetComponentInChildren<SkinnedMeshRenderer>();
        MeshRendererLeft = LeftHand.GetComponentInChildren<SkinnedMeshRenderer>();
        electrodeRightonSocket = ElectrodeRightSocket.GetComponent<OnSocketStatus>();
        electrodeLeftonSocket = ElectrodeLeftSocket.GetComponent<OnSocketStatus>();
        aedOnSocket = AEDSocket.GetComponent<OnSocketStatus>();
        electrodeCheck = AEDSocket.GetComponent<ActiveElectrode>();
        cPRController = this.GetComponent<CPRController>();
        mission = this.GetComponent<MissionController>();
    }
    private void Start()
    {
        MeshRendererRight.enabled = true;
        MeshRendererLeft.enabled = true;
    }

    private void Update()
    {
        if(mission.GetFinish() == false)
        {
            if ((CPR.activeSelf) && (CPRCheckBox.activeSelf))
            {
                MeshRendererRight.enabled = false;
                MeshRendererLeft.enabled = false;

                WakeUpCheckBox.SetActive(false);
                PulseRateCheckBox.SetActive(false);
            }
            else if (LeftHandWakeUp.activeSelf)
            {
                MeshRendererLeft.enabled = false;
                MeshRendererRight.enabled = true;

                PulseRateCheckBox.SetActive(false);
            }
            else if (RightHandWakeUp.activeSelf)
            {
                MeshRendererLeft.enabled = true;
                MeshRendererRight.enabled = false;

                PulseRateCheckBox.SetActive(false);
            }
            else if (LeftHandPulse.activeSelf)
            {
                MeshRendererLeft.enabled = false;
                MeshRendererRight.enabled = true;

                WakeUpCheckBox.SetActive(false);
            }
            else if (RightHandPulse.activeSelf)
            {
                MeshRendererLeft.enabled = true;
                MeshRendererRight.enabled = false;

                WakeUpCheckBox.SetActive(false);
            }
            else if ((CPRCheckBox.activeSelf == true)&&(CPR.activeSelf == false))
            {
                MeshRendererRight.enabled = true;
                MeshRendererLeft.enabled = true;

                PulseRateCheckBox.SetActive(false);
                WakeUpCheckBox.SetActive(false);
            }
            else if (AEDButton.activeSelf == true)
            {
                MeshRendererRight.enabled = true;
                MeshRendererLeft.enabled = true;

                PulseRateCheckBox.SetActive(false);
                WakeUpCheckBox.SetActive(false);
            }
            else if (cPRController.GetAEDCharge() == true)
            {
                MeshRendererRight.enabled = true;
                MeshRendererLeft.enabled = true;

                PulseRateCheckBox.SetActive(false);
                WakeUpCheckBox.SetActive(false);
            }
            else
            {
                MeshRendererRight.enabled = true;
                MeshRendererLeft.enabled = true;

                if ((aedOnSocket.GetStatus() == true) && (electrodeCheck.GetElectrodesSet() == true))
                {
                    if ((electrodeRightonSocket.GetStatus() == true) && (electrodeLeftonSocket.GetStatus() == true))
                    {
                        PulseRateCheckBox.SetActive(true);
                        WakeUpCheckBox.SetActive(true);
                    }
                    else
                    {
                        PulseRateCheckBox.SetActive(false);
                        WakeUpCheckBox.SetActive(false);
                    }
                }
                else
                {
                    PulseRateCheckBox.SetActive(true);
                    WakeUpCheckBox.SetActive(true);
                }
            }
        }
        else if (mission.GetFinish() == true)
        {
            MeshRendererRight.enabled = true;
            MeshRendererLeft.enabled = true;

            PulseRateCheckBox.SetActive(false);
            WakeUpCheckBox.SetActive(false);
        }
    }

}
