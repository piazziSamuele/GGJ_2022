using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] internal PowerUpSO powerUp;
    [HideInInspector] public Transform parentTransform;
    private void OnEnable()
    {
        powerUp.powerUpButtonPressed += PerformPowerUpAction;
        powerUp.powerUpButtonReleased += EndPowerUpAction;
    }
    private void OnDisable()
    {
        powerUp.powerUpButtonPressed -= PerformPowerUpAction;
        powerUp.powerUpButtonReleased -= EndPowerUpAction;

    }
    public virtual void PerformPowerUpAction() { }
    public virtual void EndPowerUpAction() { }
}
public class MovementPowerUp : PowerUp
{
    public Movement movement;
}
