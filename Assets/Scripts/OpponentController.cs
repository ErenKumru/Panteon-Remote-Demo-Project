using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OpponentController : MonoBehaviour
{
    [SerializeField] private Transform finishLine;
    [SerializeField] private float avoidancePredictionTime;

    private NavMeshAgent navMeshAgent;
    private float finishLineZ;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        finishLineZ = finishLine.position.z;
        NavMesh.avoidancePredictionTime = avoidancePredictionTime;

        //OpponentMovement();
    }

    private void Update()
    {
        OpponentMovement();
    }

    //trigger animations
    private void OpponentMovement()
    {
        Vector3 destination;
        destination = transform.position;
        destination.z = finishLineZ;
        navMeshAgent.destination = destination;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(name + " triggered with " + other.gameObject.name);
        //DO STOP BOTH THIS AND OTHER GAMEOBJECT FOR A LITTLE
        //ALSO DO ANIMATION
    }
}
