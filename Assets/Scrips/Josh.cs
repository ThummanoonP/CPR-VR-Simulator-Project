using System.Linq;
using UnityEngine;

public class Josh : MonoBehaviour
{
    private enum JoshState
    {
        Walking,
        Standing,
        Ragdoll
    }

    [SerializeField] public GameObject AlertTarget;
    [SerializeField] public GameObject AroundPoint;
    [SerializeField] public GameObject ManDownPoint;

    private Rigidbody[] RagdollRigidbodies;
    private JoshState CurrentState = JoshState.Walking;
    private Animator Animator;
    private CharacterController CharacterController;
    private GameObject Position = null;
    private Brian brian = null;
    private Alert alert;
    bool fall = false;
    bool check = false;
    int step = 0;
    int ChildNumber = 0;

    void Awake()
    {
        RagdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        brian = ManDownPoint.GetComponent<Brian>();
        Animator = GetComponent<Animator>();
        CharacterController = GetComponent<CharacterController>();
        alert = AlertTarget.GetComponent<Alert>();
        AroundPointSet();
        DisableRagdoll();
    }

    // Update is called once per frame
    void Update()
    {
        fall = brian.GetStatus();
        check = brian.GetCheck();
        switch (CurrentState)
        {
            case JoshState.Walking:
                WalkingBehaviour();
                Walking();
                break;
            case JoshState.Standing:
                RagdollBehaviour();
                Stopping();
                Stay();
                break;
            case JoshState.Ragdoll:
                RagdollBehaviour();
                break;
        }

        if (fall == true && step == 0)
        {
            CurrentState = JoshState.Standing;
            step = 1;
        }
        else if (check == true && step == 1)
        {
            Turning();
            Encircle();
            CurrentState = JoshState.Walking;
            step = 2;
        }
        else if(alert.GetAlert() == true && step == 3)
        {
            Turning();
            AroundPointSet();
            CurrentState = JoshState.Walking;
            step = 4;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Restricted Area" && step == 2)
        {
            CurrentState = JoshState.Standing;
            step = 3;
        }
        else if (other.gameObject.name == "Right Controller" && step == 3)
        {
            alert.SetGoAwayTrue();
        }
        else if (other.gameObject.name == "Left Controller" && step == 3)
        {
            alert.SetGoAwayTrue();
        }
        if (other.gameObject.name == Position.gameObject.name && step == 4)
        {
            alert.SetGoAwayFalse();
            CurrentState = JoshState.Standing;
        }
    }

    private void AroundPointSet()
    {
        ChildNumber = Random.Range(0, (AroundPoint.transform.childCount));
        if (ChildNumber == AroundPoint.transform.childCount) ChildNumber -= 1;
        Position = AroundPoint.transform.GetChild(ChildNumber).gameObject;
    }

    public void Encircle()
    {
        Position = ManDownPoint;
    }


    private void Walking()
    {
        Animator.SetBool("isStop", false);
        Animator.SetBool("isWalking", true);
    }


    private void Turning()
    {
        Animator.SetBool("isWalking", false);
        Animator.SetBool("isTurn", true);
    }


    private void Stopping()
    {
        Animator.SetBool("isStay", false);
        Animator.SetBool("isStop", true);
    }

    private void Stay()
    {
        Animator.SetBool("isTurn", false);
        Animator.SetBool("isStay", true);
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