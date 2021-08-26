using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SpawnController spawnController = other.gameObject.GetComponent<SpawnController>();
        HandleRespawnInteraction(spawnController);
    }

    private void HandleRespawnInteraction(SpawnController spawnController)
    {
        if (spawnController != null) spawnController.RespawnCharacter();
    }
}
