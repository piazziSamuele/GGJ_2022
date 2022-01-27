using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] PowerUpSO powerUp;
    [HideInInspector] public Transform parentTransform;
    private void OnEnable()
    {
        powerUp.powerUpButtonPressed += PerformPowerUpAction;
    }
    private void OnDisable()
    {
        powerUp.powerUpButtonPressed -= PerformPowerUpAction;

    }
    internal virtual void PerformPowerUpAction() { }
}
public class MovementPowerUp : PowerUp
{
    public Movement movement;
}
