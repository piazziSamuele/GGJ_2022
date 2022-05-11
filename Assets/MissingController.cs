using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MissingController : MonoBehaviour
{

    public void OnPressedStart()
    {
        GameMatchManager.Manager.StartGame();
    }

}
