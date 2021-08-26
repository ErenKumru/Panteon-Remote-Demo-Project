using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OpponentSpawnController : SpawnController
{
    [SerializeField] private float waitAtRespawnDuration;
    private Vector3 spawnPoint;

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
        if (transform.position.z != spawnPoint.z)
        {
            NavMeshAgent navMeshAgent = GetComponent<NavMeshAgent>();
            navMeshAgent.Warp(spawnPoint);
        }
    }
}
