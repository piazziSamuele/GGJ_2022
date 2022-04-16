using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp<T> : GenericPowerUp where T : PowerUpSO
{
    public T powerUpData;

    [Tooltip("power up duration in seconds")]
    [SerializeField] internal float totalPowerUpDuration = 100f;
    [Tooltip("percent of the total charge consumed for each use")]
    [Header("Ranged weapons consume one charge for each projectile")]
    [SerializeField] internal float percentChargePerUse = 10f;
    internal float currentCharge;
        
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
    public override void PerformPowerUpAction()
    {
        base.PerformPowerUpAction();
        if(currentCharge <= 0f) { return; }
    }
    private void Awake()
    {
        currentCharge = totalPowerUpDuration;
    }
    private void Update()
    {
        currentCharge -= Time.deltaTime;
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
