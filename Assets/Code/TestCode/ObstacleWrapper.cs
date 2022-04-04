using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleWrapper : MonoBehaviour
{

    private Collider m_collider;
    // Start is called before the first frame update
    void Start()
    {
        m_collider = GetComponent<Collider>();
    }

    public Vector3 GetSafePosition(Vector3 enemy)
    {
        Vector3 safePositionDirection = -(enemy - transform.position);
        safePositionDirection.y = 0;
        //Vector3 obstacleRelativeSafePosition = m_collider.ClosestPointOnBounds(transform.TransformVector( safePositionDirection));
        Vector3 obstacleRelativeSafePosition = m_collider.ClosestPoint((transform.position - enemy) + transform.position);

        return  obstacleRelativeSafePosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
