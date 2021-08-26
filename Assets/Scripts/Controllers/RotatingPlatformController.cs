using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatformController : MonoBehaviour
{
    [Header("Rotation Info")]
    [SerializeField] private float rotationSpeed;
    [SerializeField] private bool reverseRotationDirection;

    private Vector3 rotationVector;

    private void Start()
    {
        InitializeRotationInfo();
    }

    private void Update()
    {
        RotatePlatform();
    }

    private void InitializeRotationInfo()
    {
        rotationVector = Vector3.zero;
        rotationVector.z = reverseRotationDirection ? -rotationSpeed : rotationSpeed;
    }

    private void RotatePlatform()
    {
        transform.Rotate(rotationVector * Time.deltaTime);
    }

    private void OnCollisionStay(Collision collision)
    {
        //find a way for the mechanich
    }
}
