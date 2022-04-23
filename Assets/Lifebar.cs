using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifebar : MonoBehaviour
{
    [SerializeField] MeshRenderer _renderer;
    public void UpdateColor(Color color)
    {
        _renderer.material.SetColor("Color", color);
    }
    public void UpdateLife(float lifePercent)
    {
        _renderer.material.SetFloat("life", lifePercent / 100);

    }
}
