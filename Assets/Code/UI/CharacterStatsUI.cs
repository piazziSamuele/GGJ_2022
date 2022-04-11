using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatsUI : MonoBehaviour
{
    public Image healthSprite;
    [SerializeField] InputHandler player;
    [SerializeField] RectTransform m_UItransform;
    [SerializeField] float health = 100f;

    private void Start()
    {
    }
    private void OnEnable()
    {
        player.onControlledCharacterChanged += UpdateHealthUIColor;
    }
    private void OnDisable()
    {
        player.onControlledCharacterChanged -= UpdateHealthUIColor;
    }

    private void UpdateHealthUIColor(ControllableCharacter character)
    {
    }

    void Update()
    {
        m_UItransform.position = Camera.main.WorldToScreenPoint(player.controlledCharacter.transform.position);
        healthSprite.fillAmount = player.controlledCharacter.health.value * 0.01f;
    }
}
