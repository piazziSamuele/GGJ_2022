using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpUI : MonoBehaviour
{
    [SerializeField] Image powerUpLife;
    public PowerUpSO powerUp;
    public float lifeTime;

    private void Update()
    {
        if (powerUp != null)
        {
            powerUpLife.fillAmount = lifeTime;
        }
    }
}
