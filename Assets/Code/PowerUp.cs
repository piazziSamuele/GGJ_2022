using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp<T> : GenericPowerUp where T : PowerUpSO
{
    public T powerUpData;
    public override PowerUpSO PowerUpData => powerUpData;
    private void OnEnable()
    {
        powerUpData.powerUpButtonPressed += PerformPowerUpAction;
        powerUpData.powerUpButtonReleased += EndPowerUpAction;
    }
    private void OnDisable()
    {
        powerUpData.powerUpButtonPressed -= PerformPowerUpAction;
        powerUpData.powerUpButtonReleased -= EndPowerUpAction;

    }

    public override void SetPowerUpSO(PowerUpSO powerUp)
    {
        this.powerUpData = (T)powerUp;
    }
}
public class MovementPowerUp : PowerUp<MovementPowerUpSO>
{
    public Movement movement;
}

public abstract class GenericPowerUp : MonoBehaviour
{
    [HideInInspector] public Player player;
    public virtual PowerUpSO PowerUpData { get; }
    public virtual void PerformPowerUpAction() { }
    public virtual void EndPowerUpAction() { }
    public abstract void SetPowerUpSO(PowerUpSO powerUp);
}
