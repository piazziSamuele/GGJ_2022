using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool IsAI;
    private Material m_playerMat;
    // Start is called before the first frame update
    void Start()
    {
        m_playerMat = GetComponent<MeshRenderer>().sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Switch()
    {
        IsAI = !IsAI;

        m_playerMat.SetColor("_Tint", IsAI ? Color.red : Color.blue);
    }
}
