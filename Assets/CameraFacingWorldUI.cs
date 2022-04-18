using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFacingWorldUI : MonoBehaviour
{
    void Update()
    {
        RotateToFaceCamera();
    }
    private void RotateToFaceCamera()
    {
        var forward = Camera.main.transform.forward;
        var right = Camera.main.transform.right;

        forward.y = 0f;

        this.transform.rotation = Quaternion.LookRotation(Vector3.Cross(right, Vector3.up));
        Vector3 lookRot = new Vector3(90, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
        this.transform.eulerAngles = lookRot;
    }


}
