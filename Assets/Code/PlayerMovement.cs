using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement
{
    //Exposed values
    public float speed = 5;

    public PlayerInputHandler inputHandler;
    Vector3 movementDirection = new Vector3();
    public Vector3 velocity = new Vector3();

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public override Vector3 CurrentMovementDirection => movementDirection;

    void Update()
    {
        Vector3 cameraPosition = Camera.main.transform.position;
        cameraPosition.y = 0;
        movementDirection = Camera.main.transform.TransformDirection(inputHandler.CurrentMovementInput);
        movementDirection.y = 0;
        movementDirection = movementDirection.normalized;
        if (inputHandler.CurrentMovementInput.magnitude > .05f)
        {
            float targetAngle = Mathf.Atan2(movementDirection.x , movementDirection.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
        transform.position += movementDirection * speed * Time.deltaTime;
    }

}

public class Movement : MonoBehaviour
{
    public virtual Vector3 CurrentMovementDirection { get; }
}
