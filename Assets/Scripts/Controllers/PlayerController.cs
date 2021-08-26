using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] public float runSpeed;
    [SerializeField] private float rotationTime = 0f;
    [SerializeField] private float bumpDuration;
    private float rotationSpeed;

    private Rigidbody rigidBody;
    private Animator animator;
    public float runSpeedHolder;
    private bool isRunning = false;
    private bool isJumping = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        runSpeedHolder = runSpeed;
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
        //something is wrong with run <-> idle animation transitions
        if (!inputManager.HasEffectiveInput() || runSpeed == 0f) isRunning = false;
        else isRunning = true;

        if (isRunning && !isJumping) animator.SetTrigger("Run");
        else if (!isRunning && !isJumping) animator.SetTrigger("Idle");

        Vector3 newPosition = transform.position;
        newPosition.x += runSpeed * Time.deltaTime * inputManager.GetEffectiveInputVector().x;
        newPosition.z += runSpeed * Time.deltaTime * inputManager.GetEffectiveInputVector().y;
        rigidBody.MovePosition(newPosition);
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

    //BUMP BEHAVIOUR
    //Note: Can also be in a separate (abstract) class and can be extended/implemented as needed if different behaviours are desired for different characters/character types

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Bump());
    }

    private IEnumerator Bump()
    {
        isRunning = false;
        isJumping = true;
        runSpeed = 0f;
        if (isJumping) animator.SetTrigger("Jump");
        yield return new WaitForSeconds(bumpDuration);
        runSpeed = runSpeedHolder;
        isJumping = false;
    }
}
