using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OpponentSpawnController : SpawnController
{
    [SerializeField] private float waitAtRespawnDuration;
    private NavMeshAgent navMeshAgent;
    private Vector3 spawnPoint;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        spawnPoint = transform.position;
    }

    public override void RespawnCharacter()
    {
        RespawnAtStartPoint();
    }

    private void RespawnAtStartPoint()
    {
        Debug.Log(gameObject.name + " called RespawnAtStartPoint");
        if (transform.position.z != spawnPoint.z) StartCoroutine(WaitAtRespawn());
    }

    private IEnumerator WaitAtRespawn()
    {
        navMeshAgent.Warp(spawnPoint);
        OpponentController opponentController = GetComponent<OpponentController>();
        opponentController.enabled = false;
        navMeshAgent.enabled = false;
        //DO ANIMATION

        yield return new WaitForSeconds(waitAtRespawnDuration);

        navMeshAgent.enabled = true;
        opponentController.enabled = true;
    }
}
