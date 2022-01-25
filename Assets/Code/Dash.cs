using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    PlayerInput playerInput;
    public PlayerMovement movement;
    public float dashDistance = 2f;
    public float dashSpeed = 5f;
    public float dashCooldown = 2F;
    float dashTimer = 0f;
    Vector3 dashTargetPosition = new Vector3();
    Coroutine dashCoroutine;
    Vector3 movementInput = new Vector3();
    Vector3 startingPosition = new Vector3();

    private void Awake()
    {
        playerInput = new PlayerInput();
        playerInput.CharacterControls.Dash.performed += ctx => ProcessDashInput();
        
    }
    
    private void ProcessDashInput()
    {
        movementInput = movement.CurrentMovementInput;
        dashTargetPosition = transform.position + (movementInput.normalized * dashDistance);
        startingPosition = transform.position;
        if (dashTimer >= dashCooldown)
        {
            dashTimer = 0f;
            if (dashCoroutine != null)
            StopCoroutine(dashCoroutine);
            PerformDash();
        }
    }
    private void PerformDash()
    {
        dashCoroutine = StartCoroutine(DashCoroutine());
    }
    IEnumerator DashCoroutine()
    {
        float rate = dashSpeed / dashDistance;

        for (float t = 0; t <= 1; t += rate * Time.deltaTime)
        {
            transform.position = Vector3.Lerp(startingPosition, dashTargetPosition,t);
            yield return null;
        }

    }
    void Update()
    {
        dashTimer += Time.deltaTime;
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }
    private void OnDisable()
    {
        playerInput.Disable();
    }
}
