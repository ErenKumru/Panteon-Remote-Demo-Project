using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AI;

public class OpponentController : MonoBehaviour
{
    [SerializeField] private Transform finishLine;
    [SerializeField] private float avoidancePredictionTime;
    [SerializeField] private float bumpDuration;

    private Animator animator;
    private NavMeshAgent navMeshAgent;
    private float agentSpeed;
    private float finishLineZ;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        finishLineZ = finishLine.position.z;
        NavMesh.avoidancePredictionTime = avoidancePredictionTime;
        agentSpeed = navMeshAgent.speed;
    }

    private void Update()
    {
        OpponentMovement();
    }

    private void OpponentMovement()
    {
        if (navMeshAgent.speed == 0 || transform.position.z == finishLineZ) animator.SetTrigger("Idle");
        else animator.SetTrigger("Run");
        Vector3 destination;
        destination = transform.position;
        destination.z = finishLineZ;
        navMeshAgent.destination = destination;
    }

    //BUMP BEHAVIOUR
    //Note: Can also be in a separate (abstract) class and can be extended/implemented as needed if different behaviours are desired for different characters/character types

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Bump());
    }

    private IEnumerator Bump()
    {
        animator.SetTrigger("Jump");
        navMeshAgent.speed = 0f;
        yield return new WaitForSeconds(bumpDuration);
        navMeshAgent.speed = agentSpeed;
    }
}
