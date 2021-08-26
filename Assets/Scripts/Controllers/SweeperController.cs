using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweeperController : MonoBehaviour
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
        RotateSweeper();
    }

    private void InitializeRotationInfo()
    {
        rotationVector = Vector3.zero;
        rotationVector.y = reverseRotationDirection ? -rotationSpeed : rotationSpeed;
    }

    private void RotateSweeper()
    {
        transform.Rotate(rotationVector * Time.deltaTime);
    }
}
