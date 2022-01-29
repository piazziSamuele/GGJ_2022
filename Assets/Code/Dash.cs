using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : PowerUp<DashPowerUpSO>
{
    float dashTimer = 0f;
    Vector3 dashTargetPosition = new Vector3();
    Coroutine dashCoroutine;
    Vector3 movementInput = new Vector3();
    Vector3 startingPosition = new Vector3();


    public override void PerformPowerUpAction()
    {
        if (dashTimer >= powerUpData.dashCooldown)
        {
            movementInput = player.m_movememnt.CurrentMovementDirection;
            dashTargetPosition = player.transform.position + (movementInput.normalized * powerUpData.dashDistance);
            startingPosition = player.transform.position;

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
            player.transform.position = Vector3.Lerp(startingPosition, dashTargetPosition,t);
            yield return null;
        }

    }
    void Update()
    {
        dashTimer += Time.deltaTime;
    }
}
