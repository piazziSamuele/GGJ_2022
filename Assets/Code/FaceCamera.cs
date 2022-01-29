using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class FaceCamera : MonoBehaviour
{
    void Update()
    {
        this.transform.forward = Camera.main.transform.forward;
    }
}
