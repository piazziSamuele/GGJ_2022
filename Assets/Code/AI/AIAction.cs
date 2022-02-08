using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AI Action Generic", menuName = "GGJ/AI/AI Actions")]
public class AIAction : ScriptableObject
{
    protected string StrategyName = "Generic Action";


    public virtual void PlayAction()
    {
        Debug.Log("Played Generic Action");
    }
}
