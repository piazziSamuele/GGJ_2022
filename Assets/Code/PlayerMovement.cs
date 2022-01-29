using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement
{

    public PlayerInputHandler inputHandler;

    public override Vector3 MovementInput => inputHandler.CurrentMovementInput;



}

public class Movement : MonoBehaviour
{
    //Exposed values
    public float speed = 5;
    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;

    public virtual Vector3 MovementInput { get; }
    public Vector3 CurrentMovementDirection => cmaeraRelatedMovementDirection;
    internal Vector3 cmaeraRelatedMovementDirection = new Vector3();


    void Update()
    {
        Vector3 cameraPosition = Camera.main.transform.position;
        cameraPosition.y = 0;
        cmaeraRelatedMovementDirection = Camera.main.transform.TransformDirection(MovementInput);
        cmaeraRelatedMovementDirection.y = 0;
        cmaeraRelatedMovementDirection = cmaeraRelatedMovementDirection.normalized;
        if (MovementInput.magnitude > .05f)
        {
            float targetAngle = Mathf.Atan2(cmaeraRelatedMovementDirection.x, cmaeraRelatedMovementDirection.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
        transform.position += cmaeraRelatedMovementDirection * speed * Time.deltaTime;
    }

}
