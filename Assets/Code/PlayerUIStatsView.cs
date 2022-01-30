using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIStatsView : MonoBehaviour
{
    public Image Health;
    public Image Stamina;
    private Health m_TargetPlayer;
    private RectTransform m_UItransform;
    // Start is called before the first frame update
    void Start()
    {
        m_UItransform = GetComponent<RectTransform>();
    }

    public void AssignPlayer(Health playerHealth)
    {
        m_TargetPlayer = playerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        m_UItransform.position = Camera.main.WorldToScreenPoint(m_TargetPlayer.transform.position);
        Health.fillAmount = m_TargetPlayer.health * 0.01f;
    }
}
