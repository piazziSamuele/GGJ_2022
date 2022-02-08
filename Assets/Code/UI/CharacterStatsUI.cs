using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatsUI : MonoBehaviour
{
    public Image Health;
    public Image Stamina;
    [SerializeField] InputHandler player;
    [SerializeField] RectTransform m_UItransform;


    void Update()
    {
        m_UItransform.position = Camera.main.WorldToScreenPoint(player.controlledCharacter.transform.position);
        Health.fillAmount = player.controlledCharacter.health.value * 0.01f;
    }
}
