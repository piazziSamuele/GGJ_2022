using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PlayerInventory : MonoBehaviour
{
    public float radius = 1f;
    [SerializeField] ControllableCharacter character;
    [SerializeField] ControllableCharacter opponent;
    [SerializeField] List<RectTransform> buttons;
    [Range(0f, 1f)]  [SerializeField] float minRange;
    [Range(0f, 1f)] [SerializeField] float maxRange;
    public float angle;
    public float relativeRotation;
    public Quaternion defaultRotation;
    public float distance;
    public float minAngle, maxAngle;

    void Update()
    {

    }

}
