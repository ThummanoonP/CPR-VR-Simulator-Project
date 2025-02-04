using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WakeUpTutorial : MonoBehaviour
{
    [SerializeField] private GameObject LeftHand;
    [SerializeField] private GameObject RightHand;
    [SerializeField] private GameObject LeftHandWakeUp;
    [SerializeField] private GameObject RightHandWakeUp;
    [SerializeField] private GameObject Manager;
    [SerializeField] private GameObject WakeNoti;
    [SerializeField] private GameObject Brian;

    private float timer = 0.0f;
    bool LeftCheck = false;
    bool RightCheck = false;
    private SkinnedMeshRenderer MeshRendererLeft = null;
    private SkinnedMeshRenderer MeshRendererRight = null;
    private ActionBasedController LeftController = null;
    private ActionBasedController RightController = null;
    private MissionControllerTutorial Mission = null;
    private AudioSource WakeUpSound = null;

    void Awake()
    {
        MeshRendererRight = RightHand.GetComponentInChildren<SkinnedMeshRenderer>();
        MeshRendererLeft = LeftHand.GetComponentInChildren<SkinnedMeshRenderer>();
        Mission = Manager.GetComponent<MissionControllerTutorial>();
        WakeUpSound = Brian.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if ((other.gameObject.name == "Right Controller") && (LeftCheck == false))
        {
            RightHandWakeUp.SetActive(true);
            RightCheck = true;
            Mission.CheakWakeUp();
            WakeNoti.SetActive(false);
            WakeUpSound.Play(); 
        }
        else if ((other.gameObject.name == "Left Controller") && (RightCheck == false))
        {
            LeftHandWakeUp.SetActive(true);
            LeftCheck = true;
            Mission.CheakWakeUp();
            WakeNoti.SetActive(false);
            WakeUpSound.Play();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Right Controller")
        {
            RightHandWakeUp.SetActive(false);
            RightCheck = false;
            WakeUpSound.Stop();
        }
        else if (other.gameObject.name == "Left Controller")
        {
            LeftHandWakeUp.SetActive(false);
            LeftCheck = false;
            WakeUpSound.Stop();
        }
    }

    public bool HandOutOfPosition()
    {
        if ((LeftCheck == false) && (RightCheck == false)) return true;
        else return false;
    }
    
    public void Reset()
    {
        LeftCheck = false;
        RightCheck = false;
        WakeUpSound.Stop();
        MeshRendererRight.enabled = true;
        MeshRendererLeft.enabled = true;
    }

    void Update()
    {
        timer += Time.deltaTime;
        RightController = RightHand.GetComponent<ActionBasedController>();
        LeftController = LeftHand.GetComponent<ActionBasedController>();

        if ((RightHandWakeUp.activeSelf) || (LeftHandWakeUp.activeSelf))
        {
            if (timer >= 0.2f) 
            {
                if (RightCheck) RightController.SendHapticImpulse(0.1f, 0.5f);
                else if (LeftCheck) LeftController.SendHapticImpulse(0.1f, 0.5f);

                timer = 0.0f;
            }
        }
    }
}
