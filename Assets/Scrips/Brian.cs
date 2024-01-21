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
    [SerializeField] public GameObject XR;
    [SerializeField] public GameObject WakeUpCheckBox;
    [SerializeField] public GameObject PulseRateCheckBox;
    [SerializeField] public GameObject Finish;

    private Rigidbody[] RagdollRigidbodies;
    private BrianState CurrentState = BrianState.Walking;
    private Animator Animator;
    private CharacterController CharacterController;
    private InvincibleHand invin = null;
    bool Falling = false;
    bool check = false;


    private void Awake()
    {
        RagdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        Animator = GetComponent<Animator>();
        CharacterController = GetComponent<CharacterController>();
        invin = XR.GetComponent<InvincibleHand>();

        CheckBoxOff();
        DisableRagdoll();
        Invoke("ManDown", 9.0f);
        invin.enabled = false;
    }

    // Update is called once per frame


    private void CheckBoxOff()
    {
        invin.enabled = false;
        Falling = false;
        check = false;
        WakeUpCheckBox.SetActive(false);
        PulseRateCheckBox.SetActive(false);
    }

    private void CheckBoxOn()
    {
        WakeUpCheckBox.SetActive(true);
        PulseRateCheckBox.SetActive(true);
        invin.enabled = true;
        Falling = true;
        check = true;
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
        CheckBoxOff();
        Finish.SetActive(true);
    }

    private void Fall()
    {
        Falling = true;
        
    }

    public bool GetStatus()
    {
        if (Falling)
            return (true);
        else
            return (false);
    }

    public bool GetCheck()
    {
        if (check)
            return (true);
        else
            return (false);
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