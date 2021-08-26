using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineController : MonoBehaviour
{
    [SerializeField] private Animator cinemachineAnimator;
    [SerializeField] private GameObject paintWall;
    [SerializeField] private Vector3 characterPaintPoint;
    private UIManager uIManager;
    private InputManager inputManager;
    private PainterController painterController;
    private PlayerController playerController;

    private void Awake()
    {
        uIManager = FindObjectOfType<UIManager>();
        inputManager = FindObjectOfType<InputManager>();
        painterController = FindObjectOfType<PainterController>();
        playerController = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter(Collider playerCharacterCollider)
    {
        playerCharacterCollider.attachedRigidbody.useGravity = false;
        playerCharacterCollider.enabled = false;
        StartEndGameProcess();
    }

    private void StartEndGameProcess()
    {
        inputManager.enabled = false;
        playerController.enabled = false;
        playerController.gameObject.transform.position = characterPaintPoint;
        playerController.GetComponent<Animator>().SetTrigger("Idle");
        uIManager.ToggleMenuButton();
        cinemachineAnimator.Play("PaintCameraState");
        paintWall.GetComponent<MeshRenderer>().enabled = true;
        uIManager.StartPaintText();
        painterController.enabled = true;
    }
}
