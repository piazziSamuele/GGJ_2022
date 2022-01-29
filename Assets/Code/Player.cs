using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool IsAI;
    private Material m_playerMat;
    public Movement m_movememnt;
    // Start is called before the first frame update
    void Start()
    {
        m_playerMat = GetComponent<MeshRenderer>().sharedMaterial;
        m_movememnt = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Switch()
    {
        IsAI = !IsAI;
        if (m_movememnt != null) m_movememnt.enabled = !m_movememnt.enabled;
        m_playerMat.SetColor("_Tint", IsAI ? Color.red : Color.blue);
    }
}
