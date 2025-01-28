using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WakeUp : MonoBehaviour
{
    [SerializeField] private GameObject LeftHand;
    [SerializeField] private GameObject RightHand;
    [SerializeField] private GameObject LeftHandWakeUp;
    [SerializeField] private GameObject RightHandWakeUp;
    [SerializeField] private GameObject Manager;

    private float timer = 0.0f;
    bool LeftCheck = false;
    bool RightCheck = false;
    private ActionBasedController LeftController = null;
    private ActionBasedController RightController = null;
    private MissionController Mission = null;

    void Awake()
    {
        Mission = Manager.GetComponent<MissionController>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if ((other.gameObject.name == "Right Controller") && (LeftCheck == false))
        {
            RightHandWakeUp.SetActive(true);
            RightCheck = true;
            Mission.CheakWakeUp();
        }
        else if ((other.gameObject.name == "Left Controller") && (RightCheck == false))
        {
            LeftHandWakeUp.SetActive(true);
            LeftCheck = true;
            Mission.CheakWakeUp();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Right Controller")
        {
            RightHandWakeUp.SetActive(false);
            RightCheck = false;
        }
        else if (other.gameObject.name == "Left Controller")
        {
            LeftHandWakeUp.SetActive(false);
            LeftCheck = false;
        }
    }

    public bool HandOutOfPosition()
    {
        if ((LeftCheck == false) && (RightCheck == false)) return true;
        else return false;
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
