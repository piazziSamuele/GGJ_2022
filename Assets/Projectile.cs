using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    private void Start()
    {
        Destroy(this.gameObject, 5f);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        
    }
}
