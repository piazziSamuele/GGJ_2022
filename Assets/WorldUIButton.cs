using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldUIButton : MonoBehaviour
{
    [SerializeField] RectTransform rectTransform;
    [SerializeField] Image image;
    [SerializeField] Image powerUpImage;
    public GameObject powerUpUIElement;
    private void Update()
    {
        RotateToFaceCamera();
    }

    public void SetPowerUPImage(Sprite sprite)
    {
        powerUpImage.sprite = sprite;

    }
    private void RotateToFaceCamera()
    {
        var forward = Camera.main.transform.forward;
        var right = Camera.main.transform.right;

        forward.y = 0f;
        right.y = 0f;

        this.transform.rotation = Quaternion.LookRotation(Vector3.Cross(right, Vector3.up));
        Vector3 lookRot = new Vector3(90, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
        this.transform.eulerAngles = lookRot;
    }
}
