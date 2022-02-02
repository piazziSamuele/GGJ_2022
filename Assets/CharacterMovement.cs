using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] ControllableCharacter character;
    //Exposed values
    public float speed = 5;
    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;

    public Vector3 MovementInput => character.CurrentMovementInput;

    

    void Update()
    {
        if (MovementInput.magnitude > .05f)
        {
            float targetAngle = Mathf.Atan2(MovementInput.x, MovementInput.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
       transform.position += MovementInput * speed * Time.deltaTime;
    }

}
