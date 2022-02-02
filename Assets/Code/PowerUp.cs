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
    public override void SubscribeToEvents()
    {
        assignedCharacter.onSwitch += StopAllCoroutines;
    }
    private void OnDisable()
    {
        assignedCharacter.onSwitch -= StopAllCoroutines;

    }

}

public abstract class GenericPowerUp : MonoBehaviour
{
    public ControllableCharacter assignedCharacter;
    public virtual void SubscribeToEvents() { }
    public virtual PowerUpSO PowerUpData { get; }
    public virtual void PerformPowerUpAction() { }
    public virtual void EndPowerUpAction() { }
    public abstract void SetPowerUpSO(PowerUpSO powerUp);
}
