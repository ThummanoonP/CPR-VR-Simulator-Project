using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InvincibleHandTutorial : MonoBehaviour
{
    [SerializeField] private GameObject LeftHand;
    [SerializeField] private GameObject RightHand;
    [SerializeField] private GameObject CPR;
    [SerializeField] private GameObject LeftHandWakeUp;
    [SerializeField] private GameObject RightHandWakeUp;
    [SerializeField] private GameObject LeftHandPulse;
    [SerializeField] private GameObject RightHandPulse;
    [SerializeField] private GameObject CPRCheckBox;
    [SerializeField] private GameObject AEDButton;


    private SkinnedMeshRenderer MeshRendererLeft = null;
    private SkinnedMeshRenderer MeshRendererRight = null;
    private CPRControllerTutorial cPRController = null;
    private MissionControllerTutorial mission = null;


    private void Awake()
    {
        MeshRendererRight = RightHand.GetComponentInChildren<SkinnedMeshRenderer>();
        MeshRendererLeft = LeftHand.GetComponentInChildren<SkinnedMeshRenderer>();
        cPRController = this.GetComponent<CPRControllerTutorial>();
        mission = this.GetComponent<MissionControllerTutorial>();
    }
    private void Start()
    {
        MeshRendererRight.enabled = true;
        MeshRendererLeft.enabled = true;
    }

    public void ShowHand()
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
            }
            else if (LeftHandWakeUp.activeSelf)
            {
                MeshRendererLeft.enabled = false;
                MeshRendererRight.enabled = true;
            }
            else if (RightHandWakeUp.activeSelf)
            {
                MeshRendererLeft.enabled = true;
                MeshRendererRight.enabled = false;
            }
            else if (LeftHandPulse.activeSelf)
            {
                MeshRendererLeft.enabled = false;
                MeshRendererRight.enabled = true;
            }
            else if (RightHandPulse.activeSelf)
            {
                MeshRendererLeft.enabled = true;
                MeshRendererRight.enabled = false;
            }
            else if ((CPRCheckBox.activeSelf == true)&&(CPR.activeSelf == false))
            {
                MeshRendererRight.enabled = true;
                MeshRendererLeft.enabled = true;
            }
            else if ((CPRCheckBox.activeSelf == false)&&(CPR.activeSelf == false))
            {
                MeshRendererRight.enabled = true;
                MeshRendererLeft.enabled = true;
            }
            else if (AEDButton.activeSelf == true)
            {
                MeshRendererRight.enabled = true;
                MeshRendererLeft.enabled = true;
            }
            else if (cPRController.GetAEDCharge() == true)
            {
                MeshRendererRight.enabled = true;
                MeshRendererLeft.enabled = true;
            }
            else
            {
                MeshRendererRight.enabled = true;
                MeshRendererLeft.enabled = true;
            }
        }
        else if (mission.GetFinish() == true)
        {
            MeshRendererRight.enabled = true;
            MeshRendererLeft.enabled = true;
        }
    }

}
