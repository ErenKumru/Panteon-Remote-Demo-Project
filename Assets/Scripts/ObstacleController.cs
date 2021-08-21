using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(name + " collided with " + other.gameObject.name);
        SpawnController spawnController = other.gameObject.GetComponent<SpawnController>();
        spawnController.RespawnCharacter();
    }
}
