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

    //DO ANIMATION
    private IEnumerator RespawnAtStartPoint()
    {
        Debug.Log(gameObject.name + " called RespawnAtStartPoint");
        PlayerController playerController = GetComponent<PlayerController>();
        playerController.enabled = false;
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
        Collider playerCollider = GetComponent<Collider>();
        playerCollider.enabled = false;

        while (transform.position.z != spawnPoint.z)
        {
            Debug.Log("transporting " + gameObject.name);
            transform.position = Vector3.MoveTowards(transform.position, spawnPoint, transportSpeed);
            yield return new WaitForEndOfFrame();
        }

        playerCollider.enabled = true;
        rigidbody.useGravity = true;
        playerController.enabled = true;
    }
}
