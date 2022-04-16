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



    void Update()
    {
        m_UItransform.position = player.controlledCharacter.transform.position
            +(Vector3.up * ((-player.controlledCharacter.GetComponent<CapsuleCollider>().bounds.size.y/2)+0.005f));
        healthSprite.fillAmount = player.controlledCharacter.health.value * 0.01f;
    }
}
