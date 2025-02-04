using System.Linq;
using UnityEngine;

public class JoshTutorial : MonoBehaviour
{
    private enum JoshState
    {
        Walking,
        Standing,
        StandOut,
        Ragdoll
    }

    [SerializeField] public GameObject AlertTarget;
    [SerializeField] public GameObject AroundPoint;
    [SerializeField] public GameObject ManDownPoint;
    [SerializeField] private GameObject Manager;
    [SerializeField] private GameObject Noti;
    [SerializeField] private GameObject NotiPickupPhone;

    private Rigidbody[] RagdollRigidbodies;
    private JoshState CurrentState = JoshState.Walking;
    private Animator Animator;
    private CharacterController CharacterController;
    private GameObject Position = null;
    private AlertTutorial alert;
    int step = 0;
    int ChildNumber = 0;
    private MissionControllerTutorial Mission = null;
    private AudioSource heySound = null;

    void Awake()
    {
        RagdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        Animator = GetComponent<Animator>();
        CharacterController = GetComponent<CharacterController>();
        alert = AlertTarget.GetComponent<AlertTutorial>();
        Mission = Manager.GetComponent<MissionControllerTutorial>();
        heySound = Manager.GetComponent<AudioSource>();
        Encircle();
        DisableRagdoll();
    }

    // Update is called once per frame
    void Update()
    {
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
            case JoshState.StandOut:
                RagdollBehaviour();
                Stopping();
                Stay();
                Turning();
                break;
            case JoshState.Ragdoll:
                RagdollBehaviour();
                break;
        }

        if(alert.GetAlert() == true && step == 1)
        {
            Turning();
            AroundPointSet();
            CurrentState = JoshState.Walking;
            step = 2;
            Noti.SetActive(false);
        }
        
        if(((alert.GetAmOut() == true) && (step == 3)) && (alert.GetCount() <=1))
        { 
            NotiPickupPhone.SetActive(true);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Restricted Area" && step == 0)
        {
            CurrentState = JoshState.Standing;
            step = 1;
            Noti.SetActive(true);
        }
        else if (other.gameObject.name == "Right Controller" && step == 1)
        {
            Mission.ClearArea();
            alert.SetGoAwayTrue();
            alert.SetClearArea(); 
            heySound.Play(); 
        }
        else if (other.gameObject.name == "Left Controller" && step == 1)
        {
            Mission.ClearArea();
            alert.SetGoAwayTrue();
            alert.SetClearArea();
            heySound.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Stand Out Area" && step == 2)
        {
            CurrentState = JoshState.StandOut;
            alert.SetAmOutTrue();
            step = 3;
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