using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public references
    public Rigidbody rb;

    //Exposed values
    public float speed = 5;

    PlayerInput playerInput;
    Vector3 currentMovementInput = new Vector3();
    public Vector3 CurrentMovementInput { get { return currentMovementInput; } }

    private void Awake()
    {
        playerInput = new PlayerInput();
        playerInput.CharacterControls.Movement.performed += ctx => RegisterMovementInput(ctx.ReadValue<Vector2>());
        //adding this just to be sure it cancel movement when leaving input
        playerInput.CharacterControls.Movement.canceled += ctx => RegisterMovementInput(ctx.ReadValue<Vector2>());
    }
    void Update()
    {
        float targetAngle = Mathf.Atan2(CurrentMovementInput.x, CurrentMovementInput.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
        transform.position += currentMovementInput * speed * Time.deltaTime;
    }
    private void RegisterMovementInput(Vector2 input)
    {
        currentMovementInput.x = input.x;
        currentMovementInput.z = input.y;
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }
    private void OnDisable()
    {
        playerInput.Disable();
    }

}
