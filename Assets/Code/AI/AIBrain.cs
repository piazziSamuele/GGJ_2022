using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIBrain : MonoBehaviour
{

    public static AIBrain Brain;
    private UIManager m_ui;
    [SerializeField]
    private NavMeshAgent m_aiPathTracer;
    private NavMeshPath m_aiPath;

    void Awake()
    {
        if(Brain)
        {
            DestroyImmediate(this);
        }
        else
        {
            Brain = this;
        }
    }

    public void Start()
    {
        GetDebugIU();
    }

    public void GetDebugIU()
    {
        m_ui = GameMatchManager.Manager.GetUIManager();
        if(m_ui == null)
        {
            Debug.LogError("Missing UI Manager in AIBrain");
        }
    }


    private void FixedUpdate()
    {
        GetAIData();
    }

    public float GetHealthAdvantages()
    {
        float weight = 0; //difference between player and AI health -- if negative returns 1 else return -1
        return weight;
    }

    private void GetAIData()
    {

        //PRE CHOICE MAKING:
        //  get health difference advantages
        //  get player weapon advantages
        //  get player weapon lifetime advantages
        //  get player position advantages in level
        //  get level available power ups 
        //  equip weapon
        //  decide strategy


        // BASE STRATEGIES

        // RETREAT :
        //  escape
        //  hide
        //  find better loot
        //  use defense item
        //  find health power ups

        // MELEE :
        //  attck
        //  use dash
        //  use magic item

        // RANGED:
        //  find shelter
        //  ranged attack
        //  use dash
        //  use magic item

        // GET NEW RESOURCES:
        //  go for better loot 
        //  find loot and leave it for next switch
        //  find health power ups

        //SNEAKY BASTARD:
        //   use enviro advantages
        //   sacrifice some health before the switch
        //   go away from power ups before the switch
        //   go in disatvantage position before the switch




    }

    private void SetAIDestinationPosition()
    {
        Vector2 randomDest = Random.insideUnitCircle * 3.0f;
        Vector3 fullDest = new Vector3(randomDest.x, 0, randomDest.y);
        m_aiPathTracer.SetDestination(fullDest);
        
    }

}
