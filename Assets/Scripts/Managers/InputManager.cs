using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float thresholdDistance;

    private Vector2 initialInputPosition;
    private Vector2 currentInputPosition;
    private Vector2 effectiveInputVector;

    private void Update()
    {
        SwerveCircleInput();
    }

    private void SwerveCircleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            initialInputPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            currentInputPosition = Input.mousePosition;

            Vector2 inputDifference = currentInputPosition - initialInputPosition;
            effectiveInputVector = inputDifference.magnitude > thresholdDistance ? inputDifference.normalized : Vector2.zero;
        }
        else effectiveInputVector = Vector2.zero;
    }

    public Vector2 GetEffectiveInputVector()
    {
        return effectiveInputVector;
    }

    public bool HasEffectiveInput()
    {
        if (effectiveInputVector != Vector2.zero) return true;
        return false;
    }
}
