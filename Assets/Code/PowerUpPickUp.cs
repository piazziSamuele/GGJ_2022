using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPickUp : MonoBehaviour
{
    public PowerUpSO powerUpSO;
    public PowerUp equippablePowerUp;


    public PowerUp EquipPowerUP(Transform playerTransform)
    {
        PowerUp powerUp = Instantiate(equippablePowerUp, playerTransform);
        return powerUp;
    }
}
