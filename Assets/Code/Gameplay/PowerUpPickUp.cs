using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPickUp : MonoBehaviour
{
    public GenericPowerUp powerUpPrefab;
    private float m_radius = .5f;

    private void Start()
    {
        m_radius = GetComponent<SphereCollider>().radius;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, m_radius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, m_radius * 2.0f);
    }
}
