using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MovementPowerUp
{
    public float dashDistance = 2f;
    public float dashSpeed = 5f;
    public float dashCooldown = 2F;
    float dashTimer = 0f;
    Vector3 dashTargetPosition = new Vector3();
    Coroutine dashCoroutine;
    Vector3 movementInput = new Vector3();
    Vector3 startingPosition = new Vector3();

    
    public override void PerformPowerUpAction()
    {
        if (dashTimer >= dashCooldown)
        {
            movementInput = movement.CurrentMovementDirection;
            dashTargetPosition = parentTransform.position + (movementInput.normalized * dashDistance);
            startingPosition = parentTransform.position;

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
            parentTransform.position = Vector3.Lerp(startingPosition, dashTargetPosition,t);
            yield return null;
        }

    }
    void Update()
    {
        dashTimer += Time.deltaTime;
    }
}
