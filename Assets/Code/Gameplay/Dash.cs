using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : PowerUp<DashPowerUpSO>
{
    float dashTimer = Mathf.Infinity;
    Vector3 dashTargetPosition = new Vector3();
    Coroutine dashCoroutine;
    Vector3 movementInput = new Vector3();
    Vector3 startingPosition = new Vector3();


    public override void PerformPowerUpAction()
    {
        if (dashTimer >= powerUpData.dashCooldown)
        {
            movementInput = assignedCharacter.GetComponent<CharacterMovement>().MovementInput;
            dashTargetPosition = assignedCharacter.transform.position + (movementInput.normalized * powerUpData.dashDistance);
            startingPosition = assignedCharacter.transform.position;

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
        float rate = powerUpData.dashSpeed / powerUpData.dashDistance;

        for (float t = 0; t <= 1; t += rate * Time.deltaTime)
        {
            assignedCharacter.transform.position = Vector3.Lerp(startingPosition, dashTargetPosition,t);
            yield return null;
        }

    }
    void Update()
    {
        dashTimer += Time.deltaTime;
    }
}
