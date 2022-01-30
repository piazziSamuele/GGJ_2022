using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp<T> : GenericPowerUp where T : PowerUpSO
{
    public T powerUpData;
    public override PowerUpSO PowerUpData => powerUpData;
    public override void SetPowerUpSO(PowerUpSO powerUp)
    {
        this.powerUpData = (T)powerUp;
    }
}

public abstract class GenericPowerUp : MonoBehaviour
{
    public Transform assignedCharacter;
    public virtual PowerUpSO PowerUpData { get; }
    public virtual void PerformPowerUpAction() { }
    public virtual void EndPowerUpAction() { }
    public abstract void SetPowerUpSO(PowerUpSO powerUp);
}
