using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private float runSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float rotationTime = 0.1f;

    private Animator animator; //trigger animations

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        MoveCharacter();
        RotateCharacter();
    }

    private void MoveCharacter()
    {
        Vector3 newPosition;
        newPosition = transform.position;
        newPosition.x += runSpeed * Time.deltaTime * inputManager.GetEffectiveInputVector().x;
        newPosition.z += runSpeed * Time.deltaTime * inputManager.GetEffectiveInputVector().y;
        transform.position = newPosition;
    }

    private void RotateCharacter()
    {
        if(inputManager.HasEffectiveInput())
        {
            Quaternion lookDirection = transform.rotation;
            lookDirection.x = inputManager.GetEffectiveInputVector().x;
            lookDirection.z = inputManager.GetEffectiveInputVector().y;
            float targetAngle = Mathf.Atan2(lookDirection.x, lookDirection.z) * Mathf.Rad2Deg;
            float rotationAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationSpeed, rotationTime);
            transform.rotation = Quaternion.Euler(0f, rotationAngle, 0f);
        }
    }
}
