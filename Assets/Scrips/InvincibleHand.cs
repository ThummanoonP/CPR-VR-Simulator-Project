using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InvincibleHand : MonoBehaviour
{
    [SerializeField] private GameObject LeftHand;
    [SerializeField] private GameObject RightHand;
    [SerializeField] private GameObject LeftHandPhysics;
    [SerializeField] private GameObject RightHandPhysics;
    [SerializeField] private GameObject CPR;
    [SerializeField] private GameObject LeftHandWakeUp;
    [SerializeField] private GameObject RightHandWakeUp;
    [SerializeField] private GameObject LeftHandPulse;
    [SerializeField] private GameObject RightHandPulse;
    [SerializeField] private GameObject CPRCheckBox;
    [SerializeField] private GameObject PulseRateCheckBox;
    [SerializeField] private GameObject WakeUpCheckBox;


    private SkinnedMeshRenderer MeshRendererLeft = null;
    private SkinnedMeshRenderer MeshRendererRight = null;



    private void Start()
    {
        MeshRendererRight = RightHand.GetComponentInChildren<SkinnedMeshRenderer>();
        MeshRendererRight.enabled = true;
        MeshRendererLeft = LeftHand.GetComponentInChildren<SkinnedMeshRenderer>();
        MeshRendererLeft.enabled = true;
    }

    private void Update()
    {
        MeshRendererLeft = LeftHand.GetComponentInChildren<SkinnedMeshRenderer>();
        MeshRendererRight = RightHand.GetComponentInChildren<SkinnedMeshRenderer>();

            if ((CPR.activeSelf) && (CPRCheckBox.activeSelf))
            {
                MeshRendererRight.enabled = false;
                MeshRendererLeft.enabled = false;

                //LeftHandPhysics.SetActive(false);
                //RightHandPhysics.SetActive(false);
                WakeUpCheckBox.SetActive(false);
                PulseRateCheckBox.SetActive(false);
            }
            else if (LeftHandWakeUp.activeSelf)
            {
                MeshRendererLeft.enabled = false;
                MeshRendererRight.enabled = true;

                //LeftHandPhysics.SetActive(false);
                //RightHandPhysics.SetActive(true);
                CPRCheckBox.SetActive(false);
                PulseRateCheckBox.SetActive(false);
            }
            else if (RightHandWakeUp.activeSelf)
            {
                MeshRendererLeft.enabled = true;
                MeshRendererRight.enabled = false;

                //LeftHandPhysics.SetActive(true);
                //RightHandPhysics.SetActive(false);
                CPRCheckBox.SetActive(false);
                PulseRateCheckBox.SetActive(false);
            }
            else if (LeftHandPulse.activeSelf)
            {
                MeshRendererLeft.enabled = false;
                MeshRendererRight.enabled = true;

                //LeftHandPhysics.SetActive(false);
                //RightHandPhysics.SetActive(true);
                CPRCheckBox.SetActive(false);
                WakeUpCheckBox.SetActive(false);
            }
            else if (RightHandPulse.activeSelf)
            {
                MeshRendererLeft.enabled = true;
                MeshRendererRight.enabled = false;

                //LeftHandPhysics.SetActive(true);
                //RightHandPhysics.SetActive(false);
                CPRCheckBox.SetActive(false);
                WakeUpCheckBox.SetActive(false);
            }
            else if (CPRCheckBox.activeSelf == false)
            {
                MeshRendererRight.enabled = true;
                MeshRendererLeft.enabled = true;

                //LeftHandPhysics.SetActive(true);
                //RightHandPhysics.SetActive(true);
                PulseRateCheckBox.SetActive(true);
            }
            else if (CPRCheckBox.activeSelf == false)
            {
                MeshRendererRight.enabled = true;
                MeshRendererLeft.enabled = true;

                //LeftHandPhysics.SetActive(true);
                //RightHandPhysics.SetActive(true);
                PulseRateCheckBox.SetActive(true);
            }
            else
            {
                MeshRendererRight.enabled = true;
                MeshRendererLeft.enabled = true;

                //LeftHandPhysics.SetActive(true);
                //RightHandPhysics.SetActive(true);
                WakeUpCheckBox.SetActive(true);
                PulseRateCheckBox.SetActive(true);
            }
    }

}
