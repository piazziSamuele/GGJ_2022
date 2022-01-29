using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Power Up", menuName = "GGJ/Dash Power Up")]


public class DashPowerUpSO : MovementPowerUpSO
{
    public float dashDistance = 2f;
    public float dashSpeed = 5f;
    public float dashCooldown = 2F;

}
