using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnController : SpawnController
{
    [SerializeField] private float transportSpeed;
    private Vector3 spawnPoint;

    private void Start()
    {
        spawnPoint = transform.position;
    }

    public override void RespawnCharacter()
    {
        StartCoroutine(RespawnAtStartPoint());
    }

    private IEnumerator RespawnAtStartPoint()
    {
        SkinnedMeshRenderer[] skinnedMeshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();

        foreach(SkinnedMeshRenderer skinnedMeshRenderer in skinnedMeshRenderers)
        {
            skinnedMeshRenderer.enabled = false;
        }

        PlayerController playerController = GetComponent<PlayerController>();
        playerController.runSpeed = 0f;
        playerController.enabled = false;
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
        Collider playerCollider = GetComponent<Collider>();
        playerCollider.enabled = false;


        while (Mathf.Abs(transform.position.z - spawnPoint.z) > 0.01f)
        {
            playerController.runSpeed = 0f;
            transform.position = Vector3.MoveTowards(transform.position, spawnPoint, transportSpeed);
            yield return new WaitForEndOfFrame();
        }

        playerCollider.enabled = true;
        rigidbody.useGravity = true;
        playerController.enabled = true;
        playerController.runSpeed = playerController.runSpeedHolder;

        foreach (SkinnedMeshRenderer skinnedMeshRenderer in skinnedMeshRenderers)
        {
            skinnedMeshRenderer.enabled = true;
        }
    }
}
