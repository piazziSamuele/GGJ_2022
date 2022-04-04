using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bitch : MonoBehaviour
{
    public Collider mycollider;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        mycollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        if(mycollider)
        {
            Vector3 destination = mycollider.ClosestPoint(target.position);
            destination.y = 0;
            Gizmos.DrawLine(target.position, destination);
            Gizmos.color = Color.red;
            destination = mycollider.ClosestPoint((transform.position - target.position) + transform.position);
            destination.y = 0;
            Gizmos.DrawLine(target.position , destination);
        }
    }
}
