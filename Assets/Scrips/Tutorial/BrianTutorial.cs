using System.Linq;
using UnityEngine;

public class BrianTutorial : MonoBehaviour
{
    private enum BrianState
    {
        Walking,
        Standing,
        Ragdoll
    }

    [SerializeField] public GameObject Position;

    private Rigidbody[] RagdollRigidbodies;
    private BrianState CurrentState = BrianState.Walking;
    private Animator Animator;
    private CharacterController CharacterController;

    private void Awake()
    {
        RagdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        Animator = GetComponent<Animator>();
        CharacterController = GetComponent<CharacterController>();

        DisableRagdoll();
        ManDown();
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
        Animator.SetBool("isStop", true);
        Animator.SetBool("isFall", true);
        Animator.SetBool("isSeizure", true);
        Animator.SetBool("isPassOut", true);
    }

    public void Rise()
    {
        Animator.SetBool("isRegain", true);
        Animator.SetBool("isWaking", true);
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