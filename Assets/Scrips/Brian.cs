using System.Linq;
using UnityEngine;

public class Brian : MonoBehaviour
{
    private enum BrianState
    {
        Walking,
        Standing,
        Ragdoll
    }

    [SerializeField] public GameObject Position;
    [SerializeField] public GameObject Manager;
    [SerializeField] public GameObject WakeUpCheckBox;
    [SerializeField] public GameObject PulseRateCheckBox;
    [SerializeField] private GameObject aEDLocatedUI;
    [SerializeField] private GameObject aEDSocket;

    private Rigidbody[] RagdollRigidbodies;
    private BrianState CurrentState = BrianState.Walking;
    private Animator Animator;
    private CharacterController CharacterController;
    private InvincibleHand Invin = null;
    bool Falling = false;
    bool Check = false;


    private void Awake()
    {
        RagdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        Animator = GetComponent<Animator>();
        CharacterController = GetComponent<CharacterController>();
        Invin = Manager.GetComponent<InvincibleHand>();

        CheckBoxOff();
        DisableRagdoll();
        Invoke("ManDown", 9.0f);
        Invin.enabled = false;
    }

    public void CheckBoxOff()
    {
        Invin.enabled = false;
        Falling = false;
        Check = false;
        WakeUpCheckBox.SetActive(false);
        PulseRateCheckBox.SetActive(false);
    }

    public void CheckBoxOn()
    {
        WakeUpCheckBox.SetActive(true);
        PulseRateCheckBox.SetActive(true);
        aEDLocatedUI.SetActive(true);
        aEDSocket.SetActive(true);
        Invin.enabled = true;
        Falling = true;
        Check = true;
    }

    private void Update()
    {
        switch (CurrentState)
        {
            case BrianState.Walking:
                WalkingBehaviour();
                break;
            case BrianState.Standing:
                RagdollBehaviour();
                break;
            case BrianState.Ragdoll:
                RagdollBehaviour();
                break;
        }
    }


    private void ManDown()
    {
        CurrentState = BrianState.Standing;
        Falling = true;
        Animator.SetBool("isStop", true);
        Animator.SetBool("isFall", true);
        Animator.SetBool("isSeizure", true);
        Animator.SetBool("isPassOut", true);
        
        Invoke("CheckBoxOn", 12.0f);
    }

    public void Rise()
    {
        Animator.SetBool("isRegain", true);
        Animator.SetBool("isWaking", true);
    }

    public bool GetStatus()
    {
        return Falling;
    }

    public bool GetCheck()
    {
        return Check;
    }

    private void DisableRagdoll()
    {
        foreach (var rigidbody in RagdollRigidbodies)
        {
            rigidbody.isKinematic = true;
        }

        Animator.enabled = true;
        CharacterController.enabled = true;
    }

    private void EnableRagdoll()
    {
        foreach (var rigidbody in RagdollRigidbodies)
        {
            rigidbody.isKinematic = false;
        }

        Animator.enabled = false;
        CharacterController.enabled = false;
    }

    private void WalkingBehaviour()
    {
        Vector3 direction = Position.transform.position - transform.position;
        direction.y = 0;
        direction.Normalize();

        Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 20 * Time.deltaTime);
    }

    private void RagdollBehaviour()
    {

    }
}