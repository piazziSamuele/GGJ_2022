using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestBehavior : MonoBehaviour
{

    public enum AITarget {Enemy, SafeSpot, Resources };

    private NavMeshAgent m_agent;
    private NavMeshPath m_path;
    private bool m_enemyVisible; // debug variable
    [SerializeField]
    private Vector3 m_directionDebug; // debug variable
    private Vector3 m_destinationDebug; // debug variable
    [SerializeField]
    private List<Vector3> m_corners = new List<Vector3>(0);
    private ResourceWrapper m_targetResource;


    public Transform enemy;
    public AITarget targetAI;
    private AITarget targetAICheck;

    // Start is called before the first frame update
    void Start()
    {
        m_path = new NavMeshPath();
        m_agent = GetComponent<NavMeshAgent>();
        StartCoroutine(UpdateAI());
    }

    public void setDestinationDebug()
    {
        
    }

    private void ValueChanged()
    {

    }

    public IEnumerator UpdateAI()
    {
        Vector3 destination = Vector3.zero;
        if(targetAI != targetAICheck)
        {
            ValueChanged();
        }

        switch (targetAI)
        {
            case AITarget.Enemy:
                destination = enemy.position;
                break;

            case AITarget.SafeSpot:
                destination = GetClosestObstacle().GetSafePosition(enemy.position);

                break;

            case AITarget.Resources:
                if(m_targetResource == null)
                {
                    m_targetResource = GetResources();
                }                
                destination = m_targetResource.transform.position;
                break;
        }
        targetAICheck = targetAI;

        m_agent.CalculatePath(destination, m_path);
        m_corners.Clear();
        for (int i = 1; i < m_path.corners.Length; i++)
        {
            m_corners.Add(m_path.corners[i]);
        }

        yield return new WaitForSeconds(0.2f);
        StartCoroutine(UpdateAI());
    }

    public void Update()
    {
        GetDestination();
        
    }

    private void GetDestination()
    {
        if (m_corners.Count > 0)
        {
            Vector3 direction = Vector3.zero;
            int i = 0;

            direction = GetDirection();
            while (direction.x == 0.0f && direction.z == 0.0f)
            {
                direction = GetDirection(i++);
            }
            
           


            transform.Translate(direction * Time.deltaTime * 4.5f, Space.World);

            m_enemyVisible = EnemeyVisible();
        }
    }

    private bool EnemeyVisible()
    {
        Ray ray = new Ray(transform.position, enemy.position - transform.position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            return hit.collider.gameObject.tag == "Enemy";
        }

        return false;
    }

    private Vector3 GetDirection(int index = 0)
    {
        Vector3 direction = transform.InverseTransformDirection( m_corners[index] - transform.position).normalized;
        direction.x = Mathf.Round(direction.x);
        direction.y = Mathf.Round(direction.y);
        direction.z = Mathf.Round(direction.z);
        m_directionDebug = direction;
        return direction;
    }

    public void OnDrawGizmos() //debug
    {
        Gizmos.color = Color.magenta;
        if (m_corners.Count > 1)
        {
            for (int i = 1; i < m_corners.Count; i++)
            {
                Gizmos.DrawLine(m_corners[i - 1], m_corners[i]);

            }
        }

        Gizmos.color = m_enemyVisible ? Color.green : Color.red;
        Gizmos.DrawLine(transform.position, enemy.position);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + m_directionDebug);
        Gizmos.color = Color.black;
        m_destinationDebug = GetClosestObstacle().transform.position;
        if (Application.isPlaying)
        {
            Gizmos.DrawLine(transform.position, m_destinationDebug);
            Gizmos.DrawLine(m_destinationDebug, GetClosestObstacle().GetSafePosition(enemy.position));
        }
        
    }

    private ObstacleWrapper GetClosestObstacle()
    {
        ObstacleWrapper[] obstacles = GameObject.FindObjectsOfType<ObstacleWrapper>(false);
        int closestObstacleIdex = 0;
        for (int i = 1; i < obstacles.Length; i++)
        {
            if(Vector3.Distance(transform.position, obstacles[i].transform.position) < Vector3.Distance(transform.position, obstacles[closestObstacleIdex].transform.position))
            {
                closestObstacleIdex = i;
            }
        }

        return obstacles[closestObstacleIdex];
    }

    private ResourceWrapper GetResources()
    {
        //logic for resource evaluation ..
        ResourceWrapper[] resources = GameObject.FindObjectsOfType<ResourceWrapper>(false);
        return resources[Random.Range(0, resources.Length)];
    }
}
